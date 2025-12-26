using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.DTOs;
namespace ProductApi.Api.Controllers;

[ApiController]
[Route("api/v1/products")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly ICreateProductUseCase _createProductUseCase;
    private readonly IDeleteProductUseCase _deleteProductUseCase;
    private readonly IListProductUseCase _listProductUseCase;
    private readonly IGetByIdProductUseCase _getByIdProductUseCase;
    private readonly IUpdateProductUseCase _updateProductUseCase;

    public ProductsController(
        ICreateProductUseCase createProductUseCase,
        IDeleteProductUseCase deleteProductUseCase,
        IListProductUseCase listProductUseCase,
        IGetByIdProductUseCase getByIdProductUseCase, IUpdateProductUseCase updateProductUseCase)
    {
        _createProductUseCase = createProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
        _listProductUseCase = listProductUseCase;
        _getByIdProductUseCase = getByIdProductUseCase;
        _updateProductUseCase = updateProductUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var product = await _createProductUseCase.ExecuteAsync(request.Name, request.Description, request.Price);
        return CreatedAtAction(nameof(CreateProduct), new { product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromBody] CreateProductRequest request, Guid id)
    {
        await _updateProductUseCase.ExecuteAsync(id, request.Name, request.Description, request.Price);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductById(Guid id)
    {
        await _deleteProductUseCase.ExecuteAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GestAllProductList()
    {
        var productList = await _listProductUseCase.ExecuteAsync();
        return Ok(productList);
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _getByIdProductUseCase.ExecuteAsync(id);
        return Ok(product); ;
    }
}
