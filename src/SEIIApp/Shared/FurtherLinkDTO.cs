using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class FurtherLinkDTO
    {
        [Required(ErrorMessage = "Url of Link is required")]
        public string Link { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
