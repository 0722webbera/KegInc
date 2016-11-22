using System;
using UIKit;
using Parse;

namespace Tap
{
	public class TableItem
	{
		public TableItem()
		{
		}
		public string Heading { get; set; }

		public string SubHeading { get; set; }

		public string ImageUrl { get; set; }

		public string Description { get; set; }

		public bool IsFavorite { get; set; }

		public UITableViewCellStyle CellStyle
		{
			get { return cellStyle; }
			set { cellStyle = value; }
		}

		protected UITableViewCellStyle cellStyle = UITableViewCellStyle.Default;

		public UITableViewCellAccessory CellAccessory
		{
			get { return cellAccessory; }
			set { cellAccessory = value; }
		}

		protected UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None;

		public TableItem(string heading)
		{
			Heading = heading;
		} 
	}
}
