using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OO7
{
    /// <summary>
    /// Форма добавление и редактирования студентов и групп
    /// </summary>
    public partial class DataForm : Form
    {
        int _index;
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public DataForm(int table,int index)
        {
            InitializeComponent();
            _index = index;
            if (table == 1)//если надо работать со студентом
            {
                //переименование колонок
                dataGridView1.Columns[0].HeaderText = "IndexRB";
                dataGridView1.Columns[1].HeaderText = "Student name";
                dataGridView1.Columns[2].HeaderText = "Group index";
                dataGridView1.Columns[3].HeaderText = "Sex";
            }
            if (table == 2)//если надо работать с группой
            {
                //переименование колонок
                dataGridView1.Columns[0].HeaderText = "Group index";
                dataGridView1.Columns[1].HeaderText = "Group name";
            }
            dataGridView1.Rows.Add(); // добавление строки
            if(index >= 0)//если запрос был на редактирование
            {
                if (table == 1)//если это студент
                {
                    //заполнение ячеек бывшими данными
                    dataGridView1.Rows[0].Cells[0].Value = Program.sl[index].indexRB;
                    dataGridView1.Rows[0].Cells[1].Value = Program.sl[index].nameS;
                    dataGridView1.Rows[0].Cells[2].Value = Program.sl[index].indexG;
                    dataGridView1.Rows[0].Cells[3].Value = Program.sl[index].sex;
                }
                if(table == 2)//если это группа
                {
                    //заполнение ячеек бывшими данными
                    dataGridView1.Rows[0].Cells[0].Value = Program.gl[index].keyG;
                    dataGridView1.Rows[0].Cells[0].Value = Program.gl[index].nameG;
                }
            }
        }
        /// <summary>
        /// При нажатии на кнопку записи
        /// </summary>
        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns[0].HeaderText == "IndexRB")//если это был студент
            {
                if (_index >= 0)//если это было редактирование
                {
                    try
                    {
                        //запись новых данных в список
                        Program.sl[_index].indexRB = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        Program.sl[_index].nameS = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        Program.sl[_index].indexG = int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString());
                        Program.sl[_index].sex = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Данные введены неверно");
                    }
                }
                else//если это не было редактирование
                {
                    Program.sl.Add(new Student());
                    try
                    {
                        //Запись нового студента в список
                        Program.sl[Program.sl.Count - 1].indexRB = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        Program.sl[Program.sl.Count - 1].nameS = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        Program.sl[Program.sl.Count - 1].indexG = int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString());
                        Program.sl[Program.sl.Count - 1].sex = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Данные введены неверно");
                    }
                }
            }
            if(dataGridView1.Columns[0].HeaderText == "Group index") //если это были группы
            {
                if (_index >= 0)//если это было редактирование
                {
                    try
                    {
                        //редактирование данных в списке
                        Program.gl[_index].keyG = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        Program.gl[_index].nameG = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Данные введены неверно");
                    }
                }
                else
                {
                    Program.gl.Add(new Group());
                    try
                    {
                        //добавление новой группы в список
                        Program.gl[Program.gl.Count - 1].keyG = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
                        Program.gl[Program.gl.Count - 1].nameG = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Данные введены неверно");
                    }
                }
            }
            MessageBox.Show("Запись прошла успешно");
            this.Close();//закрытие формы
        }
    }
}
