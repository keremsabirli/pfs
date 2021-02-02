using System;
namespace PFSS.Models
{
    public class ResponseModel
    {
        public ResponseType Status { get; set; }
        public string UserMessage { get; set; }
        public Object Data { get; set; }
    }


}

public enum ResponseType
{
    Error,
    Success,
    BussinesError
}
