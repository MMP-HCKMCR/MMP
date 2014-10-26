using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MMP.HackMCR.DataContract.Objects;

namespace MMP.HackMCR.OneDiaryInterface
{
    public static class Inferface
    {
        public static Entries GetCalanderEntries(string userToken, DateTime startDate, DateTime endDate)
        {
            var url = new StringBuilder("https://api.onediary.com/v1/events?from=");
            url.Append(startDate.ToShortDateString());
            url.Append("&to=");
            url.Append(endDate.ToShortDateString());
            url.Append("&tzid=Etc/UTC");

            var webRequest = WebRequest.Create(url.ToString());
            webRequest.Headers.Add("Authorization", string.Format("Bearer {0}", userToken));

            var response = webRequest.GetResponse();

            Entries entries = null;

            var serializer = new DataContractJsonSerializer(typeof(Entries));

            if (response.GetResponseStream() != null)
            {
                entries = (Entries)serializer.ReadObject(response.GetResponseStream());
            }

            return entries;
        }
    }
}
