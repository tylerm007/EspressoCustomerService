using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using WebApplication4.Model;
using WebApplication4.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using System.Web.Script.Serialization;

namespace WebApplication4.views
{
    public class CustomerVBusObjectView
    {
        private dynamic summary;
        private string requestTemplate = "http://eval.espressologic.com/rest/ValsEval/nwnds/v1/main:CustomerBusObject";

        public dynamic GetSummary
        {
            get { return summary; }
        }

        public CustomerVBusObjectView()
        {
            ApiHelper.ApiKey = "0afmo2PA6zBBgDK7tKLb";
            BaseURLHelper.BaseURL = "http://eval.espressologic.com/rest/ValsEval/nwnds/v1";


            Task<dynamic> objectTaskList = GetObjectSummaryAsync();
            objectTaskList.Wait();
            summary = objectTaskList.Result;
            if (summary != null)
            {
                //Debug.WriteLine(summary[0]);
            }

        }

        private async Task<dynamic> GetObjectSummaryAsync()
        {

            dynamic respContent = null;
            string requestURI = BaseURLHelper.BaseURL + "/CustomersBusObject";
            using (HttpClient client = new HttpClient())
            {
                //do
                //{

                try
                {
                    string response = await HttpHelper.GetAsync(client, requestURI);
                    respContent = JsonConvert.DeserializeObject<dynamic>(response);
                    //Debug.WriteLine(respContent);
                }
                catch (Exception)
                {
                    Debug.WriteLine("Just a break point.");
                }
                //  } while (requesturl != null);
            }

            return respContent;
        }
    }
}