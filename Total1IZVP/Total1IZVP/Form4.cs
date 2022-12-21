namespace Total1IZVP
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        public void ShowData(ref List<Student> temp)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].grades[1] == 8 || temp[i].grades[1] == 9 || temp[i].name[0].Equals('А'))
                {
                    dataGridView1.Rows.Add(temp[i].name, temp[i].yearBirth, temp[i].group,
                        temp[i].grades[0], temp[i].grades[1], temp[i].grades[2],
                        temp[i].grades[3], temp[i].avg);
                }
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
    }
}
