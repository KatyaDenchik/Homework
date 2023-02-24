using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZVP3_1Printing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Журнал");
            comboBox1.Items.Add("Газета");
            comboBox1.Items.Add("Книга");
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            dataGridView1.ColumnCount = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class Printing
        {
            public string name { set; get; }
            public int startYear { set; get; }
            public int countInLib;
            public int countOnReader;

            public Printing() { }

            public void AddCountInLib(int x)
            {
                countInLib += x;
            }

            public void RemoveCountInLib(int x)
            {
                countInLib -= x;
            }

            public void AddCountOnReader(int x)
            {
                countOnReader += x;
            }

            public void DeleteCountOnReader(int x)
            {
                countOnReader -= x;
            }
        }

        public class Magazin : Printing
        {
            public int year;
            public int number;

            public Magazin() { }
        }

        public class Newspaper : Printing
        {
            public int dateStart;

        }

        public class Book : Printing
        {
            public string author;
            public string visionary;
            public int countPages;
            public Book() { }
        }

        public string selectedState;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = comboBox1.SelectedItem.ToString();
            if (selectedState == "Журнал")
            {
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                label6.Text = "Рік: ";
                label7.Text = "Номер видання: ";
                label8.Text = "";
            }
            else if (selectedState == "Газета")
            {
                textBox5.Visible = true;
                textBox6.Visible = false;
                textBox7.Visible = false;
                label6.Text = "Дата видання: ";
                label7.Text = "";
                label8.Text = "";
            }
            else if (selectedState == "Книга")
            {
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                label6.Text = "Автор: ";
                label7.Text = "Видавництво: ";
                label8.Text = "Кількість сторінок: ";
            }
        }

        List<Magazin> listOfMagazins = new List<Magazin>();
        List<Newspaper> listOfNewspapers = new List<Newspaper>();
        List<Book> listOfBooks = new List<Book>();

        public void printData()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < listOfMagazins.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = listOfMagazins[i].name;
                dataGridView1.Rows[i].Cells[1].Value = listOfMagazins[i].startYear;
                dataGridView1.Rows[i].Cells[2].Value = listOfMagazins[i].countInLib;
                dataGridView1.Rows[i].Cells[3].Value = listOfMagazins[i].countOnReader;
                dataGridView1.Rows[i].Cells[4].Value = "Журнал";
                dataGridView1.Rows[i].Cells[5].Value = listOfMagazins[i].year;
                dataGridView1.Rows[i].Cells[6].Value = listOfMagazins[i].number;
            }
            for (int i = listOfMagazins.Count; i < listOfNewspapers.Count + listOfMagazins.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = listOfNewspapers[i - listOfMagazins.Count].name;
                dataGridView1.Rows[i].Cells[1].Value = listOfNewspapers[i - listOfMagazins.Count].startYear;
                dataGridView1.Rows[i].Cells[2].Value = listOfNewspapers[i - listOfMagazins.Count].countInLib;
                dataGridView1.Rows[i].Cells[3].Value = listOfNewspapers[i - listOfMagazins.Count].countOnReader;
                dataGridView1.Rows[i].Cells[4].Value = "Газета";
                dataGridView1.Rows[i].Cells[5].Value = listOfNewspapers[i - listOfMagazins.Count].dateStart;
            }
            for (int i = listOfMagazins.Count + listOfNewspapers.Count; i < listOfBooks.Count + listOfMagazins.Count + listOfNewspapers.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].name;
                dataGridView1.Rows[i].Cells[1].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].startYear;
                dataGridView1.Rows[i].Cells[2].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].countInLib;
                dataGridView1.Rows[i].Cells[3].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].countOnReader;
                dataGridView1.Rows[i].Cells[4].Value = "Книга";
                dataGridView1.Rows[i].Cells[5].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].author;
                dataGridView1.Rows[i].Cells[6].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].visionary;
                dataGridView1.Rows[i].Cells[7].Value = listOfBooks[i - listOfMagazins.Count - listOfNewspapers.Count].countPages;
            }
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (selectedState == "Журнал")
            {
                Magazin newMagazin = new Magazin();
                newMagazin.name = textBox1.Text;
                newMagazin.startYear = Int16.Parse(textBox2.Text);
                newMagazin.countInLib = Int32.Parse(textBox3.Text);
                newMagazin.countOnReader = Int32.Parse(textBox4.Text);
                newMagazin.year = Int16.Parse(textBox5.Text);
                newMagazin.number = Int32.Parse(textBox6.Text);
                listOfMagazins.Add(newMagazin);
            }
            else if (selectedState == "Газета")
            {
                Newspaper newNewspaper = new Newspaper();
                newNewspaper.name = textBox1.Text;
                newNewspaper.startYear = Int16.Parse(textBox2.Text);
                newNewspaper.countInLib = Int32.Parse(textBox3.Text);
                newNewspaper.countOnReader = Int32.Parse(textBox4.Text);
                newNewspaper.dateStart = Int16.Parse(textBox5.Text);
                listOfNewspapers.Add(newNewspaper);
            }
            else if (selectedState == "Книга")
            {
                Book newBook = new Book();
                newBook.name = textBox1.Text;
                newBook.startYear = Int16.Parse(textBox2.Text);
                newBook.countInLib = Int32.Parse(textBox3.Text);
                newBook.countOnReader = Int32.Parse(textBox4.Text);
                newBook.author = textBox5.Text;
                newBook.visionary = textBox6.Text;
                newBook.countPages = Int16.Parse(textBox7.Text);
                listOfBooks.Add(newBook);
            }
            printData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int temp = Int32.Parse(textBox8.Text) - 1;
            int count = Int32.Parse(textBox9.Text);
            if (temp < listOfMagazins.Count)
            {
                listOfMagazins[temp].AddCountInLib(count);
            }
            else if (temp >= listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count)
            {
                listOfNewspapers[temp - listOfMagazins.Count].AddCountInLib(count);
            }
            else if (temp >= listOfNewspapers.Count + listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count + listOfBooks.Count)
            {
                listOfBooks[temp - listOfMagazins.Count - listOfNewspapers.Count].AddCountInLib(count);
            }
            printData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int temp = Int32.Parse(textBox8.Text) - 1;
            int count = Int32.Parse(textBox9.Text);
            if (temp < listOfMagazins.Count)
            {
                listOfMagazins[temp].RemoveCountInLib(count);
            }
            else if (temp >= listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count)
            {
                listOfNewspapers[temp - listOfMagazins.Count].RemoveCountInLib(count);
            }
            else if (temp >= listOfNewspapers.Count + listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count + listOfBooks.Count)
            {
                listOfBooks[temp - listOfMagazins.Count - listOfNewspapers.Count].RemoveCountInLib(count);
            }
            printData();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int temp = Int32.Parse(textBox8.Text) - 1;
            int count = Int32.Parse(textBox9.Text);
            if (temp < listOfMagazins.Count)
            {
                listOfMagazins[temp].AddCountOnReader(count);
            }
            else if (temp >= listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count)
            {
                listOfNewspapers[temp - listOfMagazins.Count].AddCountOnReader(count);
            }
            else if (temp >= listOfNewspapers.Count + listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count + listOfBooks.Count)
            {
                listOfBooks[temp - listOfMagazins.Count - listOfNewspapers.Count].AddCountOnReader(count);
            }
            printData();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int temp = Int32.Parse(textBox8.Text) - 1;
            int count = Int32.Parse(textBox9.Text);
            if (temp < listOfMagazins.Count)
            {
                listOfMagazins[temp].DeleteCountOnReader(count);
            }
            else if (temp >= listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count)
            {
                listOfNewspapers[temp - listOfMagazins.Count].DeleteCountOnReader(count);
            }
            else if (temp >= listOfNewspapers.Count + listOfMagazins.Count && temp < listOfNewspapers.Count + listOfMagazins.Count + listOfBooks.Count)
            {
                listOfBooks[temp - listOfMagazins.Count - listOfNewspapers.Count].DeleteCountOnReader(count);
            }
            printData();
        }
    }
}