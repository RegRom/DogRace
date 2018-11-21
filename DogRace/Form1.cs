using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRace
{
    public partial class Form1 : Form
    {
        Guy[] guys = new Guy[3];
        GreyHound[] dogs = new GreyHound[4];
        Random myRandomizer = new Random();
        int minimumBet = 5;
    public Form1()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        public void SetupRaceTrack()
        {
            dogs[0] = new GreyHound()
            {
                myPictureBox = dogPictureBox1,
                startingPosition = raceTrackPictureBox.Left,
                raceTrackLength = raceTrackPictureBox.Width - dogPictureBox1.Width,
                randomizer = myRandomizer
            };
            dogs[1] = new GreyHound()
            {
                myPictureBox = dogPictureBox2,
                startingPosition = raceTrackPictureBox.Left,
                raceTrackLength = raceTrackPictureBox.Width - dogPictureBox2.Width,
                randomizer = myRandomizer
            };
            dogs[2] = new GreyHound()
            {
                myPictureBox = dogPictureBox3,
                startingPosition = raceTrackPictureBox.Left,
                raceTrackLength = raceTrackPictureBox.Width - dogPictureBox3.Width,
                randomizer = myRandomizer
            };
            dogs[3] = new GreyHound()
            {
                myPictureBox = dogPictureBox4,
                startingPosition = raceTrackPictureBox.Left,
                raceTrackLength = raceTrackPictureBox.Width - dogPictureBox4.Width,
                randomizer = myRandomizer
            };


            guys[0] = new Guy("Joe", 50, guyRadioButton1, guy1BetLabel);
            guys[1] = new Guy("Bob", 75, guyRadioButton2, guy2BetLabel);
            guys[2] = new Guy("Al", 45, guyRadioButton3, guy3BetLabel);

            foreach (var guy in guys)
            {
                guy.PlaceBet(0, 0);
                guy.UpdateLabels();
            }
            minimumBetLabel.Text = "Minimum bet: " + minimumBet + " bucks";
            betSetNumUpDown.Minimum = minimumBet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guyRadioButton1.Checked)
            {
                guys[0].PlaceBet((int)betSetNumUpDown.Value, (int)dogNumUpDown.Value);
                guys[0].UpdateLabels();
            }
            if (guyRadioButton2.Checked)
            {
                guys[1].PlaceBet((int)betSetNumUpDown.Value, (int)dogNumUpDown.Value);
                guys[1].UpdateLabels();
            }
            if (guyRadioButton3.Checked)
            {
                guys[2].PlaceBet((int)betSetNumUpDown.Value, (int)dogNumUpDown.Value);
                guys[2].UpdateLabels();
            }
        }

        void StartRace()
        {
            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < dogs.Length; i++)
            {
                if (dogs[i].Run())
                {
                    EndRace(i);
                    break;
                }
            }

        }

        public void EndRace(int winnerDog)
        {
            timer1.Stop();
            timer1.Dispose();
            MessageBox.Show("The winner is dog #" + winnerDog);
            foreach (var guy in guys)
            {
                guy.Collect(winnerDog);
            }
            foreach (var dog in dogs)
            {
                dog.TakeStartingPosition();
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartRace();
            button2.Enabled = false;
        }
    }
}
