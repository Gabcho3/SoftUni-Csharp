using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultilplicationTable
{
    public partial class Calcolator : Form
    {
        public Calcolator()
        {
            InitializeComponent();
        }
        int numCounter = 0;
        bool error = false;
        bool plus = false;
        bool minus = false;
        bool multiplication = false;
        bool division = false;
        bool percent = false;
        bool equals = false;
        double sum;
        private void zero_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (numCounter > 1)
            {
                if (error)
                {
                    numbers.Text = "";
                    numCounter = 1;
                    error = false;
                }
                if (numCounter > 10)
                {
                    error = true;
                    numbers.Text = "Error!";
                }
                else if (numCounter == 4)
                {
                    numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "0";
                }
                else if (numCounter == 5)
                {
                    numbers.Text = numbers.Text[0].ToString() + "0 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
                }
                else if (numCounter == 6)
                {
                    numbers.Text = numbers.Text[0].ToString() + "0" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
                }
                else if (numCounter == 7)
                {
                    numbers.Text = numbers.Text[0].ToString() + " 0" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
                }
                else if (numCounter == 8)
                {
                    numbers.Text = numbers.Text[0].ToString() + "0 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
                }
                else if (numCounter == 9)
                {
                    numbers.Text = numbers.Text[0].ToString() + "0" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
                }
                else if (numCounter == 10)
                {
                    numbers.Text = numbers.Text[0].ToString() + " 0" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
                }
                else
                {
                    numbers.Text = numbers.Text + "0";
                }
            }
        }
        private void one_Click(object sender, EventArgs e)
        {
            numCounter++;
            if(equals)
            {
                numbers.Text = "";
                equals = false;
            }
            if(error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if(numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "1";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "1 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "1" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 1" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "1 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "1" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 1" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "1";
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "2";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "2 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "2" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 2" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "2 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "2" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 2" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "2";
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "3";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "3 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "3" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 3" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "3 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "3" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 3" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "3";
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "4";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "4 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "4" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 4" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "4 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "4" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 4" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "4";
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "5";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "5 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "5" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 5" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "5 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "5" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 5" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "5";
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
        
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "6";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "6 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "6" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 6" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "6 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "6" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 6" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "6";
            }
        }

        private void seven_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "7";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "7 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "7" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 7" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "7 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "7" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 7" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "7";
            }
        }

        private void eight_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "8";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "8 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "8" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 8" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "8 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "8" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 8" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "8";
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            numCounter++;
            if (error)
            {
                numbers.Text = "";
                numCounter = 1;
                error = false;
            }
            if (numCounter > 10)
            {
                error = true;
                numbers.Text = "Error!";
            }
            else if (numCounter == 4)
            {
                numbers.Text = numbers.Text[0].ToString() + " " + numbers.Text[1].ToString() + numbers.Text[2].ToString() + "9";
            }
            else if (numCounter == 5)
            {
                numbers.Text = numbers.Text[0].ToString() + "9 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString();
            }
            else if (numCounter == 6)
            {
                numbers.Text = numbers.Text[0].ToString() + "9" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString();
            }
            else if (numCounter == 7)
            {
                numbers.Text = numbers.Text[0].ToString() + " 9" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString();
            }
            else if (numCounter == 8)
            {
                numbers.Text = numbers.Text[0].ToString() + "9 " + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString();
            }
            else if (numCounter == 9)
            {
                numbers.Text = numbers.Text[0].ToString() + "9" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString();
            }
            else if (numCounter == 10)
            {
                numbers.Text = numbers.Text[0].ToString() + " 9" + numbers.Text[1].ToString() + numbers.Text[2].ToString() + numbers.Text[3].ToString() + numbers.Text[4].ToString() + numbers.Text[5].ToString() + numbers.Text[6].ToString() + numbers.Text[7].ToString() + numbers.Text[8].ToString() + numbers.Text[9].ToString() + numbers.Text[10].ToString();
            }
            else if (numCounter < 4)
            {
                numbers.Text = numbers.Text + "9";
            }
        }
        int plusCount;
        double result = 0;
        private void PlusButton_Click(object sender, EventArgs e)
        {
            percentFirst = 2;//percent is already not first
            plus = true;
            result = double.Parse(numbers.Text);
            plusCount++;
            if (plusCount == 1)
            {
                sum = result;
            }
            numbers.Text = "";
            numCounter = 0;
        }
        int minusCount = 0;
        private void Minus_Click(object sender, EventArgs e)
        {
            percentFirst = 2; //percent is already not first
            minus = true;
            result = double.Parse(numbers.Text);
            minusCount++;
            if (minusCount == 1)
            {
                sum = result;
            }
            numbers.Text = "";
            numCounter = 0;
        }

        int multiplicationCount = 0;
        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            percentFirst = 2; //percent is already not first
            multiplication = true;
            result = double.Parse(numbers.Text);
            multiplicationCount++;
            if (multiplicationCount == 1)
            {
                sum = result;
            }
            numbers.Text = "";
            numCounter = 0;
        }
        int divisionCount = 0;
        private void DivisionButton_Click(object sender, EventArgs e)
        {
            percentFirst = 2; //percent is already not first
            division = true;
            result = double.Parse(numbers.Text);
            divisionCount++;
            if (divisionCount == 1)
            {
                sum = result;
            }
            numbers.Text = "";
            numCounter = 0;
        }
        int percentCount = 0;
        double percentSum = 0;
        int percentFirst = 1;
        private void PercentButton_Click(object sender, EventArgs e)
        {
            percent = true;
            percentSum = double.Parse(numbers.Text) / 100;
            while (percentFirst == 1)
            {
                percentCount++;
                percentFirst++; //percent is already not first
            }
            numbers.Text = percentSum.ToString();
        
            numCounter = 0;
        }
        private void EqualButton_Click(object sender, EventArgs e)
        {
            if (plus)
            {
                if (percent)
                {
                    if (percentCount == 1)
                    {
                        result = double.Parse(numbers.Text);
                    }
                    else result = sum * percentSum;
                }
                else result = int.Parse(numbers.Text);
                sum += result;
                plus = false;
            }
            if (minus)
            {
                if(percent)
                {
                    if (percentCount == 1)
                    {
                        result = double.Parse(numbers.Text);
                    }
                    else result = sum * percentSum;
                }
                else result = double.Parse(numbers.Text);
                sum -= result;
                minus = false;
            }
            if (multiplication)
            {
                result = double.Parse(numbers.Text);
                sum *= result;
                multiplication = false;
            }
            if (division)
            {
                result = double.Parse(numbers.Text);
                sum /= result;
                division = false;
            }
            var sumLength = sum.ToString().Length;
            switch (sumLength)
            {
                case 1: case 2: case 3: numbers.Text = sum.ToString(); break;
                case 4: numbers.Text = sum.ToString()[0] + " " + sum.ToString()[1] + sum.ToString()[2] + sum.ToString()[3]; break;
                case 5: numbers.Text = sum.ToString()[0] + sum.ToString()[1] + " " + sum.ToString()[2] + sum.ToString()[3] + sum.ToString()[4]; break;
                case 6: numbers.Text = sum.ToString()[0] + sum.ToString()[1] + sum.ToString()[2] + " " + sum.ToString()[3] + sum.ToString()[4] + sum.ToString()[5]; break;
                case 7: numbers.Text = sum.ToString()[0] + " " + sum.ToString()[1] + sum.ToString()[2] + sum.ToString()[3] + " " + sum.ToString()[4] + sum.ToString()[5] + sum.ToString()[6]; break;
                case 8: numbers.Text = sum.ToString()[0] + sum.ToString()[1] + " " + sum.ToString()[2] + sum.ToString()[3] + sum.ToString()[4] + " " + sum.ToString()[5] + sum.ToString()[6] + sum.ToString()[7]; break;
                case 9: numbers.Text = sum.ToString()[0] + sum.ToString()[1] + sum.ToString()[2] + " " + sum.ToString()[3] + sum.ToString()[4] + sum.ToString()[5] + " " + sum.ToString()[6] + sum.ToString()[7] + sum.ToString()[8]; break;
                case 10: numbers.Text = sum.ToString()[0] + " " + sum.ToString()[1] + sum.ToString()[2] + sum.ToString()[3] + " " + sum.ToString()[4] + sum.ToString()[5] + sum.ToString()[6] + " " + sum.ToString()[7] + sum.ToString()[8] + sum.ToString()[9]; break;
                default: numbers.Text = "Error!"; break; //over 10 digits
            }
            equals = true;
            percent = false;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            percentFirst = 2; //percent is already not first
            result = 0;
            numCounter = 0;
            numbers.Text = "";
        }
        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            percentFirst = 2; //percent is already not first
            sum = 0;
            result = 0;
            numCounter = 0;
            plusCount = 0;
            minusCount = 0;
            multiplicationCount = 0;
            divisionCount = 0;
            percentCount = 0;
            minus = false;
            plus = false;
            multiplication = false;
            division = false;
            equals = false;
            numbers.Text = "";
        }
    }
}
