namespace Consimple_Test_Task.DataAccess.Entities;

public class PurchaseProduct
{
    public int PurchaseId { get; set; }
    public Purchase Purchase { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
}