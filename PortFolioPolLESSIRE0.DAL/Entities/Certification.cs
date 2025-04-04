namespace PortFolioPolLESSIRE0.DAL.Entities
{
    public class Certification
    {
    #nullable disable
        public int Id { get; set; }
        public string Name { get; set; }
        public string Authority { get; set; }
        public string LicenceNumber { get; set; }
        public string Url { get; set; }
        public DateTime LicenceDate { get; set; }  
        public bool Active { get; set; }
    }
}
