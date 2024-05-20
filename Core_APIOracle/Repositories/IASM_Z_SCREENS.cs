using DaihoWebAPI.Models;
using DaihoWebAPI.Models.Response;

namespace DaihoWebAPI.Repositories
{
    public interface IASM_Z_SCREENS
    {
        Task<IEnumerable<ASM_Z_SCREEN>> GetAllAsync();
        Task<Responses> CreateAsync(ASM_Z_SCREEN aSM_Z_SCREEN);
    }
}
