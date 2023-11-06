
namespace MedPortal

{
    public class History
    {
        public int Id { get; set; }

        public int RegistrationId { get; set; }

        public string Anamnesis { get; set; }

        public string Diagnosis { get; set; }

        public Registration? Registration { get; set; }



        //public Doctors? Doctors { get; set; }


    }
}
