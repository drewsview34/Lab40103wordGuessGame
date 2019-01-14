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
            Assert.NotEqual("andrew", index);
        }
        [Fact]
        public void AddWordWorks()
        {
            //arrange
            string location = "../../../words.txt";
            string userAdd = "andrew";
            //act
            string index = Program.AddToLocation(location, userAdd);
            //assert
            Assert.Contains("andrew", userAdd);
        }
        [Fact]
        public void DeleteWordWorks()
        {
            //arrange
            string location = "../../../words.txt";
            string[] wordsInFile = File.ReadAllLines(location);
            string userDelete = "drew";
            //act
            Program.DeleteFromLocation(location, userDelete);
            //assert
            Assert.DoesNotContain("drew", wordsInFile);
        }
        //[Fact]
        //public void CheckLetterWorks()
        //{
        //    //arrange
        //    string location = "../../../words.txt";
        //    string word = "andrew";

        //    //act
        //    Program.GuessGame(location);

        //    //assert
        //    Assert.Equal("andrew", word);
    }
}