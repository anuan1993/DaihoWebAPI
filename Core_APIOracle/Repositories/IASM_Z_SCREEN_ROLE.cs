using DaihoWebAPI.Models;
using DaihoWebAPI.Models.DTO;

namespace DaihoWebAPI.Repositories
{
    public interface IASM_Z_SCREEN_ROLE
    {
        Task<ASM_Z_SCREEN_ROLE> CreateAsync(ASM_Z_SCREEN_ROLE ScreenRole);
        Task<IEnumerable<DaihoWebAPI.Models.DTO.RoleScreenDTO>> GetAllAsync();
        Task<IEnumerable<DaihoWebAPI.Models.DTO.RoleScreenListDTO>> GetAllListAsync();
        Task<IEnumerable<DaihoWebAPI.Models.DTO.RoleScreenDTO>> GetById(string id);
        Task<IEnumerable<ASM_Z_SCREEN_ROLE>> deleteAsync(string id);

        Task<IEnumerable<ASM_Z_SCREEN_ROLE>> deleteAsyncDto(RoleIdDto idDto);
    }
}
