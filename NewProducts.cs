using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class NewProducts
{

    public string Name;
    public int Price;

    public void AddProducts()
    {


        NewProducts product = new NewProducts();

        List<string> listofproducts = new List<string>();
        bool addProduct = true;

        while (addProduct)
        {
            Console.WriteLine("\t\t\tADD PRODUCTS TO LIST\n");


            Console.Write("Name of the product: ");
            product.Name = Console.ReadLine();
            Console.Write("Price of the product: ");
            product.Price = int.Parse(Console.ReadLine());



            File.AppendAllText("../../../listofproducts.csv", $"{product.Name},{product.Price}\n");

            bool addMore = true;

            while (addMore)
            {

                Console.WriteLine("Do you want to add more? y/n?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    addProduct = true;
                    addMore = false;
                    Console.Clear();
                }
                else if (choice == "n")
                {
                    addMore = false;
                    addProduct = false;
                    Console.Clear();
                }
                else
                {

                    Console.WriteLine("Not a valid choice!");
                    addMore = true;

                }

            }

        }
    }
}
