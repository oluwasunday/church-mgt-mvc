using System.Security.Claims;

namespace church_mgt_model
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
