using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DapperContext _context;

    public ProductService()
    {
        _context = new DapperContext();
    }

    public void AddProduct(Product product)
    {
        var sql = "insert into products (name, price) values (@name, @price)";
        _context.Connection().Execute(sql, product);
    }

    public List<Product> GetProducts()
    {
        var sql = "select * from products;";
        return _context.Connection().Query<Product>(sql).ToList();
    }

    public void UpdateProduct(Product product)
    {
        var sql = "update products set name = @name, price = @price where id = @id";
        _context.Connection().Execute(sql, product);
    }

    public void DeleteProduct(int id)
    {
        var sql = "delete from products where id = @id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public Product GetProductById(int id)
    {
        var sql = "select * from products where id = @id";
        var result = _context.Connection().ExecuteReader(sql, new { Id = id });
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