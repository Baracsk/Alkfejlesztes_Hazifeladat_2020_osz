using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarSimulation
{
    class ClientCalls
    {
        private static readonly HttpClient client = new HttpClient();
        private const string URI = "http://localhost:8000/data";

        public async Task<string> GetDataStringAsync()
        {
            var result = await client.GetAsync(URI);
            string stringres = await result.Content.ReadAsStringAsync();
            return stringres;
        }


        public async Task<string> PostDataAsync(RecvData data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(jsonString);
            var result = await client.PostAsync(URI, content);
            string stringres = await result.Content.ReadAsStringAsync();
            return stringres;
        }
    }
}
