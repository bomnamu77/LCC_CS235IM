using System;

using UIKit;


namespace TipCalc
{
    

    public partial class ViewController : UIViewController
    {
        TipCalculation tipCalc = new TipCalculation();

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
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

        public void CheckChanges()
        {

            if (AmountText.Text == "")
                tipCalc.Amount = 0.0;
            else
                tipCalc.Amount = Math.Round(Convert.ToDouble(AmountText.Text),2);
            if (TaxSwitch.On && TaxPercentageText.Text != "")
                tipCalc.Tax = Math.Round(Convert.ToDouble(TaxPercentageText.Text),2);
            else
                tipCalc.Tax = 0.0;
            int serviceTip = (int)ServiceSlider.Value;
            tipCalc.Tip = (int)ServiceSlider.Value;
            //tipCalc.Tip = ServiceSlider.Value
                
           // sliderLabel.Text = progress.ToString();


            TipPercentageText.Text = tipCalc.Tip.ToString();

            //TipAmountText.Text = tipCalc.GetTipAmount().ToString();
            TipAmountText.Text = tipCalc.GetTipAmount().ToString();
            TaxAmountText.Text = tipCalc.GetTaxAmount().ToString();

            TotalText.Text = tipCalc.GetTotalAmount().ToString();


        }
    }
}
    