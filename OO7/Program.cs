﻿using System;
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
            while (whilecode == 0) //цикл работы с меню
            {
                int menucode = Menu();//функция вызова меню
                switch (menucode) //выполнение необходимой команды
                {
                    default://если число не входит в необходимый промежуток
                        dwr("Ошибка свитча");
                        whilecode = 1;
                        break;
                    case -1://если функция меню выдало код ошибки
                        dwr("Ошибка меню");
                        whilecode = 2;
                        break;
                    case 0://выход из программы
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
                        dwr("Students: indexRB, nameS, indexG, sex");
                        dwr("Group: keyG, nameG");
                        break;
                    case 6:
                        dwr("Вывод студентов в консоль");
                        constud();
                        break;
                    case 7:
                        dwr("Вывод групп в консоль");
                        congr();
                        break;
                    case 8:
                        dwr("Вывод студентов женского пола");
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
                dwr("Выберите команду из меню");

                if (int.TryParse(drl(), out code))//если перевод числа прошёл успешно
                {
                    break;
                }
                else
                {
                    dwr("Попробуйте снова");
                }
            }
            //выбор команды
            if (code > 0)
            {
                return code;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Вывод листа студентов в консоль
        /// </summary>
        static void constud()
        {
            dwr("index StudentName GroupIndex Sex");
            dwr("--------------------------------");
            foreach (Student s in sl)//вывод студентов в консоль
            {
                //Console.WriteLine("{0,10}", s.indexRB, s.nameS, s.indexG, s.sex);
                dwr($"{s.indexRB}      {s.nameS}      {s.indexG}     {s.sex}");
            }
        }
        /// <summary>
        /// Вывод листа группы в консоль
        /// </summary>
        static void congr()
        {
            dwr("index GroupName");
            dwr("---------------");
            foreach(Group g in gl)//вывод группы в консоль
            {
                dwr($"{g.keyG}      {g.nameG}");
            }
        }
        /// <summary>
        /// выполнение задания на вывод студентов женского пола
        /// </summary>
        static void woman()
        {
            dwr("index StudentName GroupIndex Sex");
            dwr("--------------------------------");
            foreach (Student s in sl)//вывод студентов женского пола в консоль
            {
                if(s.sex == "female")
                    dwr($"{s.indexRB}      {s.nameS}      {s.indexG}        {s.sex}");
            }
        }
        /// <summary>
        /// чтение данных из файла
        /// </summary>
        public static void readfile()
        {
            try
            {
                StreamReader sr = new StreamReader("Students.txt");
                string text;
                sl.Clear();
                while ((text = sr.ReadLine()) != null)//чтение до конца файла по строчно
                {
                    string[] s = text.Split();
                    sl.Add(new Student()); //заполнение данными массива
                    sl[sl.Count - 1].indexRB = int.Parse(s[0]);
                    sl[sl.Count - 1].nameS = s[1];
                    sl[sl.Count - 1].indexG = int.Parse(s[2]);
                    sl[sl.Count - 1].sex = s[3];
                }
                sr.Close();
                sr = new StreamReader("Groups.txt");
                gl.Clear();
                while ((text = sr.ReadLine()) != null)//чтение файла до конца по строчно
                {
                    string[] s = text.Split();
                    gl.Add(new Group());//заполнение данными массива
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
        /// <summary>
        /// Запись в файл из листов
        /// </summary>
        public static void writefile()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Students.txt");
                foreach(Student s in sl)//вывод студентов в файл
                {
                    sw.WriteLine($"{s.indexRB} {s.nameS} {s.indexG} {s.sex}");
                }
                sw.Close();
                sw = new StreamWriter("Groups.txt");
                foreach(Group g in gl)//вывод группы в файл
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
