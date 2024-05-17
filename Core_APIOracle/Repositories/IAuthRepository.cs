using DaihoWebAPI.Models;
using DaihoWebAPI.Models.Response;

namespace DaihoWebAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<Responses> getAuth(string USR_ID, string password);
    }
}
