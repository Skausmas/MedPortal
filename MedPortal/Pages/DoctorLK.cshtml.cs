using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MedPortal.Pages
{
    public class DoctorLKModel : PageModel
    {
        [BindProperty]

        public History history { get; set; } = new();

        
        ApplicationContext context;

        public List<Registration> Registrations { get; private set; } = new();
        public DoctorLKModel(ApplicationContext db)
        {
            context = db;

        }

        public void OnGet()
        {

            Registrations = context.Registration.Include(u => u.Hospitals).Include(u => u.Doctors).AsNoTracking().ToList();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            history.RegistrationId = 1;
            history.Anamnesis = "123";
            history.Diagnosis = "123";
            context.History.Add(history);
            await context.SaveChangesAsync();

            return RedirectToPage("CreateHistory");
        }
    }
}
