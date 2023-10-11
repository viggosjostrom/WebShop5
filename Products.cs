using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Products
{

    string? name;
    string? category;
    int price;

    public static void AddToShoppingbag()
    {

        List<string> productList = new List<string>(File.ReadAllLines("../../../ListOfProducts.csv"));

        List<string> userCart = new List<string>();

        string newProduct = string.Empty;
        string newItem = string.Empty;


        while (newProduct != "n")
        {

            Console.WriteLine("\t\t\tADD PRODUCTS IN CART\n");

            Console.WriteLine("Products to buy: ");
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productList[i]}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to add in cart: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                newItem = productList[choice - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection. No items were added.");
                Console.WriteLine();
            }

            userCart.Add(newItem);



            // Skriv över filen "products.csv" om användaren vill lägga till mer produkter.
            if (newProduct == "y")
            {
                File.WriteAllLines("../../../Shoppingbag.csv", userCart);
            }


            Console.WriteLine();
            Console.Write("Want to add more? y/n?: ");
            newProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }

        // Skriver ut användarens kundvagn.

        Console.WriteLine("Your cart:");
        Console.WriteLine();
        foreach (string row in userCart)
        {
            Console.WriteLine(row);
        }

    }

    public static void RemoveFromShoppingbag()
    {
        string removeProduct = string.Empty;


        while (removeProduct != "n")
        {


            List<string> userCart = new List<string>(File.ReadAllLines("../../../Shoppingbag.csv"));

            string removeItem = string.Empty;
            Console.WriteLine("\t\t\tREMOVE PRODUCTS FROM CART\n");

            Console.WriteLine();

            for (int i = 0; i < userCart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userCart[i]}");
            }


            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to remove from cart: ");


            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                userCart.RemoveAt(choice - 1);
                File.WriteAllLines("../../../Shoppingbag.csv", userCart);
                Console.WriteLine("Item as been removed from cart.");
            }
            else
            {
                Console.WriteLine("Invalid selection. No items were added.");
                Console.WriteLine();
            }

            foreach (var item in userCart)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.Write("Want to remove more? y/n?: ");
            removeProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }
    }

    public static void Purchase()
    {
        // List<string> checkoutShoppingbag = new List<string>(File.ReadAllLines("../../../Shoppingbag.csv"));

        Dictionary<string, int> checkout = new Dictionary<string, int>();

        string[] shop = File.ReadAllLines("../../../Shoppingbag.csv");



        if (shop != null)
        {

            int sum = 0;

            foreach (string line in shop)
            {
                string[] split = line.Split(", ");

                string res = split[1];
                if (int.TryParse(split[1], out int price))
                {
                    checkout.Add(split[0], price);
                    sum += price;
                }
            }
                    Console.WriteLine(sum + "$");

        }
        else
        {
            Console.WriteLine("Nothing in shoppingbag to Purchase");
            Console.WriteLine("Press any key to go to User Menu");
            Console.ReadKey();
            User.UserShoppingMenu();
        }
    }
}