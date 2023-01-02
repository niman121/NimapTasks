using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksInDotnet48
{
    public class DataTypeDecider
    {
        public void CheckDataType()
        {
            while(true)
            {
                Console.WriteLine("write anything to get its data type");
                var Data = Console.ReadLine();
                Console.WriteLine();
                
                if(String.IsNullOrEmpty(Data) )//checking for empty data
                {
                    Console.WriteLine("empty data");
                    continue;
                }             

                int intValue;
                if(int.TryParse(Data, out intValue)) Console.WriteLine($"{intValue} is an integer type(primitive type)");
                else Console.WriteLine($"{Data} is String type(non-primitive type)");

                Console.WriteLine();
                Console.WriteLine("Check Another yes or no");
                string Decision = Console.ReadLine().ToLower();
                if (Decision == "no") break;      
            }
        }
    }
}
