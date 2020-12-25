using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WebApiHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer CW3iwcUQaHkAAAAAAAAAAbtEAbVXnQByv_3YGOjAnITMVwJv14S9RamOy2g_NZ9K");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"file\": \"id:qBTTwJ_mh7AAAAAAAAAAGg\",\"actions\": []}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string resp = response.Content.ToString();
            Console.Write(resp);
            Console.Read();
        }
    }
}
