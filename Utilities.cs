using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Utilities
{
    public void AddToShoppingbag(Customer user) // vad är user i detta fallet? 
    {

        string username = user.Username; // Kan detta funka för att skriva till shoppingbag??

        List<string> productList = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        List<string> userCart = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{username}.csv"));

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
                File.WriteAllLines($"../../../ShoppingBag/{username}.csv", userCart); // denna bör väl skriva till användarens personliga shopping bag?
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
}
