using System.Text.Json.Serialization;
namespace DaihoWebAPI.Models.Response
{
    public class TokenResponse
    {
        public required string Token { get; set; }

        public required DateTime ExpiresAt { get; set; }

        public required string Role { get; set; }
        public List<string> Roles { get; set; } // New property for all roles
    }
}
