using Microsoft.AspNetCore.Html;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.DisplayManagement.Shapes;

namespace ReplicationFaq.Theme
{
    public class BlogShapeProvider : IShapeTableProvider
    {
        public void Discover(ShapeTableBuilder builder)
        {
            builder
                .Describe("Content__Blog")
                .OnDisplaying(displaying =>
                {
                    var shape = displaying.Shape as Shape;
                    shape.Remove("Metadata");
                    shape.Remove("Content");
                    shape.Remove("Header");

                });
        }
    }
}