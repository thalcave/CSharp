using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    //When a player clicks one of the squares with a hidden icon, the program shows the icon to the player by changing the icon color to black.
    //Then the player clicks another hidden icon.
    //If the icons match, they stay visible. If not, both icons are hidden again.


    public partial class Form1 : Form
    {
        //choose random icons for squares
        Random random = new Random();

        //list of icons, with each icon appearing twice in list
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        //first clicked Label - or null
        Label firstClicked = null;
        //second clicked Label
        Label secondClicked = null;

        //currently discovered pairs of labels
        int discoveredLabels = 0;
        //total number of icon pairs
        readonly int totalNumber;

        //store the number of clicks
        uint numberOfTries = 0;

        public Form1()
        {
            InitializeComponent();
            totalNumber = icons.Count / 2;
            AssignIconToSquares();
        }

        /// <summary> 
        /// Assign each icon from the list of icons to a random square 
        /// </summary> 
        private void AssignIconToSquares()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                //convert control to label
                Label currentLabel = (Label)control;
                if (currentLabel != null)
                {
                    //pick a random icon
                    int randomIcon = random.Next(0, icons.Count);
                    currentLabel.Text = icons[randomIcon];
                    currentLabel.ForeColor = currentLabel.BackColor;
                    icons.RemoveAt(randomIcon);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelClick(object sender, EventArgs e)
        {
            ++numberOfTries;
            // The timer is only on after two non-matching  
            // icons have been shown to the player,  
            // so ignore any clicks if the timer is running 
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked 
                // an icon that's already been revealed -- 
                // ignore the click 
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,  
                // so set firstClicked to the label that the player  
                // clicked, change its color to black, and return 
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                // If the player gets this far, the timer isn't 
                // running and firstClicked isn't null, 
                // so this must be the second icon the player clicked 
                // Set its color to black
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                //we have a match
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;

                    //make a sound
                    System.Media.SystemSounds.Exclamation.Play();

                    ++discoveredLabels;
                    if (totalNumber == discoveredLabels)
                    {
                        MessageBox.Show("Congratulations, you finished in : " + numberOfTries.ToString(), "Wow");
                        this.Close();
                    }

                    return;
                }

                //play a sound
                System.Media.SystemSounds.Beep.Play();

                // If the player gets this far, the player  
                // clicked two different icons, so start the  
                // timer (which will wait three quarters of  
                // a second, and then hide the icons)
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            //play sound
            System.Media.SystemSounds.Asterisk.Play();

            // Reset firstClicked and secondClicked  
            // so the next time a label is 
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }
    }
}
