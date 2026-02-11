using System;
using System.Threading;
using System.Threading.Tasks;

namespace GROUP_ACTIVITY
{
    class Program
    {
        static void Main(string[] args)
        {
            string pName;
            int p;

            Console.WriteLine("Welcome to Meridian Hotel!");
            Console.WriteLine("We are delighted to have you here. Please let us know your name so we can provide you with the best service possible.");

            Sleep(1500); ClearLastLines(2);
            Console.WriteLine("\nPlease enter your name: ");
            pName = Console.ReadLine(); ClearLastLines(2);
            Sleep(1000);
            Console.WriteLine(pName + ", unfortunately there's only 1 room unoccupied today. Here's the key for Room 616.");
            Sleep(1500); ClearLastLines(1);

            string choice;
            while (true)
            {
                Console.WriteLine("\nWould you like to stay here? (Yes/No)");
                choice = Console.ReadLine()?.Trim().ToLower();

                if (choice == "yes")
                {
                    Console.WriteLine("\nGreat! We hope you enjoy your stay at Meridian Hotel, " + pName + "!");
                    break;
                }

                if (choice == "no")
                {
                    Console.WriteLine("\nWe understand, " + pName + ". We hope you find a comfortable place to stay. Have a great day!");
                    Console.WriteLine("Thank you for trying out the game...");
                    Environment.Exit(0); // Exit the program
                }

                Console.WriteLine("\nInvalid choice. Please enter 'Yes' or 'No'.\n"); Sleep(2000); ClearLastLines(5);
                // input validation
            }
            Sleep(1500); ClearLastLines(5);
            Console.WriteLine("\nYou take the key and head towards Room 616. "); fsSound(repeats: 3, frequency: 900, duration: 80, spacing: 120); Sleep(3000); ClearLastLines(2);   
            //As you approach the door, you notice that it is old and creaky. "); Sleep(1000); ClearLastLines(2);

            //+
            //    "\nThe doorknob feels cold to the touch, sending a shiver down your spine. " +
            //  "\nYou can't help but feel a sense of unease as you unlock the door and step inside."); Sleep(3500); ClearLastLines(5);

            Console.WriteLine("As you enter Room 616, you notice that the room is dimly lit and has an eerie atmosphere. " +
                "\nThe walls are adorned with old, faded wallpaper, and the furniture is covered in dust. " +
                "\nYou can't shake off the feeling that something is watching you."); Sleep(3500);


        }

        // Clears previous lines
        static void ClearLastLines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Console.CursorTop == 0)
                    return;

                int line = Console.CursorTop - 1;
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, line);
            }
        }

        // Pause the program
        static void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        
        // Call example: fsSound(repeats:3, frequency:900, duration:80, spacing:120);
        static void fsSound(int repeats = 1, int frequency = 800, int duration = 100, int spacing = 100)
        {
            Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < repeats; i++)
                    {
                        Console.Beep(frequency, duration);
                        if (i < repeats - 1)
                            Thread.Sleep(spacing);
                    }
                }
                catch (PlatformNotSupportedException)
                {
                    // in case lng unsupported ang beep
                }
                catch
                {
                    // other exceptions
                }
            });
        }

    }
}