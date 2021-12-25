using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class GameMoves
    {
        public List<string> Movies 
        { 
            get; 
            private set; 
        }
        int count;
        
        public GameMoves(int count) 
        {
            this.count = count;
            Movies = GetMoves();            
        }
        static List<string> baseList = new List<string>() { "rock", "paper", "scissors" };
        private List<string> GetMoves()
        {            
            if ((count - 3) > 0)            
            {
                string s1;string s2;
                for (int i = 1; i <= (count - 3) / 2; i++)
                {
                    s1 = (i == 1) ? "lizard" : (i == 2) ? "plant" : "A" + i;//after paper
                    s2= (i == 1) ? "Spock" : (i == 2) ? "well" : "B" + i;//after rock
                    baseList.Insert(i+1, s1);
                    baseList.Insert(1, s2);
                }
            }
            return baseList;
        }        
        public byte[] GetMove(out int computerMove)
        {
            Random rnd = new Random();
            computerMove = rnd.Next(1, count);
            string move = Movies[computerMove-1].ToString();
            return StringEncode(move);
        }
        public static byte[] StringEncode(string text)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetBytes(text);
        }
    }
}
