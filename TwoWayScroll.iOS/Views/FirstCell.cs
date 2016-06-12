using System;
using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwoWayScroll.iOS.ViewModels;

namespace TwoWayScroll.iOS.Views
{
    public partial class FirstCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("FirstCell");
        public static readonly UINib Nib;
            
        static FirstCell()
        {
            Nib = UINib.FromName("FirstCell", NSBundle.MainBundle);
        }

        protected FirstCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            this.DelayBind(() => {
                numButton.TouchDown += (sender, e) => { Console.WriteLine("Touch Down!"); };
                var set = this.CreateBindingSet<FirstCell, NumberViewModel>();
                set.Bind(numButton).For("Title").To(vm => vm.Number);
                set.Bind(numButton).For("TouchDown").To(vm => vm.ButtonCommand);
                set.Apply();

                numButton.Layer.BorderWidth = 1;
                numButton.Layer.CornerRadius = 15;
                numButton.Layer.BorderColor = UIColor.Gray.CGColor;
            });
        }
    }
}
