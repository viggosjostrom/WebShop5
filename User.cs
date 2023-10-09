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
       List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));


        Console.WriteLine("Choose a username: ");
        string SignUpUsernameChoice = Console.ReadLine();
        Usernames.Add(SignUpUsernameChoice);
        File.WriteAllLines("../../../usernames.csv", Usernames);

        Console.WriteLine("Choose a password: ");
        string SignUpPasswordChoice = Console.ReadLine();
        Passwords.Add(SignUpPasswordChoice);
        File.WriteAllLines("../../../passwords.csv", Passwords);

            

       



    }

    public static void LogIn()
    {
        List<string> Usernames = new List<string>(File.ReadAllLines("../../../usernames.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../passwords.csv"));
        bool loginSuccess = false; 

        
        
        while (!loginSuccess)
        {
            Console.WriteLine("Enter your username: ");
            string InputUsername = Console.ReadLine();


            foreach (string username in Usernames)
            {
               
                if(username == InputUsername)
                {
                    int ListNumber = Usernames.IndexOf(InputUsername);
                    Console.WriteLine("Enter your password: ");
                    string InputPassword = Console.ReadLine();

                    string passwordCheck = Passwords[ListNumber];
                    if (InputPassword == passwordCheck)
                    {
                        Console.Clear();
                        Console.WriteLine("Logged in successfully!");
                        loginSuccess = true;
                        

                    }
                    
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong password, try to log in again..");

                    }
                    break;

                }
                
                
            }

        }
        

        
    }
}
