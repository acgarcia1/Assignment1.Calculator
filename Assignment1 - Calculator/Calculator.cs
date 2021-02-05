using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1___Calculator
{ //Alexander Garcia 
    public partial class Calculator : Form
    {
        string input = string.Empty;
        string operand = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyPress += Calculator_KeyPress;
        }

        void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case 48:
                    num0_Click(num0, new EventArgs());
                    break;
                case 49:
                    num1_Click(num1, new EventArgs());
                    break;
                case 50:
                    num2_Click(num2, new EventArgs());
                    break;
                case 51:
                    num3_Click(num3, new EventArgs());
                    break;
                case 52:
                    num4_Click(num4, new EventArgs());
                    break;
                case 53:
                    num5_Click(num5, new EventArgs());
                    break;
                case 54:
                    num6_Click(num6, new EventArgs());
                    break;
                case 55:
                    num7_Click(num7, new EventArgs());
                    break;
                case 56:
                    num8_Click(num8, new EventArgs());
                    break;
                case 57:
                    button14_Click(num9, new EventArgs());
                    break;
                case 61:
                    Equal_Click(Equal, new EventArgs());
                    break;
                case 43:
                    Add_Click(Add, new EventArgs());
                    break;
                case 45:
                    subtract_Click(Subtract, new EventArgs());
                    break;
                case 47:
                    Divide_Click(Divide, new EventArgs());
                    break;
                case 42:
                    Multi_Click(Multi, new EventArgs());                
                    break;
                case 10:  //I thought that the enter key would create a newline so its decimal code is 10, but it doesn't seem to work
                    Equal_Click(Equal, new EventArgs());
                    break;
                case 46:
                    Period_Click(Period, new EventArgs());
                    break;

            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            //SquareRoot
            double square = 0;
            double.TryParse(input, out square);
            if (square < 0)
            {
                textBox1.Text = "Can't Square Root Negative Number";
            }
            else
            {
                square = Math.Sqrt(square);
                textBox1.Text = textBox1.Text + '=' + square.ToString() + ' ';
                textBox2.Text = textBox2.Text + '=' + square.ToString() + ' ';
            }
        }

        private void Squared_Click(object sender, EventArgs e)
        {
            double sqr = 0;
            double.TryParse(input, out sqr);
            sqr = Math.Pow(sqr, 2);
            textBox1.Text = textBox1.Text + '=' + sqr.ToString() + ' ';
            textBox2.Text = textBox2.Text + '=' + sqr.ToString() + ' ';
        }

        private void XtoYpow_Click(object sender, EventArgs e)
        {
            double pow = 0;
            double y = 0;
            double.TryParse(input, out pow);
            /*I am stuck on how to get a power from the user and seperate it after pressing the button
              attempted to set the input to an empty string and take in a new input, but that would 
              require entering this button method again. I look forward to the peer reviews so I can 
              compare and contrast ideas. 
            */
            double.TryParse(input, out y);
            pow = Math.Pow(pow, y);
            textBox1.Text = textBox1.Text + '=' + pow.ToString() + ' ';
            textBox2.Text = textBox2.Text + '=' + pow.ToString() + ' ';
        }

        private void DivideX_Click(object sender, EventArgs e)
        {
            double Divide = 0;
            double.TryParse(input, out Divide);
            Divide = 1 / Divide;
            textBox1.Text = textBox1.Text + '=' + Divide.ToString() + ' ';
            textBox2.Text = textBox2.Text + '=' + Divide.ToString() + ' ';
        }

        private void CE_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.input = string.Empty;
            this.operand = string.Empty;
            this.operand2 = string.Empty;
        }

        private void C_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.input = string.Empty;
            this.operand = string.Empty;
            this.operand2 = string.Empty;
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                input = input.Remove(input.Length - 1);
            }         
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            operand = input;
            operation = '/';
            textBox1.Text += operation;
            textBox2.Text += operation;
            input = string.Empty;
        }
       
        private void Multi_Click(object sender, EventArgs e)
        {
            operand = input;
            operation = '*';
            textBox1.Text += operation;
            textBox2.Text += operation;
            input = string.Empty;
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            operand = input;
            operation = '-';
            textBox1.Text += operation;
            textBox2.Text += operation;
            input = string.Empty;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int count = 0;
            operand = input;
            operation = '+';
            textBox1.Text += operation;
            textBox2.Text += operation;
            input = string.Empty;        
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            operand2 = input;
            double num1 = 0;
            double num2 = 0;
            double.TryParse(operand, out num1);
            double.TryParse(operand2, out num2);

            if(operation == '+') //Addition
            {
                result = num1 + num2;
                textBox1.Text = result.ToString();
                textBox2.Text = textBox2.Text + '=' + result.ToString() + ' ';

            }
            else if (operation == '-') //Subtraction
            {
                result = num1 - num2;
                textBox1.Text = result.ToString();
                textBox2.Text = textBox2.Text + '=' + result.ToString() + ' ';
            }
            else if(operation == '*') //Multiplication
            {
                result = num1 * num2;
                textBox1.Text = result.ToString();
                textBox2.Text = textBox2.Text + '=' + result.ToString() + ' ';
            }
            else if(operation == '/') //Division
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                    textBox1.Text = result.ToString();
                    textBox2.Text = textBox2.Text + '=' + result.ToString() + ' ';
                }
                else
                {
                    textBox1.Text = "Cannot Divide by Zero.";
                    input = String.Empty;
                }
            }
            input = result.ToString();
        }   


        private void Period_Click(object sender, EventArgs e)
        {
            input += '.';
            textBox1.Text += '.';
            textBox2.Text += '.';
        }

        private void Plusminswap_Click(object sender, EventArgs e)
        {
            if(!textBox1.Text.Contains('-'))
            {
                textBox1.Text = '-' + textBox1.Text;
                textBox2.Text = '-' + textBox2.Text;
                input = "-" + input;
            }
            else
            {
                textBox1.Text = textBox1.Text.Trim('-');
                textBox2.Text = textBox2.Text.Trim('-');
            }          
        }
        private void button14_Click(object sender, EventArgs e)
        {
            //Button #9      
            input += 9;
            textBox1.Text += 9;
            textBox2.Text += 9;
        }
        private void num8_Click(object sender, EventArgs e)
        {           
            input += 8;
            textBox1.Text += 8;
            textBox2.Text += 8;
        }
        private void num7_Click(object sender, EventArgs e)
        {          
            input += 7;
            textBox1.Text += 7;
            textBox2.Text += 7;
        }
        private void num6_Click(object sender, EventArgs e)
        {            
            input += 6;
            textBox1.Text += 6;
            textBox2.Text += 6;
        }

        private void num5_Click(object sender, EventArgs e)
        {            
            input += 5;
            textBox1.Text += 5;
            textBox2.Text += 5;
        }

        private void num4_Click(object sender, EventArgs e)
        {           
            input += 4;
            textBox1.Text += 4;
            textBox2.Text += 4;
        }

        private void num3_Click(object sender, EventArgs e)
        {
            input += 3;
            textBox1.Text += 3;
            textBox2.Text += 3;
        }

        private void num2_Click(object sender, EventArgs e)
        {          
            input += 2;
            textBox1.Text += 2;
            textBox2.Text += 2;
        }

        private void num1_Click(object sender, EventArgs e)
        {           
            input += 1;
            textBox1.Text += 1;
            textBox2.Text += 1;
        }

        private void num0_Click(object sender, EventArgs e)
        {
            input += 0;
            textBox1.Text += 0;
            textBox2.Text += 0;
        }
    }
}
