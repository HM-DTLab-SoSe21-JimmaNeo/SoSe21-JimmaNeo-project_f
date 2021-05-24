using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class FurtherLink
    {
        [Key]
        public int LinkId { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

    }
}
