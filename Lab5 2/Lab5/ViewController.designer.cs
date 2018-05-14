// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Lab5
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AboutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button5 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button6 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button7 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button8 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Button9 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HistoryButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ResetButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Action ("ResetButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ResetButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("TouchUpInsideEachButton:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TouchUpInsideEachButton (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AboutButton != null) {
                AboutButton.Dispose ();
                AboutButton = null;
            }

            if (Button1 != null) {
                Button1.Dispose ();
                Button1 = null;
            }

            if (Button2 != null) {
                Button2.Dispose ();
                Button2 = null;
            }

            if (Button3 != null) {
                Button3.Dispose ();
                Button3 = null;
            }

            if (Button4 != null) {
                Button4.Dispose ();
                Button4 = null;
            }

            if (Button5 != null) {
                Button5.Dispose ();
                Button5 = null;
            }

            if (Button6 != null) {
                Button6.Dispose ();
                Button6 = null;
            }

            if (Button7 != null) {
                Button7.Dispose ();
                Button7 = null;
            }

            if (Button8 != null) {
                Button8.Dispose ();
                Button8 = null;
            }

            if (Button9 != null) {
                Button9.Dispose ();
                Button9 = null;
            }

            if (HistoryButton != null) {
                HistoryButton.Dispose ();
                HistoryButton = null;
            }

            if (ResetButton != null) {
                ResetButton.Dispose ();
                ResetButton = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}