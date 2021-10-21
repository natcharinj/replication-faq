using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OrchardCore.ContentManagement;

namespace Codesanook.OrganizationProfile.Models
{
    public class SocialNetworkPart : ContentPart
    {
        const string urlPattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()!@:%_\+.~#?&\/\/=]*)";
        const string invalidUrlErrorMessage = "Url is incorrect";

        [DisplayName("Show social network")]
        [Required]
        public bool ShowSocialNetwork { get; set; } = true;


        [RegularExpression(urlPattern, ErrorMessage = invalidUrlErrorMessage)]
        public string Facebook { get; set; }

        [RegularExpression(urlPattern, ErrorMessage = invalidUrlErrorMessage)]
        public string YouTube { get; set; }
    }
}