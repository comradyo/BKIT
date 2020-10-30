using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace programm
{
    class Program
    {
        static void Print(IPrint pr)
        {
            pr.Print();
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Rectangle a = new Rectangle(4.3, 5.1);
            Circle b = new Circle(12.7);
            Square c = new Square(0.6);
            Print(a);
            Print(b);
            Print(c);

            return;
        }
    }
    abstract class Figure
    {
        public string Type
        {
            get
            {
                return this._Type;
            }
            protected set
            {
                this._Type = value;
            }
        }
        string _Type;
        public abstract double Area();
        new public abstract string ToString();
    }

    interface IPrint
    {
        void Print();
    }

    class Rectangle : Figure, IPrint
    {
        protected double height, width;
        public Rectangle(double h, double w)
        {
            this.height = h;
            this.width = w;
            this.Type = "Прямоугольник";
        }
        public override double Area()
        {
            return this.width * this.height;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            return "Тип фигуры: " + this.Type + "\nВысота и ширина: " + height + " " + width + "\nПлощадь: " + this.Area().ToString() + '\n';
        }
    }

    class Square : Rectangle, IPrint
    {
        double length;
        public Square(double size)
        : base(size, size)
        {
            this.length = size;
            this.Type = "Квадрат";
        }
        public override string ToString()
        {
            return "Тип фигуры: " + this.Type + "\nДлина стороны: " + height + "\nПлощадь: " + this.Area().ToString() + '\n';
        }
    }
    class Circle : Figure, IPrint
    {
        double radius;
        public Circle(double r)
        {
            this.radius = r;
            this.Type = "Круг";
        }
        public override double Area()
        {
            return Math.PI * this.radius * this.radius;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            return "Тип фигуры: " + this.Type + "\nРадиус: " + radius + "\nПлощадь: " + this.Area().ToString() + '\n';
        }
    }
}