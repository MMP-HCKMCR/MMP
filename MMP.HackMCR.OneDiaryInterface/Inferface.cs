using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using MMP.HackMCR.OneDiaryInterface.ResponseObjects;

namespace MMP.HackMCR.OneDiaryInterface
{
    public static class Inferface
    {
        public static void GetCalanderEntries()
        {
            var webRequest = WebRequest.Create("https://api.onediary.com/v1/events?from=26/10/2014&to=01/11/2014&tzid=Etc/UTC");
            webRequest.Headers.Add("Authorization", "Bearer wjF0pyepu62HlYsku6A5WijkOiUyZk2j");

            var response = webRequest.GetResponse();

            Events result = null;

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Events));

            if (response.GetResponseStream() != null)
            {
                result = (Events) serializer.ReadObject(response.GetResponseStream());
            }
        }
    }
}
