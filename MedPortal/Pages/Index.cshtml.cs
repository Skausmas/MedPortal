﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<User> Users = new List<User>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        async public Task OnGet([FromServices] IGetAllUsers getus)
        {
            Users = await getus.GetAllUsers(); 
        }
         async public Task OnPost([FromServices]IFindUsers findUs, string search)
        {
            Users = await findUs.FindUsers(search);
        }
    }
}