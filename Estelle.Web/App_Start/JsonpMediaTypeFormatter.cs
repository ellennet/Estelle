using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Estelle.Web
{
    public static class HttpRequestMessageExtensions
    {
        public static string QueryString(this HttpRequestMessage request, string name)
        {
            string requestUri = request.RequestUri.Query;
            string[] queries = requestUri.Split('&');

            foreach (string s in queries)
            {
                if (s.Contains(name))
                {
                    int index = s.IndexOf('=');
                    int stopIndex = s.IndexOf('&', index);
                    if (stopIndex != -1)
                        return s.Substring(index + 1, stopIndex - index - 1);
                    else
                        return s.Substring(index + 1, s.Length - index - 1);
                }
            }

            return string.Empty;
        }
    }


    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private string callbackQueryParameter;
        private HttpRequestMessage httpRequest;
        public JsonpMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(DefaultMediaType);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));

            MediaTypeMappings.Add(new UriPathExtensionMapping("jsonp", DefaultMediaType));
        }

        public string CallbackQueryParameter
        {
            get { return callbackQueryParameter ?? "callback"; }
            set { callbackQueryParameter = value; }
        }
        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            httpRequest = request;
            return base.GetPerRequestFormatterInstance(type, request, mediaType);
        }
        public override Task WriteToStreamAsync(
              Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            string callback;

            if (IsJsonpRequest(out callback))
            {
                return Task.Factory.StartNew(() =>
                {
                    var writer = new StreamWriter(stream);
                    writer.Write(callback + "(");
                    writer.Flush();

                    base.WriteToStreamAsync(type, value, stream, content, transportContext).Wait();

                    writer.Write(")");
                    writer.Flush();
                });
            }
            else
            {
                return base.WriteToStreamAsync(type, value, stream, content, transportContext);
            }
        }


        private bool IsJsonpRequest(out string callback)
        {
            callback = null;

            //if (HttpContext.Current.Request.HttpMethod != "GET")
            if (httpRequest.Method != HttpMethod.Get)
                return false;
            //var uri = httpRequest.RequestUri;
            //var query = uri.Query;
            callback = httpRequest.QueryString(CallbackQueryParameter);

            return !string.IsNullOrEmpty(callback);
        }
    }
}