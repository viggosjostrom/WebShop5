using System.Data.Common;
using WebShop5;
IUser? user = null;


    Console.WriteLine("1 - Create new user");
    Console.WriteLine("2 - Login as existing user");
    Console.WriteLine("0 - To Exit");
   
do
{
    switch (Console.ReadLine())
    {
        case "1":
            LoginMenu.Register();
            break;

        case "2":
            user = LoginMenu.Login();
            break;
    }
} while (user is null);
user.ShowMainMenu();






