using System;
using System.Drawing;
using System.IO;
using Foundation;
using UIKit;
using CoreGraphics;

namespace iOSHandInHandSongbook
{
	public partial class MainMenuController : UITableViewController
	{
		private bool chordsEnabled;
		private string[] songNames;

		public MainMenuController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.TableView = new UITableView (View.Bounds);

			// Check for a living database and create if need be
			if (!SongData.DataBaseExists)
			{
				SongData.LoadDatabase(File.Open("songs.json", FileMode.Open), false);
				SongData.LoadDatabase(File.Open("songsChords.json", FileMode.Open), true);
			}

			chordsEnabled = SongData.GetSetting(Setting.Chords);
			songNames = SongData.GetAllTitles(chordsEnabled);

			this.TableView.Source = new MainViewSource(songNames, NavigationController, Storyboard);

			// Change settings by the chords flag
			if (SongData.GetSetting (Setting.Contrast)) {
				this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
				this.NavigationController.NavigationBar.TintColor = UIColor.LightGray;
				this.NavigationController.NavigationBar.Translucent = false;
			}

			//this.NavigationItem.SetLeftBarButtonItem(
			//	new UIBarButtonItem(UIImage.FromFile("Icon_transparent.png"), UIBarButtonItemStyle.Plain, null, null)
			//	, true);

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender,args) => LaunchSettings())
				, true);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		private void LaunchSettings()
		{
			SettingsViewController settingsViewController = Storyboard.InstantiateViewController 
				("SettingsViewController") as SettingsViewController;

			NavigationController.PushViewController (settingsViewController, true);
		}
	}
}

