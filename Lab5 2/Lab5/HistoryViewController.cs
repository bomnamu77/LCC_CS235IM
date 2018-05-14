using Foundation;
using System;
using UIKit;

namespace Lab5
{
    public partial class HistoryViewController : UIViewController
    {
        public HistoryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            HistoryLabel.Text += "You won";
        }
    }
}