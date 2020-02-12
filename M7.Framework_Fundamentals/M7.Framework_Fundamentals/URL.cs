using System.Linq;
using System.Text;

namespace M7.Framework_Fundamentals
{
    public class URL
    {
        public static string AddOrChangeUrlParameter(string url, string parameter)
        {
            //var unparsedUrl = new Uri(url);
            //var query = unparsedUrl.Query;
            //var queryParams = HttpUtility.ParseQueryString(query);
            //var r=unparsedUrl.PathAndQuery;
            var result = new StringBuilder();
            if (!url.Contains("?"))
                return url + "?" + parameter;
            else
            {
                var query = url.Split('?');
                result.Append(query[0]+'?');
                var paramPair = parameter.Split('=');

                if (query[1].Contains('&'))
                {
                    var keyValuePair = query[1].Split('&');
                    string[] pair;

                    foreach (var kv in keyValuePair)
                    {
                        pair = kv.Split('=');
                        if (pair[0] == paramPair[0])
                        {
                            result.Append(pair[0] + '=' + paramPair[1]);
                        }
                        else result.Append(kv);
                        result.Append('&');
                    }
                    result.Remove(result.Length - 1,1);
                }
                else
                {
                    var keyValuePair = query[1].Split('=');
                    if(keyValuePair[0]== paramPair[0])
                        result.Append(keyValuePair[0] + '=' + paramPair[1]);
                    else
                        result.Append(query[1]+'&'+parameter);
                }
                return result.ToString();
            }
        }
    }
}
