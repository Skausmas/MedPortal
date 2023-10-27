using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MedPortal.Pages
{
    public class CreateDoctorsModel : PageModel
    {
        ApplicationContext context;

        [BindProperty]

        public Doctors doctor { get; set; } = new();

        public CreateDoctorsModel(ApplicationContext db)
        {
            context = db;
        }
        public List<Hospitals> Hospitals { get; private set; } = new();
        public void OnGet()
        {
            Hospitals = context.Hospitals.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}
