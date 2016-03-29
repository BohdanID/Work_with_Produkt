using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsLib;


namespace Exam_Semester2
{
    public partial class Form1 : Form
    {
        private List<Product> l;

        internal List<Product> L { get { return l; } set { l = value; } }


        public Form1()
        {
            InitializeComponent();
            l = new List<Product>();

        }

        //Button Manipulation

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    string st = null;

                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    while ((st = sr.ReadLine()) != null)
                    {
                        string[] dataMas = st.Split(' ');
                        switch (dataMas[0][0])
                        {
                            case 'p': l.Add(new Product(dataMas[1], int.Parse(dataMas[2]), int.Parse(dataMas[3]), int.Parse(dataMas[4]), double.Parse(dataMas[5])));
                                break;
                            case 's': l.Add(new SaleProduct(dataMas[1], int.Parse(dataMas[2]), int.Parse(dataMas[3]), int.Parse(dataMas[4]), double.Parse(dataMas[5]), int.Parse(dataMas[6])));
                                break;
                        }
                    }

                    sr.Close();





                }
                catch (Exception)
                {

                    toolStripStatusLabel1.Text = "Enter Wrong Name of File";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (l.Count != 0)
            {
                foreach (Product el in l)
                {
                    if (el is SaleProduct)
                        listBox1.Items.Add((SaleProduct)el);
                    else
                        listBox1.Items.Add(el);
                }
                listBox1.Items.Add("\n");
            }
            else
                return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double max = l[0].Price;
            int imax = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Price > max)
                {
                    max = l[i].Price;
                    imax = i;
                }
            }

            if (l[imax] is SaleProduct)
            {
                listBox1.Items.Add(l[imax] + " (Акційний Продукт!)");
            }
            else
                listBox1.Items.Add(l[imax] + " (Не Акційний Продукт!)");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(L);
            form3.Owner = this;
            form3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (l.Count != 0)
            {
                int sum;
                if ((textBox1.Text != "") && (int.TryParse(textBox1.Text, out sum)))
                {
                    if ((int.Parse(textBox1.Text) >= 0) && (int.Parse(textBox1.Text) <= l.Count))
                    {
                        l.RemoveAt(int.Parse(textBox1.Text));
                        textBox1.Clear();
                    }
                    else
                        //if (int.Parse(textBox1.Text) < 0 || int.Parse(textBox1.Text) > l.Count)
                        MessageBox.Show("Не забувайте номерація починається з нуля!\n Введіть індекс продукту, який ви хочите видалити.");
                }

                else
                {
                    MessageBox.Show("Ви не ввели номер або ввели не ціле число!");
                }
            }
            else
                MessageBox.Show("Список продуктів порожній!");
        }

        //Обробники Подій
        internal static void WarningMessage(object obj, EventArgs e, Product pd)
        {
            MessageBox.Show("Product (" + pd + ") is spoilage ");
        }

        internal static void GoodMessage(object obj, EventArgs e, Product pd)
        {
            MessageBox.Show("Product (" + pd + ") is not spoilage ");
        }

        //Панель інструментів
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Product el in l)
            {
                if (el is SaleProduct)
                    listBox1.Items.Add((SaleProduct)el);
                else
                    listBox1.Items.Add(el);
            }

        }

        private void toolStripMenuItemOpenFile_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                PathFile.Path1 = openFileDialog1.FileName;
                backgroundWorker1.RunWorkerAsync();
                //try
                //{


                //    string st = null;

                //    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                //    while ((st = sr.ReadLine()) != null)
                //    {
                //        string[] dataMas = st.Split(' ');
                //        switch (dataMas[0][0])
                //        {
                //            case 'p': l.Add(new Product(dataMas[1], int.Parse(dataMas[2]), int.Parse(dataMas[3]), int.Parse(dataMas[4]), double.Parse(dataMas[5])));
                //                break;
                //            case 's': l.Add(new SaleProduct(dataMas[1], int.Parse(dataMas[2]), int.Parse(dataMas[3]), int.Parse(dataMas[4]), double.Parse(dataMas[5]), int.Parse(dataMas[6])));
                //                break;
                //        }
                //    }

                //    sr.Close();





                //}
                //catch (Exception)
                //{

                //    toolStripStatusLabel1.Text = "Enter Wrong Name of File";
                //}
            }
            toolStripMenuItemPrint.Enabled = true;
            toolStripMenuItemSaveToFile.Enabled = true;
            toolStripMenuItemMostExpensive.Enabled = true;
            toolStripMenuItemIsSpoilage.Enabled = true;
            toolStripMenuItemDelAll.Enabled = true;
            toolStripMenuItemShopPrice.Enabled = true;
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            //if ((int.Parse(textBox1.Text) > 30) || (int.Parse(textBox1.Text) < 0) || (int.Parse(((Form2)textBox2).Text) > 12) || (int.Parse(textBox1.Text) < 0) || (int.Parse(textBox3.Text) < 1900))
            //{
            //    MessageBox.Show("You enter wrong date!!!");
            //    return;
            //}

            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Visible = true;

            toolStripMenuItemPrint.Enabled = true;
            toolStripMenuItemSaveToFile.Enabled = true;
            toolStripMenuItemMostExpensive.Enabled = true;
            toolStripMenuItemIsSpoilage.Enabled = true;
            toolStripMenuItemDelAll.Enabled = true;
            toolStripMenuItemShopPrice.Enabled = true;
        }

        private void toolStripMenuItemMostExpensive_Click(object sender, EventArgs e)
        {
            double max = l[0].Price;
            int imax = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Price > max)
                {
                    max = l[i].Price;
                    imax = i;
                }
            }

            if (l[imax] is SaleProduct)
            {
                listBox1.Items.Add(l[imax] + " (Акційний Продукт!)");
            }
            else
                listBox1.Items.Add(l[imax] + " (Не Акційний Продукт!)");
        }

        private void toolStripMenuItemIsSpoilage_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(L);
            form3.Owner = this;
            form3.Visible = true;
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemAbouProg_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox1 = new AboutBox1();
            aboutbox1.Owner = this;
            aboutbox1.Visible = true;
        }



        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    StreamWriter sr = new StreamWriter(saveFileDialog1.FileName);
                    foreach (Product el in l)
                    {
                        sr.WriteLine(el);
                    }

                    sr.Close();
                }
                catch (Exception)
                {

                    toolStripStatusLabel1.Text = "Enter Wrong Name of File";
                }
            }
        }

        private void toolStripMenuItemDelAll_Click(object sender, EventArgs e)
        {
            l.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            foreach (Product el in l)
                if (el is SaleProduct)
                {
                    double sale = (el as SaleProduct).Vartist();
                    MessageBox.Show(sale.ToString(), el.Name);
                }
                else
                    MessageBox.Show(el.Vartist().ToString(), el.Name);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            int amount = 5;



           

                string st = null;

                // StreamReader sr = new StreamReader(openFileDialog1.FileName);
                using (StreamReader sr = File.OpenText(PathFile.Path1))
                {
                    while ((st = sr.ReadLine()) != null)
                    {
                        string[] dataMas = st.Split(' ');
                        switch (dataMas[0][0])
                        {
                            case 'p':
                                {
                                    l.Add(new Product(dataMas[1], int.Parse(dataMas[2]), int.Parse(dataMas[3]), int.Parse(dataMas[4]), double.Parse(dataMas[5])));
                                    break;
                                    count++;
                                }
                            case 's':
                                {
                                    l.Add(new SaleProduct(dataMas[1], int.Parse(dataMas[2]), int.Parse(dataMas[3]), int.Parse(dataMas[4]), double.Parse(dataMas[5]), int.Parse(dataMas[6])));
                                    break;
                                    count++;
                                }
                        }
                        System.Threading.Thread.Sleep(60);
                        backgroundWorker1.ReportProgress((count / amount) * 100);
                    }
                }
                //sr.Close();


            






        }

        public static class PathFile
        {
            private static string path;
            public static string Path1
            {
                get { return path; }
                set { path = value; }
            }
        }

    }
}
