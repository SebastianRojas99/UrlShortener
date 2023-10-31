using System;
using System.ComponentModel.DataAnnotations;

namespace URLshorter.Entities
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public Category()
		{
		}
	}
}

