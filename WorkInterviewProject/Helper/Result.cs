using System;

namespace Helper
{
    public class Result <T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Result(bool HasError, string Message, T Data)
        {
            this.HasError = HasError;
            this.Message = Message;
            this.Data = Data;
        }
    }
}
