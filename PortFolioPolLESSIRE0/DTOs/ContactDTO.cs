using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class ContactDTO
    {
    #nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Contact Name : ")]
        public string Name { get; set; }
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Email : ")]
        public string Email { get; set; }
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Phone : ")]
        public string Phone { get; set; }
    }
}











//Copyrite https://github.com/POLLESSI
