using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;

namespace Codesanook.OrganizationProfile.Drivers
{
    public class ContactInformationPartDisplayDriver : ContentPartDisplayDriver<ContactInformationPart>
    {
        public override IDisplayResult Display(ContactInformationPart part, BuildPartDisplayContext context) => 
            View(GetDisplayShapeType(context), part)
                .Location("Detail", "Content:10");

        public override IDisplayResult Edit(ContactInformationPart part, BuildPartEditorContext context) =>
            View(GetEditorShapeType(context), part);

        public override async Task<IDisplayResult> UpdateAsync(ContactInformationPart part, UpdatePartEditorContext context)
        {
            await context.Updater.TryUpdateModelAsync(part, $"{Prefix}.Value");
            return Edit(part, context);
        }
    }
}
