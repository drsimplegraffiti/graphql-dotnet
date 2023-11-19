using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlApi.Enitities;
using GraphQlApi.Repositories;

namespace GraphQlApi.GraphQL.Types
{
    public class ProductQueryTypes
    {
         public async Task<List<ProductDetails>> GetProductListAsync([Service] IProductService productService)
        {
            return await productService.ProductListAsync();
        }
        public async Task<ProductDetails> GetProductDetailsByIdAsync([Service] IProductService productService, Guid productId)
        {
            return await productService.GetProductDetailByIdAsync(productId) ?? null!;
        }
    }
}