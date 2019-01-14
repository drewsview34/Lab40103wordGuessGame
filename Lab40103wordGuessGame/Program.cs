using System;
using System.IO;
using System.Linq;

namespace Lab40103wordGuessGame
{
    public class Program
    { /// <summary>
      /// Calls the interface and creates file to interact with words in the game
      /// </summary>
      /// <param name="args"></param>
        static void Main(string[] args)
        {
            string location = "../../../words.txt";
            Console.WriteLine("Hello World!");
            CreateLocation(location);
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
                                AddToLocation(location, userAdd);
                                Console.WriteLine("Word Added Successfully");
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter The Word You Want To Delete");
                                string userDelete = Console.ReadLine().ToLower();
                                DeleteFromLocation(location, userDelete);
                                break;
                            case 3:
                                ViewWords(location);
                                break;
                            case 4:
                                GuessGame(location);
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
        /// <summary>
        /// Creates A Text File For Words To Be Saved
        /// </summary>
        /// <param name="location"></param>
        /// <returns>string</returns>
        public static string CreateLocation(string location)
        {
            try
            {
                if(File.Exists(location))
                {
                    return "Words Exist";
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(location))
                    {
                        streamWriter.WriteLine("andrew");
                    }
                    return " ";
                }
            }
            catch(Exception except)
            {
                throw except;
            }
        }
        /// <summary>
        /// Adds A Word To The Text File Entered By User
        /// </summary>
        /// <param name="location"></param>
        /// <param name="userChoose">The Word Added By The User</param>
        public static string AddToLocation(string location, string userAdd)
        {
            try
            {
                using(StreamWriter streamWriter = File.AppendText(location))
                {
                    streamWriter.WriteLine(userAdd);
                }
            }
            catch(Exception except)
            {
                throw except;
            }
            return userAdd;
        }

        /// <summary>
        /// Adds A Word To The Text File Entered By User
        /// </summary>
        /// <param name="location"></param>
        /// <param name="userChoose">The Word Added By The User</param>
        public static string DeleteFromLocation(string location, string userDelete)
        {
            try
            {
                if (userDelete.Length > 0)
                {
                    string[] wordsInFile = File.ReadAllLines(location);

                    foreach(string words in wordsInFile)
                    {
                        //Checks If The Word Deleted Equals Word In Location
                        if(string.Equals(words, userDelete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //The Location Will Delete The Word And Update Location
                            string[] newLocationList = new string[wordsInFile.Length -1];
                            int count = 0;

                            for(int index = 0; index < newLocationList.Length; index++)
                            {
                                if(userDelete == wordsInFile[count])
                                {
                                    index--;
                                    count++;
                                }
                                else
                                {
                                    newLocationList[index] = wordsInFile[count];
                                    count++;
                                }
                            }
                        //This Sends The Updated Words To The Location
                        using (StreamWriter streamWriter = new StreamWriter(location))
                        {
                            for(int index = 0; index < newLocationList.Length; index++)
                            {
                                   streamWriter.WriteLine(newLocationList[index]);
                            }
                        }
                            Console.WriteLine($"({userDelete} Word Deleted");
                            Console.ReadLine();
                        }
                    }
                    Console.WriteLine($"{userDelete} Does Not Exist");
                }
                else
                {
                    throw new Exception("Enter The Word You Want To Delete");
                }
            }
            catch(Exception except)
            {
                Console.WriteLine(except.Message);
            }
            finally
            {
                Console.WriteLine("Try Again");
            }
            return userDelete;
        }
        /// <summary>
        /// User Can View All Words
        /// </summary>
        /// <param name="location"></param>
        public static string ViewWords(string location)
        {
            //Renders Words From Location To Console
            string[] lines = File.ReadAllLines(location);

            try
            {
                for(int index = 0; index < lines.Length; index++)
                {
                    Console.WriteLine(lines[index]);
                }
            }
            catch (Exception except)
            {
                throw except;
            }
            Console.WriteLine(lines[0]);
            int indexer = 0;
            return lines[indexer];
        }
        /// <summary>
        /// Chooses A Random Word From Location
        /// </summary>
        /// <param name="location"></param>
        public static string RandomWord(string location)
        {
            try
            {
                //Renders Random Word
                string[] lines = File.ReadAllLines(location);
                Random line = new Random();
                int indexPos = line.Next(lines.Length);
                return lines[indexPos];
            }
            catch (Exception except)
            {
                throw except;
            }
        }
        /// <summary>
        /// How the Game Is Played
        /// </summary>
        /// <param name="location"></param>
        public static void GuessGame(string location)
        {
            try
            {
                //Getting A Random Word & Creating Variables To Use
                string word = RandomWord(location);
                string userGuess = " ";
                string[] renderWord = new string[word.Length];

                for(int index = 0; index < word.Length; index++)
                {
                    renderWord[index] = " _ ";
                }
                foreach (string l in renderWord)
                {
                    Console.Write(l);
                }
                Console.WriteLine();

                bool userWins = false;

                while (!userWins)
                {
                    //Logic To Determine If Guess Is Correct
                    Console.WriteLine("Guess A Letter");
                    string letter = Console.ReadLine();

                    if (letter != null && (word.ToLower().Contains(letter.ToLower()) && !userGuess.Contains(letter)))
                    {
                        for (int index = 0; index < word.Length; index++)
                        {
                            if (word[index].ToString().ToLower() == letter)
                            {
                                renderWord[index] = letter;
                                userGuess += letter;
                            }
                            else
                            {
                                Console.Write(renderWord[index]);
                            }
                        }
                        Console.WriteLine($"Your Guess: {userGuess}");

                        if(!renderWord.Contains(" _ "))
                        {
                            Console.WriteLine("Winner");
                            userWins = true;
                        }
                    }
                }
            }
            catch (Exception except)
            {
                throw except;
            }           
        }
    }    
}   