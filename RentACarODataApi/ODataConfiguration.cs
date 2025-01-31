using BusinessModel.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace RentACarODataApi
{
    public static class ODataConfiguration
    {
        public static void AddODataConfiguration(this IMvcBuilder builder)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<AutoMobile>("Vehicles");
            modelBuilder.EntitySet<Order>("Orders");
            modelBuilder.EntitySet<Customer>("Customers");

            modelBuilder.EntityType<Order>().HasMany(o => o.Items);

            builder.AddOData(options => options
                .Select()
                .Filter()
                .Expand()
                .Count()
                .OrderBy()
                .SetMaxTop(20)
                .AddRouteComponents("odata", modelBuilder.GetEdmModel())
            );
        }
    }
}
