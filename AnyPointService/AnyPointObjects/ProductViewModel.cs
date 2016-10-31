using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyPointObjects
{
    public class ProductViewModel
    {
		public int Id { get; set; }
		public string Sku { get; set; }
		public string Name { get; set; }
		public decimal OriginalPrice { get; set; }
		public decimal DiscountPrice { get; set; }
		public decimal RRP { get; set; }
	}
}
