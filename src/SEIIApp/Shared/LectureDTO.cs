using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class LectureBaseDTO
    {
        public int LectureId { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; }

        public UserDTO Author { get; set; }

        public DateTime DateOfCreation { get; set; }

    } 

    public class LectureDTO
    {
        // TDDO ??[ValidateComplexType]

        public string Text { get; set; }

        public List<LectureContentDTO> Content { get; set; }

        public List<TestBaseDTO> Test { get; set; }
    }


}
