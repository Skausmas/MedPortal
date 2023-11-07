using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedPortal.Pages
{
    public class DoctorsModel : PageModel
    {
        ApplicationContext context;
        public List<Doctors> Doctors { get; private set; } = new();

        public DoctorsModel(ApplicationContext db)
        {
            context = db;
        }

    public void OnGet()
        {

                Doctors = context.Doctors.Include(u => u.Hospitals).AsNoTracking().ToList();
            
        }

    }
}
