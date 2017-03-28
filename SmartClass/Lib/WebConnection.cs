using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace SmartClass.Lib
{
    class WebConnection
    {
        private static void AddHeader(ref HttpRequestMessage httpRequestMsg,String url="")
        {
            httpRequestMsg.Headers.Add("x-build-version", "103");
            //httpRequestMsg.Headers.Add("Host","smartclass.zakelly.com:3000");
            if (Constants.Token.Equals("")) return;
            httpRequestMsg.Headers.Add("x-access-token", Constants.Token);
        }

        public async static Task<Parameters> ConnectWithGet(String url)
        {
            try
            {
                using (HttpClient httpClient=new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
                    Cookies.addCookie(ref request);
                    AddHeader(ref request);
                    HttpResponseMessage response = await httpClient.SendRequestAsync(request);
                    int returnCode = (int)response.StatusCode;
                    Cookies.setCookie(response, url);
                    using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
                    {
                        Parameters ret = new Parameters(returnCode + "", "");
                        if (returnCode != 200) return ret;
                        StreamReader sReader = new StreamReader(responseStream);
                        String str = "";
                        String line = sReader.ReadLine();
                        while (line != null)
                        {
                            str = str + line + "\n";
                            line = sReader.ReadLine();
                        }
                        ret.Value = str;
                        return ret;
                    }
                }
            }
            catch
            {
                return new Parameters("-1", "");
            }
        }

        public async static Task<Parameters> ConnectWithPost(String url,JsonObject json)
        {
            try
            {
                HttpClient client = new HttpClient();
                
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
                url = url.Trim();
                
                HttpStringContent content = new HttpStringContent(json.ToString());
                content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                request.Content = content;
                Cookies.addCookie(ref request);
                AddHeader(ref request);
                
                HttpResponseMessage response = await client.SendRequestAsync(request);

                int returnCode = (int)response.StatusCode;
                Cookies.setCookie(response, url);
                using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
                {
                    Parameters ret = new Parameters(returnCode + "", "");
                    if (returnCode != 200) return ret;
                    StreamReader sReader = new StreamReader(responseStream);
                    String str = "";
                    String line = sReader.ReadLine();
                    while (line != null)
                    {
                        str = str + line + "\n";
                        line = sReader.ReadLine();
                    }
                    ret.Value = str;
                    return ret;
                }
            }
            catch
            {
                return new Parameters("-1", "");
            }
        }
        public async static Task<Parameters> ConnectWithPost(String url, List<Parameters> paramList)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
                url = url.Trim();
                List<KeyValuePair<String, String>> t_params = new List<KeyValuePair<string, string>>();
                if (paramList != null)
                {
                    foreach (Parameters paramItem in paramList)
                    {
                        String str = paramItem.Value;
                        if (str == null) continue;
                        t_params.Add(paramItem.keyValue);
                    }
                }
                HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(t_params);
                request.Content = content;
                Cookies.addCookie(ref request);
                AddHeader(ref request);
                HttpResponseMessage response = await client.SendRequestAsync(request);

                int returnCode = (int)response.StatusCode;
                Cookies.setCookie(response, url);
                using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
                {
                    Parameters ret = new Parameters(returnCode + "", "");
                    if (returnCode != 200) return ret;
                    StreamReader sReader = new StreamReader(responseStream);
                    String str = "";
                    String line = sReader.ReadLine();
                    while (line != null)
                    {
                        str = str + line + "\n";
                        line = sReader.ReadLine();
                    }
                    ret.Value = str;
                    return ret;
                }
            }
            catch
            {
                return new Parameters("-1", "");
            }
        }
        public async static Task<Parameters> ConnectWithPut(String url, List<Parameters> paramList)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, new Uri(url));
                url = url.Trim();
                List<KeyValuePair<String, String>> t_params = new List<KeyValuePair<string, string>>();
                if (paramList != null)
                {
                    foreach (Parameters paramItem in paramList)
                    {
                        String str = paramItem.Value;
                        if (str == null) continue;
                        t_params.Add(paramItem.keyValue);
                    }
                }
                HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(t_params);
                request.Content = content;
                Cookies.addCookie(ref request);
                AddHeader(ref request);
                HttpResponseMessage response = await client.SendRequestAsync(request);

                int returnCode = (int)response.StatusCode;
                Cookies.setCookie(response, url);
                using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
                {
                    Parameters ret = new Parameters(returnCode + "", "");
                    if (returnCode != 200) return ret;
                    StreamReader sReader = new StreamReader(responseStream);
                    String str = "";
                    String line = sReader.ReadLine();
                    while (line != null)
                    {
                        str = str + line + "\n";
                        line = sReader.ReadLine();
                    }
                    ret.Value = str;
                    return ret;
                }
            }
            catch
            {
                return new Parameters("-1", "");
            }
        }
    }
}
