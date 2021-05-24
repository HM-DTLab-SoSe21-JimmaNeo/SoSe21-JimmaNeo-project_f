using System;
using SEIIApp.Shared;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SEIIApp.Server.Domain
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public string Pw { get; set; }
        
        public Role Role { get; set; }    
    }
}
