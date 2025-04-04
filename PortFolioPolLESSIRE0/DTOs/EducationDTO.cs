using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class EducationDTO
    {
#nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("School : ")]
        public string School { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Degree : ")]
        public string Degree { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string FieldOfStudy { get; set; }
        [Required]
        [DisplayName("Start Date : ")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date :")]
        public DateTime EndDate { get; set; }
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Description : ")]
        public string Description { get; set; }
    }
}
