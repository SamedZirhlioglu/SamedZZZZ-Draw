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

namespace SamedZZZZ_Draw
{
    public partial class Form1 : Form
    {
        string[] lastList;
        string[] list;
        int[] change;
        int counter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GetList()
        {
            string filePath = openFileDialog1.FileName;

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                listBox1.Items.Add(lines[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            GetList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list = new string[listBox1.Items.Count];
            change = new int[listBox1.Items.Count];

            for (int i = 0; i < list.Length; i++)
            {
                change[i] = 1;

                list[i] = listBox1.Items[i].ToString();
                listBox1.Items[i] = change[i].ToString() + " - " + list[i];
            }

            listBox1.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            counter = 0;
            for(int i = 0; i < change.Length; i++)
            {
                counter += change[i];
            }

            lastList = new string[counter];
            int x = 0;

            for(int i = 0; i < change.Length; i++)
            {
                for(int j = 0; j < change[i]; j++)
                {
                    lastList[x] = list[i];
                    x++;
                }
            }

            label1.Text = counter.ToString();
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            change[index]--;
            if (change[index] < 0) change[index] = 0;

            listBox1.Items[index] = change[index] + " - " + list[index];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            change[index]++;

            listBox1.Items[index] = change[index] + " - " + list[index];
        }

        private void Draw()
        {
            int rand = counter;
            int sayi = new Random().Next(0, rand);
            label2.Text = lastList[sayi];
        }
    }
}
