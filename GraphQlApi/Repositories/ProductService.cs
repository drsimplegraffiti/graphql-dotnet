using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlApi.Data;
using GraphQlApi.Enitities;
using GraphQlApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GraphQlApi.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass dbContextClass;
        public ProductService(DbContextClass dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }
        public async Task<List<ProductDetails>> ProductListAsync()
        {
            return await dbContextClass.Products.ToListAsync();
            // return Task.FromResult(dbContextClass.Products.ToList()); // thi is how to use Task with synchronous method

        }
        public async Task<ProductDetails?> GetProductDetailByIdAsync(Guid productId)
        {
            return await dbContextClass.Products.Where(ele => ele.Id == productId).FirstOrDefaultAsync();
        }
        public async Task<bool> AddProductAsync(ProductDetails productDetails)
        {
            await dbContextClass.Products.AddAsync(productDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateProductAsync(ProductDetails productDetails)
        {
            var isProduct = ProductDetailsExists(productDetails.Id);
            if (isProduct)
            {
                dbContextClass.Products.Update(productDetails);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var findProductData = dbContextClass.Products.Where(_ => _.Id == productId).FirstOrDefault();
            if (findProductData != null)
            {
                dbContextClass.Products.Remove(findProductData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool ProductDetailsExists(Guid productId)
        {
            // if(productId == null){
            //     throw new NotFoundException("Product Id is null", new Exception(), 404);
            // }
            // return dbContextClass.Products.Any(e => e.Id == productId);
            var product = dbContextClass.Products.Where(_ => _.Id == productId).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException("Product Id is null", new Exception(), 404);
            }

            return true;
        }

        public Task GetAllUsingTask()
        {
            // return Task.FromResult(dbContextClass.Products.ToList());
            var tasks = dbContextClass.Products.ToListAsync();
            return Task.FromResult(tasks);
        }

        public Task CreateUsingTask(ProductDetails productDetails)
        {
             dbContextClass.Products.AddAsync(productDetails);
            var result = dbContextClass.SaveChangesAsync();
            if (result.IsCompletedSuccessfully)
            {
                return Task.CompletedTask;
            }
            else
            {
                return Task.FromException(new Exception("Error in saving data"));
            }
        }

        public async Task<List<ProductDetails>> GetAllProducts()
        {
            return await dbContextClass.Products.ToListAsync();
        }

        
    }
}