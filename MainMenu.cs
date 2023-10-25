using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class MainMenu
{
    public static void Start()
    {
        IUser? user = null;

        do
        {
            Console.WriteLine("\t\t\tMAIN MENU");
            Console.WriteLine("1 : Create new user");
            Console.WriteLine("2 : Login as existing user");
            Console.WriteLine("0 : To Exit");
            switch (Console.ReadLine())
            {
                case "0":
                    return;
                    
                case "1":
                    LoginMenu.Register();
                    break;

                case "2":
                    user = LoginMenu.Login();
                    break;
            }
        } while (user is null);
        user.ShowMainMenu();
    }
}
