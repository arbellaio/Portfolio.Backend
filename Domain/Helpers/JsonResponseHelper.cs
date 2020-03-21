using System.Collections.Generic;
using Newtonsoft.Json;
using Portfolio.Models.Content;

namespace Portfolio.Domain.Helpers
{
    public class JsonResponseHandler
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Warning { get; set; }

        // other fields
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class BaseResponse
    {
        public List<Content> ContentCollection { get; set; }
        public JsonResponseHandler Response { get; set; }
    }
}
