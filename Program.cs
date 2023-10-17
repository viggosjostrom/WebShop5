using System.Data.Common;
using WebShop5;



LoginMenu menu = new LoginMenu();
IUser? user = null;




bool Showmenu = true;

while (Showmenu)
{

    Console.WriteLine("1 - Create new user");
    Console.WriteLine("2 - Login as existing user");
    Console.WriteLine("0 - To Exit");
    int Choice = Convert.ToInt32(Console.ReadLine());
    switch (Choice)
    {
        case 0:
            Showmenu = false;
            break;

        case 1:

            menu.Register();
            break;

        case 2:
            user = menu.LogIn();
            Showmenu = false;
            break;
     }
}




if(user is Admin)
{
    AdminMenu.loadAdmin();
}

if(user is Customer c)
{
    UserMenu.UserShoppingMenu();
    c.SaveCart(); // spara nuvarande användares shoppingbag
    // c.Cart.Add customer lägger till produkt i sin shoppingbag
    c.PrintReceipts();

    Catalog.ShowProducts();

    if(int.TryParse(Console.ReadLine(), out int choice) && choice <= Catalog.Count())
    {
        c.Cart.Add(Catalog.Products[choice - 1]);
    }
    else
    {
        Console.WriteLine("Please enter a valid product number");
    }

}


