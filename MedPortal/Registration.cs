namespace MedPortal
{
    public class Registration
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int HospitalId { get; set; }

        public int DoctorsId { get; set; }

        public DateTime DateVisit { get; set; }

        public List<History> History { get; set; }

        public Hospital? Hospitals { get; set; }

        public Doctors? Doctors { get; set; }

    }
}
