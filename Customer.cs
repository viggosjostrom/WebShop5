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


}
