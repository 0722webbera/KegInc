using Foundation;
using System;
using UIKit;
using Parse;
using System.Collections.Generic;

namespace Tap
{
    public partial class SearchController : UIViewController
    {
        public SearchController (IntPtr handle) : base (handle)
        {
        }

		public async override void ViewWillAppear (bool animated)  		{ 		base.ViewWillAppear (animated); 

			try{
				 				// TODO: specify the name of your table in in place of "tblContacts" 				// TODO: Add a progress bar  				List<TableItem> tableItems = new List<TableItem>(); 
				var searchBar = srcBar.Text;
			
					// build a query to get a list of records from the Items class in Parse
					// and sort the results by the Name column
					//var query = from item in ParseObject.GetQuery("Items") where item["Name"].Equals(searchBar) orderby item["Name"] ascending select item;
					//var query = from item in ParseObject.GetQuery("Items") orderby item["Name"] ascending select item; 				var query = from item in ParseObject.GetQuery("Items") where item["Name"].Equals(searchBar) orderby item["Name"] ascending select item;
					 				// make an asynchronous call to Parse to get the contents of the query above 				IEnumerable<ParseObject> photoListResults = await query.FindAsync();  				// if the returned list from Parse is not empty 				if (photoListResults != null) 				{ 					// loop through the results and set the object properties 					foreach (var photoListItem in photoListResults) 					{ 						var photoItem = new Items ()  						{ 							Name = photoListItem.Get<string> ("Name"),  							ObjectID = photoListItem.ObjectId,  							Photo = photoListItem.Get<ParseFile> ("Photo"), 							Description = photoListItem.Get<string> ("Description"),  							IsFavorite = photoListItem.Get<bool> ("IsFavorite") 						}  ;

						// assign the retrieved properties to the TableItem’s properties 						tableItems.Add  						( 							new TableItem(photoItem.Name)  							{ 								SubHeading=photoItem.Description,  								ImageUrl = photoItem.Photo.Url.ToString(), 								IsFavorite = photoItem.IsFavorite 							}    						); 					} 				} 
				tblItems.RowHeight = 150f; // adjust this to resize the imageView  				// set the table view’s source to that of the new ImageTableSource  				tblItems.Source = new ImageTableSource (tableItems); 
				}
				catch(Exception e)
				{
				}  		 }
    }

}