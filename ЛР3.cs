using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace programm
{
    class programm
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Rectangle rect = new Rectangle(5, 4);
            Square square = new Square(5);
            Circle circle = new Circle(5);

            Console.WriteLine("\nArrayList: ");
            ArrayList al = new ArrayList();
            al.Add(circle);
            al.Add(rect);
            al.Add(square);
            foreach (var x in al) Console.WriteLine(x);

            Console.WriteLine("\nОтсортированный ArrayList: ");
            al.Sort();
            foreach (var x in al) Console.WriteLine(x);

            Console.WriteLine("\nСписок: ");
            List<Figure> fl = new List<Figure>();
            fl.Add(circle);
            fl.Add(rect);
            fl.Add(square);
            foreach (var x in fl) Console.WriteLine(x);

            Console.WriteLine("\nОтсортированный список: ");
            fl.Sort();
            foreach (var x in fl) Console.WriteLine(x);

            Console.WriteLine("\nМатрица: ");
            Matrix3D<Figure> cube = new Matrix3D<Figure>(3, 3, 3, new NullFigure());
            cube[0, 0, 0] = rect;
            cube[1, 1, 1] = square;
            cube[2, 2, 1] = circle;
            cube.ToString();
            Console.WriteLine(cube.ToString());

            Console.WriteLine("SimpleList: ");
            SimpleList<Figure> list = new SimpleList<Figure>();
            list.Add(square);
            list.Add(rect);
            list.Add(circle);
            foreach (var x in list) Console.WriteLine(x);

            Console.WriteLine("\nОтсортированный SimpleList: ");
            list.Sort();
            foreach (var x in list) Console.WriteLine(x);

            Console.WriteLine("\nСтек: ");
            SimpleStack<Figure> stack = new SimpleStack<Figure>();
            stack.Push(square);
            stack.Push(rect);
            stack.Push(circle);
            while (stack.Count > 0)
            {
                Figure f = stack.Pop();
                Console.WriteLine(f);
            }

            Console.ReadLine();
            return;
        }
        static void Print(IPrint pr)
        {
            pr.Print();
        }
    }
    interface IPrint
    {
        void Print();
    }
    public abstract class Figure : IComparable
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
        public int CompareTo(object obj)
        {
            Figure comparedFigure = obj as Figure;
            if (comparedFigure != null)
                return Area().CompareTo(comparedFigure.Area());
            throw new Exception("Impossible to compare these objects!");
        }
        public abstract double Area();
    }
    class NullFigure : Figure, IPrint
    {
        public override double Area()
        {
            return 0;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            return 0.ToString();
        }
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
            return this.Type + " a=" + height + " b=" + width + " S=" + this.Area().ToString("f4");
        }
    }

    class Square : Rectangle, IPrint
    {
        public Square(double size)
        : base(size, size)
        {
            this.Type = "Квадрат";
        }
        public override string ToString()
        {
            return this.Type + " a=" + width + " S=" + this.Area().ToString("f4");
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
            return this.Type + " r=" + radius + " S=" + this.Area().ToString("f4");
        }
    }


    public class Matrix3D<T>
    {
        Dictionary<string, T> _matrix = new Dictionary<string, T>();

        int maxX;
        int maxY;
        int maxZ;
        T nullElement;

        public Matrix3D(int x, int y, int z, T nullElementParam)
        {
            this.maxX = x;
            this.maxY = y;
            this.maxZ = z;
            this.nullElement = nullElementParam;
        }

        public T this[int x, int y, int z]
        {
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matrix.ContainsKey(key))
                    return this._matrix[key];
                else return this.nullElement;
            }
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                this._matrix.Add(key, value);
            }
        }

        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= this.maxX) throw new Exception("x=" + x + " выходит за границы");
            if (y < 0 || y >= this.maxY) throw new Exception("y=" + y + " выходит за границы");
            if (z < 0 || z >= this.maxY) throw new Exception("z=" + z + " выходит за границы");
        }

        string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int k = 0; k < this.maxZ; k++)
            {
                for (int j = 0; j < this.maxY; j++)
                {
                    b.Append("[");
                    for (int i = 0; i < this.maxX; i++)
                    {
                        if (i > 0) b.Append("\t");
                        b.Append(this[i, j, k].ToString());
                    }
                    b.Append("]\n");
                }
                b.Append("\n");
            }
            return b.ToString();
        }
    }

    public class SimpleListItem<T>
    {
        public T data { get; set; }
        public SimpleListItem<T> next { get; set; }
        public SimpleListItem(T param)
        {
            this.data = param;
        }
    }

    public class SimpleList<T> : IEnumerable<T>
    where T : IComparable
    {
        protected SimpleListItem<T> first = null;
        protected SimpleListItem<T> last = null;
        public int Count
        {
            get { return _count; }
            protected set { _count = value; }
        }
        int _count;
        public void Add(T element)
        {
            SimpleListItem<T> newItem = new SimpleListItem<T>(element);
            this.Count++;
            if (last == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                this.last.next = newItem;
                this.last = newItem;
            }
        }
        public SimpleListItem<T> GetItem(int number)
        {
            if ((number < 0) || (number >= this.Count))
            {
                throw new Exception("Выход за границу индекса");
            }
            SimpleListItem<T> current = this.first;
            int i = 0;

            while (i < number)
            {
                current = current.next;
                i++;
            }
            return current;
        }
        public T Get(int number)
        {
            return GetItem(number).data;
        }
        public IEnumerator<T> GetEnumerator()
        {
            SimpleListItem<T> current = this.first;

            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        System.Collections.IEnumerator
        System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Sort()
        {
            Sort(0, this.Count - 1);
        }

        private void Sort(int low, int high)
        {
            int i = low;
            int j = high;
            T x = Get((low + high) / 2);
            do
            {
                while (Get(i).CompareTo(x) < 0) ++i;
                while (Get(j).CompareTo(x) > 0) --j;
                if (i <= j)
                {
                    Swap(i, j);
                    i++; j--;
                }
            } while (i <= j);
            if (low < j) Sort(low, j);
            if (i < high) Sort(i, high);
        }
        private void Swap(int i, int j)
        {
            SimpleListItem<T> ci = GetItem(i);
            SimpleListItem<T> cj = GetItem(j);
            T temp = ci.data;
            ci.data = cj.data;
            cj.data = temp;
        }
    }
    class SimpleStack<T> : SimpleList<T>
        where T : IComparable
    {
        public void Push(T element)
        {
            Add(element);
        }

        public T Pop()
        {
            if (Count != 0)
            {
                T top = Get(Count - 1);
                if (Count != 1)
                {
                    last = GetItem(Count - 2);
                    last.next = null;
                }
                else
                {
                    first = null;
                    last = null;
                }
                Count-=1;
                return top;
            }
            throw new Exception("Ошибка! Стек пустой, извлечение элемента невозможно.");
        }
    }
}