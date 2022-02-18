using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class CustomerListDto : IDto
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string CustomerSurName { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerMail { get; set; }
		public string Description { get; set; }
		public string ProductType { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool Status { get; set; }
	}
}
