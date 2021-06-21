using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{

    public class ToDoDTO
    {
        public int ToDoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Task { get; set; }

        public UserDTO Author { get; set; }

        public bool IsDone { get; set; }
    }

}
