using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class User
{
    public string? FirstName;
    public string? LastName; 
    public string? Username;
    public string? Email;
    public string? Password;


    public static void SignUpNewUser()
    {
        User currentUser = new User();
        string[] userList;  
  

        Console.WriteLine("");
        Console.WriteLine("First name: "); 
        currentUser.FirstName = Console.ReadLine();
        userList[0] = currentUser.FirstName; 

        Console.WriteLine("Last name: ");
        currentUser.LastName = Console.ReadLine();
        userList[1] = currentUser.FirstName; 

        Console.WriteLine("Choose a username: ");
        currentUser.Username = Console.ReadLine();
        userList[2] = currentUser.Username;
        if (currentUser.Username == string.Empty)
        {
            Console.WriteLine("Try again");
            Console.WriteLine("Choose a username: ");
            currentUser.Username = Console.ReadLine();
            userList[2] = currentUser.Username;

        }
        Console.WriteLine("Email: ");
        currentUser.Email = Console.ReadLine();
        userList[3] = currentUser.Email;

        Console.WriteLine("Choose a password: ");
        currentUser.Password = Console.ReadLine();
        userList[4] = currentUser.Password;


       

        userList = File.ReadAllLines("../../../userList.csv");

        foreach (var item in userList)
        {
            Console.Write(item);
        }



    }
}
