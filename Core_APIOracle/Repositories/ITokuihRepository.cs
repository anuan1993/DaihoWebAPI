using DaihoWebAPI.Models;
using System.Drawing;

namespace DaihoWebAPI.Repositories
{
    public interface ITokuihRepository
    {
       Task<IEnumerable<HM_TOKUIH_ALL>> GetAllAsync();
        Task<HM_TOKUIH_ALL> GetTokuihAsync(string itm_cd);
        Task<HM_TOKUIH_ALL> AddSync(HM_TOKUIH_ALL tokuih);
    }
}
