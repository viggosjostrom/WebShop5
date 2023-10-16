using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;

public class UserMenu : IUser
{
    public void UserShoppingMenu()
    {



        bool UserMenu = true;

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
                    break;

                case 1:
                    // Loop som listar alla produkter
                    foreach (var item in productList)
                    {
                        Console.WriteLine(item);
                    }

                    break;

                case 2:
                    // Användaren kan lägga till från produkterna i sin Shoppingbag
                    Products.AddToShoppingbag();
                    break;

                case 3:
                    // Användaren kan ta bort produkter från sin shoppingbag
                    Products.RemoveFromShoppingbag();
                    break;
                case 4:
                    // Användaren kan efter att ha lagt till produkter i sin varukorg nu välja
                    // att genomföra köpet. Denna infon ska kopplas till kvitto / orderhistorik för användaren
                    // Products.PurchaseShoppingBag();
                    break;
                case 5:
                    // Se sin egen Order history (Fredriks kod)
                    break;

            }
        }
    }

}
}
