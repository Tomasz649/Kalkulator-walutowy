using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        CurrencyExchange exchange;

        public Form1()
        {
            InitializeComponent();
            exchange = new CurrencyExchange();

            foreach (var currency in exchange.GetCurrencies())
            {
                comboBox1.Items.Add(currency.code);
                comboBox2.Items.Add(currency.code); 
            }

            comboBox1.SelectedItem = "EUR";
            comboBox2.SelectedItem = "PLN";

            comboBox1.SelectedIndexChanged += ComboBoxes_Changed;
            comboBox2.SelectedIndexChanged += ComboBoxes_Changed;
            textBox1.TextChanged += textBox1_TextChanged;
        }


        private void ComboBoxes_Changed(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            if (!double.TryParse(textBox1.Text, out double amount))
            {
                textBox1.BackColor = Color.Red;
                textBox2.Text = "";
                return;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                textBox2.Text = "";
                return;
            }

            try
            {
                string fromCode = comboBox1.SelectedItem.ToString();
                string toCode = comboBox2.SelectedItem.ToString();

                Currency fromCurrency = exchange.GetFromCode(fromCode);
                Currency toCurrency = exchange.GetFromCode(toCode);

                double result = exchange.Convert(amount, fromCurrency, toCurrency);
                textBox2.Text = result.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox2.Text = "";
            }
        }
        private void textBox2_ReadOnlyChanged(object sender, EventArgs e)
        {
        }
    }
}
