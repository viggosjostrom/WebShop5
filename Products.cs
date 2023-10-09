using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Products
{

    string? name;
    string? category;
    int price;

    public static void AddProduct()
    {

        List<string> productList = new List<string>(File.ReadAllLines("../../../Cart.csv"));

        List<string> userCart = new List<string>();

        string newProduct = string.Empty;


        while (newProduct != "n")
        {

            Console.WriteLine("\t\t\tADD PRODUCTS IN CART\n");

            foreach (string item in productList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to add in cart: ");
            string addProduct = Console.ReadLine();


            foreach (string item in productList)
            {
                if (item.Contains(addProduct)) 
                {
                    userCart.Add(item);
                }
            }


            for (int i = 0; i < userCart.Count; i++) // Lägger till ett nummer i början av produkten. Kanske inte behövs??
            {
                Console.WriteLine($"{i + 1}. {userCart[i]}");
            }



            // Skriv över filen "products.csv" om användaren vill lägga till mer produkter.
            if (newProduct == "y")
            {
                File.WriteAllLines("../../../products.csv", userCart);
            }


            Console.WriteLine();
            Console.Write("Want to add more? y/n?: ");
            newProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }

        // Skriver ut användarens kundvagn.
        Console.WriteLine("Your cart:");
        foreach (string row in userCart)
        {
            Console.WriteLine(row);
        }

    }

    public static void RemoveProduct() // inte klar med denna.
    {

        List<string> productList = new List<string>(File.ReadAllLines("../../../products.csv"));

        Console.WriteLine("What postion do you want to remove?: ");
        Console.WriteLine();

        foreach (string row in productList)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine();
        Console.Write("Number: ");
        string? removeNumber = Console.ReadLine();
        int removeIndex = int.Parse(removeNumber);
        productList.RemoveAt(removeIndex);

        File.WriteAllLines("../../../products.csv", productList); //Måste uppdatera så listans nummer också uppdateras??

    }

}