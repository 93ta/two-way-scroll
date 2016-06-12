using System;
using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwoWayScroll.iOS.ViewModels;

namespace TwoWayScroll.iOS.Views
{
    public partial class TableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TableViewCell");
        public static readonly UINib Nib;

        static TableViewCell()
        {
            Nib = UINib.FromName("TableViewCell", NSBundle.MainBundle);
        }

        protected TableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            this.DelayBind(() => {
                var set = this.CreateBindingSet<TableViewCell, NumberGroupViewModel>();
                var groupSource = new MvxCollectionViewSource(groupCollectionView, FirstCell.Key);
                groupCollectionView.Source = groupSource;
                groupCollectionView.RegisterNibForCell(FirstCell.Nib, FirstCell.Key);

                set.Bind(groupSource).To(vm => vm.NumberVms);
                set.Bind(groupLabel).To(vm => vm.GroupKey);
                set.Apply();
            });
        }
    }
}
