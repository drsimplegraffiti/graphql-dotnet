using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlApi.Enitities;

namespace GraphQlApi.Repositories
{
    public interface IProductService
    {
        public Task<List<ProductDetails>> ProductListAsync();
        public Task<ProductDetails?> GetProductDetailByIdAsync(Guid productId);
        public Task<bool> AddProductAsync(ProductDetails productDetails);
        public Task<bool> UpdateProductAsync(ProductDetails productDetails);
        public Task<bool> DeleteProductAsync(Guid productId);

        public Task GetAllUsingTask();

        public Task CreateUsingTask(ProductDetails productDetails);

        Task<List<ProductDetails>> GetAllProducts();
    }
}