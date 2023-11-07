using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Numerics;
using System.Security.Claims;

namespace MedPortal.Pages
{
    public class DoctorLKModel : PageModel
    {
        [BindProperty]

        public Registration registr { get; set; } = new();

        ApplicationContext context;


        public DoctorLKModel(ApplicationContext db)
        {
            context = db;

        }

        public void OnGet()
        {

           
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    history.RegistrationId = 1;
        //    history.Anamnesis = "123";
        //    history.Diagnosis = "123";
        //    context.History.Add(history);
        //    await context.SaveChangesAsync();

        //    return RedirectToPage("CreateHistory");
        //}

        public async Task<IActionResult> OnPost()
        {
            registr.UserId = @PageContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            registr.DateVisit = registr.DateVisit.ToUniversalTime();
            context.Registration.Add(registr);
            //context.History.Add(new History(registr.UserId, registr.HospitalId, registr.DoctorId, registr.DateVisit, "графа не заполнена", "графа не заполнена"));
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }

}
