using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace ReplicationFaq.Theme.Drivers
{
    public class BlogPostContentDisplayDriver : ContentDisplayDriver
    {
        public override  IDisplayResult Display(ContentItem contentItem, IUpdateModel updater)
        {
            if (contentItem.ContentType != "BlogPost")
            {
                return null;
            }

            return View("BlogPostMeta", contentItem).Location("Detail", "Meta:1");
        }

    }
}