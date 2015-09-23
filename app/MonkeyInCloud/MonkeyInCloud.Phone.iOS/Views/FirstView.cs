using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using MonkeyInCloud.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace MonkeyInCloud.Phone.iOS.Views
{
    [Register("FirstView")]
    public class FirstView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

			if (ViewModel != null && ViewModel is FirstViewModel) {
				
				((FirstViewModel)ViewModel).LoadSomeMonkeys ();
				Title = "Monkeys in the Cloud";
			}


			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
               EdgesForExtendedLayout = UIRectEdge.None;
            }
			   
			var source = MvxStandardTableViewSource (TableView, "Name TwitterHandle");
			TableView.Source = source;

			var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(source).To(vm => vm.Monkeys);
            set.Apply();
        }
    }
}