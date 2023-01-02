using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksInDotnet48
{
    public abstract class Shape
    {
        private int Length { get; set; }
        private int Breadth { get; set; }
        protected Shape(int Length, int Breadth)
        {
            this.Length = Length;
            this.Breadth = Breadth;
        }

        public virtual int Area(int Length, int breadth)
        {
            return Length+breadth;
        } 
    }


    public class Square : Shape
    {
        public Square(int Length, int Breadth) : base(Length, Breadth)
        {
        }

        public override int Area(int Length, int breadth)
        {
            return Length*breadth;
        }
    }
}
