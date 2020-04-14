using System;

namespace AleBlog.API.Model.Dto.Response
{
    public class Responce
    {
        public string Message { get; set; } = string.Empty;

        public string Status => string.IsNullOrEmpty(Message)?"fail":"success";

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public void HandleException(Exception ex) => Message = ex.InnerException?.StackTrace.ToString();

    }

    public class Responce<T>:Responce where T :class
    {
        public T Result { get; set; }
        
    }
}
