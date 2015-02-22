using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace StoryboardTables
{
	public class RootTableSource : UITableViewSource
	{
		//using in memory tables to hold information 
		Chore[] tableItems;
		string cellIdentifier = "taskcell"; // this always trips me up. Remember to set this in Storyboard

		public RootTableSource (Chore[] items)
		{
			tableItems = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			//Dequeue will always return a Cell in a Storyboard
			var cell = tableView.DequeueReusableCell (cellIdentifier); //this is what was created in the storyboard

			cell.TextLabel.Text = tableItems [indexPath.Row].Name; //this gets the names from the Array previously set
			if (tableItems [indexPath.Row].Done)
				cell.Accessory = UITableViewCellAccessory.Checkmark; //this adds a check mark if the switch is set to done
			else
				cell.Accessory = UITableViewCellAccessory.None;
			return cell;
		}

		public Chore GetItem (int id) {
			return tableItems [id];
		}

	}
}

