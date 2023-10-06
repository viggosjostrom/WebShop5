using System;
using System.Collections.Generic;
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

        List<string> productList = new List<string> (File.ReadAllLines("../../../products.csv"));


        List<string> productName = new List<string>();
        List<string> productPrice = new List<string>();

        Console.WriteLine("Add a product");
        string? addProduct = Console.ReadLine();
        productList.Add(addProduct);
        File.WriteAllLines("../../../products.csv", productList);

        Console.WriteLine("Add price for the product");
        string addPrice = Console.ReadLine();
        productList.Add(addPrice);
        File.WriteAllLines("../../../products.csv", productList);



        foreach (string row in productList)
        {
            Console.WriteLine(row);
        }

    }

}
