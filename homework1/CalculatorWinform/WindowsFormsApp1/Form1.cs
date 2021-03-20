using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string sign;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void equalbutton_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(this.textBox1.Text);
            double num2 = double.Parse(this.textBox2.Text);
            switch (sign)
            {
                case "+": textBox3.Text = (num1 + num2).ToString(); break;
                case "-": textBox3.Text = (num1 - num2).ToString(); break;
                case "*": textBox3.Text = (num1 * num2).ToString(); break;
                case "/": textBox3.Text = (num1 / num2).ToString(); break;
                case "^": textBox3.Text = Math.Pow(num1, num2).ToString(); break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sign = "+";
        }

        private void minusbutton_Click(object sender, EventArgs e)
        {
            sign = "-";
        }

        private void multiplebutton_Click(object sender, EventArgs e)
        {
            sign = "*";
        }

        private void dividebutton_Click(object sender, EventArgs e)
        {
            sign = "/";
        }

        private void powerbutton_Click(object sender, EventArgs e)
        {
            sign = "^";
        }
    }
}
