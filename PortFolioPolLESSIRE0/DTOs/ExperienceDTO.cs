using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class ExperienceDTO
    {
#nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Company : ")]
        public string Company { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Position : ")]
        public string Position { get; set; }
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Description : ")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Start Date : ")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date : ")]
        public DateTime EndDate { get; set; }
    }
}
