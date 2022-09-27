using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yang.Weather.Business.Models.GoogleMapApi;
using Yang.Weather.Business.Models.OpenWeather;
using Yang.Weather.Business.Services;
using Yang.Weather.DataAccess.Contracts;

namespace Yang.Weather.Core.WebApp.Pages
{
    public class GoogleMapApiQueryModel : PageModel
    {
        private readonly IGoogleMapApiService _googleMapApiService;
        private readonly IWeatherApiService _weatherApiService;
        private readonly IGeoCodeDao _geoCodeDao;

        [BindProperty]
        public Address? AddressModel { get; set; }

        [BindProperty]
        public GeoCode? GeoCodeResult { get; set; }

        [BindProperty]
        public OpenWeatherApiResponse? WeatherCondition { get; set; }

       
        public GoogleMapApiQueryModel(IGoogleMapApiService service, IWeatherApiService weather, IGeoCodeDao geocodeDao )
        { 
            _googleMapApiService = service;
            _weatherApiService = weather;
            _geoCodeDao = geocodeDao;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var apiResult = AddressModel != null? _googleMapApiService.QueryGeocoding(AddressModel): null;

            if (apiResult != null)
            {
                GeoCodeResult = apiResult.Geometry.Location;
                if (GeoCodeResult != null)
                {
                    var id = _geoCodeDao.CreateGeoCode(new DataAccess.Models.GeoCode()
                    {
                        Latitude = GeoCodeResult.Latitude,
                        Longitude = GeoCodeResult.Longitude,
                        Description = apiResult.PlaceId,
                        Postalcode = AddressModel?.PostalCode ?? String.Empty
                    });
                    
                    return RedirectToPage("Weather" , new { Id = id, Longitude = GeoCodeResult.Longitude, Latitude = GeoCodeResult.Latitude, PlaceId=apiResult.PlaceId, PostalCode = AddressModel?.PostalCode });

                }
                //GetWeatherCondition(GeoCodeResult);

                //return new OkObjectResult(new { message = "Geocode found ok", data = apiResult });
            }

            return RedirectToPage("Error", new { errorMessage = $"Geocode was not found with your address for zipcode {AddressModel?.PostalCode}" });
            
        }

        public void GetWeatherCondition(GeoCode? locale)
        {
            if (locale == null)
            {
                throw new Exception("Geocode is required");
            }
            
            var result = _weatherApiService.QueryWeatherCondition(locale);
            
            WeatherCondition = result;           

       }
    }
}
