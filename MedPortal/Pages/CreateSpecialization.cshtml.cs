using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPortal.Pages
{
    public class CreateSpecializationModel : PageModel
    {
        ApplicationContext context;

        [BindProperty]
        public Specialization spec{ get; set; } = new();
        public CreateSpecializationModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Specialization.Add(spec);
            await context.SaveChangesAsync();
            return RedirectToPage("CreateDoctors");
        }
    }
}