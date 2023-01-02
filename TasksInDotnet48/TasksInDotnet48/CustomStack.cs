using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksInDotnet48
{
    public class CustomStack
    {
       
        private List<object> _stack = new List<object>();

        public void Push(object item)
        {
            if (item == null) new InvalidOperationException("there is no item to push");
            _stack.Add(item);            
        }

        public object Pop()
        {
            if (_stack.Count == 0) return new InvalidOperationException("there is no item to pop");
            var Item = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);            
            return Item;
        }

        public object Peek()
        {
           return _stack[_stack.Count-1];
        }

        public bool Contains(object item)
        {
            if (item == null) return false;

            foreach(var value in _stack)
            {
                if(value.Equals(item)) return true;
            }
            return false;
        }

        public void GetAllStacks()
        {
            if (_stack.Count == 0)
            {
                Console.WriteLine("No items in stack");
            }
            else
            {
                foreach (var item in _stack) Console.WriteLine(item.ToString());
            }
            
        }

        public int Count()
        {
            return _stack.Count;
        }


        public void Clear()
        {
            for (int i = _stack.Count - 1; i >= 0; i--)
            {
                _stack.RemoveAt(i);
            }

        }
    }
}
