namespace Consimple_Test_Task.DataAccess.Entities;

public class Purchase
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
}