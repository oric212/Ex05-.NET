
using System;
using System.Collections.Generic;

namespace Ex02
{
    public class Board
    {
        public void PrintHeadAndSecret(string i_Secert)
        {
            string spacedGuess = string.Join(" ", i_Secert.ToCharArray());
            System.Console.Write($@"
| Pins:    |Result:     |
|==========|============|
| {spacedGuess, -9}|            |
|==========|============|");
        }
        public void PrintHead()
        {
            System.Console.Write(@"
| Pins:    |Result:     |
|==========|============|
| # # # #  |            |
|==========|============|");
        }

        public void PrintGuessAndResultLine(string i_Guess, string i_Result)
        {
            string spacedGuess = string.Join(" ", i_Guess.ToCharArray());
            string spacedResult = string.Join(" ", i_Result.ToCharArray());
            System.Console.Write($@"
| {spacedGuess,-9}| {spacedResult,-11}| 
|==========|============|");;
        }

        public void PrintEmptyLine()
        {
            // $G$ CSS-999 (-1) Redundant namespace prefix of System.
            System.Console.Write(@"
|          |            |
|==========|============|");
        }

        internal void RenderBoard(List<Guess> i_GuessesList, Secret i_SecretItem, string i_Message, bool i_GameEnded)
        {
            // $G$ NTT-999 (-3) You should use a 'using' statement for Ex02.ConsoleUtils to avoid fully qualifying Screen.Clear().
            ConsoleUtils.Screen.Clear();
            if (i_GameEnded)
            {
                PrintHeadAndSecret(i_SecretItem.SecretValue);
            }
            else
            {
                PrintHead();
            }
            foreach(Guess t in i_GuessesList)
            {
                PrintGuessAndResultLine(t.GuessValue, t.Result);
            }

            int emptyLines = Settings.m_MaxNumOfGuesses - i_GuessesList.Count;
            for (int i = 0; i < emptyLines; i++)
            {
                PrintEmptyLine();
            }

            Console.WriteLine();
            Console.WriteLine(i_Message);
        }
    }
}