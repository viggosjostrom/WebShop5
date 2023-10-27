using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WebShop5;

public static class LoginMenu
{
    public static IUser? Login()
    {
        Console.Clear();
        string path = @"users.csv";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, $"admin,password," + Role.Admin);
        }
        string[] users = File.ReadAllLines(path);
        if (users.Length > 0) 
        { 
            bool foundUser = false; 
            Console.WriteLine("please enter a username"); 
            string usernameInput = Console.ReadLine();
            foreach (string user in users)
            {
                string[] userInfo = user.Split(',');
                if (userInfo[0] == usernameInput)
                {
                    bool login = true;
                    foundUser = true;
                    while (login)
                    {
                        string name = usernameInput;
                        string passwordInput = Console.ReadLine();
                        if (passwordInput == userInfo[1])
                        {
                            if (Enum.TryParse(userInfo[2], out Role role))
                            {
                                switch (role)
                                {
                                    case Role.Customer:
                                        return new Customer(name, LoadCustomer(name));
                                    case Role.Admin:
                                        return new Admin(name);
                                }
                            }

                        }
                    }
                }
            }
            if (!foundUser)
            {
                Console.WriteLine("user not found, do you want to create a new user");
                string input = Console.ReadLine();
                if (input == "y" || input == "yes")
                {

                }
                else if (input == "n" || input == "no")
                {

                }
                else
                    Console.WriteLine("invalid input, try again");
            }
        }
 
    }

    private static List<Product> LoadCustomer(string username)
    {
        List<Product> shoppingBag = new List<Product>();
        string[] savedShoppingBag = File.ReadAllLines($"../../../ShoppingBag/{username}.csv");
        foreach (string item in savedShoppingBag)
        {
            string[] details = item.Split(",");
            if (int.TryParse(details[1], out int price))
            {
                shoppingBag.Add(new Product(details[0], price));
            }
        }
        return shoppingBag;
    }
}
~