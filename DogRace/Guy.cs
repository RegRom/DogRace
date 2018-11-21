using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRace
{
    class Guy
    {
        public string name;
        public Bet myBet;
        public int cash;
        public RadioButton myRadioButton;
        public Label myLabel;

        public Guy(string _name, int _cash, RadioButton button, Label label)
        {
            name = _name;
            cash = _cash;
            myRadioButton = button;
            myLabel = label;
            myBet = new Bet(this);
        }

        public void UpdateLabels()
        {
            myLabel.Text = myBet.GetDescription();
            myRadioButton.Text = name + " has " + cash + " bucks";
        }

        public void ClearBet()
        {
            myBet.amount = 0;
        }

        public bool PlaceBet(int betAmount, int dogToWin)
        {
            myBet.amount = betAmount;
            myBet.dog = dogToWin;
            if (cash >= betAmount) return true;
            return false;
        }

        public void Collect(int winner)
        {
            cash += myBet.PayOut(winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
