using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching;
using System.Globalization;

namespace Yang.Weather.Core.WebApp.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string currentTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["Timestamp"] = currentTime;
        }
    }
}