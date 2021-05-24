using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class NewsDTO
    {
        public int NewsID { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; }

        public string Content { get; set; }

        public UserDTO Author { get; set; }

        public DateTime Date { get; set; }

    }
}
