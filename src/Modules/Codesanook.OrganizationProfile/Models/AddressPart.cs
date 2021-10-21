using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OrchardCore.ContentManagement;

namespace Codesanook.OrganizationProfile.Models
{
    public class AddressPart : ContentPart
    {

        [DisplayName("Show address")]
        [Required]
        public bool ShowAddress { get; set; } = false;

        [DisplayName("House number")]
        //[Required]
        public string HouseNumber { get; set; }

        [DisplayName("Village name")]
        public string VillageName { get; set; }

        [DisplayName("Village number")]
        public int? VillageNumber { get; set; }

        [DisplayName("Building name")]
        ///[Required]
        public string BuildingName { get; set; }

        [DisplayName("Room number")]
        public string RoomNumber { get; set; }
        public int? Floor { get; set; }
        public string Lane { get; set; }

        //[Required]
        public string Street { get; set; }

        ///[Required]
        public string Subdistrict { get; set; }

        //[Required]
        public string District { get; set; }

        //[Required]
        public string Province { get; set; }

        //[Required]
        public string State { get; set; }

        //[Required]
        public string Country { get; set; }


        [DisplayName("Zip code")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "ZIP code must be 5 digits.")]
        [Required]
        public string ZipCode { get; set; }
    }
}