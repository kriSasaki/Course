﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18__2
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbols = Console.ReadLine();
            int leftBracket=0;
            int rightBracket = 0;
            int depth = 1;
            for(int i=0;i<symbols.Length;i++)
            {
                if (symbols[i] == '(')
                {
                    leftBracket++;
                }
                if (symbols[i] == ')')
                {
                    if(i!=symbols.Length-1 && symbols[i+1] != '(')
                    {
                        depth++;
                    }
                    rightBracket++;
                }
            }
            if (leftBracket == rightBracket)
            {
                Console.WriteLine("Строка корректная");
            }
            else
            {
                Console.WriteLine("Строка некорректная");
                depth = 0;
            }
            Console.WriteLine("Максимальная глубина: " + depth);
        }
    }
}
