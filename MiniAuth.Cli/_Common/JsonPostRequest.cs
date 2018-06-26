using System.Net;
using Utf8Json;

namespace MiniAuth.Cli
{
    public sealed class JsonPostRequest<T>
    {
        private readonly string _url;
        private readonly object _request;

        public JsonPostRequest(string url, object request)
        {
            _url = url;
            _request = request;
        }

        public T GetResponse()
        {
            var req = WebRequest.CreateHttp(_url);
            req.Method = "Post";
            req.ContentType = "application/json";
            JsonSerializer.Serialize(req.GetRequestStream(), _request);

            var resp = (HttpWebResponse)req.GetResponse();
            if ((int)resp.StatusCode < 200 || (int)resp.StatusCode > 299)
                throw new WebException($"Request to {_url} did not succeed: {resp.StatusDescription}");
            
            return JsonSerializer.Deserialize<T>(resp.GetResponseStream());
        }
    }
}
