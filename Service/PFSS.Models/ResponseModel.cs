using System;
namespace PFSS.Models
{
    public class ResponseModel
    {
        public ResponseType status { get; set; }
        public string UserMessage { get; set; }
        public Object data { get; set; }
    }


}

public enum ResponseType
{
    Error,
    Success,
    BussinesError
}
