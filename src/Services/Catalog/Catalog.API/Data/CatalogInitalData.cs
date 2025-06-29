using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitalData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync(cancellation))
            {
                return;
            }

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Category = new List<string> { "Category 1" },
                    Description = "Description for Product 1",
                    ImageFile = "product1.jpg",
                    Price = 10.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Category = new List<string> { "Category 2" },
                    Description = "Description for Product 2",
                    ImageFile = "product2.jpg",
                    Price = 20.99m
                }
            };
        }
    }
}
