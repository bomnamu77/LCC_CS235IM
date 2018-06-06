using Foundation;
using System;
using UIKit;

namespace Lab7
{
    public partial class DetailViewController : UIViewController
    {
        string detailText, title;
        public DetailViewController (IntPtr handle) : base (handle)
        {
        }

        public void SetDetailText(string text)
        {
            detailText = text;
        }
        public void SetTitle(string text)
        {
            title = text;
        }
        public override void ViewWillAppear(bool animated)
        {
            DetailTextView.Text = detailText;
            TitleLabel.Text = title;

            base.ViewWillAppear(animated);
        }
    }
}