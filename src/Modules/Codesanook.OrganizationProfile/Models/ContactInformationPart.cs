using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OrchardCore.ContentManagement;

public class ContactInformationPart : ContentPart
{
    [DisplayName("Show contact information")]
    [Required]
    public bool ShowContactInformation { get; set; } = true;

    [DisplayName("Phone number")]
    [RegularExpression(@"^[\+]?[(]?[0-9]{1,3}[)]?[-\s\.]?[0-9]{3,4}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Format phone number is incorrect")]
    [Required]
    public string PhoneNumber { get; set; }

    [DisplayName("Email address")]
    [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "Email code is incorrect")]
    [Required]
    public string EmailAddress { get; set; }
}