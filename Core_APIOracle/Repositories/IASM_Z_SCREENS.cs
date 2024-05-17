using DaihoWebAPI.Models;

namespace DaihoWebAPI.Repositories
{
    public interface IASM_Z_SCREENS
    {
        Task<IEnumerable<ASM_Z_SCREEN>> GetAllAsync();
        Task<ASM_Z_SCREEN> CreateAsync(ASM_Z_SCREEN aSM_Z_SCREEN);
    }
}
