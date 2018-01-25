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
                
                else if (t == ")")
                {
                    while (true)
                    {
                        if (t != "(" && st.Count != 0)
                        {
                            st.Pop();
                            post = post + t;
                        }
                        else break;
                    }
                }

                else
                {
                    bool pre = false;
                    if(t =="*" || t == "/")
                    {
                        pre = true;
                    }

                    while (/*/pre == false ||  t=="(" || st.Count != 0/*/ true)
                    {
                        

                        if (pre == false) break;

                        if (t == "(") break;

                        if (st.Count == 0) break;

                        st.Pop();
                        post = post + t;


                    }

                    st.Push(t);

                }

            }

           
            for(int i=0;i<st.Count;i++)
            {
                
                post = post + st.Peek();
                st.Pop();
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
