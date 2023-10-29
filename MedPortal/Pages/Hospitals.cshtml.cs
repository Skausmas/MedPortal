using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedPortal.Pages
{
    public class HospitalsModel : PageModel
    {
        ApplicationContext context;
        public List<Hospitals> Hospitals { get; private set; } = new();
        public List <string> Special {get; private set;} = new();
        public List <string> UniqSpec { get; private set;} = new();
        public HospitalsModel(ApplicationContext db)
        {
            context = db;
        }
        //public List<string> Spec(string name)
        //{

        //    foreach (Hospitals Hosp in Hospitals)
        //    {
        //        foreach (var Doc in Hosp.Doctor)
        //        {
        //            Special.Add(Doc.Specialization);
        //        }
        //    }
        //    foreach (string str in Special)
        //    {
        //        if (!UniqSpec.Contains(str))
        //        {
        //            UniqSpec.Add(str);
        //        }
        //    }
        //    return UniqSpec;
        //}
  
        public void OnGet()

        {
        Hospitals = context.Hospitals.Include(d => d.Doctor).AsNoTracking().ToList();
            //не работает как надо//
            //foreach(Hospitals Hosp in Hospitals)
            //{
            //    Hosp.Specialist = Spec(Hosp.Name);
            //}
        }
    }
}
