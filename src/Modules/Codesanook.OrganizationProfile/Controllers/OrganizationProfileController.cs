using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using OrchardCore.Admin;
using OrchardCore.Autoroute.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Notify;
using YesSql;

namespace Codesanook.OrganizationProfile.Controllers
{
    [Admin]
    public class OrganizationProfileController : Controller
    {
        private readonly IContentItemDisplayManager _contentItemDisplayManager;
        private readonly IUpdateModelAccessor _updateModelAccessor;
        private readonly IContentManager _contentManager;
        private readonly ISession _session;
        private readonly IStringLocalizer S;
        private readonly INotifier _notifier;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IHtmlLocalizer H;
        private const string contentTypeName = "OrganizationProfile";

        public OrganizationProfileController(
            IContentItemDisplayManager contentItemDisplayManager,
            ISession session,
            IContentManager contentManager,
            IUpdateModelAccessor updateModelAccessor,
            IStringLocalizer<OrganizationProfileController> stringLocalizer,
            IContentDefinitionManager contentDefinitionManager,
            IHtmlLocalizer<OrganizationProfileController> htmlLocalizer,
            INotifier notifier)
        {
            _contentItemDisplayManager = contentItemDisplayManager;
            _session = session;
            _contentManager = contentManager;
            _updateModelAccessor = updateModelAccessor;
            S = stringLocalizer;
            H = htmlLocalizer;
            _contentDefinitionManager = contentDefinitionManager;
            _notifier = notifier;
        }

        public async Task<IActionResult> Edit()
        {
            var (contentItem, _) = await GetContentItemAsync();
            var contentItemEditorShape = await _contentItemDisplayManager.BuildEditorAsync(
                contentItem,
                _updateModelAccessor.ModelUpdater,
                 false
            );
            return View(contentItemEditorShape);
        }

        [HttpPost]
        [ActionName(nameof(OrganizationProfileController.Edit))]
        public async Task<IActionResult> EditPost()
        {
            var (contentItem, contentItemAction) = await GetContentItemAsync();
            var contentItemEditorShape = await _contentItemDisplayManager.UpdateEditorAsync(contentItem, _updateModelAccessor.ModelUpdater, false);
            if (!ModelState.IsValid)
            {
                await _session.CancelAsync();
                return View(contentItemEditorShape);
            }

            contentItemAction(); // create or update content item
            var typeDefinition = _contentDefinitionManager.GetTypeDefinition(contentTypeName);
            var contentItemMetadata = await _contentManager.GetContentItemMetadataAsync(contentItem);

            _notifier.Success(
                string.IsNullOrWhiteSpace(typeDefinition.DisplayName)
                    ? H["Your content has been published."]
                    : H["Your {0} has been published.", typeDefinition.DisplayName]
            );

            return View(contentItemEditorShape);
        }

        private async Task<(ContentItem, Action)> GetContentItemAsync()
        {
            var contentItem = await _session
                .Query<ContentItem, ContentItemIndex>(q => q.ContentType == contentTypeName)
                .FirstOrDefaultAsync();
            if (contentItem != null) return (contentItem, () => _contentManager.UpdateAsync(contentItem));

            // Set auto route part only for a new content item
            contentItem = await _contentManager.NewAsync(contentTypeName);
            var autoroutePart = contentItem.As<AutoroutePart>();
            autoroutePart.Path = "/contact-us";
            return (contentItem, () => _contentManager.CreateAsync(contentItem, VersionOptions.Published));
        }
    }
}