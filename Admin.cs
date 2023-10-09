using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WebShop5
{
    public class Admin
    {


        public List<string> newCart = new List<string>(); // Deklarera newCart som en instansvariabel


        static public void AdminLogIn()
        {
            string AdminUserName = "1";
            string AdminPassword = "1";

            Console.Clear();
            Console.WriteLine("Admin Home\n");

            Console.Write("Enter your admin log in: ");
            string inputLogin = Console.ReadLine();
            Console.Write("Enter your password: ");
            string inputPassword = Console.ReadLine();
            Console.Clear();

            if (inputLogin == AdminUserName && inputPassword == AdminPassword)
            {
                bool AdminMenu = true;
                while (AdminMenu)
                {
                    Console.WriteLine("ADMIN MENY: ");
                    Console.WriteLine("1 : Lägg till produkt");
                    Console.WriteLine("2 : Visa Produkter");
                    Console.WriteLine("3 : Ta bort produkter");
                    Console.WriteLine("0 : EXIT");
                    Console.WriteLine();
                    Console.Write("Make a choice: ");
                    int AdminChoice = Convert.ToInt32(Console.ReadLine());


                    switch (AdminChoice)
                    {
                        case 0:
                            AdminMenu = false;
                            break;

                        case 1:
                            updateCart();
                            break;

                        case 2:
                            showProducts();
                            break;

                        case 3:
                            removeproducts();
                            break;

                    }

                }

            }

            else
            {
                Console.WriteLine("Please make sure you entered the right username or password");
                return;
            }
        }

        public static void updateCart()
        {
            List<string> newCart = new List<string>(File.ReadAllLines("../../../Cart.csv"));

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
                newCart.Add(productToAdd);

                
                for (int i = 0; i < newCart.Count; i++)
                {
                    newCart[i] = $"{i + 1}. {newCart[i]}";
                }

                Console.WriteLine();
                File.WriteAllLines("../../../Cart.csv", newCart);
            }

        }

        public static void removeproducts()
        {
            {
                Console.Clear();
                Admin Remove = new Admin();
                Remove.newCart = new List<string>(File.ReadAllLines("../../../Cart.csv"));

                Console.WriteLine("Items in the cart: ");
                for (int i = 0; i < Remove.newCart.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Remove.newCart[i]}");
                }

                Console.Write("Enter the number of the item you wish to remove: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= Remove.newCart.Count)

                {
                    Remove.newCart.RemoveAt(choice - 1);
                    File.WriteAllLines("../../../Cart.csv", Remove.newCart);
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
            {
                Console.Clear();
                Admin admin = new Admin();
                admin.newCart = new List<string>(File.ReadAllLines("../../../Cart.csv"));

                foreach (var item in admin.newCart)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }

        }

    }

}


