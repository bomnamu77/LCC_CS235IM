using Foundation;
using System;
using UIKit;

namespace Lab7
{
    public partial class ProgrammingLangTableViewController : UITableViewController
    {
        ProgrammingLangDataSource programmingLangDataSource;

        public ProgrammingLangTableViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            programmingLangDataSource = new ProgrammingLangDataSource(this);
            TableView.Source = programmingLangDataSource;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "ProgLangDetailSeque") // set in Storyboard
            {
                var detailController = segue.DestinationViewController as DetailViewController;
                if (detailController != null)
                {
                    
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var progLangInfo = programmingLangDataSource.GetProgrammingLangInfo(rowPath.Section, rowPath.Row);

                    string detail = "• Chief Developer: " + progLangInfo.ChiefDevelopers + "\n\n";
                    detail += "• Predecessors: " + progLangInfo.Predecessors;

                    detailController.SetDetailText(detail);
                    detailController.SetTitle(progLangInfo.Name);

                }
            }
        }

        public override string[] SectionIndexTitles (UITableView tableView)
        {

            return base.SectionIndexTitles (tableView);
        }

    }
}