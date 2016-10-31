using System.ComponentModel.DataAnnotations;

namespace AnyPointObjects
{
	public class UserViewModel
    {
		
		public int ID { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
