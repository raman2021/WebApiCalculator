using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public class API_Operations
    {
        string url = "";
        public async Task LoginUser(string Email, string password)
        {
            HttpClient hc = new HttpClient();
            var response = hc.GetAsync(System.IO.Path.Combine(url, "account/UserLogin?EmailId=" + Email + "&Password=" + password)).Result;
        }

        public async Task UserRegistration(Registration ObjRegistration)
        {
            string JsonTest = JsonConvert.SerializeObject(ObjRegistration);

            var httpClient = new HttpClient();

            var data = httpClient.GetAsync(url + "account/UserRegistration?JsonRegister=" + JsonTest).Result;
        }

        public class Registration
        {
            public int Id { get; set; }
        }
    }
}
