using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Foundation;
using UIKit;

namespace TermProject {
	public class RootTableSource : UITableViewSource {

		IList<Event> tableItems;
	    string cellIdentifier = "eventcell"; // in Storyboard
	 
		public RootTableSource (IEnumerable<Event> items)
		{
			tableItems = items.ToList(); 
		}
	    
	    public override nint RowsInSection (UITableView tableview, nint section)
	    {
	        return tableItems.Count;
	    }
	    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
	    {
			Console.WriteLine ("   Id:" + tableItems[indexPath.Row].Id + " " + tableItems[indexPath.Row].Name);
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
	        UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
            cell.TextLabel.Text = tableItems[indexPath.Row].Month + "/"+ tableItems[indexPath.Row].Day;
			cell.DetailTextLabel.Text = tableItems[indexPath.Row].Name;
		    return cell;
	    }

		public Event GetItem(int id) {
			return tableItems[id];
		}
	}
}