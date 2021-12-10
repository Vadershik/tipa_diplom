using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace tipa_diplom
{
    public partial class Form1 : Form
    {
        public long[] ar;
        public int type = 0;
        static long Formula(int i) {
            return (long)Math.Pow(i, 2); //парабола
        }
        static long Formula(int i, int x)
        {
            if (x == 0) return 0;
            return i / x;
        }
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Диапозон: от -50 до 50";
            radioButton2.Checked = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            string text = "";
            switch (trackBar1.Value)
            {
                case 1:
                    text = "-50 до 50";
                    break;
                case 2:
                    text = "-100 до 100";
                    break;
                case 3:
                    text = "-150 до 150";
                    break;
                case 4:
                    text = "-200 до 200";
                    break;
                case 5:
                    text = "-250 до 250";
                    break;
                case 6:
                    text = "-300 до 300";
                    break;
                case 7:
                    text = "-350 до 350";
                    break;
                case 8:
                    text = "-400 до 400";
                    break;
                case 9:
                    text = "-450 до 450";
                    break;
                case 10:
                    text = "-500 до 500";
                    break;
            }
            label1.Text = $"Диапозон: от {text}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "Входные       Выходные\n";
            long[] arr = new long[(trackBar1.Value * 100)+2];

            #region день в пустую
            //for (int i = trackBar1.Value * 100 / 2; i > 0; i--) {
            //    arr[i] = (long)Math.Pow(i/(-1), 2);
            //    richTextBox1.Text += $"{i/(-1)}              {arr[i]}\n";
            //}
            //arr[trackBar1.Value*100/2+1] = 0;
            //richTextBox1.Text += $"0              0\n";
            //long a=1;
            //for (int i = trackBar1.Value*100/2+2; i <= trackBar1.Value*100; i++)
            //{
            //    arr[i] = (long)Math.Pow(a, 2);
            //    richTextBox1.Text += $"{a}                {arr[i]}\n";
            //    a++;
            //}
            //arr[trackBar1.Value * 100 + 1] = (long)Math.Pow(trackBar1.Value*100/2, 2);
            //richTextBox1.Text += $"{trackBar1.Value * 100/2}                {arr[trackBar1.Value * 100 + 1]}";
            #endregion

            int a = 0;
            for (int i = trackBar1.Value*50/(-1); i <= trackBar1.Value*50; i++)
            {
                if (radioButton1.Checked) { arr[a] = i; }
                if (radioButton2.Checked) { arr[a] = Formula(i); }
                richTextBox1.Text += $"{i}              {arr[a]}\n";
                a++;
            }
            ar = arr;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;
            if (ar.Length!=0)
            {
                int x = trackBar1.Value*50/(-1);
                for (int i = 0; i < ar.Length; i++)
                {
                    if (radioButton1.Checked) { chart1.Series[0].Points.AddXY(x, Formula(i,x)); } 
                    chart1.Series[0].Points.AddXY(x, ar[i]);
                    x++;
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = 0;
        }
    }
}
