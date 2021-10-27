using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Codesanook.OrganizationProfile
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();
            _manifest.DefineStyle("codesanook-organization-profile").SetUrl("~/Codesanook.OrganizationProfile/styles/style.css");
        }

        public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
    }
}