using System.Text.Json;

namespace Client_Lab1_PRN222.Models
{
    public class ResponseDTO
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public string? Error { get; set; }

        public JsonElement? Payload { get; set; }
    }
}