using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop5;

//Ta bort innan Merge
var add = new NewProducts();
add.Products();

//Ta bort innan merge
var user = new LoginMenu();


bool Showmenu = true;

while (Showmenu)
{

    Console.WriteLine("1 - Create new user");
    Console.WriteLine("2 - Login as existing user");
    Console.WriteLine("3 - Login as admin");
    Console.WriteLine("0 - To Exit");
    int Choice = Convert.ToInt32(Console.ReadLine());
    switch (Choice)
    {
        case 0:
            Showmenu = false;
            break;

        case 1:
            user.Register();
            break;

        case 2:
            user.LogIn();
            break;

    }
}