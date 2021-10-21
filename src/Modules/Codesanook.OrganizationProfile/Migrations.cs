using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using Codesanook.OrganizationProfile.Models;
using OrchardCore.ContentManagement;
using OrchardCore.Autoroute.Models;

namespace Codesanook.OrganizationProfile
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentManager _contentManager;

        public Migrations(
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager
        )
        {
            _contentDefinitionManager = contentDefinitionManager;
            _contentManager = contentManager;
        }

        public int CreateAsync()
        {
            CreateOrganizationProfileType();
            return 1;
        }

        private void CreateOrganizationProfileType()
        {
            // Define content parts
            _contentDefinitionManager.AlterPartDefinition(
                nameof(AddressPart),
                builder => builder.Attachable().WithDescription("Providing an address part for a content item")
            );

            _contentDefinitionManager.AlterPartDefinition(
                nameof(ContactInformationPart),
                builder => builder.Attachable().WithDescription("Providing a contact information part for a content item")
            );

            _contentDefinitionManager.AlterPartDefinition(
                nameof(SocialNetworkPart),
                builder => builder.Attachable().WithDescription("Providing a social network part for a content item")
            );

            // Define a new content type for a contact us page
            const string contentType = "OrganizationProfile";
            _contentDefinitionManager.AlterTypeDefinition(
                contentType,
                type => type
                    .WithPart(nameof(AutoroutePart))
                    .WithPart(nameof(AddressPart))
                    .WithPart(nameof(ContactInformationPart))
                    .WithPart(nameof(SocialNetworkPart))
                    .Draftable(false)
                    .Versionable(false)
                    .Listable()
            );
        }
    }
}
