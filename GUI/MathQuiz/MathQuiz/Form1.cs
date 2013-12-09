using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //initialize a new instance of Random class
        Random randomizer = new Random();

        //use these 2 for addition problem
        int addend1;
        int addend2;

        //subtraction problem
        int minuend;
        int subtrahend;

        //multiplication problem
        int leftFactor;
        int rightFactor;

        //division
        int dividend;
        int divisor;

        //Keep track of remaining time
        int timeLeft;

        const int initialTime = 20;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Start the quiz by filling in all of the problems 
        /// and starting the timer. 
        /// </summary> 
        public void StartTheQuiz()
        {
            //Fill-in the addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = Convert.ToString(addend1);
            plusRightLabel.Text = Convert.ToString(addend2);

            //initialize it to 0
            sum.Value = 0;

            minuend = randomizer.Next(51);
            subtrahend = randomizer.Next(51);
            minusLeftLabel.Text = Convert.ToString(minuend);
            minusRightLabel.Text = Convert.ToString(subtrahend);
            difference.Value = 0;

            leftFactor = randomizer.Next(10);
            rightFactor = randomizer.Next(15);
            timesLeftLabel.Text = leftFactor.ToString();
            timesRightLabel.Text = rightFactor.ToString();
            product.Value = 0;

            dividend = randomizer.Next(51);
            divisor = randomizer.Next(1, 51);
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = initialTime;
            timeLabel.Text = initialTime.ToString() + " seconds";
            timer1.Start();
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void ResetQuiz()
        {
            startButton.Enabled = true;
            timeLabel.BackColor = default(Color);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //a value of 1000 causes the Tick event to fire every second.

            if (CheckSum() && CheckDiff() && CheckMultiplication() && CheckDivision())
            {
                // If all functions return true, then the user  
                // got the answer right. Stop the timer   
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");

                ResetQuiz();
            }
            else if (timeLeft > 0)
            {
                          
                //Display the new time left
                --timeLeft;
                timeLabel.Text = timeLeft.ToString();

                if (timeLeft == 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                //ran out of time --> display a MessageBox
                //stop the timer
                timer1.Stop();

                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;

                ResetQuiz();

            }
        }

        /// <summary> 
        /// Check the answer to see if the user got everything right. 
        /// </summary> 
        /// <returns>True if the answer's correct, false otherwise.</returns> 
        private bool CheckSum()
        {
            //MessageBox.Show("Check sum", "Congratulations!");
            return addend1 + addend2 == sum.Value;
        }

        private bool CheckDiff()
        {
            //MessageBox.Show("Check diff", "Congratulations!");
            return minuend - subtrahend == difference.Value;
        }

        /// <summary> 
        /// Check if multiplication is OK
        /// </summary> 
        /// <returns>True if the answer's correct, false otherwise.</returns> 
        private bool CheckMultiplication()
        {
            //MessageBox.Show("Check mul", "Congratulations!");
            return leftFactor * rightFactor == product.Value;
        }

        /// <summary>
        /// Check if division is OK
        /// </summary>
        /// <returns>True if result is correct, false otherwise
        private bool CheckDivision()
        {
            //MessageBox.Show("Check div", "Congratulations!");
            return dividend / divisor == quotient.Value;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //sender = object whose event is firing
            NumericUpDown answerBox = sender as NumericUpDown;  //cast sender to NumericUpDown
            if (answerBox != null)  //conversion succeeded
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length; //get length of answer
                answerBox.Select(0, lengthOfAnswer);    //select current value based on length: text in NumericUpDown will be selected when entering it
            }
        }
    }
}
