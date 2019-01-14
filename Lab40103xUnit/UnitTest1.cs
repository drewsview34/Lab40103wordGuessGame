using System;
using Xunit;
using System.IO;
using Lab40103wordGuessGame;

namespace Lab40103xUnit
{
    public class UnitTest1
    {
        [Fact]
        public void CanViewAllWordsWorks()
        {
            //arrange
            string location = "../../../words.txt";

            //act
            string index = Program.ViewWords(location);

            //assert
            Assert.Equal("andrew", index);

        }

        [Fact]
        public void AddWordWorks()
        {
            //arrange
            string location = "../../../words.txt";
            string userAdd = "CAT";
            //act
            string index = Program.AddToLocation(location, userAdd);

            //assert
            Assert.Contains("CAT", userAdd);

        }

        [Fact]
        public void DeleteWordWorks()
        {
            //arrange
            string location = "../../../words.txt";
            string[] wordsInLocation = File.ReadAllLines(location);
            string userDelete = "BAG";

            //act
            Program.DeleteFromLocation(location, userDelete);

            //assert
            Assert.DoesNotContain("BAG", wordsInLocation);

        }

        [Fact]
        public void CheckLetterWorks()
        {
            //arrange
            string path = "../../../hangman.txt";
            string word = "BUT";

            //act
            Program.GuessGame(path);

            //assert
            Assert.Contains("U", word);

        }
    }
}