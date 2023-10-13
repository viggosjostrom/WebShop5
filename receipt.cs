using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebShop5;

namespace WebShop5;

public class receipt
{
    public void printReceipts(Customer user)
    {
        string usernameFile = user.Username;
        string[] receiptList = File.ReadAllLines($"../../../{usernameFile}.csv");


        Console.WriteLine(receiptList);
        

    }
}
