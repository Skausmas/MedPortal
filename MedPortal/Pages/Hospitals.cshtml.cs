using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedPortal.Pages
{
    public class HospitalsModel : PageModel
    {
        ApplicationContext context;
        public List<Hospitals> Hospitals { get; private set; } = new();
        public List<HospitalSpecialization> Special { get; private set; } = new();
        public List<string> DoctorSpec { get; private set; } = new();
        public HospitalsModel(ApplicationContext db)
        {
            context = db;
        }

        public void OnGet()

        {
            Hospitals = context.Hospitals.Include(d => d.Doctor).AsNoTracking().ToList();


            foreach (Hospitals hospitals in Hospitals)
            {
                foreach (Doctors doc in hospitals.Doctor)
                {
                    DoctorSpec.Add(doc.Specialization);
                }

                HospitalSpecialization h1 = new HospitalSpecialization(hospitals.Name, DoctorSpec);
                Special.Add(h1);
                DoctorSpec.Clear();
            }

        }
    }
}
