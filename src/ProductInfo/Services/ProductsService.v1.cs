using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Ecommerce.V1;

namespace Ecommerce
{
    public class ProductsServiceV1 :  Products.ProductsBase
    {
        private readonly ILogger<ProductsServiceV1> _logger;
        
        public ProductsServiceV1(ILogger<ProductsServiceV1> logger)
        {
            _logger = logger;
        }

        public override Task<Product> GetProduct(ProductId request, ServerCallContext context)
        {
            return Task.FromResult(new Product 
            {
                Id = "abc-1001",
                Name = "sample product name",
                Description = "sample product description",
            });
        }
    }
}
