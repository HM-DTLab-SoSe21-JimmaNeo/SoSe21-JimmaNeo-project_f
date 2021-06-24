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
        [StringLength(100)]
        public string Topic { get; set; }

        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Creator { get; set; }

        public string Tags { get; set; }
    }
}
