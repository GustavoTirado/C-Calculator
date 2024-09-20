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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        double firstNumber = 0;
        double secondNumber = 0;
        string operation = "";
        bool isOperationPerformed = false;
        bool resultDisplayed = false;
        string operationHistory = "";

        private void Calculatorclick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (char.IsDigit(button.Text, 0))
            {
                if ((answer.Text == "0") || (isOperationPerformed) || resultDisplayed)
                {
                    answer.Clear();
                }

                isOperationPerformed = false;
                resultDisplayed = false;
                answer.Text += button.Text;

                operationHistory += button.Text;
                math.Text = operationHistory;
            }
            else
            {
                switch (button.Text)
                {
                    case "C":
                        answer.Clear();
                        answer.Text = "0";
                        firstNumber = 0;
                        secondNumber = 0;
                        operation = "";
                        isOperationPerformed = false;
                        resultDisplayed = false;
                        operationHistory = "";
                        math.Text = "";
                        break;

                    case "x^2":
                        firstNumber = Double.Parse(answer.Text);
                        answer.Text = Math.Pow(firstNumber, 2).ToString();
                        resultDisplayed = true;

                        operationHistory = "ans";
                        math.Text = "ans";
                        break;

                    case "=":
                        if (!string.IsNullOrEmpty(operation))
                        {
                            secondNumber = Double.Parse(answer.Text);

                            switch (operation)
                            {
                                case "√":
                                    answer.Text = Math.Sqrt(firstNumber).ToString();
                                    break;
                                case "+":
                                    answer.Text = (firstNumber + secondNumber).ToString();
                                    break;
                                case "-":
                                    answer.Text = (firstNumber - secondNumber).ToString();
                                    break;
                                case "*":
                                    answer.Text = (firstNumber * secondNumber).ToString();
                                    break;
                                case "/":
                                    if (secondNumber != 0)
                                        answer.Text = (firstNumber / secondNumber).ToString();
                                    else
                                        MessageBox.Show("No se puede dividir por cero");
                                    break;
                            }

                            resultDisplayed = true;
                            isOperationPerformed = false;
                            math.Text = $"ans";
                            operation = "";
                            operationHistory = "";
                        }
                        break;

                    default:
                        if (resultDisplayed)
                        {
                            firstNumber = Double.Parse(answer.Text);
                        }
                        else
                        {
                            firstNumber = Double.Parse(answer.Text);
                        }

                        operation = button.Text;
                        isOperationPerformed = true;
                        resultDisplayed = false;

                        operationHistory = $" {operation} ";
                        math.Text = operationHistory;
                        break;
                }
            }
        }


    }
}
