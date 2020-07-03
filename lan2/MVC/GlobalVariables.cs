using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public class GlobalVariables
    {
        public static HttpClient api = new HttpClient();
        static GlobalVariables()
        {
            api.BaseAddress = new Uri("http://localhost:60686/api/");
            api.DefaultRequestHeaders.Clear();
            api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}