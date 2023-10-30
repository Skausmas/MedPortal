using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MedPortal
{
    public class HospitalSpecialization
    {
        public string Name { get; set; }
        public List <string>Specialization { get; set; }
        public HospitalSpecialization (string name, List<string> special)
        {
            Name = name;

            List<string> UniqSpecial = new List<string> { };

                foreach (string str in special)
                {
                    if (!UniqSpecial.Contains(str))
                    {
                    UniqSpecial.Add(str);
                    }
                }
            Specialization = UniqSpecial;
        }

    }
}
