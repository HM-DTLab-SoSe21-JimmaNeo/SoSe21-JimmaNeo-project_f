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

        [Required(ErrorMessage = "Lecture Topic is required")]
        [StringLength(50)]
        public string Topic { get; set; }

        public UserDTO Author { get; set; }

        public DateTime DateOfCreation { get; set; }

    } 

    public class LectureDTO : LectureBaseDTO
    {
        [ValidateComplexType]

        public string Text { get; set; }

        [ValidateComplexType]
        public List<PictureContentDTO> Content { get; set; }

        [ValidateComplexType]
        public List<VideoContentDTO> Videos{ get; set; }

        public TestBaseDTO Test { get; set; }
    }


}
