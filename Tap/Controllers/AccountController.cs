using Foundation;
using System;
using UIKit;
using Parse;

namespace Tap
{
    public partial class AccountController : UIViewController
    {

		partial void BtnEdit_TouchUpInside(UIButton sender)
		{
			var edit = Storyboard.InstantiateViewController("Edit") as EditUserController;
			NavigationController.PushViewController(edit, true);
		}

		partial void BtnLogout_TouchUpInside(UIButton sender)
		{
			//Parse.ParseUser.LogOut();

			ParseUser.LogOutAsync();
			var home = Storyboard.InstantiateViewController("Home") as ViewController;
			NavigationController.PushViewController(home, true);
		}

		public AccountController (IntPtr handle) : base (handle)
        {
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationController.NavigationBar.Hidden = true;
			//this.NavigationItem.SetHidesBackButton(true, false);
			// on page load we will show the current user's First Name from Parse
			var currentUser = ParseUser.CurrentUser;
			lblWelcome.Text = "Welcome, " + currentUser["FirstName"] + " " + currentUser["LastName"];
		}

    }

}