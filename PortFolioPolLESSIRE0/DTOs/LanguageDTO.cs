using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class LanguageDTO
    {
    #nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Name : ")]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(16)]
        [DisplayName("Level : ")]
        public string Level { get; set; }
    }
}












//Copyrite https://github.com/POLLESSI