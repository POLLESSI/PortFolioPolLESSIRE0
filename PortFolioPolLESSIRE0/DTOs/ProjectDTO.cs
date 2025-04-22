using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortFolioPolLESSIRE0.DTOs
{
    public class ProjectDTO
    {
#nullable disable
        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Project Name : ")]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string Description { get; set; }
        [DisplayName("URL : ")]
        public string Url { get; set; }
        [Required]
        [DisplayName("Start Date : ")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date : ")]
        public DateTime EndDate { get; set; }
    }
}











//Copyrite https://github.com/POLLESSI

