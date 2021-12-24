using System.Collections.Generic;

namespace Task4
{
    class GameRules
    {
        public static List<string> GetResult(int move,int count, out bool isWinComp)
        {
            isWinComp = false;
            List<string> resultList = new List<string>();
            int center = (count - 1) / 2;
            if ((count - 1 - move)< center)//2 half
            {
                for (int i = (move - 1); i >= (move - center); i--)
                {
                    if (i == 0)
                        resultList.Add(count.ToString());
                    else
                        resultList.Add(i.ToString());                    
                }
                isWinComp = true;
            }
            else//1 half
            {
                for (int i = (move + 1); i <= (move + center); i++)
                    resultList.Add(i.ToString());
            }
            return resultList;
        }
    }
}
