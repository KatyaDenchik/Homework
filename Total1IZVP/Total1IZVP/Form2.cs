namespace Total1IZVP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<Student> students = new List<Student>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                double avg = (Convert.ToDouble(textBox4.Text)
                            + Convert.ToDouble(textBox5.Text)
                            + Convert.ToDouble(textBox6.Text)
                            + Convert.ToDouble(textBox7.Text)) / 4;
                textBox8.Text = Convert.ToString(avg);
            }
            else MessageBox.Show("Всі оцінки повинні бути внесені.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" &&
                textBox7.Text != "" && textBox8.Text != "")
            {
                Student stud = new Student();
                stud.name = textBox1.Text;
                stud.yearBirth = Convert.ToInt32(textBox2.Text);
                stud.group = textBox3.Text;
                stud.grades = new int[4];
                stud.grades[0] = Convert.ToInt32(textBox4.Text);
                stud.grades[1] = Convert.ToInt32(textBox5.Text);
                stud.grades[2] = Convert.ToInt32(textBox6.Text);
                stud.grades[3] = Convert.ToInt32(textBox7.Text);
                stud.avg = Convert.ToDouble(textBox8.Text);
                students.Add(stud);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
            else MessageBox.Show("Всі поля повинні бути заповненими.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = @"";
            str += textBox9.Text;
            ClassSerialize.SerialiazeToXml<List<Student>>(ref students, str);
        }
    }
}
