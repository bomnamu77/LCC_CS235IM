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

namespace Lab7
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView DetailTextView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DetailTextView != null) {
                DetailTextView.Dispose ();
                DetailTextView = null;
            }
        }
    }
}