using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using ReplicationFaq.Theme.Models;

namespace ReplicationFaq.Theme.Drivers
{
    public class BlockListPartDisplayDriver : ContentPartDisplayDriver<BlockListPart>
    {
        public override IDisplayResult Display(BlockListPart part, BuildPartDisplayContext context)
        {
            // Todo query taxonomy and pass as name:URL
            return Dynamic(nameof(BlockListPart)).Location("Detail", "Content:10");
        }

    }

}