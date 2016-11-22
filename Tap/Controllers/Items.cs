using System;
using Parse;

namespace Tap
{
	public class Items
	{
		public Items()
		{
		}
		public string Name { get; set; } 		public string Description { get; set; } 		public ParseFile Photo { get; set; } 		public bool IsFavorite { get; set; } 		public string ObjectID { get; set; } 
	}
}
