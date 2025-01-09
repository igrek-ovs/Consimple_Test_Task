using Consimple_Test_Task.Core.DTO_s;
using Consimple_Test_Task.Core.Interfaces;
using Consimple_Test_Task.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Consimple_Test_Task.Core;

public class StoreService : IStoreService
{
    private readonly StoreDbContext _context;

    public StoreService(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClientDto>> GetBirthdayClientsAsync(DateTime date)
    {
        return await _context.Clients
            .Where(c => c.DateOfBirth.Month == date.Month && c.DateOfBirth.Day == date.Day)
            .Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.FullName
            })
            .ToListAsync();
    }

    public async Task<List<ClientDto>> GetRecentBuyersAsync(int days)
    {
        var cutoffDate = DateTime.UtcNow.AddDays(-days);

        var recentBuyers = await _context.Purchases
            .Where(p => p.Date >= cutoffDate)
            .GroupBy(p => p.Client)
            .Select(g => new
            {
                Client = g.Key,
                LastPurchaseDate = g.Max(p => p.Date)
            })
            .ToListAsync();

        return recentBuyers
            .Select(x => new ClientDto
            {
                Id = x.Client.Id,
                Name = $"{x.Client.FullName} (Last purchase: {x.LastPurchaseDate:yyyy-MM-dd})"
            })
            .ToList();
    }

    public async Task<List<CategoryDto>> GetPopularCategoriesAsync(int clientId)
    {
        var categories = await _context.Purchases
            .Where(p => p.ClientId == clientId)
            .Include(p => p.PurchaseProducts)
            .ThenInclude(pp => pp.Product)
            .SelectMany(p => p.PurchaseProducts)
            .GroupBy(pp => pp.Product.Category)
            .Select(g => new CategoryDto
            {
                Category = g.Key,
                TotalCount = g.Sum(pp => pp.Quantity)
            })
            .ToListAsync();

        return categories;
    }
}