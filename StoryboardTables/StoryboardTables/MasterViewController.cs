using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace StoryboardTables
{
	public partial class MasterViewController : UITableViewController
	{
		List<Chore> chores; //never specified in example but this needed for RootTableSource to pick up
		Chore currentTask { get; set; }
		public MasterViewController Delegate { get; set; }



		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("ChoresBoard", "ChoresBoard");
			 chores = new List<Chore> {
				new Chore {Name="Evo Conference", Notes="Learn Xamarin, Learn iOS Dev", Done=false},
				new Chore {Name="Snowed In", Notes="Shovel Snow, DeIce Driveway", Done = false}
			};

			// Custom initialization
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "TaskSegue") {
				var navctlr = segue.DestinationViewController as TaskDetailViewController;
				if (navctlr != null) {
					var source = TableView.Source as RootTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem (rowPath.Row);
					navctlr.SetTask (this, item);
				}

			}
		}

		public void CreateTask()
		{
			//we add teh task to the underlying data
			var newId = chores [chores.Count - 1].Id + 1;
			var newChore = new Chore{ Id = newId };
			chores.Add (newChore);

			//then open teh detail view to edit it
			var detail = Storyboard.InstantiateViewController ("detail") as TaskDetailViewController;
			detail.SetTask (this, newChore);
			NavigationController.PushViewController (detail, true);
		}

		public void SaveTask(Chore chore)
		{
			var oldTask = chores.Find (t => t.Id == chore.Id);
			NavigationController.PopViewControllerAnimated (true);
		}

		public void DeleteTask(Chore chore)
		{
			var oldTask = chores.Find (t => t.Id == chore.Id);
			chores.Remove (oldTask);
			NavigationController.PopViewControllerAnimated (true);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);
			TableView.Source = new RootTableSource (chores.ToArray());
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			btnChoreAdd.Clicked += (sender, e) => CreateTask();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
	}
}

