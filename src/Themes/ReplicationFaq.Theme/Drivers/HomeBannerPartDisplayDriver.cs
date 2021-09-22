using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.Views;
using ReplicationFaq.Theme.Models;
using YesSql;

namespace ReplicationFaq.Theme.Drivers
{
    public class HomeBannerPartDisplayDriver : ContentPartDisplayDriver<HomeBannerPart>
    {
        private readonly ISession _session;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentManager _contentManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public HomeBannerPartDisplayDriver(
            ISession session,
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _session = session;
            _contentDefinitionManager = contentDefinitionManager;
            _contentManager = contentManager;
            _urlHelperFactory = urlHelperFactory;
            this._actionContextAccessor = actionContextAccessor;
        }

        public override IDisplayResult Display(HomeBannerPart part, BuildPartDisplayContext context)
        {
            return View(nameof(HomeBannerPart), part).Location("Detail", "Content:10");
        }
    }
}