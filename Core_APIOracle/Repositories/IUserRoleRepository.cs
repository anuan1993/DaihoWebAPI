using DaihoWebAPI.Models;
using DaihoWebAPI.Models.DTO;
using DaihoWebAPI.Models.Response;


namespace DaihoWebAPI.Repositories
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<DaihoWebAPI.Models.DTO.UserRolesDTO>> GetAllAsync();
        Task<userRole> CreateAsync(userRole UserRole);
        Task<IEnumerable<userRole>> UpdateAsync(int id, RoleIdDto idDto);
        Task<IEnumerable<userRole>> deleteAsync(UserRolesDTO id);
        Task<IEnumerable<UserRolesDTO>> GetUserAsync();
    }
}
