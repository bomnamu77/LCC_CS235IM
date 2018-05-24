using Foundation;
using System;
using UIKit;

namespace Lab6
{
    public partial class HistoryViewController : UIViewController
    {
        public int winCount { get; set; }
        public int lossCount { get; set; }
        public int gameCount { get; set; }
        public HistoryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
        }


        public void SetMessage ()
        {
            HistoryLabel.Text = "You Played "+ gameCount + " times.";
            WinLabel.Text = "You won "+winCount + " times.";
            LossLabel.Text = "You lose "+lossCount + " times.";
        }
    }
}