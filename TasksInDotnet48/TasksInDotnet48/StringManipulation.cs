using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TasksInDotnet48
{
    public class StringManipulation
    {
        public bool ConsecutiveNumberChecker(int[] Number)
        {
            int Counter = 1;
            bool Decreasing = false;
            bool Increasing = false;
            for(int i = 0; i< Number.Length - 1; i++)
            {
                if (Number[i] - Number[i + 1] == 1)
                {
                    Decreasing = true;
                    if(!(Increasing && Decreasing)) Counter++;
                }
                else if (Number[i] - Number[i + 1] == -1)
                {
                    Increasing = true;
                    if(!(Increasing && Decreasing)) Counter++;
                }

            }

            if (Counter == Number.Length) return true;
            return false;
        }

        public bool DuplicateNumberChecker(int[] Numbers)
        {
            for(int i = 0; i< Numbers.Length -1; i++)
            {
                if (Numbers[i] == Numbers[i +1]) return true;
            }
            return false;
        }
        

        public string ReturnSummary(string Paragraph, int maxLength)
        {
            var Words = Paragraph.Split(' ');
            int totalCharacters = 0;
            string Summary = "";
            foreach(string word in Words)
            {
                totalCharacters += word.Length+1;
                if (totalCharacters < maxLength)
                {
                    Summary += word+" ";
                }
                else break;
            }


            return  String.Join(" ", Summary) + "...";
        }
    }
}
