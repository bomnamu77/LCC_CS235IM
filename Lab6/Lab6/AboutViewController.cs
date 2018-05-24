using Foundation;
using System;
using UIKit;

namespace Lab6
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
            DataPicker.Model = new DataModel(gameLabel);

            base.ViewDidLoad();
        }

        partial void SubmitButton_TouchUpInside(UIButton sender)
        {
            
            var alert = UIAlertController.Create("Your choice", "You choose "+gameLabel.Text, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}