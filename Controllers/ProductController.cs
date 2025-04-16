using Microsoft.AspNetCore.Mvc;
using SimpleCrudApi.Data;
using SimpleCrudApi.Models;

namespace SimpleCrudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly AppDbContext context;
    public ProductController(AppDbContext context)
    {
        this.context = context;
    }

    // Get /api/product
    [HttpGet]
    public ActionResult<IEnumerable<ProductModel>> GetAll()
    {
        IEnumerable<ProductModel> products = context.Products.ToList();
        return Ok(new { message = "Products retrieved successfully", data = products });
    }

    // Get /api/product/{id}
    [HttpGet("{id}")]
    public ActionResult<ProductModel> GetById(int id)
    {
        var product = context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(new { message = "Product retrieved successfully", data = product });
    }

    // Post /api/product
    [HttpPost]
    public ActionResult<ProductModel> Create(ProductModel product)
    {
        context.Products.Add(product);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // Put /api/product/{id}
    [HttpPut()]
    public ActionResult<ProductModel> Update(ProductModel product)
    {
        try
        {
            ProductModel? existingProduct = context.Products.Find(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            context.Products.Update(existingProduct);
            context.SaveChanges();

            // Return a success message
            return Ok(new { message = "Product updated successfully" });
        }
        catch (System.Exception)
        {
            return BadRequest(new { message = "Error updating product" });
        }
    }

    // Delete /api/product/{id}
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var product = context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        context.Products.Remove(product);
        context.SaveChanges();
        return Ok(new { message = "Product deleted successfully" });
    }
}
