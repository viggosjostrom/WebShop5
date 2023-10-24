namespace WebShop5;

public record Admin(string Username) : IUser
{
    public void AddToCatalog()
    {
        List<string> productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        Console.Clear();
        Console.Write("Add new product: ");
        string? addProduct = Console.ReadLine();
        Console.Write("Price in $: ");
        string? addPrice = Console.ReadLine();
        Console.WriteLine();


        if (addPrice == string.Empty || addProduct == string.Empty)
        {
            Console.WriteLine("Enter Either a product or the price");
        }

        else
        {
            string productToAdd = string.Format("{0},{1}", addProduct, addPrice);
            productlist.Add(productToAdd);


            Console.WriteLine();
            File.WriteAllLines("../../../listofproducts.csv", productlist);
        }

    }

    public void Removeproducts()
    {


        AdminMenu admin = new AdminMenu();
        {
            admin.productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

            Console.WriteLine("Items in the cart: ");
            for (int i = 0; i < admin.productlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {admin.productlist[i]}");
            }

            Console.Write("Enter the number of the item you wish to remove: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice <= admin.productlist.Count)

            {
                admin.productlist.RemoveAt(choice - 1);
                File.WriteAllLines("../../../Cart.csv",
                    admin.productlist);
                Console.WriteLine("Item has been removed from the cart.");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Invalid selection. No items were removed.");
                Console.WriteLine();
            }

        }

    }

    public void DisplayCatalog()
    {

        AdminMenu admin = new AdminMenu();
        {
            Console.Clear();

            admin.productlist = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

            foreach (var item in admin.productlist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

        }


    }

    public void ChangeUser()
    {
        List<string> userNames = new List<string>(File.ReadAllLines("../../../users.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../users.csv"));

        for (int i = 0; i < userNames.Count; i++)
        {


            Console.WriteLine("Do you wish to remove or change? : Type: remove - To remove Type: change - To change");
            string change = Console.ReadLine();
            if (change == "remove")
            {
                for (int v = 0; i < userNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userNames[i]}");
                }

                Console.Write("Enter the number of the item you wish to remove: ");
                if (int.TryParse(Console.ReadLine(), out int removeNumb) && removeNumb <= userNames.Count)
                {
                    userNames.RemoveAt(removeNumb - 1);
                    File.WriteAllLines("../../../users.csv", userNames);
                    Console.WriteLine("User succesfully removed! Updated user list:");
                    foreach (string users in userNames)
                    {
                        Console.WriteLine(users);
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
            }

            if (change == "change")
            {
                for (int v = 0; i < userNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userNames[i]}");
                }



                Console.WriteLine("What user do you want to change? Enter a number:");
                if (int.TryParse(Console.ReadLine(), out int changeNumb) && changeNumb <= userNames.Count)
                {
                    Console.WriteLine($"You choosed: {userNames[changeNumb - 1]}");
                    Console.WriteLine("Enter you change: ");
                    string changedUser = Console.ReadLine();
                    Console.WriteLine($"Previus password :{Passwords[changeNumb - 1]}");
                    Console.WriteLine("Enter your new");
                    string? newPassword = Console.ReadLine();

                    Passwords[changeNumb - 1] = newPassword;
                    userNames[changeNumb - 1] = changedUser;
                    File.WriteAllLines("../../../users.csv", userNames);
                    File.WriteAllLines("../../../users.csv", Passwords);

                    Console.WriteLine("User has succesfully been changed press any key to see your updates: ");
                    Console.ReadKey();
                    Console.Clear();
                    foreach (string userschange in userNames)
                    {
                        Console.WriteLine(userschange);
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }


        }


    }
}