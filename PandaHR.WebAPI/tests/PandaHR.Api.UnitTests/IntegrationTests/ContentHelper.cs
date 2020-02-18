using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;

namespace PandaHR.Api.UnitTests.IntegrationTests
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj),
                Encoding.Default, "application/json");

        public static MultipartFormDataContent GetFileContent(string path, string name)
        {
            var mpContent = new MultipartFormDataContent();

            using (var file = File.OpenRead(path + name))
            using (var content = new StreamContent(file))
            {
                mpContent.Add(content, "files", name);
            }

            return mpContent;
        }
    }
}
