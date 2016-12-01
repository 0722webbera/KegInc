using Foundation;
using System;
using UIKit;
using Parse;

namespace Tap
{
    public partial class EditUserController : UIViewController
    {

		 partial void BtnSave_TouchUpInside(UIButton sender)
		{
			var firstName = txtFirstName.Text;
			var lastName = txtLastName.Text;
			var email = txtEmail.Text;
			var password = txtPassword.Text;
			var confirmPassword = txtConfirmPassword.Text;
			var currentUser = ParseUser.CurrentUser;

			if (password != confirmPassword)
			{
				// display an alert pop-up if password is not the same as confirm password
				var alert = new UIAlertView("Input Validation Failed", "Password and Confirm Password must match!", null, "OK");
				alert.Show();
			}
			else
			{
				currentUser.Email = email;
				currentUser["FirstName"] = firstName;
				currentUser["LastName"] = lastName;
				currentUser["username"] = email;
				currentUser.Password = password;
				currentUser.SaveAsync();
				var account = Storyboard.InstantiateViewController("Account") as AccountController;
				NavigationController.PushViewController(account, true);
			}

		}

		public EditUserController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var currentUser = ParseUser.CurrentUser;
			txtFirstName.Text = "" + currentUser["FirstName"];
			txtLastName.Text = "" + currentUser["LastName"];
			txtEmail.Text = "" + currentUser.Email;

		}
    }
}