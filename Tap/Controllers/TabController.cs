using Foundation;
using System;
using UIKit;

namespace Tap
{
    public partial class TabController : UITabBarController
    {
        public TabController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.NavigationItem.SetHidesBackButton(true, false);
		}
    }
}