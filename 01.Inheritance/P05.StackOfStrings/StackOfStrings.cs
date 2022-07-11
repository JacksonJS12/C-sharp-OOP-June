using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            Stack<string> stack = new Stack<string>();
            if (stack.Count == 0)
            {
                return true;
            }
            return false;
        }
        public Stack<string> AddRange()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(string.Empty);
            return stack;
        }
    }
}
