using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CompanyServiceListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
