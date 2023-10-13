using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebShop5;

public class LoginMenu
{
    public void Register()
    {
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
                    password = string.Empty;
                    Console.WriteLine("The passwords you've entered doesn't match!");
                }
            }

        }
        File.Create($"../../../ShoppingBag/{username}.csv").Close();
        File.AppendAllText("../../../users.csv", $"{username},{password},{Role.Customer}\n");
    }

    public void LogIn()
    {
        bool loginLoop = true;
        while (loginLoop)
        {
            string[] users = File.ReadAllLines("../../../users.csv");
            
            Customer user = null;
            Console.WriteLine("Enter username: ");
            string input = Console.ReadLine() ?? string.Empty;
            foreach (string line in users)
            {
                string[] userInfo = line.Split(',');
                if (userInfo[0].Equals(input))
                {
                    Console.WriteLine("Enter password: ");
                    input = Console.ReadLine() ?? string.Empty;
                    if (userInfo[1].Equals(input))
                    {
                        Console.WriteLine($"Welcome {userInfo[0]}!");
                        List<NewProducts> shoppingBag = new List<NewProducts>();
                        string[] savedShoppingBag = File.ReadAllLines($"../../../ShoppingBag/{userInfo[0]}.csv");
                        foreach (string item in savedShoppingBag)
                        {
                            shoppingBag.Add(new NewProducts(item));
                        }
                        loginLoop = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password! Try to login again");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("The username you've entered does not exist. Try again..");
                    break;
                }
            }
        }
    }

}
