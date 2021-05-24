using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class SubjectAreaDTO
    {
        public int ADId { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public List<LectureBaseDTO> Lectures { get; set; }

    }
}
