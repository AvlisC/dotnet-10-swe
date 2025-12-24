using ProductApi.Application.DTOs;

public interface IUpdateProductUseCase
{
    Task<ProductResponse> ExecuteAsync(Guid id, string name, string description, decimal price);

}