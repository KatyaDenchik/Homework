namespace Total1IZVP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        List<Student> studentsClear = new List<Student>();

        private void ShowData(ref List<Student> temp)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                dataGridView1.Rows.Add(temp[i].name, temp[i].yearBirth, temp[i].group,
                    temp[i].grades[0], temp[i].grades[1], temp[i].grades[2],
                    temp[i].grades[3], temp[i].avg);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ClassSerialize.DeserializationFromXml<List<Student>>(ref students, openFileDialog1.FileName);
            }
            ShowData(ref students);
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
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ClassSerialize.DeserializationFromXml<List<Student>>(ref studentsClear, saveFileDialog1.FileName);
                System.IO.File.WriteAllText(saveFileDialog1.FileName, string.Empty);
                studentsClear.Clear();
                ClassSerialize.SerialiazeToXml<List<Student>>(ref students, saveFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClassSerialize.SerialiazeToXml<List<Student>>(ref students, openFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
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


    }
}
