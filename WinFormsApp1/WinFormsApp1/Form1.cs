using RationalNumbers;
using System.Net;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public List<RationalNumber> rationalNumbers = new List<RationalNumber>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetValidRationalNumbers();
            var list = FormList();

            richTextBox2.Text = list.FormatToString();

            list.Remove(list.First());
            list.Remove(list.Last());

            richTextBox3.Text = list.FormatToString();
        }
        private List<RationalNumber> FormList() =>
            rationalNumbers.Select(s => { s.Swip(); return s; }).OrderByDescending(s => s.Numerator / s.Denominator).ToList();


        public void GetValidRationalNumbers()
        {
            var regex = new Regex("[0-9]+/[0-9]+");
            var matches = regex.Matches(richTextBox1.Text);
            foreach (var match in matches)
            {
                string[] substring = match.ToString().Split('/');

                var rationalNumber = new RationalNumber()
                {
                    Numerator = int.Parse(substring[0]),
                    Denominator = int.Parse(substring[1])
                };

                rationalNumbers.Add(rationalNumber);
            }
        }
    }
}