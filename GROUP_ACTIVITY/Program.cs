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

            Sleep(2000); ClearLastLines(2);
            Console.WriteLine("\nPlease enter your name: ");
            pName = Console.ReadLine(); ClearLastLines(2);
            Sleep(1500);
            Console.WriteLine(pName + ", unfortunately there's only 1 room unoccupied today. Here's the key for Room 616.");
            Sleep(1500); 
            ClearLastLines(1);

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

                Console.WriteLine("\nInvalid choice. Please enter 'Yes' or 'No'.\n"); 
                Sleep(2000); 
                ClearLastLines(5);
                // input validation
            }
            ClearLastLines(3);
            Sleep(1500); // small pause before heading to the room
            Console.WriteLine("\nYou take the key and head towards Room 616.");
            fsSound(repeats: 3, frequency: 900, duration: 80, spacing: 120);
            Sleep(1200);

            // Story beats previously in comments are rendered here
            Console.WriteLine("As you approach the door, you notice that it is old and creaky.");
            Sleep(1000);
            Console.WriteLine("The doorknob feels cold to the touch, sending a shiver down your spine.");
            fsSound(repeats: 5, frequency: 700, duration: 100, spacing: 140);
            Sleep(1000);
            Console.WriteLine("You can't help but feel a sense of unease as you unlock the door and step inside.");
            Sleep(800);

            Console.WriteLine("As you enter Room 616, you notice that the room is dimly lit and has an eerie atmosphere. ");
            Sleep(750);
            Console.WriteLine("The walls are adorned with old, faded wallpaper, and the furniture is covered in dust. ");
            Sleep(750);
            Console.WriteLine("You can't shake off the feeling that something is watching you."); 
            Sleep(750);
            ClearLastLines(8);

            // Scene state
            bool foundNote = false;
            bool foundFloorboard = false;
            bool pulledLever = false;
            bool escaped = false;

            Console.WriteLine();
            Sleep(800);

            while (!escaped)
            {
                // remember where the menu starts so we can clear all menu and action lines after handling
                int menuStart = Console.CursorTop;

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1) Inspect the bed");
                Console.WriteLine("2) Inspect the dresser");
                Console.WriteLine("3) Inspect the wardrobe");
                Console.WriteLine("4) Inspect the door / use key");
                Console.WriteLine("5) Listen closely");
                Console.WriteLine("Enter the number of your choice:");

                string action = Console.ReadLine()?.Trim();

                switch (action)
                {
                    case "1": // bed
                        Console.WriteLine("\nYou lift the thin, dusty sheets. The mattress sighs. ");
                        Sleep(1000);
                        if (!foundNote)
                        {
                            Console.WriteLine("You find a small folded note tucked under the pillow. It reads: 'third board by the dresser' ");
                            fsSound(repeats: 1, frequency: 900, duration: 80);
                            foundNote = true;
                        }
                        else
                        {
                            Console.WriteLine("There's nothing else of interest on the bed.");
                        }
                        break;

                    case "2": // dresser
                        Console.WriteLine("\nYou kneel by the old dresser. Its drawers stick, but one opens to reveal dust and a child's toy.");
                        Sleep(1000);
                        if (foundNote && !foundFloorboard)
                        {
                            Console.WriteLine("As you move the toy, the third floorboard near the dresser feels loose under your hand.");
                            fsSound(repeats: 5, frequency: 750, duration: 120, spacing: 120);
                            foundFloorboard = true;
                        }
                        else if (!foundNote)
                        {
                            Console.WriteLine("You don't notice anything unusual yet. Maybe there's a clue somewhere else.");
                        }
                        else
                        {
                            Console.WriteLine("You've already found the loose floorboard here.");
                        }
                        break;

                    case "3": // wardrobe
                        Console.WriteLine("\nYou open the wardrobe. A gust of cold air brushes past your face.");
                        Sleep(1000);
                        Console.WriteLine("Something briefly moves in the shadow... a silhouette that vanishes when you blink.");
                        // eerie double beep
                        fsSound(repeats: 7, frequency: 600, duration: 120, spacing: 160);
                        break;

                    case "4": // door / use key
                        Console.WriteLine("\nYou approach the door. The key you were given fits the lock, but the bolt is jammed from the inside.");
                        Sleep(1000);
                        if (foundFloorboard && !pulledLever)
                        {
                            Console.WriteLine("You pry up the loose floorboard and find a rusted lever. You pull it.");
                            fsSound(repeats: 5, frequency: 900, duration: 60, spacing: 80);
                            Sleep(900);
                            Console.WriteLine("A grinding sound echoes through the room as the bolt slides away. The door is unlocked.");
                            pulledLever = true;
                        }
                        else if (pulledLever)
                        {
                            Console.WriteLine("The door is unlocked. You can open it now.");
                        }
                        else
                        {
                            Console.WriteLine("You try the key. The lock resists — something inside keeps the bolt stuck.");
                            fsSound(repeats: 1, frequency: 1500, duration: 150);
                        }

                        if (pulledLever)
                        {
                            Console.WriteLine("Do you want to open the door and leave? (Yes/No)");
                            string leave = Console.ReadLine()?.Trim().ToLower();
                            if (leave == "yes" || leave == "y")
                            {
                                Console.WriteLine("You open the door and step out into the dimly lit corridor. Fresh air fills your lungs.");
                                fsSound(repeats: 2, frequency: 1000, duration: 120, spacing: 150);
                                Sleep(800);
                                Console.WriteLine("You made it out of Room 616. Escape successful.");
                                escaped = true;
                            }
                            else
                            {
                                Console.WriteLine("You hesitate and step back into the room.");
                            }
                        }
                        break;

                    case "5": // listen
                        Console.WriteLine("\nYou stop and listen. At first, nothing — then a faint, rhythmic tapping, like footsteps far away.");
                        fsSound(repeats: 7, frequency: 700, duration: 130, spacing: 200);
                        Sleep(1200);
                        Console.WriteLine("A whisper brushes your ear: 'don't trust the wallpaper' — or was it just the wind?");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Try using the number for your action.");
                        break;
                }

                // pause for a little before removing lines
                Sleep(5000);
                // clear everything printed for current iteration
                int linesPrinted = Console.CursorTop - menuStart;
                if (linesPrinted > 0)
                    ClearLastLines(linesPrinted + 1); // +1 remove the blank line before menu
            }

            // final pause and exit
            Sleep(1000);
            Console.WriteLine("\nThank you for playing. (End of demo)");
            Sleep(1500);
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
        
        // Foot steps sound
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
