using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MMP.HackMCR.DataContract.Objects;
using System.Collections.Generic;
using MMP.HackMCR.DataContract;
using System.IO;

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

        public static void AddCalanderEntry(string userToken, List<User> users, Entry entry)
        {
            foreach(User user in users)
            {
                var url = new StringBuilder("https://api.onediary.com/v1/calendars/");
                url.Append(user.Entries.events[0].calendar_id);
                url.Append("/events");

                var webRequest = WebRequest.Create(url.ToString());
                webRequest.Headers.Add("Authorization", string.Format("Bearer {0}", userToken));

                entry.calendar_id = user.Entries.events[0].calendar_id;

                MemoryStream stream1 = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(Entry));
                serializer.WriteObject(stream1, entry);
            }
        }

        public static void RemoveCalanderEntry(string userToken, List<User> users, int eventId)
        {
            foreach (User user in users)
            {
                var url = new StringBuilder("https://api.onediary.com/v1/calendars/");
                url.Append(user.Entries.events[0].calendar_id);
                url.Append("/events");

                var webRequest = WebRequest.Create(url.ToString());
                webRequest.Headers.Add("Authorization", string.Format("Bearer {0}", userToken));

                MemoryStream stream1 = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(Entry));
                serializer.WriteObject(stream1, eventId);
            }
        }


    }
}
