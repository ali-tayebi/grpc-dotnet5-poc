using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Ecommerce.V2;

namespace Ecommerce
{
    public class ProductsServiceV2 :  Products.ProductsBase
    {
        private readonly ILogger<ProductsServiceV1> _logger;
        
        public ProductsServiceV2(ILogger<ProductsServiceV1> logger)
        {
            _logger = logger;
        }

        public override Task<Product> GetProduct(ProductId request, ServerCallContext context)
        {
            return Task.FromResult(new Product 
            {
                Id = 1001,
                Name = "sample product name - ver2.0",
                Description = "sample product description - ver2.0",
            });
        }
    }
}
