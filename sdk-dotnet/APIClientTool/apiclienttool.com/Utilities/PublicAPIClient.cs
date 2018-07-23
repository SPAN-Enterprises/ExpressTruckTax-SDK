using System;
using System.Net.Http.Headers;
using System.Web;
using System.Net.Http;

namespace apiclienttool.com.Utilities
{
    public class PublicAPIClient : HttpClient
    {
        public PublicAPIClient()
        {
            if (!string.IsNullOrWhiteSpace(Utility.GetAppSettings("PublicAPIUrl")))
            {
                string apiURL = Utility.GetAppSettings("PublicAPIUrl");
                string appURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                Uri apiURI = new Uri(apiURL);
                this.BaseAddress = apiURI;
            }
            else
            {
                this.BaseAddress = new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
            }

            this.DefaultRequestHeaders.Accept.Clear();

            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}