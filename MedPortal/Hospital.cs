namespace MedPortal
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Sector { get; set; }
        public string Adress { get; set; }
        public string Direction { get; set; }
        public List<Doctors> Doctor { get; set; }

        public List<Registration> Registrations { get; set; }

    }
}
