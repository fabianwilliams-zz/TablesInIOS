// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace StoryboardTables
{
	[Register ("MasterViewController")]
	partial class MasterViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnChoreAdd { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnChoreAdd != null) {
				btnChoreAdd.Dispose ();
				btnChoreAdd = null;
			}
		}
	}
}
