// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Tap
{
    [Register ("AccountController")]
    partial class AccountController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEdit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWelcome { get; set; }

        [Action ("BtnEdit_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnEdit_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnLogout_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnLogout_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnEdit != null) {
                btnEdit.Dispose ();
                btnEdit = null;
            }

            if (btnLogout != null) {
                btnLogout.Dispose ();
                btnLogout = null;
            }

            if (lblWelcome != null) {
                lblWelcome.Dispose ();
                lblWelcome = null;
            }
        }
    }
}