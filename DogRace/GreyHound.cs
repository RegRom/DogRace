using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRace
{
    public class GreyHound
    {
        public int startingPosition;
        public int raceTrackLength;
        public PictureBox myPictureBox;
        public int location;
        public Random randomizer;

        public void TakeStartingPosition()
        {
            this.myPictureBox.Left = 0;
            this.location = 0;
        }

        public bool Run()
        {
            location = randomizer.Next(5);
            myPictureBox.Left += startingPosition + location;

            if (myPictureBox.Left >= raceTrackLength)
                return true;

            return false;
        }
    }
}
