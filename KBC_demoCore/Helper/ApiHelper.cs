using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KBC_demoCore.Helper
{
    public class ApiHelper
    {
        public HttpClient Inital()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://kbcPatient:80/");
            return client;
        }
    }
}
