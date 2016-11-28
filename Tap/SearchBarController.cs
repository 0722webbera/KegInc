using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using Parse;
using System.Threading.Tasks;

namespace Tap
{
    public partial class SearchBarController : UITableViewController
    {
		

		public SearchBarController (IntPtr handle) : base (handle)
        {

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			UISearchController searchController = new UISearchController();
			//searchController.SearchBar.SizeToFit();
			this.TableView.TableHeaderView = searchController.SearchBar;

			//UISearchController searchController = new UISearchController()
			//{
			//	WeakDelegate = this,
			//	DimsBackgroundDuringPresentation = false,
			//	WeakSearchResultsUpdater = this
			//};


			//tblList.TableHeaderView = searchController.SearchBar;
			//searchController.SearchBar.SizeToFit();

			//searchController.SearchBar.WeakDelegate = this;


		}



		//async public override void ViewWillAppear(bool animated)
		//{
		//	this.TableView.TableHeaderView = searchController.SearchBar;
		//}

		//public SearchBarController (IntPtr handle) : base (handle)
		//{
  		//}r

		//[Export ("searchBarSearchButtonClicked:")]


		//public virtual void SearchButtonClicked(UISearchBar searchBar)
		//{
		//	searchBar.ResignFirstResponder();
		//}


		//[Export("updateSearchResultsForSearchController:")]


		public async virtual Task UpdateSearchResultsForSearchController(UISearchController searchController)
		{
			//var tableController = this;//(ResultsTableController)searchController.SearchResultsController;
			await PerformSearch(searchController.SearchBar.Text);
			//tableController.TableView.ReloadData();
		}

		async Task PerformSearch(string searchString)
		{
			searchString = searchString.Trim();

			try
			{

				// TODO: specify the name of your table in in place of "tblContacts"
				// TODO: Add a progress bar

				List<TableItem> tableItems = new List<TableItem>();

				//var searchBar = srcBar.Text;

				// build a query to get a list of records from the Items class in Parse
				// and sort the results by the Name column
				//var query = from item in ParseObject.GetQuery("Items") where item["Name"].Equals(searchBar) orderby item["Name"] ascending select item;

				//for table test class 
				var query = from item in ParseObject.GetQuery("TestTable") orderby item["Name"] ascending select item;

				//for items class
				//var query = from item in ParseObject.GetQuery("Items") orderby item["CreatedAt"] ascending select item;

				//String search

				//var query = from item in ParseObject.GetQuery("TestTable") where item["Name"].Equals(searchString) orderby item["Name"] ascending select item;

				// make an asynchronous call to Parse to get the contents of the query above
				IEnumerable<ParseObject> photoListResults = await query.FindAsync();

				// if the returned list from Parse is not empty
				if (photoListResults != null)
				{
					// loop through the results and set the object properties
					foreach (var photoListItem in photoListResults)
					{
						var photoItem = new Items()
						{
							Name = photoListItem.Get<string>("Name"),
							ObjectID = photoListItem.ObjectId,
							Photo = photoListItem.Get<ParseFile>("Photo"),
							Description = photoListItem.Get<string>("Description"),
							IsFavorite = photoListItem.Get<bool>("IsFavorite")
						};

						// assign the retrieved properties to the TableItem’s properties
						tableItems.Add
						(
							new TableItem(photoItem.Name)
							{
								SubHeading = photoItem.Description,
								ImageUrl = photoItem.Photo.Url.ToString(),
								IsFavorite = photoItem.IsFavorite
							}
						);
					}
				}

				tblList.RowHeight = 150f; // adjust this to resize the imageView

				// set the table view’s source to that of the new ImageTableSource 
				tblList.Source = new ImageTableSource(tableItems);
			}

			catch (Exception e)
			{
				UIAlertView alert = new UIAlertView()
				{
					Title = "Error",
					Message = "Error loading list."
				};
				alert.AddButton("Okay");
				alert.Show();
			}
			//return filteredProducts.Distinct().ToList();
		}

    }
}