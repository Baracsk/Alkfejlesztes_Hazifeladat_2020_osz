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

        // Sends a GET request to Server, the content is returned as a string
        public async Task<string> GetDataStringAsync()
        {
            var result = await client.GetAsync(URI);
            string stringres = await result.Content.ReadAsStringAsync();
            return stringres;
        }

        // Sends a GET request to Server, the content is returned as the received Data (SendData from the Client's side)
        public async Task<GetData> GetDataAsync()
        {
            string stringres = await this.GetDataStringAsync();
            GetData result = JsonConvert.DeserializeObject<GetData>(stringres);
            return result;
        }

        //Sends a POST request to the Server (RecvData from the Client's side)
        public async Task<string> PostDataAsync(PostData data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(jsonString);
            var result = await client.PostAsync(URI, content);
            string stringres = await result.Content.ReadAsStringAsync();
            return stringres;
        }
    }
}
