using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using TwoWayScroll.iOS.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace TwoWayScroll.iOS.Views
{
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var collectionSource = new MvxCollectionViewSource(collectionView, FirstCell.Key);
            collectionView.RegisterNibForCell(FirstCell.Nib, FirstCell.Key);
            collectionView.Source = collectionSource;

            var tableSource = new MvxSimpleTableViewSource(tableView, TableViewCell.Key, TableViewCell.Key);
            tableView.RegisterNibForCellReuse(TableViewCell.Nib, TableViewCell.Key);
            tableView.Source = tableSource;
            tableView.AllowsSelection = false;

            //binding
            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(collectionSource).To(vm => vm.AllNumbers);
            set.Bind(tableSource).To(vm => vm.AllGroups);
            set.Apply();

            collectionView.ReloadData();
            tableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


