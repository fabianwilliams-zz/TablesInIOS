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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel detailDescriptionLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (detailDescriptionLabel != null) {
				detailDescriptionLabel.Dispose ();
				detailDescriptionLabel = null;
			}
		}
	}
}
