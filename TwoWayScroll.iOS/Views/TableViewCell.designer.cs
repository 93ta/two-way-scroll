// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TwoWayScroll.iOS.Views
{
	[Register ("TableViewCell")]
	partial class TableViewCell
	{
		[Outlet]
		UIKit.UICollectionView groupCollectionView { get; set; }

		[Outlet]
		UIKit.UILabel groupLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (groupLabel != null) {
				groupLabel.Dispose ();
				groupLabel = null;
			}

			if (groupCollectionView != null) {
				groupCollectionView.Dispose ();
				groupCollectionView = null;
			}
		}
	}
}
