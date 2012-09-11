using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Net;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace Web.e.tool
{
    public partial class proxy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = WS.RequestString("url");
            string encode = WS.RequestString("encode", "utf-8");
            string html = "";// Url.GetHtml(url, encode);

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "www.svnhost.cn";

                request.Timeout = 20000;
                request.AllowAutoRedirect = true;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < 1024 * 1024)
                {
                    reader = new StreamReader(response.GetResponseStream(),System.Text.Encoding.GetEncoding(encode));
                    html = reader.ReadToEnd();
                }
            }
            catch { }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (request != null)
                {
                    request = null;
                }
            }


            //Match m_a = html.GetMatchGroup("href=\"(?<key>[^<>\"]*?)\"");
            //while (m_a.Success)
            //{
            //    string v = m_a.Groups["key"].Value;
            //    if (v.StartsWith("#")||v.IsNullOrEmpty())
            //    {
            //        m_a = m_a.NextMatch();
            //        continue;
            //    }
            //    string newUrl = string.Format("/e/tool/proxy.aspx?url={0}&encode={1}",v.AppendToDomain(url),encode);
            //    html = Regex.Replace(html, "href=\"" + v, "href=\"" + newUrl);
            //    m_a = m_a.NextMatch();
            //}

            //m_a = html.GetMatchGroup("src=\"(?<key>[^<>\"]*?)\"");
            //while (m_a.Success)
            //{
            //    string v = m_a.Groups["key"].Value;
            //    if (v.StartsWith("#") || v.IsNullOrEmpty())
            //    {
            //        m_a = m_a.NextMatch();
            //        continue;
            //    }
            //    string newUrl = string.Format("/e/tool/proxy.aspx?url={0}&encode={1}", v.AppendToDomain(url), encode);
            //    html = Regex.Replace(html, "src=\"" + v, "src=\"" + newUrl);
            //    m_a = m_a.NextMatch();
            //}

            Response.Clear();
            Response.Write(html);
        }
    }
}