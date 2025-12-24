using ProductApi.Application.DTOs;

public interface ICreateProductUseCase
{
    Task<ProductResponse> ExecuteAsync(string name, string description, decimal price);

}