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
    [Register ("DetailController")]
    partial class DetailController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgPhoto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgPhoto != null) {
                imgPhoto.Dispose ();
                imgPhoto = null;
            }

            if (lblDescription != null) {
                lblDescription.Dispose ();
                lblDescription = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }
        }
    }
}