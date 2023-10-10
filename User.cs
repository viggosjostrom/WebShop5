using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class User
{

    public string? Username;
    public string? Password;



    public static void SignUp()
    {
        User currentUser = new User();

        List<string> Usernames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));


        Console.WriteLine("Choose a username: ");
        string SignUpUsernameChoice = Console.ReadLine();
        Usernames.Add(SignUpUsernameChoice);
        File.WriteAllLines("../../../usernames.csv", Usernames);

        bool usernameCheck = false;
        while(!usernameCheck)
        {
            Console.WriteLine("Choose a password: ");
            string SignUpPasswordChoice = Console.ReadLine();
            if (SignUpPasswordChoice == string.Empty)
            {
                Console.WriteLine("Error: Your username must contain atleast 1 character.");
            }
            else
            {
                Passwords.Add(SignUpPasswordChoice);
                File.WriteAllLines("../../../passwords.csv", Passwords);
                usernameCheck = true; 

            }
            
        }
        







    }

    public static bool LogIn()
    {
        List<string> Usernames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));
        bool loginSuccess = false;



        while (!loginSuccess)
        {
            Console.WriteLine("Enter your username: ");
            string InputUsername = Console.ReadLine();


            foreach (string username in Usernames)
            {

                if (username == InputUsername)
                {
                    int ListNumber = Usernames.IndexOf(InputUsername);
                    Console.WriteLine("Enter your password: ");
                    string InputPassword = Console.ReadLine();

                    string passwordCheck = Passwords[ListNumber];
                    if (InputPassword == passwordCheck)
                    {
                        Console.Clear();
                        Console.WriteLine("Logged in successfully!");
                        loginSuccess = true;
                        UserShoppingMenu();
                        return true;


                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong password, try to log in again..");

                    }
                    break;

                }


            }
            
        }
        return false;


    }

    public static void UserShoppingMenu()
    {
        List<string> productList = new List<string>(File.ReadAllLines("../../../Cart.csv"));

        bool UserMenu = true;
        
        while (UserMenu)
        {
            Console.WriteLine("MENU: ");
            Console.WriteLine("1 : Show Products");
            Console.WriteLine("2 : Shop Products");
            Console.WriteLine("3 : Remove from your Shopping Bag");
            Console.WriteLine("4 : Order History");
            Console.WriteLine("0 : Sign Out");
            int UserChoice = Convert.ToInt32(Console.ReadLine());


            switch (UserChoice)
            {
                case 0:
                    UserMenu = false;
                    break;

                case 1:
                    // Loop som listar alla produkter
                    foreach (var item in productList)
                    {
                        Console.WriteLine(item);
                    }
                   
                    break;

                case 2:
                    // Användaren kan lägga till från produkterna i sin Shoppingbag
                    Products.AddToShoppingbag();
                    break;

                case 3:
                    // Användaren kan ta bort produkter från sin shoppingbag
                    Products.RemoveFromShoppingbag();
                    break;
                
                case 4:
                    // Order history (Fredriks kod)
                    break;


            }
        }
    }

}
