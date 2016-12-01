using Foundation;
using System;
using UIKit;
using Parse;


namespace Tap
{
    public partial class RegisterController : UIViewController
    {

		async partial void BtnCreateAccount_TouchUpInside(UIButton sender)
		{
			var firstName = txtFirstName.Text;
			var lastName = txtLastName.Text;
			var email = txtEmail.Text;
			var password = txtPassword.Text;
			var confirmPassword = txtConfirmPassword.Text;
			var birthday = txtBirthday;
			var vendor = sldVendor.On;
			//string sdate = birthday.Date.ToString();

			//txtLastName.Text = sdate;


			                          
   			var alert = new UIAlertView();

			if ((string.IsNullOrEmpty(email)) || (string.IsNullOrEmpty(password)) ||
				(string.IsNullOrEmpty(firstName)) || (string.IsNullOrEmpty(lastName)))
			{
				// display an alert pop-up if any of the required fields are left out
				alert = new UIAlertView("Input Validation Failed", "Please complete all the input fields!", null, "OK");
				alert.Show();
			}
			else
			{
				if (password != confirmPassword)
				{
					// display an alert pop-up if password is not the same as confirm password
					alert = new UIAlertView("Input Validation Failed","Password and Confirm Password must match!", null, "OK");
					alert.Show();
				}
				else
				{
					// call Parse to create a new user, put it in a try-catch block
					// if an internet connection doesn’t exist, the Parse call will fail
					// in addition, if the email already exists in Parse, the call will fail

					try
					{
						// create a new user in Parse, 
						// by setting the default User class properties as follows:
						var user = new ParseUser()
						{
							Username = email,
							Password = password,
							Email = email,
						};

						// the non-default fields can be set using the following approach
						user["LastName"] = lastName;
						user["FirstName"] = firstName;
						//user["Birthday"] = birthday;
						user["Vendor"] = vendor;

						// make an asynchronous call to Parse to create a new user
						await user.SignUpAsync();

						// show an alert to confirm
						alert = new UIAlertView("Account Created","Your account has been successfully created!", null, "OK");
						alert.Show();

						// navigate to the login page now that the user is registered
						NavigationController.PopViewController(true);
					}
					catch (Exception ex)
					{
						var error = ex.Message;
						alert = new UIAlertView("Registration Failed", "Sorry, we might be experiencing some connectivity difficulties or your email is already in the system!", null, "OK");
						alert.Show();
					}
				}
			}
		}

		public RegisterController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			sldVendor.On = false;
		}

    }
}