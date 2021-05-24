using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class UserDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [DefaultValue(Role.None)]
        public Role Role { get; set; }
    }

    public enum Role
    {
        None,
        Student,
        Teacher,
        Admin
    }

}
