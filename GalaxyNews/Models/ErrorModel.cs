namespace GalaxyNews.Models
{
    public class ErrorModel
    {
        public readonly int Code;
        public readonly string Message;

        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
