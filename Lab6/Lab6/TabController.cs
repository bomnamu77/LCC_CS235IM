using Foundation;
using System;
using UIKit;

namespace Lab6
{
    public partial class TabController : UITabBarController
    {
        public TabController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            ViewControllerSelected += (object sender, UITabBarSelectionEventArgs e) =>
            {

                if (TabBar.SelectedItem.Title == "History")   // only sending messages to the SecondViewController
                {
                    var viewController = ((HistoryViewController)e.ViewController);



                    viewController.gameCount = ((AppDelegate)UIApplication.SharedApplication.Delegate).gameCount;
                    viewController.winCount = ((AppDelegate)UIApplication.SharedApplication.Delegate).winCount;
                    viewController.lossCount = ((AppDelegate)UIApplication.SharedApplication.Delegate).lossCount;

                    viewController.SetMessage();

                }
            };
        }
    }
}