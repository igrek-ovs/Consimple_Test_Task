namespace Consimple_Test_Task.DataAccess.Entities;

public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}