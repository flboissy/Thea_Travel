using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel
{
    class HttpException : HttpRequestException
    {
        public HttpStatusCode Status { get; private set; }
        public HttpException(string msg,HttpStatusCode status) : base(msg)
        {
            Status = status;
        }
    }
}
