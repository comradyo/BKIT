#define part2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

#if (part1)

namespace LR6_1
{
    /*
     * Если кратко описывать сущность делегата, то он является аналогом типа данных для методов. 
     * Класс является типом данных, экземпляром класса является объект, содержащий конкретные данные. 
     * Делегат является типом методов, экземпляром делегата является метод, соответствующий делегату. 
     */

    delegate void PlusDelegate(string s, int p1, int p2);
    class Program
    {
        static void Plus(string a, int b, int c)
        {
            int Result = b + c;
            Console.WriteLine(a + Result.ToString());
        }
        static void PlusMethod(string str, int p1, int p2, PlusDelegate r)
        {
            r(str, p1, p2);
        }
        static void PlusMethodAction(string str, int p1, int p2, Action<string, int, int> r)
        {
            r(str, p1, p2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Метод с параметром-делегатом Plus");
            PlusMethod("Сумма: ", 1, 2, Plus);
            Console.WriteLine("Метод с параметром-делегатом в виде Лямбда-выражения");
            PlusMethod("Сумма: ", 1, 2, (string a, int b, int c) => {
                int Result = b + c;
                Console.WriteLine(a + Result.ToString());
            });

            Console.WriteLine();
            Console.WriteLine("Обобщённый делегат Action< >");
            Console.WriteLine("Метод с параметром-делегатом Plus");
            //Plus - это строка, означающая название метода
            PlusMethodAction("Сумма: ", 1, 2, Plus);
            Console.WriteLine("Метод с параметром-делегатом в виде Лямбда-выражения");
            PlusMethodAction("Сумма: ", 1, 2, (string a, int b, int c) => {
                int Result = b + c;
                Console.WriteLine(a + Result.ToString());
            });
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}

#endif

#if (part2)

namespace LR6_2
{
    /*
    Атрибуты предоставляют универсальные средства связи данных (в виде аннотаций) с типами, определенными в С#.

    Основная задача рефлексии - работа со сборками, типами данных и атрибутами.

    Сериализация представляет процесс преобразования какого-либо объекта в поток байтов. 
    После преобразования мы можем этот поток байтов или записать на диск или сохранить его временно в памяти. 
    А при необходимости можно выполнить обратный процесс - десериализацию, то есть получить из потока байтов ранее сохраненный объект.

    Класс атрибута должен быть помечен атрибутом AttributeUsage, который принимает три параметра: 
    - параметр типа перечисление AttributeTargets, которое указывает, к каким элементам класса может применяться атрибут NewAttribute (классам, свойствам, методам и т.д.); 
    в данном случае только к свойствам (Property); 
    - логический параметр AllowMultiple, указывающий, может ли применяться к свойству несколько атрибутов NewAttribute; 
    - логический параметр Inherited, указывающий, наследуется ли атрибут классами, производными от класса с атрибутами; 
    */
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    class NewAttribute : Attribute
    {
        public NewAttribute() { }
        public NewAttribute(string description)
        {
            Description = description;
        }
        public string Description { get; set; }
    }

    class Movie
    {
        [NewAttribute(Description = "Название фильма")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name;

        [NewAttribute(Description = "Съемочная студия")]
        public string studio
        {
            get { return _studio; }
            set { _studio = value; }
        }
        private string _studio;

        [NewAttribute("Год выхода на экраны")]
        public int year
        {
            get { return _year; }
            set { _year = value; }
        }
        private int _year;

        public void MovieInfo()
        {
            Console.WriteLine("Фильм " + name + " был выпущен в " + year + " студией " + studio);
        }
        public void AgeOfTheMovie()
        {
            Console.WriteLine(name + " вышел " + (int.Parse(DateTime.Now.ToString("yyyy")) - year) + " лет назад");
        }

        public Movie() { }
        public Movie(string name) { }
        public Movie(string movieName, string movieStudio, int movieDateOfRealise)
        {
            name = movieName;
            studio = movieStudio;
            year = movieDateOfRealise;
        }
    }
    class Program
    {
        static bool CheckAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Res = false;
            attribute = null;

            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Res = true;
                attribute = isAttribute[0];
            }

            return Res;
        }
        static void Main(string[] args)
        {
            // 3
            Type tMovie = typeof(Movie);

            Console.WriteLine("Конструкторы: ");
            foreach (var temp in tMovie.GetConstructors())
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine();

            Console.WriteLine("Методы: ");
            foreach (var temp in tMovie.GetMethods())
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine();

            Console.WriteLine("Свойства: ");
            foreach (var temp in tMovie.GetProperties())
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine();

            Console.WriteLine("Описание свойств:");
            foreach (var temp in tMovie.GetProperties())
            {
                object objectAttribute;
                if (CheckAttribute(temp, typeof(NewAttribute), out objectAttribute))
                {
                    NewAttribute attr = objectAttribute as NewAttribute;
                    Console.WriteLine(temp.Name + " - " + attr.Description);
                }
            }
            Console.WriteLine();

            List<Movie> movieList = new List<Movie>();
            movieList.Add(new Movie("Batman", "Paramount pictures", 1996));
            movieList.Add(new Movie("House of the dead", "Alylum studios", 2003));
            movieList.Add(new Movie("Speedrun", "Columbia pictures", 2010));


            Console.WriteLine("Список фильмов: ");
            Console.WriteLine();
            //Метод InvokeMember класса Type позволяет выполнять динамические действия с объектами классов: 
            //создавать объекты, вызывать методы, получать и присваивать значения свойств.
            //InvokeMethod - вызывать метод.
            foreach (var temp in movieList)
            {
                tMovie.InvokeMember("MovieInfo", BindingFlags.InvokeMethod, null, temp, null);
                tMovie.InvokeMember("AgeOfTheMovie", BindingFlags.InvokeMethod, null, temp, null);
                Console.WriteLine();
            }
        }
    }
}

#endif
