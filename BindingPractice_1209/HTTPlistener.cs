using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BindingPractice_1209
{
    class HTTPlistener { 
        private const string URI = "http://localhost:8000/data";
        private Thread lThread;
        private static HttpListener listener;

        public static RecvData rd;
        public static SendData sd;

        public HTTPlistener()
        {
            rd = new RecvData();
            sd = new SendData();
            listener = new HttpListener();
            listener.Prefixes.Add(URI);
            listener.Start();

            lThread = new Thread(new ThreadStart(listenThread));
            lThread.Start();
        }

        public async void listenThread()
        {
            while (listener.IsListening)
            {
                var context = await listener.GetContextAsync();
                try
                {
                    await HandlerMethodAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }

            listener.Close();
        }

        private static async Task HandlerMethodAsync(HttpListenerContext ctx)
        {
            HttpListenerRequest req = ctx.Request;
            HttpListenerResponse resp = ctx.Response;
            Console.WriteLine($"URL: {req.Url} \t{req.HttpMethod}");
            if (req.Url.ToString().Equals(""))
            {
                if (req.HttpMethod.Equals("POST"))
                    await HandleBookPostAsync(req, resp);
                else if (req.HttpMethod.Equals("GET"))
                    await HandleBookGet(req, resp);
            }

        }

        private static async Task<string> GetStringContentAsync(HttpListenerRequest req)
        {
            string result = "";
            using (var bodyStream = req.InputStream)
            {
                var encoding = req.ContentEncoding;
                using (var streamReader = new StreamReader(bodyStream, encoding))
                {
                    result = await streamReader.ReadToEndAsync();
                }
            }
            return result;
        }

        private static async Task BuildResponse(HttpListenerResponse resp, Encoding encoding, string content)
        {
            resp.StatusCode = 200;
            byte[] buffer = encoding.GetBytes(content);
            resp.ContentLength64 = buffer.Length;

            await resp.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            resp.OutputStream.Close();
        }
      

        private static async Task HandleBookPostAsync(HttpListenerRequest req, HttpListenerResponse resp)
        {
            string reqcontent = await GetStringContentAsync(req);

            JObject json = JObject.Parse(reqcontent);
            rd = json.ToObject<RecvData>(); //EZ KELL


            
            //await BuildResponse(resp, req.ContentEncoding, json.ToString());
        }

        private static async Task HandleBookGet(HttpListenerRequest req, HttpListenerResponse resp)
        {
            string jsonString = JsonConvert.SerializeObject(sd);

            await BuildResponse(resp, req.ContentEncoding, jsonString);
        }
    }
}
