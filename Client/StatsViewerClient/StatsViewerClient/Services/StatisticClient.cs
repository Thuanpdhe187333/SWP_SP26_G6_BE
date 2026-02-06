using Client_Lab1_PRN222.Helpers;
using Client_Lab1_PRN222.Models;

namespace Client_Lab1_PRN222.Services
{
    internal class StatisticClient
    {
        public ResponseDTO GetStatistics(string? category, string? action)
        {
            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(action))
            {
                return new ResponseDTO
                {
                    Success = false,
                    Error = "Category or Action is null"
                };
            }

            var request = new
            {
                Category = category,
                Action = action
            };

            try
            {
                return SocketHelper.SendRequest<ResponseDTO>(request);
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }
}