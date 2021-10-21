using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using Codesanook.OrganizationProfile.Models;

namespace Codesanook.OrganizationProfile.Drivers
{
    public class SocialNetworkPartDisplayDriver : ContentPartDisplayDriver<SocialNetworkPart>
    {
        public override IDisplayResult Display(SocialNetworkPart part, BuildPartDisplayContext context) => 
            View(GetDisplayShapeType(context), part)
                .Location("Detail", "Content:10");

        public override IDisplayResult Edit(SocialNetworkPart part, BuildPartEditorContext context) =>
            View(GetEditorShapeType(context), part);

        public override async Task<IDisplayResult> UpdateAsync(SocialNetworkPart part, UpdatePartEditorContext context)
        {
            await context.Updater.TryUpdateModelAsync(part, $"{Prefix}.Value");
            return Edit(part, context);
        }
    }
}
