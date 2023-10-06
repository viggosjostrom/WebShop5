using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Transaction
{
    public string[] transactionHistory = File.ReadAllLines("transactions/history.csv");

    public void printHistory()
    {
        
        foreach (string transaction in transactionHistory) 
        { 
            Console.WriteLine(transaction);
        }
        
    }

    public void viewReceipt()
    {
        foreach (string transaction in transactionHistory)
        {
            Console.WriteLine(transaction);
        }

        Console.WriteLine("choose a receipt number: ");
        
        string userInput = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("please choose a valid receipt number");
            userInput = Console.ReadLine();

        }

        foreach (string a in transactionHistory)
        {

            string[] transaction = a.Split(",");
            string compare = transaction[1];

            if (userInput == compare)
            {
                //lägg till någon sorts funktion som använder input för att kunna hitta och printa en transaction fil
            }
            

        }
    } 
    

}


