using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OO7
{
    class Program
    {
        public static StreamWriter csw = new StreamWriter("document7.txt");
        //создание списка студентов и групп
        public static List<Student> sl = new List<Student>();
        public static List<Group> gl = new List<Group>();
        [STAThread]
        static void Main(string[] args)
        {
            //настройка для форм
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            readfile(); // чтение из файла базы
            int whilecode = 0;
            while (whilecode == 0)
            {
                int menucode = Menu();
                switch (menucode)
                {
                    default:
                        dwr("Ошибка свитча");
                        whilecode = 1;
                        break;
                    case -1:
                        dwr("Ошибка меню");
                        whilecode = 2;
                        break;
                    case 0:
                        dwr("Good bye");
                        whilecode = -1;
                        break;
                    case 1:
                        dwr("Добавление студента");
                        Student.Create();
                        break;
                    case 2:
                        dwr("Добавление группы");
                        Group.Create();
                        break;
                    case 3:
                        dwr("Запись изменений в файл");
                        writefile();
                        break;
                    case 4:
                        dwr("Чтение из файла");
                        readfile();
                        break;
                    case 5:
                        dwr("Students: indexRB, nameS, indexG");
                        dwr("Group: keyG, nameG");
                        break;
                    case 6:
                        constud();
                        break;
                    case 7:
                        congr();
                        break;
                    case 8:
                        woman();
                        break;
                    case 9:
                        dwr("введите индекс студента");
                        int i = int.Parse(drl());
                        Student.change(i);
                        break;
                    case 10:
                        dwr("введите индекс группы");
                        i = int.Parse(drl());
                        Group.change(i);
                        break;
                }
            }
            csw.Close();
            Console.ReadKey();
        }
        /// <summary>
        /// Функция меню
        /// </summary>
        static int Menu()
        {
            int code;
            while (true)
            {
                dwr("");
                dwr("Напишите '0' для выхода");
                dwr("Напишите '1' для ввода нового студента");
                dwr("Напишите '2' для ввода новой группы");
                dwr("Напишите '3' для записи изменений в файл");
                dwr("Напишите '4' для чтения из файла и сброса изменений");
                dwr("Напишите '5' для отображения модели данных");
                dwr("Напишите '6' для вывода студентов");
                dwr("Напишите '7' для вывода групп");
                dwr("Напишите '8' для вывода ответа на задания");
                dwr("Напишите '9' для изменения студента");
                dwr("Напишите '10' для изменения группы");

                if (int.TryParse(drl(), out code))
                {
                    break;
                }
                else
                {
                    dwr("Попробуйте снова");
                }
            }
            //выбор команды
            switch (code)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 6:
                    return 6;
                case 7:
                    return 7;
                case 8:
                    return 8;
                case 9:
                    return 9;
                case 10:
                    return 10;
            }
            return -1;
        }
        
        static void constud()
        {
            dwr("index StudentName GroupIndex Sex");
            dwr("--------------------------------");
            foreach (Student s in sl)
            {
                dwr($"{s.indexRB}      {s.nameS}      {s.indexG}        {s.sex}");
            }
        }
        static void congr()
        {
            dwr("index GroupName");
            dwr("---------------");
            foreach(Group g in gl)
            {
                dwr($"{g.keyG}      {g.nameG}");
            }
        }
        static void woman()
        {
            dwr("index StudentName GroupIndex Sex");
            dwr("--------------------------------");
            foreach (Student s in sl)
            {
                if(s.sex == "female")
                dwr($"{s.indexRB}      {s.nameS}      {s.indexG}        {s.sex}");
            }
        }

        public static void readfile()
        {
            try
            {
                StreamReader sr = new StreamReader("Students.txt");
                string text;
                while ((text = sr.ReadLine()) != null)
                {
                    string[] s = text.Split();
                    sl.Clear();
                    sl.Add(new Student());
                    sl[sl.Count - 1].indexRB = int.Parse(s[0]);
                    sl[sl.Count - 1].nameS = s[1];
                    sl[sl.Count - 1].indexG = int.Parse(s[2]);
                    sl[sl.Count - 1].nameS = s[3];
                }
                sr.Close();
                sr = new StreamReader("Groups.txt");
                while ((text = sr.ReadLine()) != null)
                {
                    string[] s = text.Split();
                    gl.Clear();
                    gl.Add(new Group());
                    gl[gl.Count - 1].keyG = int.Parse(s[0]);
                    gl[gl.Count - 1].nameG = s[1];
                }
                sr.Close();
                dwr("Чтение прошло успешно");
            }
            catch
            {
                dwr("Ошибка чтения");
            }
        }
        public static void writefile()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Students.txt");
                foreach(Student s in sl)
                {
                    sw.WriteLine($"{s.indexRB} {s.nameS} {s.indexG} {s.sex}");
                }
                sw.Close();
                sw = new StreamWriter("Groups.txt");
                foreach(Group g in gl)
                {
                    sw.WriteLine($"{g.keyG} {g.nameG}");
                }
                sw.Close();
                dwr("Запись прошла успешно");
            }
            catch
            {
                dwr("Ошибка записи в файл");
            }
        }

        /// <summary>
        /// Совместный вывод в текстовый файл и консоль
        /// </summary>
        static void dwr(string text)
        {
            Console.WriteLine(text);
            csw.WriteLine(text);
        }
        /// <summary>
        /// Чтение из консоли с пометкой в логах
        /// </summary>
        static string drl()
        {
            string t = Console.ReadLine();
            csw.WriteLine(t);
            return t;
        }
    }
}
