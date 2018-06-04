using Foundation;
using System;
using UIKit;

namespace Lab7
{
    public partial class DetailViewController : UIViewController
    {
        string detailText;
        public DetailViewController (IntPtr handle) : base (handle)
        {
        }

        public void SetDetailText(string text)
        {
            detailText = text;
        }

        public override void ViewWillAppear(bool animated)
        {
            DetailTextView.Text = detailText;

            base.ViewWillAppear(animated);
        }
    }
}