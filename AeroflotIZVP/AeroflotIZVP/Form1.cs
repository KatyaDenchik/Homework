using System.Net;

namespace AeroflotIZVP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct Aeroflot
        {
            public string destinationPointOfTheFlight;
            public string flightNumber;
            public string typeOfAircraft;
        }
        private Aeroflot[] aeroflots = new Aeroflot[7];
        private int n = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            Aeroflot aeroflot = new Aeroflot();
            aeroflot.destinationPointOfTheFlight = textBox1.Text;
            aeroflot.flightNumber = textBox2.Text;
            aeroflot.typeOfAircraft = textBox3.Text;
            dataGridView1.Rows.Add(aeroflot.destinationPointOfTheFlight, aeroflot.flightNumber, aeroflot.typeOfAircraft);
            aeroflots[n] = aeroflot;
            n++;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string point = textBox4.Text;
            bool isFind = false;
            dataGridView1.RowCount = aeroflots.Length;
            dataGridView1.ColumnCount = 3; 

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            for (int i = 0; i < aeroflots.Length; i++)
            {

                if (aeroflots[i].destinationPointOfTheFlight==point)
                {
                    dataGridView1.Rows.Add(aeroflots[i].destinationPointOfTheFlight, aeroflots[i].flightNumber, aeroflots[i].typeOfAircraft);
                    isFind = true;
                }
                   
            }

            if (!isFind)
                MessageBox.Show("Таких рейсів немає.");
        }
    }
}