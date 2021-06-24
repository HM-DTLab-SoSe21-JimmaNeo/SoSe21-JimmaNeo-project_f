using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }

        public string Task { get; set; }

        public User Author { get; set; }

        public bool IsDone { get; set; }

    }
}
