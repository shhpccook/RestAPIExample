using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace ConsoleFrameworkREST
{
    abstract class BaseAPI
    {
        private HttpClient client = null;
        protected String URI = null;
        protected object result { get; set; }
        protected string data;

        abstract public void Convert(String data);

        abstract public void Show();

        public async Task<String> GetData(String path)
        {
            String data = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }
            return data;
        }

        public async Task RunAsync()
        {
            client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.BaseAddress = new Uri(URI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                this.data = await GetData(client.BaseAddress.ToString());
                this.Convert(this.data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


    }
}
