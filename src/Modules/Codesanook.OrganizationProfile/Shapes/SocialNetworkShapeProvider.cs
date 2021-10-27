
using System.Text;
using System.Threading.Tasks;
using Codesanook.OrganizationProfile.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.DisplayManagement.Implementation;
using OrchardCore.DisplayManagement.Shapes;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Environment.Shell.Scope;
using OrchardCore.ResourceManagement;
using YesSql;

namespace Codesanook.OrganizationProfile.Shapes
{
    public class SocialNetworkShapeProvider : IShapeAttributeProvider
    {
        private const string contentTypeName = "OrganizationProfile";

        [Shape]
        public async Task<IHtmlContent> SocialNetwork(DisplayContext displayContext, IShapeFactory shapeFactory)
        {
            // var resourceManager = ShellScope.Services.GetRequiredService<IResourceManager>();
            // resourceManager
            // .RegisterResource("style", "codesanook-organization-profile")
            // .AtHead()
            // .ShouldAppendVersion(true);

            var session = ShellScope.Services.GetRequiredService<ISession>();
            var contentItem = await session
                .Query<ContentItem, ContentItemIndex>(q => q.ContentType == contentTypeName)
                .FirstOrDefaultAsync();
            if (contentItem == null) return new HtmlString("");

            var socialNetworkPart = contentItem.As<SocialNetworkPart>();
            var model = new ShapeViewModel<SocialNetworkPart>(socialNetworkPart);
            var templateShape = await shapeFactory.CreateAsync(nameof(SocialNetworkPart), () => new ValueTask<IShape>(model));

            // shape.Properties["count"] = 10;
            // shape.Metadata.Type = "BazTemplate";
            return await displayContext.DisplayHelper.ShapeExecuteAsync(templateShape);
        }
    }
}