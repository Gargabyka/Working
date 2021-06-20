using System;


namespace Working
{
    class Program
    {
        public static void Main()
        {
            var working = new Settings();
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow; 
                Console.WriteLine("1. Add new employee \t 2. Add new intern  \t 3. Hire intern");
                Console.WriteLine("4. Promote employee \t 5. Show employee list \t 6. Exit");
                Console.WriteLine("Choose a number:");
                Console.ForegroundColor = color;
                
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    if (command > 6 || command < 1)
                    {
                        Console.WriteLine("Error. No number");
                        Console.WriteLine("Press any key to restart menu");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    switch (command)
                    {
                        case 1:
                            working.CreateUser(command);
                            break;
                        case 2:
                            working.CreateUser(command);
                            break;
                        case 3:
                            working.Hiring(working.interns);
                            break;
                        case 4:
                            working.Promotion(working.employees);
                            break;
                        case 5:
                            working.ShowEmployees(working.employees, working.interns);
                            break;
                        case 6:
                            Console.WriteLine("Goodbye");
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}