using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class GameTable
    {
        public static void GetHelp(List<string> moves)
        {
            Console.WriteLine(new String('-', 8 * (moves.Count + 1) + moves.Count + 2));
            GenerateRow(moves);
            string[,] matr = GenerateTable(moves.Count);
            Console.WriteLine(new String('-', 8 * (moves.Count + 1) + moves.Count + 2));

            for (int i = 0; i < moves.Count; i++)
            {
                Console.Write("|" + moves[i].PadLeft(8)+"|");
                for (int j = 0; j < moves.Count; j++)
                {
                    Console.Write(matr[i, j].PadLeft(8)+"|");
                }
                Console.Write("\n");
                Console.WriteLine(new String('-', 8 * (moves.Count + 1) + moves.Count + 2));
            }
        }
        private static void GenerateRow(List<string> moves)
        {
            Console.Write("|"+"".PadLeft(8));
            for(int i = 0; i < moves.Count; i++)
            {
                Console.Write("|"+ moves[i].PadLeft(8));
            }
            Console.Write("|\n");
        }
        private static string[,] GenerateTable(int count)
        {
            int half = (count - 1) / 2;
            int draw = 1;
            string[,] help = new string[count,count] ;
            for(int i = 0; i < count; i++)
            {
                for(int j = 0; j < count; j++)
                {
                    if (i == j)
                    {
                        help[i, j] = "Draw";
                        draw = j+1;
                    }
                    else if (j >= draw && j < half+draw)
                        help[i, j] = "Lose";
                    else
                        help[i, j] = "Win";
                    draw = (i > half) && (i - j > half+1) ? (draw + 1) : (i > half && (i - j) <= (half+1) && (i - j > 0)) ? (count) : draw;
                }
                draw = (i>=half)?0:i+1;
            }
            return help;
        }
    }
}
