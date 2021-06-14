using System;
using System.Collections.Generic;
namespace SnakesAndLaddersGame
{ 
    class Program
    {
        private static Dictionary<int, int> LadderUpWards = new Dictionary<int, int>() {
            {2, 23},
            {8, 12},
            {17, 93},
            {39, 80},
            {62, 78},
            {70, 89},
            {75, 96} 
        };

        private static Dictionary<int, int> SnakeDownWards = new Dictionary<int, int>() {
            {41, 20},
            {31, 14},
            {59, 37},
            {83, 80},
            {92, 76},
            {99, 5},
            {67, 50},
        };
        private static Random Dice = new Random(); 
        static int rollingDice(int player, int currentSquare)
        { 
            int square= currentSquare;
            while (true)
            {
                int DiceNumber = Dice.Next(1, 6); 
                Console.Write("Player {0}, on square {0}, DiceNumbers a {0}", player, square, DiceNumber);
                if (square + DiceNumber > 100)
                {
                    Console.WriteLine("square can not be more than 100 ..");
                }
                else
                {
                    square = square+ DiceNumber;
                    Console.WriteLine("Moves to square {0}", square);

                    if (square == 100)
                        return 100;
 
                    if (LadderUpWards.ContainsKey(square))
                    { 
                        Console.WriteLine("LadderUpWards. Climb up to {0}.",  LadderUpWards[square]- square);
                        square = LadderUpWards[square];
                    }
                    else if (SnakeDownWards.ContainsKey(square))
                    { 
                        Console.WriteLine("SnakeDownWards. Down to {0}.", square- SnakeDownWards[square]);
                        square = SnakeDownWards[square]; 
                    } 
                }
                if (DiceNumber < 6 )
                {
                    return square;
                }
                Console.WriteLine("DiceNumbere is a 6 so rolling dice again.");
            }
        }
        static void Main(string[] args)
        {
            // four players is starting on square one
            int[] players = { 1, 1, 1,1 };
            while (true)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    int ns = rollingDice(i+1 , players[i]);
                    if (ns == 100)
                    {
                        players[i] = ns;
                        Console.WriteLine("Player {0} wins!", i + 1);
                        Console.ReadLine();
                        return;
                    }
                    players[i] = ns; 
                }
            } 
           
        }
    }
}