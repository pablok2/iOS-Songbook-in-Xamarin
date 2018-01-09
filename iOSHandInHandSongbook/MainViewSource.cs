using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using UIKit;

namespace iOSHandInHandSongbook
{
	partial class MainViewSource : UITableViewSource
	{
		string[] tableItems;
		string cellIdentifier = "TableCell";
		UINavigationController parentController;
		UIStoryboard parentStoryboard;
		//Dictionary<string, List<string>> indexedTableItems;
		//string[] keys;

		public MainViewSource (string[] items, UINavigationController controller, UIStoryboard storyboard)
		{
			tableItems = items;
			parentController = controller;
			parentStoryboard = storyboard;

			//indexedTableItems = new Dictionary<string, List<string>>();
			//
			//foreach (var t in items)
			//{
			//	if (indexedTableItems.ContainsKey (t[0].ToString ()))
			//	{
			//		indexedTableItems[t[0].ToString ()].Add(t);
			//	}
			//	else
			//	{
			//		indexedTableItems.Add (t[0].ToString (), new List<string>() {t});
			//	}
			//}
			//
			//keys = new string[indexedTableItems.Keys.Count];
			//indexedTableItems.Keys.CopyTo (keys, 0);
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			// if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			}
			cell.TextLabel.Text = tableItems[indexPath.Row];
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			SongViewController songViewController = parentStoryboard.InstantiateViewController 
				("SongViewController") as SongViewController;
			
			songViewController.SongName = tableItems [indexPath.Row];
			songViewController.Chords = SongData.GetSetting (Setting.Chords);
			parentController.PushViewController (songViewController, true);	        
		}

		//public override nint NumberOfSections (UITableView tableView)
		//{
		//	return keys.Length;
		//}
		//
		//public override nint RowsInSection (UITableView tableview, nint section)
		//{
		//	return indexedTableItems[keys[section]].Count;
		//}
		//
		//public override string[] SectionIndexTitles (UITableView tableView)
		//{
		//	return keys;
		//}
	}
}
