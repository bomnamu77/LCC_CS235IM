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

                CheckChanges();

            };

            TaxPercentageText.EditingDidEnd += (object sender, EventArgs e) =>
            {

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

            tipCalc.Amount = Convert.ToDouble(AmountText.Text);
            if (TaxSwitch.On)
                tipCalc.Tax = Convert.ToDouble(TaxPercentageText.Text);
            else
                tipCalc.Tax = 0.0;
            
            tipCalc.Tip = Convert.ToDouble(ServiceSlider.Value);


            TipPercentageText.Text = Math.Round(ServiceSlider.Value,2).ToString();
            TipAmountText.Text = Math.Round(tipCalc.GetTipAmount(),2).ToString();
            TaxAmountText.Text = Math.Round(tipCalc.GetTaxAmount(),2).ToString();

            TotalText.Text = Math.Round(tipCalc.GetTotalAmount(),2).ToString();


        }
    }
}
