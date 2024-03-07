using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly DapperContext _context;

    public ProductService()
    {
        _context = new DapperContext();
    }

    public async Task<string> AddProductAsync(Product product)
    {
        var sql = @"insert into products (name, price) values (@name, @price);";
        var count = await _context.Connection().ExecuteAsync(sql, product);
        return $"Added successfully: {count}";
        // return await GetProductByIdAsync(product.Id);
    }

    public Task<string> AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var sql = "select * from products;";
        var result = await _context.Connection().QueryAsync<Product>(sql);
        return result.ToList();
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        var sql = "update products set name = @name, price = @price where id = @id";
        await _context.Connection().ExecuteAsync(sql, product);
        return await GetProductByIdAsync(product.Id);
    }

    public async Task DeleteProductAsync(int id)
    {
        var sql = "delete from products where id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var sql = "select * from products where id = @id";
        var result = await _context.Connection().ExecuteReaderAsync(sql, new { Id = id });
        var product = new Product();
        if (result.Read())
        {
            product.Id = result.GetInt32(0);
            product.Name = result.GetString(1);
            product.Price = result.GetDecimal(2);
            return product;
        }

        return new Product();
    }
}