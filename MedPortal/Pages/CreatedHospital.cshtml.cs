using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedPortal.Pages
{
    public class CreatedHospitalModel : PageModel
    {
        ApplicationContext context;

        [BindProperty]
        public Hospital hospit { get; set; } = new();
        public CreatedHospitalModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Hospitals.Add(hospit);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
