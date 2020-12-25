using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApiHomework
{
    public class EndPoints
    {
        [Test]
        public void UploadTest()
        {
            var DropBoxClientTest = new RestClient("https://content.dropboxapi.com/2/files/upload");
            DropBoxClientTest.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH");
            request.AddHeader("Dropbox-API-Arg", "{\"path\":\"/StorozhenkoTest/UploadFor.txt\",\"mode\":\"add\",\"autorename\":true,\"mute\":false,\"strict_conflict\":false}");
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddParameter("application/octet-stream", "Hello World!", ParameterType.RequestBody);
            IRestResponse response = DropBoxClientTest.Execute(request);
            string responseStr = response.Content.ToString();
            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.AreEqual(true, responseStr.Contains("UploadFor"));
            Assert.AreEqual(true, responseStr.Contains("\"size\": 12"));
        }

        [Test]
        public void GetFileMetadataTest()
        {
            var DropBoxClientTest = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            DropBoxClientTest.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer CW3iwcUQaHkAAAAAAAAAAbtEAbVXnQByv_3YGOjAnITMVwJv14S9RamOy2g_NZ9K");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"file\": \"id:qBTTwJ_mh7AAAAAAAAAAGg\",\"actions\": []}", ParameterType.RequestBody);
            IRestResponse response = DropBoxClientTest.Execute(request);
            string responseStr = response.Content.ToString();
            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.AreEqual(true, responseStr.Contains("/Storozhenko_Vlad.txt"));
            Assert.AreEqual(true, responseStr.Contains("https://www.dropbox.com/scl/fi/yirivqvace9mwz8qrxdz2/Storozhenko_Vlad.txt?dl=0"));
        }

        [Test]
        public void DeleteFileTest()
        {
            var DropBoxClientTest = new RestClient("https://api.dropboxapi.com/2/files/delete");
            DropBoxClientTest.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n\t\"path\":\"/StorozhenkoTest/UploadFor.txt\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = DropBoxClientTest.Execute(request);
            string responseStr = response.Content.ToString();
            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.AreEqual(true, responseStr.Contains("UploadFor"));
        }
    }
}
