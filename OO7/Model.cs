using System;
using System.Windows.Forms;

namespace OO7
{
    /// <summary>
    /// Класс студентов
    /// </summary>
    class Student
    {
        public int indexRB; //Индекс студенческого
        public string nameS; //Фамилия студента
        public int indexG; // Индекс группы
        public string sex; // Пол студента
        /// <summary>
        /// Добавление студента
        /// </summary>
        public static void Create()
        {
            Application.Run(new DataForm(1,-1));
        }
        /// <summary>
        /// Редактирование студента по индексу
        /// </summary>
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
        /// <summary>
        /// Создание новой группы
        /// </summary>
        public static void Create()
        {
            Application.Run(new DataForm(2, -1));
        }
        /// <summary>
        /// Редактирование группы по индексу 
        /// </summary>
        public static void change(int index)
        {
            Application.Run(new DataForm(2, index));
        }
    }
}
