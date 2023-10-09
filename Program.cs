namespace WebShop5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Showmenu = true;

            while (Showmenu)
            {
                
                Console.WriteLine("1 - Skapa en användare");
                Console.WriteLine("2 - Logga in som användare");
                Console.WriteLine("3 - Logga in som admin");
                Console.WriteLine("0 - To Exit");
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 0: break;

                  //*  case "1": User();
                  //*      break;
                    
                  //*  case "2": LogInUser();
                  //*      break;

                    case 3: Admin.AdminLogIn();
                        break;
                }


            }
        }
    }
}

