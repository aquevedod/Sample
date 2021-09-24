using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Utilities
{
    /// <summary>
    /// This class if to made a valid response in each method.
    /// Keep in mind return a message and code in case of generate an error.
    /// </summary>
    public class Response
    {
        public IEnumerable Entities { get; set; }

        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }
    }
}
