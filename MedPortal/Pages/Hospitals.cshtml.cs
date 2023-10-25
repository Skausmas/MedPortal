using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedPortal.Pages
{
    public class HospitalsModel : PageModel
    {
        ApplicationContext context;
        public List<Hospitals> Hospitals { get; private set; } = new();
        public HospitalsModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Hospitals = context.Hospitals.AsNoTracking().ToList();
        }
    }
}
