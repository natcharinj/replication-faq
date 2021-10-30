using System.Collections.Generic;
using OrchardCore.ContentManagement;

namespace ReplicationFaq.Theme.Models
{
    public class BlockListPart : ContentPart
    {
        public IReadOnlyCollection<BlockListItem> Items { get; set; }
    }

    public class BlockListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}