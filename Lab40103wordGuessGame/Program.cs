using System;
using System.IO;

namespace Lab40103wordGuessGame
{
    class Program
    { /// <summary>
      /// Calls the interface and creates file to interact with words in the game
      /// </summary>
      /// <param name="args"></param>
        static void Main(string[] args)
        {
            string location = "../../../words.txt";
            Console.WriteLine("Hello World!");
            Createfile(location);
            UserInterface(location);
        }
        /// <summary>
        /// Allows the user to interact with the game
        /// </summary>
        /// <param name="location"></param>
        public static void UserInterface(string location)
        {
            //Interface is running
            bool execute = true;
            //Execute this code for game interface
            while(execute)
            {
                Console.WriteLine("Please Choose An Option");
                Console.WriteLine("1 | Add A Word");
                Console.WriteLine("2 | Delete A Word");
                Console.WriteLine("3 | See All Words");
                Console.WriteLine("4 | Play Game");
                Console.WriteLine("5 | Exit");

                try
                {
                    string userSelection = Console.ReadLine();
                    int userChoose = Convert.ToInt32(userSelection);

                    if (userChoose == 1 || userChoose == 2 || userChoose == 3 || userChoose == 4 || userChoose == 5)
                    {
                        switch(userChoose)
                        {
                            //If user chooses 1
                            case 1:
                                Console.WriteLine("Enter The Word You Want To Add");
                                string userAdd = Console.ReadLine().ToLower();
                                AddToFile(location, userAdd);
                                Console.WriteLine("Word Added Successfully");
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter The Word You Want To Delete");
                                string userDelete = Console.ReadLine().ToLower();
                                DeleteFromFile(location, userDelete);
                                break;
                            case 3:
                                ViewAllWords(location);
                                break;
                            case 4:
                                Play(location);
                                break;
                            default:
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Plesae Choose A 1, 2, 3, 4, or 5. Press Enter To Continue");
                        Console.ReadLine();
                        UserInterface(location);
                    }
                 }
                catch
                {
                    Console.WriteLine("Plesae Choose A 1, 2, 3, 4, or 5");
                }       
            }
        }
    public static string CreateFile(string location)
    }
}
