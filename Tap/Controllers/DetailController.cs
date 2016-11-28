using Foundation;
using System;
using UIKit;
using Parse;

namespace Tap
{
    public partial class DetailController : UIViewController
    {
		public TableItem item { get; set; }

		public DetailController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = item.Heading;
			lblDescription.Text = item.Description;
			lblName.Text = item.Heading;
			imgPhoto.Image = LoadImage(item.ImageUrl);

		}

		public UIImage LoadImage(string uri)
		{
			using (var url = new NSUrl(uri))
			using (var data = NSData.FromUrl(url))
				return UIImage.LoadFromData(data);
		}

    }
}