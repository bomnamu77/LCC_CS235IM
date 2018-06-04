using System;

using UIKit;
using Foundation;


namespace Lab8
{


    public partial class ViewController : UIViewController
    {
        TipCalculation tipCalc = new TipCalculation();
        NSObject observer = null;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            CheckChanges();
            ServiceSlider.ValueChanged += (object sender, EventArgs e) =>
            {

                CheckChanges();

            };

            AmountText.EditingDidEnd += (object sender, EventArgs e) =>
            {
                AmountText.ResignFirstResponder();
                CheckChanges();

            };

            TaxPercentageText.EditingDidEnd += (object sender, EventArgs e) =>
            {
                TaxPercentageText.ResignFirstResponder();
                CheckChanges();

            };
            TaxSwitch.ValueChanged += (object sender, EventArgs e) =>
            {
                UIActionSheet actionSheet;

                string taxMessage = "off";

                //When user tries to turn on
                if (TaxSwitch.On)
                    taxMessage = "on";
                else
                    taxMessage = "off";
                //Display Action Sheet
                actionSheet = new UIActionSheet("Would you like to turn " + taxMessage + "?");

                actionSheet.AddButton("Yes");
                actionSheet.AddButton("No");

                //When user finishes to select an answer
                actionSheet.Clicked += delegate (object a, UIButtonEventArgs b)
                {
                    if (b.ButtonIndex == 1)
                        TaxSwitch.On = !TaxSwitch.On;
                    if (!TaxSwitch.On)
                        TaxPercentageText.Enabled = false;
                    else
                        TaxPercentageText.Enabled = true;
                    CheckChanges();
                };
                actionSheet.ShowInView(View);


            };


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

        private void RefreshFields()
        {
            NSUserDefaults defaults = NSUserDefaults.StandardUserDefaults;

            ServiceSlider.Value = defaults.FloatForKey(Constants.TIPPERCENTAGE_KEY);
            TaxPercentageText.Text = defaults.StringForKey(Constants.TAXPERCENTAGE_KEY);
            tipCalc.currencyType = defaults.StringForKey(Constants.CURRENCYTYPE_KEY);
            UIColor color = UIColor.White;
            string colorString = defaults.StringForKey(Constants.BACKGROUNDCOLOR_KEY);
            if (colorString == "White")
                color = UIColor.White;
            else if (colorString == "Green")
                color = UIColor.Green;
            else
                color = UIColor.Blue;
            this.View.BackgroundColor = color;

        }


        // We will subscribe to the applicationWillEnterForeground notification
        // so that this method is called when that notification occurs
        private void ApplicationWillEnterForeground(NSNotification notification)
        {
            var defaults = NSUserDefaults.StandardUserDefaults;
            defaults.Synchronize();
            RefreshFields();
        }

        public void CheckChanges()
        {

            if (AmountText.Text == "")
                tipCalc.Amount = 0.0;
            else
                tipCalc.Amount = Math.Round(Convert.ToDouble(AmountText.Text), 2);
            if (TaxSwitch.On && TaxPercentageText.Text != "")
                tipCalc.Tax = Math.Round(Convert.ToDouble(TaxPercentageText.Text), 2);
            else
                tipCalc.Tax = 0.0;
            int serviceTip = (int)ServiceSlider.Value;
            tipCalc.Tip = (int)ServiceSlider.Value;



            TipPercentageText.Text = tipCalc.Tip.ToString();



            TipAmountText.Text = tipCalc.currencyType +" " + tipCalc.GetTipAmount().ToString();
            TaxAmountText.Text = tipCalc.currencyType + " " + tipCalc.GetTaxAmount().ToString();

            TotalText.Text = tipCalc.currencyType + " " + tipCalc.GetTotalAmount().ToString();


        }
    }
}
