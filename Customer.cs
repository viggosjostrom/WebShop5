using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public record Customer(string Username, List<Product> Cart) : IUser
{
    public void SaveCart()
    {
        List<string> tempCart = new List<string>();
        foreach(Product product in Cart)
        {
            tempCart.Add(product.ToCSVString());
        }

        File.Create($"../../../ShoppingBag/{Username}.csv").Close();
        File.AppendAllLines($"../../../ShoppingBag/{Username}.csv", tempCart);

    }


    public void PrintReceipts()
    {
        string[] receipt = File.ReadAllLines($"../../../{Username}.csv");
        foreach(string item in receipt)
        {
            Console.WriteLine(item);
        }
    }

    public void AddToShoppingbag()
    {


       

        List<string> productList = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        List<string> ShoppingBag = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{Username}.csv"));

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
            Console.WriteLine("To go back to menu write x");
            string? input = Console.ReadLine();
            if(input == "x")
            {
                newProduct = "n";
                break;
            }
            if (int.TryParse(input, out int choice))
            {
                
                if(choice > productList.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection. No items were added.");
                    Console.WriteLine();
                    break;
                }
                newItem = productList[choice - 1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection. No items were added.");
                Console.WriteLine();
                break;
            }

            ShoppingBag.Add(newItem);



            // Skriv över filen "products.csv" om användaren vill lägga till mer produkter.
            if (newProduct == "y")
            {
                File.WriteAllLines($"../../../ShoppingBag/{Username}.csv", ShoppingBag); // denna bör väl skriva till användarens personliga shopping bag?
            }


            Console.WriteLine();
            Console.Write("Want to add more? y/n?: ");
            newProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }

        // Skriver ut användarens kundvagn.

        Console.WriteLine("\t\t\tYOUR SHOPPINGBAG:");
        Console.WriteLine();
        foreach (string row in ShoppingBag)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine();
    }

    public void RemoveFromShoppingbag()
    {
        string removeProduct = string.Empty;


        while (removeProduct != "n")
        {


            List<string> userCart = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{Username}.csv"));

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
                File.WriteAllLines($"../../../ShoppingBag/{Username}.csv", userCart);
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

    public void PurchaseShoppingbag()
    {

        Console.WriteLine("\t\t\tPURCHASE PRODUCTS FROM CART\n");


      
        List<string> bag = File.ReadAllLines($"../../../ShoppingBag/{Username}.csv").ToList();


        if (bag.Count != 0)
        {

            int sum = 0;
           
            foreach (string line in bag)
            {
                
                string[] split = line.Split(",");
                

                if (int.TryParse(split[1], out int price))
                {
                    
                    sum += price;
                }
                else
                {
                    Console.WriteLine("Something went wrong with the 'Parse'.");
                }
                string str = line.Replace(',', '\t');
                Console.WriteLine($"{str}$");
            }

         
            DateTime date = DateTime.Now;

            Console.WriteLine("Total: " + sum + "$\t\t  " + date);

            bool purchase = true;

            while (purchase)
            {

                Console.Write("Would you like to complete the purchase? y/n?: ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    //Göra ett kvitto och tömma Shoppingbag???
                    purchase = false;
                }
                else if (choice == "n")
                {
                    Console.WriteLine("To bad, you will be redirected to user menu");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();

                    purchase = false;
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invaild choice.");

                }
            }
        }

        else
        {
            Console.WriteLine("Nothing in shoppingbag to purchase");
            Console.WriteLine("Press any key to go to User Menu");
            Console.ReadKey();
            
        }
    }

    public void ShowProducts()
    {
        List<string> Catalog = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        foreach (var item in Catalog)
        {
            Console.WriteLine($"{item}$");
        }
        Console.WriteLine();
        Console.WriteLine();
    }


}
