using ProductApi.Application.DTOs;
using ProductApi.Domain;

public interface IGetByIdProductUseCase
{
    Task<ProductResponse> ExecuteAsync(Guid id);

}