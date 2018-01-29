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
            String ops = "+-*/()";
            Stack<char> st = new Stack<char>();

            foreach (String t in letters)
            {
                if (!"*+-/()".Contains(t))
                    post = post + t;
                
                else if (t == ")")
                {
                    while (true)
                    {
                        if (st.Count != 0)
                        {
                            if (st.Peek() == '(')
                            {

                                st.Pop();
                                break;
                            }
                            else
                                post = post + st.Pop();
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

                    while (true)
                    {
                        
                        if (st.Count == 0 || st.Peek() == '(') break;

                        if (ops.IndexOf(st.Peek()) < ops.IndexOf(t))
                            break;

                        post = post + st.Peek();
                        st.Pop();


                    }

                    char[] myChar = t.ToCharArray();
                    st.Push(myChar[0]);

                }

            }

           
            for(int i=0;i<st.Count;i++)
            {
                
                post = post + st.Peek();
                st.Pop();
            }

            post = post.Replace("(", "");
            post = post.Replace(")", "");

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
