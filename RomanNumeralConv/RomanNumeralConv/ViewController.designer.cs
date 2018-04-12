// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RomanNumeralConv
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InstructionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NumberText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ToNumeralButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ToRomanButton { get; set; }

        [Action ("ToNumeralButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ToNumeralButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("ToRomanButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ToRomanButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (InstructionLabel != null) {
                InstructionLabel.Dispose ();
                InstructionLabel = null;
            }

            if (NumberText != null) {
                NumberText.Dispose ();
                NumberText = null;
            }

            if (ResultLabel != null) {
                ResultLabel.Dispose ();
                ResultLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }

            if (ToNumeralButton != null) {
                ToNumeralButton.Dispose ();
                ToNumeralButton = null;
            }

            if (ToRomanButton != null) {
                ToRomanButton.Dispose ();
                ToRomanButton = null;
            }
        }
    }
}