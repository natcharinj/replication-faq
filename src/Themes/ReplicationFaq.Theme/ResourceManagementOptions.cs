using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace ReplicationFaq.Theme
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();
            _manifest.DefineStyle("replication-faq-theme").SetUrl("~/ReplicationFaq.Theme/styles/style.css");
        }

        public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
    }
}