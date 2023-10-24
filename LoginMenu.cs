using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebShop5;

public static class LoginMenu
{

    public static void Register()
    {
        Console.Clear();
        string username = string.Empty;
        while (username.Length is < 3 or > 20) // inte kortare än 3 eller längre än 20
        {
            Console.WriteLine("Choose a username. It must be longer than 3 characters and shorter than 20.");
            username = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(username))
            {
                username = string.Empty;
                Console.WriteLine("Username can't be empty or use white spaces!");
            }
            Console.Clear();
        }

        string password = string.Empty;
        while (password.Length is < 8 or > 64)
        {
            Console.WriteLine("Choose a password");
            password = Console.ReadLine() ?? string.Empty;
            Console.Clear();

            if (password.Length is < 8 or > 64)
            {
                password = string.Empty;
                Console.WriteLine("Password needs to be longer than 8 characters and shorter than 64.");

            }
            else if (password.Length is > 8 or < 64)
            {
                Console.WriteLine("Please re-enter your choosen password");
                if (!password.Equals(Console.ReadLine()))
                {
                    Console.Clear();
                    password = string.Empty;
                    Console.WriteLine("The passwords you've entered doesn't match!");
                }
            }

        }
        File.Create($"../../../ShoppingBag/{username}.csv").Close();   

        File.AppendAllText("../../../users.csv", $"\n{username},{password},{Role.Customer}");
      Console.Clear();

    }

    public static IUser? Login()
    {
        Console.Clear();
        string[] users = File.ReadAllLines("../../../users.csv");

        Console.WriteLine("Enter your username: ");
        string input = Console.ReadLine();
        bool correctName = false;

        foreach (string line in users)
        {
            string[] info = line.Split(',');
            string name = info[0];
            string pass = info[1];

            if (name.Equals(input))
            {
                Console.WriteLine("Enter Password: ");
                input = Console.ReadLine();
                correctName = true;

                if (pass.Equals(input))
                {
                    if (Enum.TryParse(info[2], out Role role))
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
                else
                {

                    Console.WriteLine("Wrong password! Try to login again");
                    break;
                }
            }

        }
        if (!correctName)
        {
            Console.WriteLine("The username you've entered does not exist. Try again..");
        }


        return null;
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
