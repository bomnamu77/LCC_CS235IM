using System;

using UIKit;

namespace RomanNumeralConv
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }


        partial void ToRomanButton_TouchUpInside(UIButton sender)
        {
            // Convert the phone number with text to a number
                // using PhoneTranslator.cs
            string result = NumberConvertor.ToRomanNumeral(Int32.Parse(NumberText.Text)-1);


            // Dismiss the keyboard if text field was tapped
            //NumberText.ResignFirstResponder();

            ResultLabel.Text = "Result: " + NumberText.Text + " -> " + result;

            NumberText.Text = "";
        }


        partial void ToNumeralButton_TouchUpInside(UIButton sender)
        {
            int result = NumberConvertor.ToDecimalNumber(NumberText.Text);
            // Dismiss the keyboard if text field was tapped
            //NumberText.ResignFirstResponder();

            ResultLabel.Text = "Result: " + NumberText.Text + " -> " + result;

            NumberText.Text = "";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
