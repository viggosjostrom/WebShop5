using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Transaction
{
    public string[] transactionHistory = File.ReadAllLines("~/source/repos/WebShop5/transactions/history.csv");

    public void printHistory()
    {
        foreach (string transaction in transactionHistory) 
        { 
            Console.WriteLine(transaction);
        }
        
    }

    /*public void viewReceipt()
    {
        string test = transactionHistory.Split(",");    
    } 
    vet inte vad problemet är, split verkar inte funka */

}


