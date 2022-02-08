using Microsoft.AspNetCore.Mvc.Rendering;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AUDescriptionUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int AboutUsId { get; set; }

    }
}
