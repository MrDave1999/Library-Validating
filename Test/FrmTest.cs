using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ValidBox;

namespace Test
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    validTextBox1.Type = TypeValid.Letter;
                    break;
                case 1:
                    validTextBox1.Type = TypeValid.Numeric;
                    break;
                case 2:
                    validTextBox1.Type = TypeValid.Numeric;
                    break;
                case 3:
                    validTextBox1.Type = TypeValid.Decimal;
                    break;
                case 4:
                    validTextBox1.Type = TypeValid.SDecimal;
                    break;
                case 5:
                    validTextBox1.Type = TypeValid.SNumeric;
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double temp;
            if (validTextBox1.Type == TypeValid.SDecimal)
            {
                temp = ValidString.ToDouble(validTextBox1.Text, 'S');
                MessageBox.Show("La temperatura fue de " + temp);
            }
            else
                MessageBox.Show("Dato: " + validTextBox1.Text);
        }

        private void validTextBox1_Validating(object sender, CancelEventArgs e)
        {
            int age;
            double price;
            if(validTextBox1.Type == TypeValid.Numeric)
            {
                if(comboBox1.SelectedIndex == 1 && validTextBox1.Text.Length != 10)
                {
                    validTextBox1.MsgError.SetError(validTextBox1, "La cedula solo puede ser de 10 dígitos.");
                    e.Cancel = true;
                }
                else if(comboBox1.SelectedIndex == 2)
                {
                    age = Convert.ToInt32(validTextBox1.Text);
                    if(validTextBox1.Text.Length != 3)
                    {
                        validTextBox1.MsgError.SetError(validTextBox1, "La edad solo puede ser de 3 digitos");
                        e.Cancel = true;
                    }
                    if(!(age >= 1 && age <= 110))
                    {
                        validTextBox1.MsgError.SetError(validTextBox1, "La edad debe estar en el rango de 1 al 110.");
                        e.Cancel = true;
                    }
                }
            }
            else if(validTextBox1.Type == TypeValid.Decimal)
            {
                price = ValidString.ToDouble(validTextBox1.Text);
                if(!(price >= 1 && price <= 5000))
                {
                    validTextBox1.MsgError.SetError(validTextBox1, "El precio debe estar en el rango de 1 a 5000 USD.");
                    e.Cancel = true;
                }
            }
        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
