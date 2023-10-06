using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class User
{
     
    public string? Username;
    public string? Password;


    public static void SignUp()
    {
        User currentUser = new User();

       
        List<string> Usernames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
        List<string> Passowrds = new List<string>(File.ReadAllLines("../../../passwords.csv"));

        Console.WriteLine("Choose a username: ");

        Console.WriteLine("Choose a password: "); 

       

         

       



    }
}
