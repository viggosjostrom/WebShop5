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
    bool UserMenu = true;

    Console.WriteLine("\t\t\tUSER MENU\n");

    while (UserMenu)
    {
        Console.WriteLine("MENU: ");
        Console.WriteLine("1 : Show Products");
        Console.WriteLine("2 : Shop Products");
        Console.WriteLine("3 : Remove from your Shopping Bag");
        Console.WriteLine("4 : Go to payment / Checkout");
        Console.WriteLine("5 : Order History");
        Console.WriteLine("0 : Sign Out");
        int UserChoice = Convert.ToInt32(Console.ReadLine());


        switch (UserChoice)
        {
            case 0:
                // Användaren loggar ut                  
                UserMenu = false;
                Console.Clear();
                break;

            case 1:
                // Loop som listar alla produkter
                c.ShowProducts(); 
                break;

            case 2:
                c.AddToShoppingbag();
                break;
            
            case 3:
                c.RemoveFromShoppingbag();
                break;
            
            case 4:
                c.PurchaseShoppingbag();
                break;

            case 5:
                c.PrintReceipts();
                break;
            
            default:
                Console.WriteLine("Invalid choice"); 
                break;   

        }
    }
    
    c.SaveCart(); // spara nuvarande användares shoppingbag
    // c.Cart.Add customer lägger till produkt i sin shoppingbag
  
    //Catalog.ShowProducts();

    //if(int.TryParse(Console.ReadLine(), out int choice) && choice <= Catalog.Count())
    //{
    //    c.Cart.Add(Catalog.Products[choice - 1]);
    //}
    //else
    //{
    //    Console.WriteLine("Please enter a valid product number");
    //}

}


