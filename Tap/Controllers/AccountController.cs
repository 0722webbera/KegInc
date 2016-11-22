using Foundation;
using System;
using UIKit;
using Parse;

namespace Tap
{
    public partial class AccountController : UIViewController
    {
        public AccountController (IntPtr handle) : base (handle)
        {
			
		}

		public override void ViewDidLoad()
		{
			// on page load we will show the current user's First Name from Parse
			var currentUser = ParseUser.CurrentUser;
			lblWelcome.Text = "Welcome, " + currentUser["FirstName"] + " " + currentUser["LastName"];
		}

    }

}