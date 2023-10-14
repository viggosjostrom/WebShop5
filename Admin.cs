using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;


public class AdminUser
{


        public List<string> productlistt = new List<string>(); // Deklarera newCart som en instansvariabel




        public static void updateCart()
        {
            List<string> productlist = new List<string>(File.ReadAllLines("../../../Cart.csv"));

            Console.Clear();
            Console.Write("Add new product: ");
            string? addProduct = Console.ReadLine();
            Console.Write("Price in $: ");
            string? addPrice = Console.ReadLine();
            Console.WriteLine();


            if (addPrice == string.Empty || addProduct == string.Empty)
            {
                Console.WriteLine("Enter Either a product or the price");
            }

            else
            {
                string productToAdd = string.Format("{0}, {1}$", addProduct, addPrice);
                productlist.Add(productToAdd);


                Console.WriteLine();
                File.WriteAllLines("../../../Cart.csv", productlist);
            }

        }

        public static void removeproducts()
        {


              AdminUser remove = new AdminUser();
             {
                productlistt = new List<string>(File.ReadAllLines("../../../Cart.csv"));
    
                 Console.WriteLine("Items in the cart: ");
                for (int i = 0; i < remove.productlistt.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {remove.productlistt[i]}");
                }

                Console.Write("Enter the number of the item you wish to remove: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= remove.productlistt.Count)

                {
                    remove.productlistt.RemoveAt(choice - 1);
                    File.WriteAllLines("../../../Cart.csv",
                        remove.productlistt);
                    Console.WriteLine("Item has been removed from the cart.");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Invalid selection. No items were removed.");
                    Console.WriteLine();
                }

            }

            }

            public static void showProducts()
        {
            
        AdminUser show = new AdminUser();
        {
                        Console.Clear();
               
                show.productlistt = new List<string>(File.ReadAllLines("../../../Cart.csv"));

                foreach (var item in show.productlistt)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

        }
                    

        }

            public static void ChangeUser()
        {
            List<string> userNames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
            List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));

            for (int i = 0; i < userNames.Count; i++)
            {

                Console.WriteLine("Do you wish to remove or change? : Type: remove - To remove Type: change - To change");
                string change = Console.ReadLine();
                if (change == "remove")
                {
                    Console.WriteLine($"{i + 1}. {userNames[i]}");


                    Console.Write("Enter the number of the item you wish to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeNumb) && removeNumb <= userNames.Count)
                    {
                        userNames.RemoveAt(removeNumb - 1);
                        File.WriteAllLines("../../../usernames.csv", userNames);
                        Console.WriteLine("User succesfully removed! Updated user list:");
                        foreach (var item in userNames)
                        {
                            Console.WriteLine(userNames);
                        }
                    }
                }

                if (change == "change")
                {
                    Console.WriteLine($"{i + 1}. {userNames[i]}");


                    Console.WriteLine("What user do you want to change? Enter a number:");
                    if (int.TryParse(Console.ReadLine(), out int changeNumb) && changeNumb <= userNames.Count)
                    {
                        Console.WriteLine($"You choosed: {userNames[changeNumb - 1]}");
                        Console.WriteLine("Enter you change: ");
                        string changedUser = Console.ReadLine();
                        Console.WriteLine($"Previus password :{Passwords[changeNumb - 1]}");
                        Console.WriteLine("Enter your new");
                        string? newPassword = Console.ReadLine();

                        Passwords[changeNumb - 1] = newPassword;
                        userNames[changeNumb - 1] = changedUser;
                        File.WriteAllLines("../../../usernames.csv", userNames);
                        File.WriteAllLines("../../../passwords.csv", Passwords);

                        Console.WriteLine("User has succesfully been changed press any key to see your updates: ");
                        Console.ReadKey();
                        Console.Clear();
                        foreach (var item in userNames)
                        {
                            Console.WriteLine(userNames);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }


            }


        }

}


