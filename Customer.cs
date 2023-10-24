namespace WebShop5;

public record Customer(string Username, List<Product> Cart) : IUser
{

    public void ShowMainMenu()
    {
        
        
        while (true)
        {
            Console.WriteLine("\t\t\tUSER MENU\n");
            Console.WriteLine("MENU: ");
            Console.WriteLine("1 : Show Products");
            Console.WriteLine("2 : Shop Products");
            Console.WriteLine("3 : Remove from your Shopping Bag");
            Console.WriteLine("4 : Go to payment / Checkout");
            Console.WriteLine("5 : Order History");
            Console.WriteLine("0 : Sign Out");


            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 0:
                        // Användaren loggar ut                  
                        Console.Clear();
                        MainMenu.Start();
                        break;

                    case 1:
                        // Loop som listar alla produkter
                        Console.Clear();
                        ShowProducts();
                        break;

                    case 2:
                        Console.Clear();
                        AddToShoppingbag();
                        break;

                    case 3:
                        Console.Clear();
                        RemoveFromShoppingbag();
                        break;

                    case 4:
                        Console.Clear();
                        PurchaseShoppingbag();
                        break;

                    case 5:
                        Console.Clear();
                        DisplayReceipts();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }


            }
            else
            {
                Console.WriteLine("Input must be number");
                Console.ReadLine();
            }

        }
    }
    public void SaveCart()
    {
        List<string> tempCart = new List<string>();
        foreach (Product product in Cart)
        {
            tempCart.Add(product.ToCSVString());
        }

        File.Create($"../../../ShoppingBag/{Username}.csv").Close();
        File.AppendAllLines($"../../../ShoppingBag/{Username}.csv", tempCart);

    }


    public void DisplayReceipts()
    {
        string path = @$"receipts/{Username}/";
        string[] receipts = Directory.GetFiles(path);
        foreach (string receipt in receipts)
        {
            string[] receiptInfo = receipt.Split(path);
            Console.WriteLine(receiptInfo[1]);
        }
    }

    public void ChooseReceipt()
    {
        string userInput = null;

        string path = @$"receipts/{Username}/";
        string[] receipts = Directory.GetFiles(path);

        while (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("please enter a valid receipt number");
            userInput = Console.ReadLine();
        }

        for (int i = 0; i <= receipts.Length; i++)
        {
            int compare = i + 1;
            if (Int32.TryParse(userInput, out int userChoice) && compare == userChoice) ;
            {
                Console.WriteLine(receipts[i]);
                string[] receipt = File.ReadAllLines($"receipts/{Username}/");
            }
        }
    }


    public void AddToShoppingbag()
    {
        List<string> productList = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        List<string> ShoppingBag = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{Username}.csv"));

        string newProduct = string.Empty;
        string newItem = string.Empty;


        while (newProduct != "n")
        {

            Console.WriteLine("\t\t\tADD PRODUCTS IN CART\n");

            Console.WriteLine("Products to buy: ");
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productList[i]}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to add in cart: ");
            Console.WriteLine("To go back to menu write x");
            string? input = Console.ReadLine();
            if (input == "x")
            {
                newProduct = "n";
                break;
            }
            if (int.TryParse(input, out int choice))
            {

                if (choice > productList.Count)

                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection. No items were added.");
                    Console.WriteLine();
                    break;
                }
                newItem = productList[choice - 1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection. No items were added.");
                Console.WriteLine();
                break;
            }

            ShoppingBag.Add(newItem); // Använd "Cart" lista istället?




            // Skriv över filen "products.csv" om användaren vill lägga till mer produkter.
            if (newProduct == "y")
            {
                File.WriteAllLines($"../../../ShoppingBag/{Username}.csv", ShoppingBag); // denna bör väl skriva till användarens personliga shopping bag?
            }


            Console.WriteLine();
            Console.Write("Want to add more? y/n?: ");
            newProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }

        // Skriver ut användarens kundvagn.

        Console.WriteLine("\t\t\tYOUR SHOPPINGBAG:");
        Console.WriteLine();
        foreach (string row in ShoppingBag)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine();
    } // Använd Cart

    public void RemoveFromShoppingbag()
    {
        string removeProduct = string.Empty;


        while (removeProduct != "n")
        {


            List<string> userCart = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{Username}.csv"));

            string removeItem = string.Empty;
            Console.WriteLine("\t\t\tREMOVE PRODUCTS FROM CART\n");

            Console.WriteLine();

            for (int i = 0; i < userCart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userCart[i]}");
            }


            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to remove from cart: ");


            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                userCart.RemoveAt(choice - 1);
                File.WriteAllLines($"../../../ShoppingBag/{Username}.csv", userCart);
                Console.WriteLine("Item as been removed from cart.");
            }
            else
            {
                Console.WriteLine("Invalid selection. No items were added.");
                Console.WriteLine();
            }

            foreach (var item in userCart)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.Write("Want to remove more? y/n?: ");
            removeProduct = Console.ReadLine().ToLower();
            Console.Clear();

        }
    } // Använd Cart , samma som i PurchaseShoppingBag

    public void PurchaseShoppingbag()
    {
        Console.WriteLine("\t\t\tPURCHASE PRODUCTS FROM CART\n");


        if (Cart.Count() == 0)

        {
            Console.WriteLine("Nothing in shoppingbag to purchase");
            Console.WriteLine("Press any key to go to User Menu");
            Console.ReadKey();
            
        }
        else
        {
            DateTime date = DateTime.Now;
            int total = 0;

            foreach (Product product in Cart)
            {
                Console.WriteLine($"{product.Name}, \t{product.Price}$, \t\t{date}");
                total += product.Price;
            }

            Console.WriteLine($"Total: {total}$");

            string receiptdate = DateTime.Now.ToString();
            receiptdate = receiptdate.Replace(" ", "-");
            receiptdate = receiptdate.Replace(":", "-");

            bool purchase = true;

            while (purchase)
            {

                Console.Write("Would you like to complete the purchase? y/n?: ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    string path = @$"receipts/{Username}/{Username}-{receiptdate}";

                    Directory.CreateDirectory(@$"receipts/{Username}");

                    List<string> ShoppingBag = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{Username}.csv"));

                    File.Create(path + ".csv").Close();
                    File.WriteAllLines(path + ".csv", ShoppingBag);
                    
                    purchase = false;
                }
                else if (choice == "n")
                {
                    Console.WriteLine("To bad, you will be redirected to user menu");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();

                    purchase = false;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invaild choice.");

                }
            }
        }


    }

    public void ShowProducts()
    {
        List<string> Catalog = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        foreach (var item in Catalog)
        {

            string str = item.Replace(',', '\t');
            Console.WriteLine($"{str}$");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

}