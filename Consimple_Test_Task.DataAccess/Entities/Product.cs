namespace Consimple_Test_Task.DataAccess.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
}