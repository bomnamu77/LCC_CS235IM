using Foundation;
using System;
using UIKit;

namespace Lab5
{
    public partial class AboutViewController : UIViewController
    {
        public AboutViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AboutLabel.Text += "TicTacToe is a game for two players, X and O, who take turns marking the spaces in a 3×3 grid. \n\nThe player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row wins the game.";
        }
    }
}