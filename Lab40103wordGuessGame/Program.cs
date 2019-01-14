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
    }
}
