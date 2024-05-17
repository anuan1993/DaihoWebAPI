using DaihoWebAPI.Models;

namespace DaihoWebAPI.Repositories
{
    public interface IASM_Z_ROLE
    {
        Task<IEnumerable<ASM_Z_ROLES>> getAllSync();
        Task<ASM_Z_ROLES> CreateAsync(ASM_Z_ROLES aSM_Z_ROLES);

        Task<IEnumerable<ASM_Z_ROLES>> GetById(string id);

        Task<IEnumerable<ASM_Z_ROLES>> UpdateAsync(string id, ASM_Z_ROLES roles);

         Task<IEnumerable<ASM_Z_ROLES>> deleteAsync(string id);
    }
}
