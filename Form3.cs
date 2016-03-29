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
    public partial class Form3 : Form
    {
        private List<Product> Myl1;

        public Form3()
        {
            InitializeComponent();
            
        }

        internal Form3(List<Product> L)
        {
            InitializeComponent();
            Myl1 = L;
            //for (int i = 0; i < Myl1.Count; i++)
            //{
            //    Myl1[i].IsSpoilage += Form1.WarningMessage;
            //    Myl1[i].IsNotSpoilage += Form1.GoodMessage;
            //}
            //Myl1[0].IsSpoilage += Form1.WarningMessage;
            //Myl1[0].IsNotSpoilage += Form1.GoodMessage;

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                if ((int.Parse(textBox1.Text) > 30) || (int.Parse(textBox1.Text) < 0) || (int.Parse(textBox2.Text) > 12) || (int.Parse(textBox1.Text) < 0) || (int.Parse(textBox3.Text) < 1900))
                {
                    MessageBox.Show("You enter wrong date!!!");
                    return;
                }
                for (int i = 0; i < Myl1.Count; i++)
                {
                    //if(Myl1[i].Name.Equals(textBoxProductName.Text))
                    Myl1[i].DaysLeft(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                this.Close();
            }
            else
                return;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < Myl1.Count; i++)
            {
                Myl1[i].IsSpoilage += Form1.WarningMessage;
                Myl1[i].IsNotSpoilage += Form1.GoodMessage;
            }
        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
