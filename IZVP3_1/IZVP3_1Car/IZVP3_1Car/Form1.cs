using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IZVP3_1Car
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class People
        {
            public string fname { set; get; }
            public string lname { set; get; }
            public string phone { set; get; }

            public People(string fn, string ln, string pn)
            {
                fname = fn;
                lname = ln;
                phone = pn;
            }
        }

        public class Auto
        {
            public string regNumber;
            public string model;
            public string color;
            public People data;

            public Auto(string rnn, string mn, string cn, string fn, string ln, string pn)
            {
                regNumber = rnn;
                model = mn;
                color = cn;
                data = new People(fn, ln, pn);
            }
        }

        List<Auto> listOfAutoInfo = new List<Auto>();

       

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            string color = "Naf";
            if (radioButton1.Checked)
            {
                color = "Чорний";
            }
            else if (radioButton2.Checked)
            {
                color = "Білий";
            }
            else if (radioButton3.Checked)
            {
                color = "Червоний";
            }
            Auto newAuto = new Auto(textBox4.Text, textBox5.Text, color, textBox1.Text, textBox2.Text, textBox3.Text);
            listOfAutoInfo.Add(newAuto);
            checkedListBox1.Items.Clear();
            for (int i = 0; i < listOfAutoInfo.Count; ++i)
            {
                checkedListBox1.Items.Add(listOfAutoInfo[i].regNumber);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            List<object> chosenElements = new List<object>();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; ++i)
            {
                chosenElements.Add(checkedListBox1.CheckedItems[i]);
            }
            for (int i = 0; i < chosenElements.Count; i++)
            {
                for (int j = 0; j < listOfAutoInfo.Count; j++)
                {
                    if (chosenElements[i].ToString() == listOfAutoInfo[j].regNumber)
                    {
                        listOfAutoInfo.RemoveAt(j);
                        break;
                    }

                }
            }
            checkedListBox1.Items.Clear();
            for (int i = 0; i < listOfAutoInfo.Count; ++i)
            {
                checkedListBox1.Items.Add(listOfAutoInfo[i].regNumber);
            }
        }
    }
}