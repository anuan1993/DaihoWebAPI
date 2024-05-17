using Core_APIOracle.Models;
using DaihoWebAPI.Models;

namespace DaihoWebAPI.Repositories
{
    public interface IPrintLabelRepository
    {
        Task<IEnumerable<PrintLabel>> GetAllAsync();
        //Task<PrintLabel?> DeleteAsync(string id);
    }
}
