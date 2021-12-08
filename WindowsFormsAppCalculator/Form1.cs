using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCalculator
{
    public partial class Form1 : Form
    {
        public bool Flag;
        public string Action;
        public string number1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Panel2_Resize(object sender, EventArgs e)
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.Height = panel2.Height / 6;
                button.Width = panel2.Width / 4;
                button.Top = 10;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Flag = false;
            Panel2_Resize(sender, e);
        }

        private void Number_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;

            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }

            textBox1.Text += B.Text;
        }

        private void Delete_CLick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length - 1 < 0) textBox1.Text = "0";
            else
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void Operand_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            Action = B.Text;
            number1 = textBox1.Text;
            textBox1.Text = "";
        }

        private double Calculate()
        {
            if (Action == "+")
            {
                return Convert.ToDouble(number1) + Convert.ToDouble(textBox1.Text);           
            }
            else if (Action == "-")
            {
                return Convert.ToDouble(number1) - Convert.ToDouble(textBox1.Text);
            }
            else if (Action == "*")
            {
                return Convert.ToDouble(number1) * Convert.ToDouble(textBox1.Text);
            }
            else if (Action == "/")
            {
               // if (number1 != "0" && textBox1.Text != "0")
                    return Convert.ToDouble(number1) / Convert.ToDouble(textBox1.Text);
            }
            else if (Action == "%")
            {
                return Convert.ToDouble(number1) * Convert.ToDouble(textBox1.Text) / 100;
            }
            return 0;
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            double res = Calculate();
            textBox1.Text = res.ToString();
            Action = "";
        }

        private void Pow_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Pow(Convert.ToDouble(textBox1.Text), 2)).ToString();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Sqrt(Convert.ToDouble(textBox1.Text))).ToString();
        }

        private void Fraction_Click(object sender, EventArgs e)
        {
            textBox1.Text = (1 / Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void Degree_Click(object sender, EventArgs e)
        {
            double res = Convert.ToDouble(textBox1.Text);
            
            res = -res;
            textBox1.Text = res.ToString();            
        }
    }
}
