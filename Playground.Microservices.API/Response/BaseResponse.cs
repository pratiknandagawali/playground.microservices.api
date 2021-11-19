namespace Playground.Microservices.API.Response
{
    using System;
    public class BaseResponse
    {
        public DateTimeOffset CreatedTimeStamp { get; set; }

        public DateTimeOffset ModifiedTimeStamp { get; set; }
    }
}
