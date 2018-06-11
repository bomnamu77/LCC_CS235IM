using Foundation;
using System;
using UIKit;

namespace TermProject
{
    public partial class MainViewController : UIViewController
    {

        MonthModel pickerModel = new MonthModel();
        NSObject observer = null;

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            monthPicker.Model = pickerModel;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            // Update the values shown in view 1 from the StandardUserDefaults
            RefreshFields();

            // Subscribe to the applicationWillEnterForeground notification
            var app = UIApplication.SharedApplication;
            // NSNotificationCenter.DefaultCenter.AddObserver (this, UIApplication.WillEnterForegroundNotification, "ApplicationWillEnterForeground", app);
            // NSNotificationCenter.DefaultCenter.AddObserver (UIApplication.WillEnterForegroundNotification, ApplicationWillEnterForeground);
            observer = NSNotificationCenter.DefaultCenter.AddObserver(aName: UIApplication.WillEnterForegroundNotification, notify: ApplicationWillEnterForeground, fromObject: app);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NSNotificationCenter.DefaultCenter.RemoveObserver(observer);
        }

        partial void CheckEventsButton_TouchUpInside(UIButton sender)
        {
            UIViewController controller = this.Storyboard.InstantiateViewController("RootViewController") as RootViewController;
              //  this.Storyboard.InstantiateViewController("RootViewController") as RootViewController;
            ((RootViewController)controller).month = pickerModel.months[monthPicker.SelectedRowInComponent(0)];
            this.NavigationController.PushViewController(controller, true);
        }

        // We will subscribe to the applicationWillEnterForeground notification
        // so that this method is called when that notification occurs
        private void ApplicationWillEnterForeground(NSNotification notification)
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            defaults.Synchronize();
            RefreshFields();
        }

        private void RefreshFields()
        {
            NSUserDefaults defaults = NSUserDefaults.StandardUserDefaults;


            // get value for nameLabel from settings
            string tempName = defaults.StringForKey(Constants.NAME_KEY);
            if (tempName == "")
                tempName = "Guest";
            
            nameLabel.Text =  "Hello! "+ tempName;
            nameLabel.TextAlignment = UITextAlignment.Center;

            UIColor color = UIColor.White;
            // get color value for background color from settings
            string backgroundColor = defaults.StringForKey(Constants.BACKGROUNDCOLOR_KEY);
            if (backgroundColor == "White")
                color = UIColor.White;
            else if (backgroundColor == "LightGrey")
                color = UIColor.LightGray;
            else
                color = UIColor.FromRGB(0,163, 241);
            this.View.BackgroundColor = color;
            // get color value for font color from settings
            string fontColor = defaults.StringForKey(Constants.FONTCOLOR_KEY);
            if (fontColor == "Black")
                color = UIColor.Black;
            else if (fontColor == "Blue")
                color = UIColor.Blue;
            else
                color = UIColor.Purple;
            guideLabel.TextColor = color;
            nameLabel.TextColor = color;

        }
    }




}

