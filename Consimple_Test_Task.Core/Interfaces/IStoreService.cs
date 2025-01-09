using Consimple_Test_Task.Core.DTO_s;
using Consimple_Test_Task.DataAccess.Entities;

namespace Consimple_Test_Task.Core.Interfaces;

public interface IStoreService
{
    Task<List<ClientDto>> GetBirthdayClientsAsync(DateTime date);
    Task<List<ClientDto>> GetRecentBuyersAsync(int days);
    Task<List<CategoryDto>> GetPopularCategoriesAsync(int clientId);
}