﻿namespace MedPortal
{
    public class Doctors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialization { get; set; }

        public string Experience { get; set; }

        public string Education { get; set; }

        public int HospitalsId { get; set; } 
        public Hospitals? Hospitals { get; set; }
    }
}
