using System.Security.Authentication;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        Klasa exchange;
        public Form1()
        {
            InitializeComponent();
            exchange = new Klasa();
        }

        private void textBox2_ReadOnlyChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)

        {


            if (!double.TryParse(textBox1.Text, out double currency))
            {
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }
            double rate = 0.00;



            if (radioButton1.Checked)
            {
                rate = exchange.toPLN(currency, Currency.EUR);
            }
            if (radioButton2.Checked)
            {
                rate = exchange.toPLN(currency, Currency.GBP);
            }
            if (radioButton3.Checked)
            {
                rate = exchange.toPLN(currency, Currency.USD);
            }


            textBox2.Text = rate.ToString("0.00");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
