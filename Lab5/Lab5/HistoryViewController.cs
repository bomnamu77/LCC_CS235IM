using Foundation;
using System;
using UIKit;

namespace Lab5
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

            HistoryLabel.Text +=  gameCount + " times.";
            WinLabel.Text +=  winCount + " times.";
            LossLabel.Text+= lossCount +" times.";
        }
    }
}