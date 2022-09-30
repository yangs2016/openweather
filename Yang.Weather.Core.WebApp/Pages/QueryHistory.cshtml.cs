using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Yang.Weather.Business.Models.GoogleMapApi;
using Yang.Weather.DataAccess.Contracts;

namespace Yang.Weather.Core.WebApp.Pages
{
    public class QueryWeatherHistoryModel : PageModel
    {
        private readonly IGeoCodeDao _geoCodeDao;

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "US Zip code is required.")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid US Zipcode.")]
        public string Postalcode { get; set; } = String.Empty;

        [BindProperty]
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-30);

        [BindProperty]
        public DateTime EndDate { get; set; } = DateTime.Now;

        public QueryWeatherHistoryModel(IGeoCodeDao geocodeDao) => _geoCodeDao = geocodeDao;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var geoCodes = _geoCodeDao.GetGeocodeByZipcode(Postalcode);

            if (geoCodes != null)
            {
               return RedirectToPage("WeatherHistory", "Hist", new { zip = Postalcode, startDate = StartDate, endDate = EndDate });
            }
           
            return RedirectToPage("Error", new { errorMessage = $"Geocodes was not found for the zipcode {Postalcode}" });
        }
    }
}
