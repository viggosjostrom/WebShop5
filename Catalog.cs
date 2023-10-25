using WebShop5;

public class Catalog
{
    List<string> productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));


    public static void AddToCatalog()
    {
        List<string> productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        Console.Clear();
        Console.Write("Add new product: ");
        string? addProduct = Console.ReadLine();
        Console.Write("Price in $: ");
        string? addPrice = Console.ReadLine();
        Console.WriteLine();


        if (addPrice == string.Empty || addProduct == string.Empty)
        {
            Console.WriteLine("Enter Either a product or the price");
            Console.Clear();
        }

        else
        {
            string productToAdd = string.Format("{0},{1}", addProduct, addPrice);
            productlist.Add(productToAdd);

            File.WriteAllLines("../../../listofproducts.csv", productlist);
            Console.WriteLine("Products succesfully added");
            Thread.Sleep(1500);
            Console.Clear();

        }

    }

    public void RemoveProducts()
    {
        Console.Clear();
        productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        Console.WriteLine("\t\t\tPRODUCTS:");
        for (int i = 0; i < productlist.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productlist[i]}");
        }

        Console.Write("Enter the number of the item you wish to remove: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice <= productlist.Count)

        {
            Console.Clear();

            productlist.RemoveAt(choice - 1);
            File.WriteAllLines("../../../listofproducts.csv", productlist);
            Console.WriteLine("Item has been removed from the cart.");
            Console.WriteLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid selection. No items were removed.");
            Console.WriteLine();
        }

    }

    public static void DisplayCatalog()
    {
        Console.Clear();
        Console.WriteLine("\t\t\tPRODUCTS:");
        List<string> productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        foreach (var item in productlist)
        {
            Console.WriteLine($"{item}$");
        }
        Console.WriteLine();
        Console.ReadKey();

    }


}