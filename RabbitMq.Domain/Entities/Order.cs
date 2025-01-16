namespace EasyNetQDemo.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public string Product { get; private set; }
    public int Quantity { get; private set; }

    public Order(string product, int quantity)
    {
        if (string.IsNullOrWhiteSpace(product))
            throw new ArgumentException("Product cannot be empty");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        Id = Guid.NewGuid();
        Product = product;
        Quantity = quantity;
    }
}
