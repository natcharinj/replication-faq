// DISTRIBUTOR
// SNAPSHOT
// TRANSACTIONAL
// PEER TO PEER
// MERGE
// SYNC SERVICES
// ALWAYS ON
// CONTACT
using OrchardCore.Data.Migration;
using OrchardCore.ContentManagement;
using OrchardCore.Layers.Services;
using OrchardCore.Rules;
using OrchardCore.DisplayManagement.Notify;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Threading.Tasks;
using OrchardCore.Menu.Models;
using OrchardCore.Title.Models;
using OrchardCore.Alias.Models;
using YesSql;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReplicationFaq.Theme
{
    public class Migrations : DataMigration
    {
        private readonly IContentManager _contentManager;
        private readonly IContentHandleManager _contentHandleManager;
        private readonly ISession _session;
        private readonly ILayerService _layerService;
        private readonly IConditionIdGenerator _conditionIdGenerator;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer<Migrations> H;
        private static readonly Regex pattern = new Regex(@"\s+", RegexOptions.Compiled);

        public Migrations(
            INotifier notifier,
            IHtmlLocalizer<Migrations> localizer,
            IConditionIdGenerator conditionIdGenerator,
            IContentManager contentManager,
            IContentHandleManager contentHandleManager,
            ISession session
        )
        {
            _contentManager = contentManager;
            _contentHandleManager = contentHandleManager;
            _session = session;
            _notifier = notifier;
            H = localizer;
            _conditionIdGenerator = conditionIdGenerator;
        }

        public async Task<int> CreateAsync()
        {
            await CreateMenuAsync();
            return 1;
        }

        private async Task CreateMenuAsync()
        {
            // Create home menu item
            // var homeMenuItem = await _contentManager.NewAsync("LinkMenuItem");
            // homeMenuItem.DisplayText = "Home";
            // homeMenuItem.Alter<LinkMenuItemPart>(p => { p.Name = "Home"; p.Url = "~/"; });
            // await _contentManager.CreateAsync(homeMenuItem, VersionOptions.Published);

            // _session.Query()

            // Create about us menu item
            // var aboutUsMenuItem = await _contentManager.NewAsync("LinkMenuItem");
            // aboutUsMenuItem.DisplayText = "About us";
            // aboutUsMenuItem.Alter<LinkMenuItemPart>(p => { p.Name = "About us"; p.Url = "~/about-us"; });
            // await _contentManager.CreateAsync(aboutUsMenuItem, VersionOptions.Published);

            // Create contact us menu item
            var distributorMenuItem = await CreateMenuItem("Distributor");
            var SnapshotMenuItem = await CreateMenuItem("Snapshot");
            var transactionalMenuItem = await CreateMenuItem("Transactional");
            var peerToPeerMenuItem = await CreateMenuItem("Peer to Peer");
            var mergeMenuItem = await CreateMenuItem("Merge");
            var syncServicesMenuItem = await CreateMenuItem("Sync Services");
            var alwaysOnMenuItem = await CreateMenuItem("Always On");
            var contactMenuItem = await CreateMenuItem("Contact");

            //await _contentManager.CreateAsync(contactUsMenuItem, VersionOptions.Published);
            // C:\projects\OrchardCore\src\OrchardCore.Modules\OrchardCore.Alias\Razor\AliasPartRazorHelperExtensions.cs
            var contentItemId = await _contentHandleManager.GetContentItemIdAsync("alias:main-menu");
            var menuContentItem = await _contentManager.GetAsync(contentItemId);

            // // Create main menu
            // const string mainMenuName = "Main Menu";
            //var mainMenu =  menuContentItem.As<MenuPart>();
            // mainMenu.Alter<TitlePart>(p => p.Title = mainMenuName);
            // mainMenu.DisplayText = mainMenuName;
            // mainMenu.Alter<AliasPart>(p => p.Alias = "main-menu");
            // var menuItems = menuContentItem.As<MenuItemsListPart>().MenuItems;
            // var aboutMenuItem = menuItems.Single(x => x.DisplayText == "About");

            // menuContentItem.Alter<MenuItemsListPart>(p =>
            // {
            //     var aboutMenuItem = p.MenuItems.Single(x => x.DisplayText == "About");
            //     aboutMenuItem.DisplayText = "About Us";
            //     aboutMenuItem.As<LinkMenuItemPart>().Url = "~/about-us";
            // });

            menuContentItem.Alter<MenuItemsListPart>(
                p =>
                {
                    var aboutMenuItem = p.MenuItems.Single(x => x.DisplayText == "About");
                    p.MenuItems.Remove(aboutMenuItem);

                    p.MenuItems.AddRange(new[] {
                        distributorMenuItem,
                        SnapshotMenuItem,
                        transactionalMenuItem,
                        peerToPeerMenuItem,
                        mergeMenuItem,
                        syncServicesMenuItem,
                        alwaysOnMenuItem,
                        contactMenuItem
                    });
                }
            );

            // Update without a new version
            await _contentManager.UpdateAsync(menuContentItem);
        }

        private async Task<ContentItem> CreateMenuItem(string displayText)
        {
            var contactUsMenuItem = await _contentManager.NewAsync("LinkMenuItem");
            contactUsMenuItem.DisplayText = displayText;

            var url = pattern.Replace(displayText.Trim(), "-").ToLower();
            contactUsMenuItem.Alter<LinkMenuItemPart>(p => p.Url = $"~/{url}");
            return contactUsMenuItem;
        }
    }
}