using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
    class Program
    {
        static void Main(string[] args)
        {
            string stCorrect = "([тут скобки правильно]{})[]";
            string stIncorrect = "(]{})[тут скобки не правильно]";

            Console.WriteLine("Строка \"{0}\" содержит {1} расставленые скобки", stCorrect, GetCorrectBrakets(stCorrect) ? "коректно" : "некоректно");
            Console.WriteLine("Строка \"{0}\" содержит {1} расставленые скобки", stIncorrect, GetCorrectBrakets(stIncorrect) ? "коректно" : "некоректно");

            Console.ReadKey();
        }

        public static bool GetCorrectBrakets(string st)
        {
            bool isCorrect = true;
            Stack<char> bracketStack = new Stack<char>();
            foreach (char literal in st)
            {
                if (new char[] { '{', '[', '(' }.Contains(literal))
                {
                    bracketStack.Push(literal);
                }

                if (new char[] { '}', ']', ')' }.Contains(literal)&& bracketStack.Count>0)
                {

                    if (bracketStack.Peek()=='{' && literal.Equals('}') ||
                        bracketStack.Peek()=='[' && literal.Equals(']') ||
                        bracketStack.Peek()=='(' && literal.Equals(')')
                        )
                    {
                        bracketStack.Pop();
                    }
                    else
                    {
                        isCorrect = false;
                    }
                }
            }

            if(bracketStack.Count>0)
            {
                isCorrect = false;
            }

            return isCorrect;
        }
    }
}
