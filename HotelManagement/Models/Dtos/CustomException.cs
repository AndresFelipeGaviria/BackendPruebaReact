namespace HotelManagement.Models.Dtos
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public CustomException(string message, int statusCode, List<string> errors = null)
            : base(message)
        {
            StatusCode = statusCode;
            Errors = errors ?? new List<string>();
        }

        public object ToResponse()
        {
            return new
            {
                StatusCode,
                Message = Message,
                Errors
            };
        }
    }
}
