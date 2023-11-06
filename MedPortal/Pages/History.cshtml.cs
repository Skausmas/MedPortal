using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace MedPortal.Pages
{
    public class HistoryModel : PageModel
    {
        ApplicationContext context;

        public List<Registration> Registrations { get; private set; } = new();
        public HistoryModel(ApplicationContext db)
        {
            context = db;

        }

        public void OnGet()
        {


            Registrations = context.Registration.Include(u => u.Hospitals).Include(u => u.Doctors).AsNoTracking().ToList();



        }

    }
}
