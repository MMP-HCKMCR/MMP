using System;
using System.Linq;
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

        public static string UserCalanders(string userToken)
        {
            var url = new StringBuilder("https://api.onediary.com/v1/calendars/");

            var webRequest = WebRequest.Create(url.ToString());
            webRequest.Headers.Add("Authorization", string.Format("Bearer {0}", userToken));
            var response = webRequest.GetResponse();

            Calendars calendars = null;

            var serializer = new DataContractJsonSerializer(typeof(Calendars));

            if (response.GetResponseStream() != null)
            {
                calendars = (Calendars)serializer.ReadObject(response.GetResponseStream());
            }

            var result = string.Empty;

            if (calendars != null)
            {
                result = calendars.calendars[0].calendar_id;
            }

            return result;
        }

        public static void AddCalanderEntry(string userToken, string summary, string description, string startDate, string endDate)
        {
            string calendarId = UserCalanders(userToken);

            var eventId = Guid.NewGuid().ToString();
            eventId = eventId.Replace("-", "");
   
            var entry = new Entry
            {
                calendar_id = calendarId,
                event_id = eventId,
                summary = summary,
                description = description,
                start = startDate,
                end = endDate
            };

            var url = new StringBuilder("https://api.onediary.com/v1/calendars/");
            url.Append(calendarId);
            url.Append("/events");

            var webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
            webRequest.ProtocolVersion = HttpVersion.Version10;
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", string.Format("Bearer {0}", userToken));
            webRequest.ContentType = "application/json; charset=UTF-8";
            webRequest.Accept = "application/json";

            entry.calendar_id = calendarId;

            var stream1 = webRequest.GetRequestStream();
            var serializer = new DataContractJsonSerializer(typeof (Entry));
            serializer.WriteObject(stream1, entry);

            webRequest.GetResponse();
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
