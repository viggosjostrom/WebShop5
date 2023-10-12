using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        // Två listor, en för lösenord och en för användarnamn
        List<string> Usernames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));

        // Välj ditt användarnamn
        bool usernameCheck = false;
        while(!usernameCheck)  // kör tills att usernameCheck = true, som det blir längre ner när användaren skrivit in ett username enligt kraven.
        {
            Console.WriteLine("Choose a username: ");
            string SignUpUsernameChoice = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(SignUpUsernameChoice)) // Om username du valt är tomt eller mellanslag
            {
                Console.WriteLine("Error: Your username must contain atleast 1 character.");

            }
            if(Usernames.Contains(SignUpUsernameChoice)) // om username du valt redan finns
            {
                Console.WriteLine("The username you've entered is already taken");
            }
            else // Om username du valt är OK
            {
                Usernames.Add(SignUpUsernameChoice);
                File.WriteAllLines("../../../usernames.csv", Usernames);
                usernameCheck = true;
            }
            
        }
        
        // Välj ditt lösenord
        bool passwordCheck = false;
        while(!passwordCheck) // kör tills att passwordCheck = true, som det blir längre ner när användaren skrivit in ett lösenord enligt kraven.
        {
            Console.WriteLine("Choose a password: ");
            string SignUpPasswordChoice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(SignUpPasswordChoice)) // Om lösenordet du skrivit in är tomt eller mellanslag
            {
                Console.WriteLine("Error: Your password must contain atleast 1 character.");
            }  
            else // Om lösenordet är OK
            {
                Passwords.Add(SignUpPasswordChoice);
                File.WriteAllLines("../../../passwords.csv", Passwords);
                passwordCheck = true; 

            }
            
        }
        







    }

    public static bool LogIn()
    {
        // Listor me usernames och lösenord
        List<string> Usernames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));
        bool loginSuccess = false;



        while (!loginSuccess)
        {
            Console.WriteLine("Enter your username: ");
            string InputUsername = Console.ReadLine();


            foreach (string username in Usernames) // Loppar igenom alla usernames som redan finns sparade
            {

                if (username == InputUsername)  // Om användarnamet användaren skrivit in finns med i listan
                {
                    int ListNumber = Usernames.IndexOf(InputUsername); // Kollar vilken plats i listan användarnamet finns på
                    Console.WriteLine("Enter your password: ");
                    string InputPassword = Console.ReadLine();

                    string passwordCheck = Passwords[ListNumber]; // väljer samma plats i listan för lösenord, som användarnamnet
                    if (InputPassword == passwordCheck) // kollar om lösenordet du skrivit in är samma som det som står på platsen
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
        List<string> productList = new List<string>(File.ReadAllLines("../../../Cart.csv")); // läser in befintliga produkter

        bool UserMenu = true;
        
        while (UserMenu)
        {
            Console.WriteLine("MENU: ");
            Console.WriteLine("1 : Show Products");
            Console.WriteLine("2 : Shop Products");
            Console.WriteLine("3 : Remove from your Shopping Bag");
            Console.WriteLine("4 : Go to payment / Checkout");
            Console.WriteLine("5 : Order History");
            Console.WriteLine("0 : Sign Out");
            int UserChoice = Convert.ToInt32(Console.ReadLine());


            switch (UserChoice)
            {
                case 0:
                    // Lägg in ShoppingBag listan och töm den när användaren loggar ut
                    // User.ShoppingBag.Clear();
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
                    // Användaren kan efter att ha lagt till produkter i sin varukorg nu välja
                    // att genomföra köpet. Denna infon ska kopplas till kvitto / orderhistorik för användaren
                    // Products.PurchaseShoppingBag();
                    break;
                case 5:
                    // Se sin egen Order history (Fredriks kod)
                    break;


            }
        }
    }

}
