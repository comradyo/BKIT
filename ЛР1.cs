using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;   // к примеру зеленый
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Винников Степан ИУ5-32Б\n");
        double a = 0, b = 0, c = 0;
        bool flag = false;

        if (args.Length == 3)
        {
            flag = true;
            if (!Double.TryParse(args[0], out a))
            {
                Console.WriteLine("Ошибка, переданный параметр a - не число!");
                return;
            }
            if (a == 0)
            {
                Console.WriteLine("Ошибка, коэффициент a не может быть равен нулю!");
                return;
            }
            if (!Double.TryParse(args[1], out b))
            {
                Console.WriteLine("Ошибка, переданный параметр b - не число!");
                return;
            }
            if (!Double.TryParse(args[2], out c))
            {
                Console.WriteLine("Ошибка, переданный параметр b - не число!");
                return;
            }
            Console.WriteLine("Коэффициенты, заданные в качестве параметров командной строки: ");
            Console.WriteLine("a = "+a);
            Console.WriteLine("b = "+b);
            Console.WriteLine("c = "+c);
        }

        if (flag == false)
        {
            a = b = c = 0;

            Console.WriteLine("Введите ненулевой коэффициент a: ");
            while (!double.TryParse(Console.ReadLine(), out a) || a == 0)
                Console.WriteLine("Введено некорректное значение коэффициента a!");

            Console.WriteLine("Введите коэффициент b: ");
            while (!double.TryParse(Console.ReadLine(), out b))
                Console.WriteLine("Ошибка, переданный параметр b - не число!");

            Console.WriteLine("Введите коэффициент c: ");
            while (!double.TryParse(Console.ReadLine(), out c))
                Console.WriteLine("Ошибка, переданный параметр b - не число!");
        }

        List<double> roots = new List<double>();

        double d = b * b - 4 * a * c;
        if(d > 0)
        {
            double t1 = (-b + Math.Sqrt(d)) / (2 * a);
            double t2 = (-b - Math.Sqrt(d)) / (2 * a);
            if (t1 > 0)
            {
                roots.Add(Math.Sqrt(t1));
                roots.Add(-Math.Sqrt(t1));
            }
            if(t2 > 0)
            {
                roots.Add(Math.Sqrt(t2));
                roots.Add(-Math.Sqrt(t2));
            }
            if (t1 == 0 || t2 == 0) roots.Add(0);
            else if(t1 < 0 && t2 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет");
                Console.ResetColor();
                return;
            }
        }
        else
            if(d == 0)
        {
            double t = -b / (2 * a);
            if (t > 0)
            {
                roots.Add(Math.Sqrt(t));
                roots.Add(-Math.Sqrt(t));
            }
            else if (t == 0)
                roots.Add(0);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет");
                Console.ResetColor();
                return;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Корней нет");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Корни уравнения:");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i<roots.Count; i++)
        {
            Console.WriteLine(roots[i]);
        }
        Console.ResetColor();

    }
}