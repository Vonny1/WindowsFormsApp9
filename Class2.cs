using System;
using System.Net;
using System.IO;
using System.Text;

namespace WindowsFormsApp9
{
    using System;
    using System.Net;
    using System.IO;
    using System.Text;
    public class ClassRequest
    {
        public static string Get(string site)
        {
            //string site = "http://127.0.0.1:8000/sqltable/";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using StreamReader stream = new StreamReader(
                 resp.GetResponseStream(), Encoding.UTF8);
            string Text = stream.ReadToEnd();
            //Console.WriteLine(Text);
            return Text;
        }
    }
    public class EffTime
    {
        public DateTimeOffset Datefirst { get; set; }
        public DateTimeOffset Datesecond { get; set; }
        public long Worker { get; set; }
        public double Efftime { get; set; }
    }

}
