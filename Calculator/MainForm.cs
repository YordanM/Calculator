using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        StringBuilder sb = new StringBuilder();

        double current;
        double memory = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            sb.Append("0");
            textBox1.Text = sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sb.Append("1");
            textBox1.Text = sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sb.Append("2");
            textBox1.Text = sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sb.Append("3");
            textBox1.Text = sb.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sb.Append("4");
            textBox1.Text = sb.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sb.Append("5");
            textBox1.Text = sb.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sb.Append("6");
            textBox1.Text = sb.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sb.Append("7");
            textBox1.Text = sb.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sb.Append("8");
            textBox1.Text = sb.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sb.Append("9");
            textBox1.Text = sb.ToString();
        }

        private void MemoryClearButton_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            sb.Remove(0, sb.Length);
            textBox1.Text = sb.ToString();
        }

        private void percentageDivisionButton_Click(object sender, EventArgs e)
        {
            sb.Append(" % ");
            textBox1.Text = sb.ToString();
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            if (sb.Length == 0)
            {
                return;
            }
            if (sb[sb.Length - 1] == ' ')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Remove(sb.Length - 1, 1);

            textBox1.Text = sb.ToString();
        }
        //

        private void divButton_Click(object sender, EventArgs e)
        {
            sb.Append(" ÷ ");
            textBox1.Text = sb.ToString();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            sb.Append(" + ");
            textBox1.Text = sb.ToString();
        }

        private void commaButton_Click(object sender, EventArgs e)
        {
            sb.Append(",");
            textBox1.Text = sb.ToString();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            sb.Append(" - ");
            textBox1.Text = sb.ToString();
        }

        private void memoryPlusButton_Click(object sender, EventArgs e)
        {
            char[] separator = { ' ' };

            string[] input = textBox1.ToString().Split(separator);
            int lastIndex = input.Length - 1;

            double.TryParse(input[lastIndex], out current);
            memory += current;
        }

        private void multiplicationButton_Click(object sender, EventArgs e)
        {
            sb.Append(" × ");
            textBox1.Text = sb.ToString();
        }

        private void memoryMinusButton_Click(object sender, EventArgs e)
        {
            char[] separator = { ' ' };

            string[] input = textBox1.ToString().Split(separator);
            int lastIndex = input.Length - 1;

            double.TryParse(input[lastIndex], out current);
            memory -= current;
        }

        private void memoryRecall_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
        }

        private void clearEntryButton_Click(object sender, EventArgs e)
        {
            char[] separator = { ' ' };

            string[] input = sb.ToString().Split(separator);

            string lastEntry = input[input.Length - 1];

            int startLenght = sb.Length - lastEntry.Length;
            int endIndex = lastEntry.Length;

            sb.Remove(startLenght, endIndex);
            textBox1.Text = sb.ToString();
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            char[] separator = { ' ' };

            string[] input = sb.ToString().Split(separator).ToArray();

            if (!FirstCheckInput(input))
            {
                MessageBox.Show("Invalid input. Please try again!");
                sb.Clear();
                return;
            }

            input = SquareRootSimplifying(input).Split(separator);

            input = SecondPowerSimplifying(input).Split(separator);


            if (!SecondCheckInput(input))
            {
                MessageBox.Show("Invalid input. Please try again!");
                sb.Clear();
                return;
            }

            textBox1.Text = CalculateSimplifiedExpression(input).ToString();
            sb.Clear();
        }

        private void squareRootButton_Click(object sender, EventArgs e)
        {
            sb.Append("√ ");
            textBox1.Text = sb.ToString();
        }

        private void secondPowerButton_Click(object sender, EventArgs e)
        {
            sb.Append(" ²");
            textBox1.Text = sb.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private string SecondPowerSimplifying(string[] input)
        {
            string oldInput;
            string newInput;

            for (int j = 0; j < input.Length; j++)
            {
                double value = 0;

                if (input[j] == "²")
                {
                    /*if (input.[j - ] == 1)
                    {
                        MessageBox.Show("Invalid input. Please try again!");
                        return sb.Clear().ToString();
                    } TO DO!!!*/

                    value = Math.Pow(double.Parse(input[j - 1]), 2);
                    oldInput = $"{input[j - 1]} ²";
                    newInput = $"{value.ToString()}";
                    sb.Replace(oldInput, newInput);
                }
            }
            return sb.ToString();
        }

        private string SquareRootSimplifying (string[] input)
        {
            string oldInput;
            string newInput;

            for (int j = 0; j < input.Length; j++)
            {
                double value = 0;

                if (input[j] == "√")
                {
                    value = Math.Sqrt(double.Parse(input[j + 1]));
                    oldInput = $"√ {input[j + 1]}";
                    newInput = $"{value.ToString()}";
                    sb.Replace(oldInput, newInput);
                }
            }

            return sb.ToString();
        }

        private double CalculateSimplifiedExpression(string[] input)
        {
            double firstTemp = 0;
            double secondTemp = 0;
            string symbol;
            double total = double.Parse(input[0]);

            for (int i = 1; i < input.Length; i = i + 2)
            {
                firstTemp = double.Parse(input[i - 1]);
                secondTemp = double.Parse(input[i + 1]);
                symbol = input[i];

                if (symbol == "+")
                {
                    total = firstTemp + secondTemp;
                }
                else if (symbol == "-")
                {
                    total = firstTemp - secondTemp;
                }
                else if (symbol == "%")
                {
                    total = firstTemp / secondTemp * 100;
                }
                else if (symbol == "×")
                {
                    total = firstTemp * secondTemp;
                }
                else if (symbol == "÷")
                {
                    if (secondTemp != 0)
                    {
                        total = firstTemp / secondTemp;
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please try again!");
                        sb.Clear();
                        return 0;
                    }
                }

                input[i + 1] = total.ToString();
            }
            return total;
        }

        private bool FirstCheckInput(string[] input)
        {
            double num;
            int index = 0;
            string currentString;
            //"²", "√"
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "²")
                {
                    index = i;
                    if (input.Length - i >=  1 && !double.TryParse(input[i - 1], out num))
                    {
                        return false;
                    }
                }
                if (input[i] == "√")
                {
                    index = i;
                    if (input.Length - i > 1 && !double.TryParse(input[i + 1], out num))
                    {
                        return false;
                    }
                }
                if (input[i].Contains("√"))
                {
                    string checkString = input[i];
                    if (!(checkString[0] == '√'))
                    {
                        return false;
                    }
                }
                if (input[i].Contains("²"))
                {
                    string checkString = input[i];
                    if (!(checkString[checkString.Length - 1] == '²'))
                    {
                        return false;
                    }
                }
                currentString = input[i];
                for (int j = 0; j < currentString.Length; j++)
                {
                    if (currentString[j] == ',' && j == 0)
                    {
                        return false;
                    }
                }
            }
            if (input.Length == 1 && input[0] == "")
            {
                return false;
            }
            return true;
        }

        private bool SecondCheckInput(string[] input)
        {
            double num;
            string[] symbols = { "+", "-", "%", "÷", "×" };
            //"²", "√"
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (input[i] == symbols[j])
                    {
                        if (!(double.TryParse(input[i - 1], out num) && double.TryParse(input[i + 1], out num)))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
