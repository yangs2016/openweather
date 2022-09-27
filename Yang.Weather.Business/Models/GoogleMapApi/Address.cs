using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Yang.Weather.Business.Models.GoogleMapApi
{
    public class Address
    {
        public string? AdressLine1 { get; set; }
        public string? AdressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "US Zip code is required.")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid US Zipcode.")]
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

    }
}
