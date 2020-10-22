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
    public partial class DataForm : Form
    {
        int _index;
        public DataForm()
        {
            InitializeComponent();
        }
        public DataForm(int table,int index)
        {
            InitializeComponent();
            _index = index;
            if (table == 1)
            {
                dataGridView1.Columns[0].HeaderText = "IndexRB";
                dataGridView1.Columns[1].HeaderText = "Student name";
                dataGridView1.Columns[2].HeaderText = "Group index";
                dataGridView1.Columns[3].HeaderText = "Sex";
            }
            if (table == 2)
            {
                dataGridView1.Columns[0].HeaderText = "Group index";
                dataGridView1.Columns[1].HeaderText = "Group name";
            }
            dataGridView1.Rows.Add();
            if(index >= 0)
            {
                if (table == 1)
                {
                    dataGridView1.Rows[0].Cells[0].Value = Program.sl[index].indexRB;
                    dataGridView1.Rows[0].Cells[1].Value = Program.sl[index].nameS;
                    dataGridView1.Rows[0].Cells[2].Value = Program.sl[index].indexG;
                    dataGridView1.Rows[0].Cells[3].Value = Program.sl[index].sex;
                }
                if(table == 2)
                {
                    dataGridView1.Rows[0].Cells[0].Value = Program.gl[index].keyG;
                    dataGridView1.Rows[0].Cells[0].Value = Program.gl[index].nameG;
                }
            }
        }
        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns[0].HeaderText == "IndexRB")
            {
                if (_index >= 0)
                {
                    try
                    {
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
                else
                {
                    Program.sl.Add(new Student());
                    try
                    {
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
            if(dataGridView1.Columns[0].HeaderText == "Group index")
            {
                if (_index >= 0)
                {
                    try
                    {
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
            this.Close();
        }
    }
}
