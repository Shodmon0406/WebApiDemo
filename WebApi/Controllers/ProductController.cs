using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController()
    { 
        _productService = new ProductService();
    }

    [HttpPost("create-product")]
    public void AddProduct([FromForm]Product product)
    {
        _productService.AddProduct(product);
    }

    [HttpGet("get-products")]
    public List<Product> GetProduct()
    {
        return _productService.GetProducts();
    }

    [HttpPut("update-product")]
    public void UpdateProduct(Product product)
    {
        _productService.UpdateProduct(product);
    }

    [HttpDelete("delete-product/{id}")]
    public void DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
    }

    [HttpGet("get-product-by-id/{id}")]
    public Product GetProductById([FromQuery]int id)
    {
        return _productService.GetProductById(id);
    }
}