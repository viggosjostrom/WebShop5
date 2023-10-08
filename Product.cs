using System;
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

    public static void ProductInventory()
    {

        List<string> productList = new List<string>(File.ReadAllLines("../../../products.csv"));


        List<string> productName = new List<string>();
        List<string> productPrice = new List<string>();

        string newProduct = string.Empty;



        while (newProduct != "n")
        {

            Console.WriteLine("\t\t\tADD PRODUCTS\n");

            Console.Write("Add a product: ");
            string? addProduct = Console.ReadLine();
            

            Console.Write("Add price for the product: ");
            string addPrice = Console.ReadLine();
            productList.Add(addProduct + ", " + addPrice + "$");
            File.WriteAllLines("../../../products.csv", productList);
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

    public void RemoveProduct()
    {

    }

}
