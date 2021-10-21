using System.Threading.Tasks;
using Codesanook.OrganizationProfile.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Shapes;
using OrchardCore.DisplayManagement.Zones;
using OrchardCore.ResourceManagement;

namespace Codesanook.OrganizationProfile.Handlers
{
    public class ContentDisplayHandler : IContentDisplayHandler
    {
        private readonly IResourceManager _resourceManager;

        public ContentDisplayHandler(IResourceManager resourceManager)
        {
            this._resourceManager = resourceManager;
        }

        public Task BuildDisplayAsync(ContentItem contentItem, BuildDisplayContext context) => Task.CompletedTask;

        public Task BuildEditorAsync(ContentItem contentItem, BuildEditorContext context)
        {
            if (contentItem.ContentType != "OrganizationProfile")
            {
                return Task.CompletedTask;
            }

            _resourceManager
                .RegisterUrl("script", "~/Codesanook.OrganizationProfile/scripts/script.js", null)
                .AtFoot()
                .ShouldAppendVersion(true);

            return Task.CompletedTask;
        }

        public Task UpdateEditorAsync(ContentItem contentItem, UpdateEditorContext context)
        {
            // var addressPart = contentItem.As<AddressPart>();
            // toggleDisplayedFormPart
            return Task.CompletedTask;
        }
    }
}