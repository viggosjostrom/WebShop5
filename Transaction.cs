using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class Transaction
{
    public string[] transactionHistory = File.ReadAllLines("../../transactions/history.csv");

    public void printHistory()
    {
        //skriver ut kvitto till alla köp

        foreach (string transaction in transactionHistory) 
        { 
            Console.WriteLine(transaction);
        }
        
    }

    public void viewReceipt()
    {
        //skriver ut kvitto till alla köp
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
            // använder userinputen vi fick för att printa ut en fil
            string[] transaction = a.Split(",");
            string compare = transaction[0];

            if (userInput == compare)
            {
                string[] file = File.ReadAllLines($"../../../transactions/receipt{userInput}.txt");

                foreach (string line in file)
                {
                    Console.WriteLine(line);
                }    
            }
            

        }
    }

    public void makeReceipt()
    {
        //funktion för att skriva alla linjer till en dictionary till huvudfilen med alla köp
        Dictionary<string, string> reWriteFile = new Dictionary<string, string>();

        foreach (string a in transactionHistory)
        {
            string[] transaction = a.Split(",");

            reWriteFile.Add(transaction[0], transaction[1]);


        }

        //reWriteFile.Add(/*string[0], string[1]*/);
        // !!! byt string[0] och string[1] när jag vet vad köpets saker blir !!!

        //File.WriteAllText("../../../transactions/receipt.txt", reWriteFile);
        //"cannot convert from dictionary to string

        //funktion för att skriva till helt ny fil som inte finns än
    }


}


