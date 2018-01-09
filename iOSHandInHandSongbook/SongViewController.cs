using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace iOSHandInHandSongbook
{
	partial class SongViewController : UIViewController
	{
		public SongViewController (IntPtr handle) : base (handle)
		{
		}

		public SongViewController ()
		{
			
		}

		public string SongName { get; set; }

		public bool Chords { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = SongName;

			textView.Text = SongData.GetSong (SongName, Chords);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

	}
}
