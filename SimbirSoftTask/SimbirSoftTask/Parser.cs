using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirSoftTask
{
    public static class Parser
    {
        public static string Pars(string site)
        {
            string txt = null;
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                {
                    txt = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Try again with other link");
            }
            return txt;

        }
        public static string HtmlPars(string txt)
        {
            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(txt);
                txt = doc.DocumentNode.InnerText;
                char[] charsToReplace = { '\t', '\n', '\r', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '-', '+', '=', '/', '\\', '<', '>', '—', '«', '»' };
                foreach (var c in charsToReplace)
                {
                    txt = txt.Replace(c, ' ');
                }
                txt = txt.Trim();
                Regex regex = new Regex(@"\s+");
                txt = regex.Replace(txt, " ");
                txt = txt.ToLower();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Try again");
            }
            return txt;

        }

    }
}
