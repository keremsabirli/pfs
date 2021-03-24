using System;
namespace PFSS.Models
{
    public class ResponseModel<T>
    {
        public ResponseType Status { get; set; }
        public string UserMessage { get; set; }
        public T Data { get; set; }
    }


}

public enum ResponseType
{
    Error,
    Success,
    BussinessError
}
