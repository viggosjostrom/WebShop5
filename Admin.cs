
namespace WebShop5;

public record Admin(string Username) : IUser
{
    public void ShowMainMenu()
    {
        while (true)
        {
            Catalog c = new Catalog();
            Console.WriteLine($"Current user: {Username}");
            Console.WriteLine("1: Add product to catalog");
            Console.WriteLine("2: Remove product from catalog");
            Console.WriteLine("3 :Display Product catalog");
            Console.WriteLine("4 : Edit or remove user");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {

                switch (choice)
                {
                    case 1:
                        Catalog.AddToCatalog();
                        break;
                    case 2:
                        c.RemoveProducts();
                        break;
                    case 3:
                        Catalog.DisplayCatalog();
                        break;
                    case 4:
                        ChangeUser();
                        break;
                }


            }

        }



    }

    public static void ChangeUser()
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
                string path = "../../../users.csv";


                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }

                List<string> users = new(File.ReadAllLines(path));

                for (int v = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i}. {users[i]}");
                }

                Console.WriteLine("enter user index for which you wish to modify");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice < users.Count())
                {
                    string[] old_user = users[choice].Split(',');

                    Console.Write("new username (enter to skip): ");
                    string username = Console.ReadLine() ?? string.Empty;
                    if (username.Equals(string.Empty) && old_user.Length >= 1)
                    {
                      username = old_user[0];

                        
                    }
                    
                     
                    

                    Console.Write("new password (enter to skip): ");
                    string password = Console.ReadLine() ?? string.Empty;
                    if (password.Equals(string.Empty) && old_user.Length >= 2)
                    {
                        password = old_user[1];
                    }

                    Console.Write("new role (enter to skip): ");
                    string raw_role = Console.ReadLine() ?? string.Empty;
                    Role role;
                    if (Enum.TryParse(raw_role, out Role new_role))
                    {
                        role = new_role;
                    }
                    else if (old_user.Length >= 3 && Enum.TryParse(old_user[2], out Role old_role))
                    {
                        role = old_role;
                    }
                    else
                    {
                        role = Role.Customer;
                    }

                    users.RemoveAt(choice); // [a,b,c] => [a,c]
                    users.Insert(choice, $"{username},{password},{role}"); // [a,c] => [a,d,c]
                }
                else
                {
                    Console.WriteLine("invalid user index, quitting program");
                }

                File.WriteAllLines(path, users);
            }


        }


    }
}









