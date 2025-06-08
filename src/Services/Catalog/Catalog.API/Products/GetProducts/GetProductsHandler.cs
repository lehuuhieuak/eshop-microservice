namespace Catalog.API.Products.GetProducts
{
    public record GetProductsResult(IEnumerable<Product> Products);

    public record GetProductQuery() : IQuery<GetProductsResult>;

    public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductQueryHandler.Handle called with {@Query}", query);

            var products = await session.Query<Product>()
                .ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
