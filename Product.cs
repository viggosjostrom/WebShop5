using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Product
{

    string? name;
    string? category;
    int price;

    public static void AddProduct()
    {

        List<string> productList = new List<string>(File.ReadAllLines("../../../products.csv"));


        string newProduct = string.Empty;
        int positionNumber = 1;        // Lägger till siffran "1." igen när ny produkt ska läggas till, lösa att den ska börja i slutet av listan?


        while (newProduct != "n")
        {

            Console.WriteLine("\t\t\tADD PRODUCTS\n");

            Console.Write("Add a product: ");
            string? addProduct = Console.ReadLine();


            Console.Write("Add price in $ for the product: ");
            string addPrice = Console.ReadLine();
            productList.Add(positionNumber.ToString() + ". " + addProduct + ", " + addPrice + "$");
            File.WriteAllLines("../../../products.csv", productList);
            positionNumber++;
            Console.Clear();

            Console.Write("Want to add more? y/n?: ");
            newProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }

        foreach (string row in productList)
        {
            Console.WriteLine(row);
        }

    }

    public static void RemoveProduct()
    {

        List<string> productList = new List<string>(File.ReadAllLines("../../../products.csv"));

        Console.WriteLine("What postion do you want to remove?: ");
        Console.WriteLine();

        foreach (string row in productList)
        {
            Console.WriteLine(row);
        }
        //Console.WriteLine();
        //Console.Write("Number: ");
        //productList.Remove(Console.ReadLine());

        //File.WriteAllLines("../../../products.csv", productList);

    }

}
