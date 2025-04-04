using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class SkillDTO
    {
    #nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Skill Name : ")]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Level : ")]
        public string Level { get; set; }
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Description : ")]
        public string Description { get; set; }
    }
}
