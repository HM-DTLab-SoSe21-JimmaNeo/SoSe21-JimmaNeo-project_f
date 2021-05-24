using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class LoginInformationDTO
    {
        [Required]
        public UserDTO User { get; set; }

        [Required]
        public string Pw { get; set; }

    }
}
