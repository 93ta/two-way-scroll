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
	[Register ("FirstCell")]
	partial class FirstCell
	{
		[Outlet]
		UIKit.UIButton numButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (numButton != null) {
				numButton.Dispose ();
				numButton = null;
			}
		}
	}
}
