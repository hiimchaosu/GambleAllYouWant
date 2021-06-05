using System;
using System.Threading;

namespace SlotMachine
{
    internal class Program {
        static int AmountOfASCII = 3; // How many pictures will there be
        static string[,] ASCII = new string[Program.AmountOfASCII, 7]; // Matrix like array for this string which will be used to draw ASCII pictures

        public static void Main(string[] args) { // Main point of the program
            Program.Introduction();
        }

        private static void Introduction() { // Introduction after which, User is supposed to click anything on the keyboard
            Program.HeaderStart();
            Console.ReadKey();
            Program.Game();
        }

        private static void Game() {
            while(Program.SlotGame()) { // User is supposed to play until they win the game
                Console.WriteLine("\n\nYOU LOST!\nWould you like to lose (money) again? If so, click any key.");
                Console.ReadKey();
            }Console.ReadKey();
            Program.GameWon(); // If the loop has ended, go to the winning function
        }

        private static bool SlotGame() {
            Program.SetGame();
            Program.HeaderASCII();
            Random RDM = new Random();
            int RollTime = RDM.Next(20); // Random number up to 20
            int RollSpeed = 25; // Variable to make a speed of "rolling"
            int[] PictureArray = new int[3];
            RDM = new Random();
            for (int i = 0; i < RollTime + 1; i++) { // Amount of time that it takes to stop the randomization - random time +1
                for (int j = 0; j < 3; j++) { // Taking a random array of asciis
                    PictureArray[j] = RDM.Next(Program.AmountOfASCII);
                }Program.RowGame(PictureArray[0], PictureArray[1], PictureArray[2]); // Send the order of the pictures
                RollSpeed += 10 * i;
                Thread.Sleep(RollSpeed); // Making a "rolling animation"
            }bool Status = PictureArray[0] == PictureArray[1] && PictureArray[0] == PictureArray[2];
            if (Status) Console.Write("The end of rolling. Click to get your prize!");
            return !Status; // Wait till arrays are rolled, and return opposite status, if those arrays are not true, send false, if they are the same, send false, after which it breaks the while loop
        }

        private static void SetGame() { // Preparing pictures to use to gamble
            Program.ASCII[0, 0] = " O--,---,--O        ";
            Program.ASCII[0, 1] = "    \\ O /          ";
            Program.ASCII[0, 2] = "     - -            ";
            Program.ASCII[0, 3] = "      -             ";
            Program.ASCII[0, 4] = "     / \\           ";
            Program.ASCII[0, 5] = "    =   =           ";
            Program.ASCII[1, 0] = "    \\~~~~~/        ";
            Program.ASCII[1, 1] = "     \\   /         ";
            Program.ASCII[1, 2] = "      \\ /          ";
            Program.ASCII[1, 3] = "       V            ";
            Program.ASCII[1, 4] = "       |            ";
            Program.ASCII[1, 5] = "      ---           ";
            Program.ASCII[2, 0] = "     o O o          ";
            Program.ASCII[2, 1] = "    o \\|/ o        ";
            Program.ASCII[2, 2] = " o o \\ | / o o     ";
            Program.ASCII[2, 3] = "  \\ \\ \\|/ / /    ";
            Program.ASCII[2, 4] = "  (+++\\@/+++)      ";
            Program.ASCII[2, 5] = "  '---------'       ";
        }

        private static void RowGame(int ASCII1, int ASCII2, int ASCII3) {
            for (int i = 0; i < 7; i++) { // Drawing the ASCII pictures in rows
                Console.Write(Program.ASCII[ASCII1, i] + '\t');
                Console.Write(Program.ASCII[ASCII2, i] + '\t');
                Console.Write(Program.ASCII[ASCII3, i] + '\n');
            }
        }

        private static void HeaderStart() { // Simple header for starter point
            Console.Clear();
            Console.SetWindowSize(65, 10); // Having fun with the size of the window
            Console.ForegroundColor = ConsoleColor.Green;
            string Author = "                                            by Patryk Sobczak\n\n\nPress any key to start your gambling adventure!";
            Console.WriteLine("     _       _                        _     _            \n    | |     | |                      | |   (_)           \n ___| | ___ | |_ _ __ ___   __ _  ___| |__  _ _ __   ___ \n/ __| |/ _ \\| __| '_ ` _ \\ / _` |/ __| '_ \\| | '_ \\ / _ \\\n\\__ \\ | (_) | |_| | | | | | (_| | (__| | | | | | | |  __/\n|___/_|\\___/ \\__|_| |_| |_|\\__,_|\\___|_| |_|_|_| |_|\\___|");
            Console.ResetColor();
            Console.WriteLine(Author);
        }

        private static void GameWon() { // When the game is won, this will show up
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.SetWindowSize(85, 30);
            string Congratulations = "Really?! \n\nSure... I wasn't expecting this to happen, but you have to be a lucky one... \nGo buy yourself a lottery ticket, you may win something more than this console game! :D\nAnd no... There were no prizes from the start.";
            Console.WriteLine(Congratulations);
            Console.ReadKey();
        }

        private static void HeaderASCII() {
            Console.Clear();
            Console.SetWindowSize(70, 15);
            Console.ForegroundColor = ConsoleColor.Green;
            string value = "     _       _                        _     _            \n    | |     | |                      | |   (_)           \n ___| | ___ | |_ _ __ ___   __ _  ___| |__  _ _ __   ___ \n/ __| |/ _ \\| __| '_ ` _ \\ / _` |/ __| '_ \\| | '_ \\ / _ \\\n\\__ \\ | (_) | |_| | | | | | (_| | (__| | | | | | | |  __/\n|___/_|\\___/ \\__|_| |_| |_|\\__,_|\\___|_| |_|_|_| |_|\\___|\n";
            Console.WriteLine(value);
        }
    }
}
