using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace StoryboardTables
{
	partial class TaskDetailViewController : UITableViewController
	{
		Chore currentTask { get; set; }

		public MasterViewController Delegate { get; set; }

		public TaskDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SaveButton.TouchUpInside += (sender, e) => {
				currentTask.Name = TitleText.Text;
				currentTask.Notes = NotesText.Text;
				currentTask.Done = DoneSwitch.On;
				Delegate.SaveTask(currentTask);
			};

			DeleteButton.TouchUpInside += (sender, e) => Delegate.DeleteTask(currentTask);

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);
			TitleText.Text = currentTask.Name;
			NotesText.Text = currentTask.Notes;
			DoneSwitch.On = currentTask.Done;
		}

		public void SetTask (MasterViewController d, Chore task)
		{
			Delegate = d;
			currentTask = task;
		}
	}
}
