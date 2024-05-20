using DaihoWebAPI.Models;
using DaihoWebAPI.Models.DTO;
using DaihoWebAPI.Models.Response;

namespace DaihoWebAPI.Repositories
{
    public interface IASM_Z_SCREEN_ROLE
    {
        Task<Responses> CreateAsync(ASM_Z_SCREEN_ROLE ScreenRole);
        Task<IEnumerable<DaihoWebAPI.Models.DTO.RoleScreenDTO>> GetAllAsync();
        Task<IEnumerable<DaihoWebAPI.Models.DTO.RoleScreenListDTO>> GetAllListAsync();
        Task<IEnumerable<DaihoWebAPI.Models.DTO.RoleScreenDTO>> GetById(string id);
        Task<IEnumerable<ASM_Z_SCREEN_ROLE>> deleteAsync(string id);

        Task<IEnumerable<ASM_Z_SCREEN_ROLE>> deleteAsyncDto(RoleIdDto idDto);
    }
}
