using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static int countMove;
        public static List<string> movies = new List<string>();
        static void Main(string[] args)
        {
            countMove = args.Length;
            string strConfirm = String.Empty;
            if ((countMove < 3) || (countMove % 2 == 0))
                strConfirm = "The number of moves must be odd and greater than or equal to 3";
            else
            {
                for (int i = 0; i < countMove; i++)
                {
                    string s = args[i];
                    for (int j = i + 1; j < countMove; j++)
                    {
                        if (args[j].Equals(s))
                            strConfirm = "The moves must not be repeated!";
                    }
                }
            }
            if (strConfirm != String.Empty)
            {
                Console.WriteLine(strConfirm);
                return;
            }
            GameMoves game = new GameMoves(countMove);
            movies = game.Movies;
            byte[] secureKey = SecureRandom.GetSecureRandom();
            int compMove;
            byte[] computerMove = game.GetMove(out compMove);
            byte[] hMAC = GameHMAC.HashHMAC(secureKey, computerMove);
            Console.WriteLine("HMAC: {0}", string.Join(null, hMAC.Select(b => string.Format("{0:X2}", b))));
            while (true)
            {
                GenerateMenu(countMove);
                int move = 0;
                Console.Write("Enter your move: ");
                string answ = Console.ReadLine();
                bool f = int.TryParse(answ, out move);
                if (!f && answ != "?")
                    continue;
                if (answ == "?")
                {
                    GameTable.GetHelp(movies);
                    continue;
                }                    
                else if (move >= 1 && move <= countMove)
                {
                    Console.WriteLine("Your move: {0}", movies[move - 1]);
                    Console.WriteLine("Computer move: {0}", movies[compMove - 1]);
                    bool result;
                    List<string> resultList = new List<string>();
                    resultList = GameRules.GetResult(compMove, countMove, out result);
                    bool isEq = false;
                    foreach (string s in resultList)
                    {
                        if (s.Equals(answ))
                        {
                            isEq = true;
                            break;
                        }
                    }
                    if (result)
                    {
                        if (isEq)
                            Console.WriteLine("Sorry, you are lose!\n");
                        else if (compMove.ToString() == answ)
                            Console.WriteLine("Draw!");
                        else
                            Console.WriteLine("You are win!");
                    }
                    else 
                    {
                        if (isEq)
                            Console.WriteLine("You are win!");
                        else
                        if (compMove.ToString() == answ)
                            Console.WriteLine("Draw!");
                        else
                            Console.WriteLine("Sorry, you are lose!\n");
                    }
                    Console.WriteLine("HMAC Key: {0}", string.Join(null, secureKey.Select(b => string.Format("{0:X2}", b))));
                    break;
                }                    
                else if (move == 0)
                    break;
            }
        }             
        private static void GenerateMenu(int count)
        {
            for(int i = 1; i <= count; i++)
            {
                Console.WriteLine("{0} - {1}",i,movies[i-1]);
            }
            Console.WriteLine("0 - exit\n? - help");            
        }
    }
}
