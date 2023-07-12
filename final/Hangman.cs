using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.Threading;

namespace HangmanGame
{
    public class Hangman
    {
        // Attributes
        private string _letterGuessed;
        private Player player;
        private GallowsRenderer gallowsRenderer;
        private WordGenerator randomWord;
        private ScoreBoard simpleScore = new ScoreBoard(new ScoreSimple());
        private ScoreBoard complexScore = new ScoreBoard(new ScoreComplex());

        // Constructors
        public Hangman()
        {
            player = new Player();
            gallowsRenderer = new GallowsRenderer();
            randomWord = new WordGenerator();
        }

        // Methods
        private void DisplayRandomWord()
        {
            Console.WriteLine("\n{0}", player.randomWord);
        }

        public void StartGame(string fileName)
        {
            Console.Clear(); // This will clear the console
            SelectRandomWord(fileName);
            DisplayRandomWord();
            do
            {
                Console.Clear(); // This will clear the console
                ShowTitle();
                ShowGallows();
                //DisplayRandomWord(); // SHOWS THE WORD TO BE GUESSED.
                ShowLettersGuessesRight();
                //Console.WriteLine($"The word has {player.randomWord.Length} letters.\n"); // SHOWS HOW MANY LETTERS THE GUESS WORD HAS.
                ShowLettersGuessedWrong();
                ShowNumberOfGuesses();
                PromptPlayerForLetter();
                CheckPlayerGuess();
            } while (!player.GameOver());

            GameOver();
            PlayAgain();
        }

        public void ShowRandomWord()
        {
            StringBuilder sb = new StringBuilder();
            bool correctLetter = false;

            for (int i = 0; i < player.randomWord.Length; i++)
            {
                correctLetter = false;
                foreach (string l in player.lettersGuessed)
                {
                    if (player.randomWord[i].ToString().Equals(l))
                    {
                        correctLetter = true;
                    }
                }
                if (!correctLetter)
                {
                    sb.Append("_ ");
                }
                else
                {
                    sb.Append(player.randomWord[i].ToString()).Append(" ");
                }
            }
            player.showRandomWord = sb.ToString();
        }

        private void SelectRandomWord(string fileName)
        {
            player.randomWord = randomWord.GetRandomWord(fileName);
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private void PromptPlayerForLetter()
        {
            Console.Write("Guess a letter >>  ");

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    continue;
                }

                string input = keyInfo.KeyChar.ToString().ToLower();

                if (input.Length > 0 && (char.IsLetterOrDigit(input[0])))
                {
                    _letterGuessed = input.Substring(0, 1);

                    if (!player.CheckIfGuessed(player, _letterGuessed))
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You already guessed that letter. Please try again.");
                        Console.ResetColor();

                        // Wait for 1.5 seconds
                        Thread.Sleep(1500);

                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write("Guess a letter >>  ");
                    }
                }
            }
            while (true);

            player.lettersGuessed.Add(_letterGuessed);
        }

        private void CheckPlayerGuess()
        {
            player.CheckLatestGuess(_letterGuessed);
            ShowRandomWord();
        }

        private void PlayAgain()
        {
            Console.Write($"\nPress <ENTER> to continue.");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                ClearCurrentConsoleLine();
                Console.Write($"Press <ENTER> to continue.");
            }

            Console.Clear(); // This will clear the console
        }

        private void ShowNumberOfGuesses()
        {
            Console.WriteLine($"\nGuesses Left = {player.wrongGuessCount}/7\n");
        }

        private void ShowGallows()
        {
            gallowsRenderer.ShowGallows(player.wrongGuessCount);
        }

        private void ShowLettersGuessesRight()
        {
            Console.WriteLine($"\n{player.showRandomWord}\n");
        }

        private void ShowLettersGuessedWrong()
        {
            Console.WriteLine($"\n{player.wrongGuesses}\n");
        }

        private void ShowTitle()
        {
            Console.WriteLine($">>> Lets Play Hangman <<<\n");
        }

        private void ShowPlayerScore()
        {
            if (!player.PlayerLost())
            {
                simpleScore.DisplayScore(player.correctGuessCount, player.rightGuessList, player.randomWord);
                complexScore.DisplayScore(player.correctGuessCount, player.rightGuessList, player.randomWord);
            }
            else
            {
                simpleScore.DisplayScore(0, player.emptyList, player.randomWord);
                complexScore.DisplayScore(0, player.emptyList, player.randomWord);
            }
        }

        private void GameOver()
        {
            Console.Clear(); // This will clear the console
            if (player.GameOver() && player.PlayerWon())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">>> Congratulations You Won! <<<");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">>> Sorry, you lost! <<<");
                Console.ResetColor();
            }
            ShowGallows();
            ShowNumberOfGuesses();
            Console.WriteLine($"\nThe word was - {player.randomWord}\n");
            ShowPlayerScore();
        }
    }
}