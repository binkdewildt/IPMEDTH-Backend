using Newtonsoft.Json;

namespace IPMEDTH.Backend.Models.Exceptions
{
    public class ErrorDTO
    {
        public int StatusCode { get; set; } = default;
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
