using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ
{
    public class Worker
    {
        public int id_worker;
        public string surname;
        public int departmentID;

        public Worker(int id_, string surname_, int department)
        {
            id_worker = id_;
            surname = surname_;
            departmentID = department;
        }

        public string toString()
        {
            return "ID сотрудника: " + id_worker + ", фамилия: " + surname + ", работает в " + departmentID.ToString();
        }
    }

    public class Department
    {
        public int id_department;
        public string name;

        public Department(int id_, string name_)
        {
            id_department = id_;
            name = name_;
        }

        public string toString()
        {
            return "ID отдела: " + id_department + ", название: " + name;
        }
    }

    class DepartmentWorker
    {
        public int workerID;
        public int departmentID;

        public DepartmentWorker(int worker, int department)
        {
            workerID = worker;
            departmentID = department;
        }

        public string toString()
        {
            return "ID сотрудника: " + workerID.ToString() + ", ID отдела: " + departmentID.ToString();
        }
    }

    class Program
    {
        //static - для работы с join
        static List<Worker> workers = new List<Worker>()
        {
            new Worker(1, "Алексеев", 1),
            new Worker(2, "Баранов", 3),
            new Worker(3, "Петухов", 2),
            new Worker(4, "Колярин", 2),
            new Worker(5, "Солженицын", 3),
            new Worker(6, "Алохин", 4)
        };

        static List<Department> departments = new List<Department>()
        {
            new Department(1, "Финансы"),
            new Department(2, "Разработка"),
            new Department(3, "Учет"),
            new Department(4, "Администрация")
        };

        static List<DepartmentWorker> departmentWorkers = new List<DepartmentWorker>()
        {
            new DepartmentWorker(1, 3),
            new DepartmentWorker(2, 1),
            new DepartmentWorker(3, 2),
            new DepartmentWorker(4, 3),
            new DepartmentWorker(5, 1),
            new DepartmentWorker(6, 4),
        };

        static void Menu(int option)
        {
            switch(option)
            {
                case 1:
                    Console.WriteLine("Список всех отделов и их сотрудников:");
                    var request1 = from w in workers
                                   from d in departments
                                   where w.departmentID == d.id_department
                                   orderby d.name ascending
                                   select new
                                   {
                                       Отдел = d.name,
                                       Работник = w.surname
                                   };
                    foreach (var w in request1) Console.WriteLine(w);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Сотрудники с фамилией, начинающейся на 'А' : ");
                    var request2 = from w in workers
                                   where w.surname.StartsWith('А')
                                   select w.surname;
                    foreach (var w in request2) Console.WriteLine(w);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Количество сотрудников по отделам:");
                    var request3 = (from d in departments
                                    join w in workers on d.id_department equals w.departmentID into temp
                                    from t in temp
                                    select new { Отдел = d.name, количество_сотрудников = temp.Count() }).Distinct();
                    foreach (var d in request3) Console.WriteLine(d);
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Отделы с сотрудниками с фамилией, которая начинается только на 'А' :");
                    var request4 = (from d in departments
                                    join w in workers on d.id_department equals w.departmentID into temp
                                    from t in temp
                                    where temp.Count(t => t.surname.StartsWith('А')) == temp.Count()
                                    select d.name).Distinct();
                    foreach (var x in request4) Console.WriteLine(x);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Отделы с хотя-бы одним сотрудником, у которого фамилия начинается на 'А' :");
                    var request5 = (from x in departments
                                    join y in workers on x.id_department equals y.departmentID into temp
                                    from t in temp
                                    where t.surname.StartsWith('А')
                                    select x.name).Distinct();
                    foreach (var x in request5) Console.WriteLine(x);
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Список сотрудников по отделам: ");
                    var request6 = from d in departments
                                   from w in workers
                                   join dw in departmentWorkers on d.id_department equals dw.departmentID into temp1
                                   from t1 in temp1
                                   where t1.workerID == w.id_worker
                                   select new { Отдел = d.name, Работник = w.surname };

                    string st = "";
                    foreach (var rq in request6)
                    {
                        if (rq.Отдел != st)
                        {
                            st = rq.Отдел;
                            Console.WriteLine(st + ":");
                            Console.WriteLine('\t' + rq.Работник);
                        }
                        else
                        {
                            Console.WriteLine('\t' + rq.Работник);
                        }
                    }
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("Количество сотрудников по отделам:");
                    var request7 = (from d in departments
                                    join dp in departmentWorkers on d.id_department equals dp.departmentID into temp
                                    from t in temp
                                    select new
                                    {
                                        Отдел = d.name,
                                        Количество_сотрудников = temp.Count()
                                    }).Distinct();
                    foreach (var x in request7) Console.WriteLine(x);
                    Console.WriteLine();
                    break;
            }
        }

        static void Main(string[] args)
        {
            int nOption = 1;
            while (nOption != 0)
            {
                Console.WriteLine("Введите запрос: \n");
                Console.WriteLine("\tСвязь типа 'Один ко многим': ");
                Console.WriteLine("1 - Список всех отделов и их сотрудников: ");
                Console.WriteLine("2 - Сотрудники с фамилией, начинающейся на 'А': ");
                Console.WriteLine("3 - Количество сотрудников по отделам: ");
                Console.WriteLine("4 - Отделы с сотрудниками с фамилией, которая начинается только на 'А' : ");
                Console.WriteLine("5 - Отделы с хотя-бы одним сотрудником, у которого фамилия начинается на 'А': \n");
                Console.WriteLine("\tСвязь типа 'Многие ко многим': ");
                Console.WriteLine("6 - Список сотрудников по отделам: ");
                Console.WriteLine("7 - Количество сотрудников по отделам: ");
                Console.Write("Запрос: ");
                string sOption = Console.ReadLine();
                Console.WriteLine();
                nOption = Convert.ToInt32(sOption);
                Console.WriteLine("===========================================");
                Menu(nOption);
                Console.WriteLine("===========================================");
            }
        }
    }
}