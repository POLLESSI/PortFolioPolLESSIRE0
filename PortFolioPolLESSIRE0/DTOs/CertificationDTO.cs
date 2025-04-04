using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class CertificationDTO
    {
#nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Certification Name : ")]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Authority : ")]
        public string Authority { get; set; }
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Licence Number : ")]
        public string LicenceNumber { get; set; }
        [MinLength(2)]
        [MaxLength(4000)]
        [DisplayName("Url : ")]
        public string Url { get; set; }
        [Required]
        [DisplayName("Date : ")]
        public DateTime LicenceDate { get; set; }
    }
}
