using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{

    public class TestBaseDTO
    {
        public int TestID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Topic { get; set; }
        
        public string Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public UserDTO Author { get; set; }
        
    }

    public class TestDTO : TestBaseDTO
    {

        // TDDO [ValidateComplexType]
        public List<QuestionDTO> Questions { get; set; }
        
        public List<VideoContentDTO> Videos { get; set; }

        public List<PictureContentDTO> Content { get; set; }

        public List<FurtherLinkDTO> FurtherLinks { get; set; }

    }
}
