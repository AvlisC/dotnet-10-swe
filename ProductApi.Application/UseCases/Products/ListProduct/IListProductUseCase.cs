using ProductApi.Application.DTOs;

public interface IListProductUseCase
{
    Task<List<ProductResponse>> ExecuteAsync();

}