using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Infix_to_Postfix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in an expression: ");
            String xp = "A*B–(C+D)+E";//Console.ReadLine().Replace(" ", "");

            String post = "";

            String[] letters = new String[xp.Length];
            for(int i=0;i<letters.Length;i++)
            {
                letters[i] = xp.Substring(i, 1);
            }

            Stack st = new Stack();

            foreach (String t in letters)
            {
                if (!"*+-/()".Contains(t))
                    post = post + t;

                else if (t == "(")
                {
                    while (t != ")")
                        st.Pop();
                }

                else
                {
                    bool x = true;
                    object oper = st.Peek();
                    if (t == "*" && oper == "+") x = false;
                    else if (t == "*" && oper == "-") x = false;
                    else if (t == "/" && oper == "+") x = false;
                    else if (t == "/" && oper == "-") x = false;

                    while ( x == false || t=="(" || st.Count == 0)
                    {
                        st.Pop();
                        post = post + t;
                    }
                    st.Push(t);

                }

            }

           
            foreach (String t in st)
            {
                st.Pop();
                post = post + t;
            }

            Console.WriteLine(post);





            /*/
            st.Push('A');

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();

            st.Push('V');
            Console.WriteLine("The next poppable value in stack: {0}", st.Peek());
            Console.WriteLine("Current stack: ");

            foreach (char c in st)
            {
                Console.Write(c + " ");

            }

            Console.WriteLine();

            Console.WriteLine("Removing values ");
            st.Pop();

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }/*/
        }
    }
} 
