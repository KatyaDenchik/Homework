using static IZVP3_3.Form1;
using System.Windows.Forms;

namespace IZVP3_3
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

        public class Book
        {
            public string Name;
            public string Author;
            public string Visionary;

            public Book(string name, string author, string visionary)
            {
                Name = name;
                Author = author;
                Visionary = visionary;
            }
        }

        public  static class Library
        {
            public static List<Book> listOfBooks = new List<Book>();

            public static void AddBook(Book newBook)
            {
                listOfBooks.Add(newBook);
            }

            public static string viewLibrary()
            {
                string temp = "";
                for (int i = 0; i < listOfBooks.Count; i++)
                {
                    temp += "Назва: " + listOfBooks[i].Name + " Автор: " + listOfBooks[i].Author + " Видавництво: " + listOfBooks[i].Visionary + "\n";
                }
                return temp;
            }

            public delegate void sort();

            public static sort sortAuthor = delegate ()
            {
                listOfBooks.Sort(delegate (Book x, Book y)
                {
                    return x.Author.CompareTo(y.Author);
                });
            };

            public static sort sortName = delegate ()
            {
                listOfBooks.Sort(delegate (Book x, Book y)
                {
                    return x.Name.CompareTo(y.Name);
                });
            };

            public static sort sortVisionary = delegate ()
            {
                listOfBooks.Sort(delegate (Book x, Book y)
                {
                    return x.Visionary.CompareTo(y.Visionary);
                });
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Book nBook = new Book(textBox1.Text, textBox2.Text, textBox3.Text);
                Library.AddBook(nBook);
            }
            richTextBox1.Text = Library.viewLibrary();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Library.sortAuthor();
            richTextBox1.Text = Library.viewLibrary();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Library.sortName();
            richTextBox1.Text = Library.viewLibrary();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Library.sortVisionary();
            richTextBox1.Text = Library.viewLibrary();

        }
    }
}