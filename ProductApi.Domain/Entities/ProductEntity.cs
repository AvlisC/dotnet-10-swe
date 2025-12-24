namespace ProductApi.Domain;

public class ProductEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }


    protected ProductEntity() { }

    public ProductEntity(string name, string description, decimal price)
    {
        Id = Guid.CreateVersion7();
        ChangeName(name);
        ChangePrice(price);
        ChangeDescription(description);
    }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Nome inválido");

        Name = name;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }

    public void ChangePrice(decimal price)
    {
        if (price <= 0)
            throw new DomainException("Preço não pode ser negativo ou igual a zero");

        Price = price;
    }
}

