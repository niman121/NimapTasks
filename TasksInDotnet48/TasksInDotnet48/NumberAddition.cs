using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksInDotnet48
{
    internal class NumberAddition
    {

        private int FirstNumber = 0;
        private int SecondNumber = 0;

        public NumberAddition()
        {
            Console.WriteLine("Welcome to Number Addition With parameterless constructor");
        }

        public NumberAddition(int n1, int n2) : this()
        {
            FirstNumber = n1;
            SecondNumber = n2;
            Console.WriteLine($"first number : {FirstNumber} second number : {SecondNumber}");
        }

        public int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public int AddNumbers(int number1, int number2, int number3)
        {
            return number1 + number2 + number3;
        }

    }
}
