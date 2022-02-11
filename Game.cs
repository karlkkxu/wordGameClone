using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGames
{
    class Game
    {
        private string chosenWord;
        private string filePath = "C:\\Bak\\test.txt";
        internal bool isCompleted = false;
        private int tries = 0;
        private List<string> alreadyGuessed = new List<string>();
        public Game()
        {
            Console.WriteLine("Initializing Game");

            ChooseNewWord(filePath);
            Console.WriteLine("The chosen word is: " + chosenWord);
        }

        private void ChooseNewWord(string file)
        {
            string[] allWords = File.ReadLines(file).ToArray();
            Random rng = new Random();
            int index = rng.Next(allWords.Length);
            chosenWord = allWords[index].ToLower().Trim();
        }

        internal bool Guess()
        {
            string guessedWord = Console.ReadLine().ToLower();
            Console.Clear();

            //Discard illegal guesses
            if (guessedWord.Length != chosenWord.Length)
            {
                Console.WriteLine("Invalid guess");
                return false;
            }

            //Increment guess counter and do all other actions in common for all valid guesses
            tries++;
            alreadyGuessed.Add(guessedWord);
            PrintInfo();
            if (guessedWord == chosenWord)
            {
                isCompleted = true;
                Console.WriteLine("Correct!");
                return isCompleted;
            }

            //Final return, if guess was valid but not correct
            return isCompleted;
        }

        private void PrintInfo()
        {
            foreach (string word in alreadyGuessed)
            {
                //Write the word itself
                Console.WriteLine(word);

                StringBuilder sb = new StringBuilder();
                //This loop operates on the assumption that the correct answer has as many letters as the guessed word (should be checked before added to already guessed list)
                for (int i = 0; i < word.Length; i++)
                {
                    //If the letter in the chosen word also appears in the same location in the correct word
                    if (word[i] == chosenWord[i])
                    {
                        sb.Append('2');
                        continue;
                    }
                    //If the prior case didn't occur, but the letter does appear in the correct word
                    if (chosenWord.IndexOf(word[i]) != -1)
                    {
                        sb.Append('1');
                        continue;
                    }
                    //If the letter does not appear in the word
                    sb.Append('0');
                }
                Console.WriteLine(sb);
            }
        }
    }
}
