namespace ProductApi.Application.DTOs;

public record ProductResponse(Guid? Id, string Name, string? Description, decimal Price);
