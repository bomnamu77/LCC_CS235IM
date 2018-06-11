using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace TermProject
{
	public partial class RootViewController : UITableViewController
	{
		public RootViewController (IntPtr handle) : base (handle)
		{
		}

		IEnumerable<Event> events;
        public string month;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Wire up the Add [+] button
			AddButton.Clicked += (sender, e) => {
				EditEvent ();
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
            events = AppDelegate.Database.GetEventsByMonth(month);
			TableView.Source = new RootTableSource(events);
			TableView.ReloadData ();
		}

		/// <summary>
		/// Prepares for segue.
		/// </summary>
		/// <remarks>
		/// The prepareForSegue method is invoked whenever a segue is about to take place. 
		/// The new view controller has been loaded from the storyboard at this point but 
		/// it’s not visible yet, and we can use this opportunity to send data to it.
		/// </remarks>
		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "EventSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as EventDetailViewController;
				if (navctlr != null) {
					var source = TableView.Source as RootTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetEvent(this, item);
				}
			}
		}
		
        // create event
		public void EditEvent () {
			// then open the detail view to edit it
			var detail = Storyboard.InstantiateViewController("detail") as EventDetailViewController;
			detail.Delegate = this;
            detail.month = month;
			NavigationController.PushViewController (detail, true);
			
			// Could to this instead of the above, but need to create 'new Stock()' in PrepareForSegue()
			//this.PerformSegue ("StockSegue", this);
		}

		public void SaveEvent (Event ev) {
			Console.WriteLine("Save "+ev.Name);
			AppDelegate.Database.SaveEvent (ev);
			NavigationController.PopViewController(true);
		}
		public void DeleteEvent (Event ev) {
            Console.WriteLine("Delete "+ ev.Name);
            AppDelegate.Database.DeleteEvent (ev);
			NavigationController.PopViewController(true);
		}
	}
}