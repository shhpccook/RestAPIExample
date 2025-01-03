using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleFrameworkREST
{
    class Apod
    {
        public string copyright { get; set; }
        public string date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }

    }

    class NasaAPI:BaseAPI
    {
        public NasaAPI(String URI)
        {
            this.URI = URI;
            base.RunAsync().GetAwaiter().GetResult();
        }

        override public void Show()
        {
            Apod pod = (Apod)result;
            if (pod == null) return;
            Console.WriteLine($"date: {pod.date}\r\n title: {pod.title}\r\n explanation: {pod.explanation}\r\n hdurl:{pod.hdurl}\r\n");
        }

        override public void Convert(String data)
        {
            this.result = JsonConvert.DeserializeObject<Apod>(data);
        }


    }
}
