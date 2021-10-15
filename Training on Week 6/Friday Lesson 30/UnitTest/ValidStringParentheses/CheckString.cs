using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidStringParentheses
{
    public class CheckString
    {
        //Depedency injection, passing depedency in constructor and using that whenever its required.
        private ITakeInput _takeInput;
        public CheckString(ITakeInput takeInput)  // constructor dependency injection      // can take from interface ITakeInput or TakeInput , concrete class
        {
            _takeInput = takeInput;
        }

        public bool checkValidString()       // unit test to test this method
        {
            string str = _takeInput.TakeInputMethod();             // new Itakeinput and call the method , Mocking = dont care what is inside the method, but just testing checkValidString
            Stack<char> stk = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                {
                    stk.Push(str[i]);
                }
                else
                {
                    if (stk.Count == 0)
                    {
                        return false;
                    }
                    var temp = stk.Pop();
                    if (str[i] == ')' && temp == '(') // match
                    {
                        continue;
                    }
                    if (str[i] == '}' && temp == '{')
                    {
                        continue;
                    }
                    if (str[i] == ']' && temp == '[')
                    {
                        continue;
                    }
                    else
                    {

                        return false;
                    }
                }
            }

            if(stk.Count != 0)
            {
                return false;
            }
            return true;

        }
    }
}
