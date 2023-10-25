namespace WebShop5;

public record Customer(string Username, List<Product> Cart) : IUser
{

    public void ShowMainMenu()
    {


        while (true)
        {
            Console.Clear();
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
                        SaveCart(); // Sparar användarens Cart vid utloggning
                        Console.Clear();
                        MainMenu.Start();
                        break;

                    case 1:                        
                        Console.Clear();
                        Catalog.DisplayCatalog();
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
                        ChooseReceipt();
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

    public void ChooseReceipt()
    {
        
        string path = @$"receipts/{Username}/";
        string[] receipts = Directory.GetFiles(path);
        int receiptNumber = 1;
        foreach (string receipt in receipts)
        {
            string[] receiptInfo = receipt.Split(path);
            Console.WriteLine(receiptNumber + ". " + receiptInfo[1]);
            receiptNumber += 1;
        }
        string userInput = null;
      



        while (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("please enter a valid receipt number");
            userInput = Console.ReadLine();
        }

        for (int i = 0; i <= receipts.Length; i++)
        {
            int compare = i + 1;
            if (Int32.TryParse(userInput, out int userChoice) && compare == userChoice)
            {
                Console.WriteLine(receipts[i]);
                string choicepath = receipts[i];
                string[] receipt = File.ReadAllLines(choicepath);
                foreach (string line in receipt)
                {
                    Console.WriteLine(line);
                }
            }
        }
        
        Console.ReadKey();
    }

    public void AddToShoppingbag()
    {
        List<string> productList = new List<string>(File.ReadAllLines("../../../listofproducts.csv"));

        string newProduct = string.Empty;
        string tempProduct = string.Empty;
        string choosenProductName = string.Empty;
        int choosenProductPrice;


        while (newProduct != "n")
        {

            Console.WriteLine("\t\t\tADD PRODUCTS TO SHOPPINGBAG\n");

            Console.WriteLine("Products to buy: ");
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productList[i]}$");
            }

            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to add in cart: ");
            Console.WriteLine("To go back to menu write x");
            string? input = Console.ReadLine();
            if (input == "x")
            {
                newProduct = "n";
                Console.Clear();
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
                tempProduct = productList[choice - 1];  // Ska ta fram rätt rad (produkten användaren valt) från listofproducts
                string[] NameAndPrice = tempProduct.Split(','); // Splittar raden för att få fram namn och pris separat
                choosenProductName = NameAndPrice[0].ToString(); // Sparar produktnamnet på plats 0 till variabel string
                choosenProductPrice = int.Parse(NameAndPrice[1]); // Sparar produktpriset på plats 1 till variabel int



            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection. No items were added.");
                Console.WriteLine();
                break;
            }

            Cart.Add(new Product(choosenProductName, choosenProductPrice)); // Lägger till vald produkt i Cart

            Console.WriteLine();
            Console.Write("Want to add more? y/n?: "); // För "y" går det att trycka vad som helst förutom "n"
            newProduct = Console.ReadLine().ToLower();
            Console.Clear();
            
        }

        // Skriver ut användarens kundvagn.
        int total = 0;
        Console.WriteLine("\t\t\tYOUR SHOPPINGBAG:");
        Console.WriteLine();
        foreach (Product p in Cart)
        {
            Console.WriteLine($"{p.Name} {p.Price}$");
            total += p.Price;

        }
        Console.WriteLine();
        Console.WriteLine($"Total: {total}$");
    }

    public void RemoveFromShoppingbag()
    {
        string removeProduct = string.Empty;


        while (removeProduct != "n")
        {


            int count = 0;
            string removeItem = string.Empty;
            Console.WriteLine("\t\t\tREMOVE PRODUCTS FROM SHOPPINGBAG\n");
            Console.WriteLine();

            foreach (Product p in Cart)
            {
                count++;
                Console.WriteLine($"{count}. {p.Name} {p.Price}$");
            }

            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to remove from cart: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if(choice < Cart.Count)
                {
                Cart.RemoveAt(choice - 1);
                Console.WriteLine("Item as been removed from cart.");

                }
                else
                {
                    Console.WriteLine("Invalid selection. No items were added.");
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                }
            }
            
            Console.WriteLine();
            Console.Write("Want to remove more? y/n?: ");
            removeProduct = Console.ReadLine().ToLower();
            Console.Clear();
        }
    }

    public void PurchaseShoppingbag()
    {
        Console.WriteLine("\t\t\tPURCHASE PRODUCTS IN SHOPPINGBAG\n");

        if (Cart.Count() == 0)
        {
            Console.WriteLine("Nothing in shoppingbag to purchase");
            Console.WriteLine("Press any key to go to User Menu");
            Console.ReadKey();
        }
        else
        {
            int total = 0;

            foreach (Product p in Cart)
            {
                Console.WriteLine($"{p.Name}, {p.Price}$");
                total += p.Price;
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
                    Console.WriteLine("Purchase successful!");
                    string path = @$"receipts/{Username}/{Username}-{receiptdate}.csv";

                    Directory.CreateDirectory(@$"receipts/{Username}");

                    List<string> ShoppingBag = new List<string>(File.ReadAllLines($"../../../ShoppingBag/{Username}.csv"));
                    List<string> tempCart = new List<string>();

                    foreach (Product product in Cart)
                    {
                        tempCart.Add(product.ToCSVString());
                    }

                    File.Create(path).Close();
                    File.WriteAllLines(path, tempCart);
                    File.AppendAllText(path, "\n \nTotal: " + total.ToString() + "$");

                    purchase = false;
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else if (choice == "n")
                {
                    Console.WriteLine("To bad, you will be redirected to user menu");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    purchase = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invaild choice.");
                    Console.ReadKey();
                }
            }
        }
    }
}