// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Lab6
{
    [Register ("HistoryViewController")]
    partial class HistoryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HistoryLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LossLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WinLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (HistoryLabel != null) {
                HistoryLabel.Dispose ();
                HistoryLabel = null;
            }

            if (LossLabel != null) {
                LossLabel.Dispose ();
                LossLabel = null;
            }

            if (WinLabel != null) {
                WinLabel.Dispose ();
                WinLabel = null;
            }
        }
    }
}