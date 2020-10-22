using System;
using System.Windows.Forms;

namespace OO7
{
    /// <summary>
    /// Класс студентов
    /// </summary>
    class Student
    {
        public int indexRB;
        public string nameS;
        public int indexG;
        public string sex;
        public static void Create()
        {
            Application.Run(new DataForm(1,-1));
        }
        public static void change(int index)
        {
            Application.Run(new DataForm(1, index));
        }
    }
    /// <summary>
    /// Класс групп
    /// </summary>
    class Group
    {
        public int keyG;
        public string nameG;
        public static void Create()
        {
            Application.Run(new DataForm(2, -1));
        }
        public static void change(int index)
        {
            Application.Run(new DataForm(2, index));
        }
    }
}
