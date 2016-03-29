using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsLib;



namespace Exam_Semester2
{
    public partial class Form2 : Form
    {

        private List<Product> MyL;

        public Form2()
        {

            InitializeComponent();
            
        }

        internal Form2(List<Product> L)
        {
            InitializeComponent();
            MyL = L;

           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           // ((Form1)this.Owner).L.Add(new Product(textBox1.Text,int.Parse(textBox2.Text),int.Parse(textBox3.Text),int.Parse(textBox4.Text),double.Parse(textBox5.Text)));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox6.Visible = false;
                label6.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox6.Visible = true;
                label6.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((int.Parse(textBox2.Text) > 30) || (int.Parse(textBox2.Text) < 0) || (int.Parse(textBox3.Text) > 12) || (int.Parse(textBox3.Text) < 0) || (int.Parse(textBox4.Text) < 1900))
            {
                MessageBox.Show("You enter wrong date!!!");
                return;
            }
            ((Form1)this.Owner).L.Add(new Product(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), double.Parse(textBox5.Text)));
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
