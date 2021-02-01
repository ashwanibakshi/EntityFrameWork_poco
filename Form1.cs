using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.dto;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }
        repository repo = new repository();
        private void Form1_Load(object sender, EventArgs e)
        {
            department dp = new department();
            using (empDBContext emp = new empDBContext())
            {
                //dp.Name = "hr";
                //dp.Location = "kota";
                //emp.departments.Add(dp);
                //emp.SaveChanges();
                List<department> d =  emp.departments.ToList();
                foreach (department x in d)
                {
                    comboBox1.Items.Add(x.Name);
                }
                dataGridView1.DataSource = repo.getGridData();
               
            }
        }

        private void demoDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            employee empp = new employee();
            department dep = new department();
            using (empDBContext emp2 = new empDBContext())
            {
                dep.Name = comboBox1.SelectedItem.ToString();
                dep = emp2.departments.Where(data => data.Name == dep.Name).SingleOrDefault();
                empp.FirstName = textBox1.Text.ToString();
                empp.LastName  = textBox2.Text.ToString();
                empp.Gender    = textBox3.Text.ToString();
                empp.Salary    = Int32.Parse(textBox4.Text);
                empp.Department = dep;
                emp2.employees.Add(empp);
                int count = emp2.SaveChanges();
                if(count>0)
                    MessageBox.Show("Add successfully added to db");
                else
                    MessageBox.Show("Data not edited to db");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                dataGridView1.DataSource = repo.getGridData();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("combobox"+comboBox1.SelectedItem);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
