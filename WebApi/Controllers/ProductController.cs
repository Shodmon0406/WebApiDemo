using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController()
    { 
        _productService = new ProductService();
    }

    [HttpPost("create-product")]
    public async Task<string> AddProduct(Product product)
    {
        return await _productService.AddProductAsync(product);
    }

    [HttpGet("get-products")]
    public async Task<List<Product>> GetProduct()
    {
        // Thread.Sleep(1000);
        return await _productService.GetProductsAsync();
    }

    [HttpPut("update-product")]
    public async Task<Product> UpdateProduct(Product product)
    {
        var result = await _productService.UpdateProductAsync(product);
        return result;
    }

    [HttpDelete("delete-product/{id}")]
    public async Task DeleteProductAsync(int id)
    {
       await _productService.DeleteProductAsync(id);
    }

    [HttpGet("get-product-by-id/{id}")]
    public async Task<Product> GetProductById([FromQuery]int id)
    {
        Thread.Sleep(millisecondsTimeout: 10000);
        return await _productService.GetProductByIdAsync(id);
    }
}