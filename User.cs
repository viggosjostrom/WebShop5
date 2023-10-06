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
        string userList = File.ReadAllText("../../../userList.csv");

        foreach (var item in userList)
        {
            Console.Write(item);
        }

        Console.WriteLine("Your first name: "); 
        currentUser.FirstName = Console.ReadLine();
        Console.WriteLine("Your last name: ");
        currentUser.LastName = Console.ReadLine();
        Console.WriteLine("Choose a username: ");
        currentUser.Username = Console.ReadLine();
        if (currentUser.Username == string.Empty)
        {
            Console.WriteLine("Try again");
            Console.WriteLine("Choose a username: ");
            currentUser.Username = Console.ReadLine();
        }
        Console.WriteLine("Email: ");
        currentUser.Email = Console.ReadLine();
        Console.WriteLine("Choose a password: ");
        currentUser.Password = Console.ReadLine();

        

        
        

        
        
    }
}
