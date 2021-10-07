using OrchardCore.ContentManagement;

namespace ReplicationFaq.Theme.Models
{
    public class HomeBannerPart : ContentPart
    {
        public string Terms { get; set; }
        // transform to search term
        // var searchTerm = string.Join(" OR ", words);
        // https://dba.stackexchange.com/a/230067/165543
        // Transform search queries keyword to search term
        // var words = request.SearchQueries
        //     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //     .Select(w => $"\"{w}*\"");
        // var searchTerm = string.Join(" OR ", words);
        
    }
}