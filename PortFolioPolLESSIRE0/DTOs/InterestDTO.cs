using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class InterestDTO
    {
#nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Interest Name : ")]
        public string Name { get; set; }
        [DisplayName("Description : ")]
        public string Description { get; set; }

    }
}

