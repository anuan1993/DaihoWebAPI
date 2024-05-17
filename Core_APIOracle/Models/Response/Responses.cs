
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DaihoWebAPI.Models.Response
{
    public class Responses
    {
        public bool Success { get; set; }

        public Object? Data { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public Pagination? Pagination { get; set; }

        public string? Message { get; set; }

        public string? Status { get; set; }

        public int Code { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
