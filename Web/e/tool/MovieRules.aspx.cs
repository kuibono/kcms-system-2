using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Net;
using Voodoo.Basement.Collect;

using System.Text.RegularExpressions;
using System.IO;

namespace Web.e.tool
{
    public partial class MovieRules : System.Web.UI.Page
    {
        #region 静态变量
        protected static string html = "";
        protected static string contentUrl = "";
        protected static string ContentHtml = "";
        protected static string KuaiboArea = "";
        protected static string BaiduArea = "";
        protected static string KuaiboPageUrl = "";
        protected static string KuaiboPageContnt = "";
        protected static string BaiduPageUrl = "";
        protected static string BaiduPageContent = "";

        protected static string KuaibSourceUrl = "";
        protected static string KuaiboSourceContent = "";

        protected static string BaiduSourceUrl = "";
        protected static string BaiduSourceContent = "";
        #endregion

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRuleList();
            }
        }
        #endregion

        #region 载入规则列表
        protected void LoadRuleList()
        {
            ddl_RuleList.Items.Add(new ListItem("新建规则", ""));
            FileInfo[] files = new DirectoryInfo(Server.MapPath("~/Config/MovieRule")).GetFiles();
            foreach (var file in files)
            {
                ddl_RuleList.Items.Add(new ListItem(Path.GetFileName(file.Name)));
            }
            ddl_RuleList.SelectedIndex = 0;

        }
        #endregion

        #region 测试按钮点击
        /// <summary>
        /// 打开列表页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            html = Url.GetHtml(txt_ListPageUrl.Text, ddl_Encoding.SelectedValue);
            Button1.Text = "成功";
        }

        /// <summary>
        /// 分页规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(html, txt_NextListRule.Text))
            {
                Button2.Text = "成功";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Match m = html.GetMatchGroup(txt_ListInfoRule.Text);
            if (m.Success)
            {
                Button3.Text = "成功";
                contentUrl = m.Groups["url"].Value.AppendToDomain(txt_ListPageUrl.Text);
                ContentHtml = Url.GetHtml(contentUrl, ddl_Encoding.SelectedValue);
            }

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Match m = ContentHtml.GetMatchGroup(txt_InfoRule.Text);
            if (m.Success)
            {
                Button4.Text = "成功";
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Match m = ContentHtml.GetMatchGroup(txt_KuaibAreaRule.Text);
            if (m.Success)
            {
                Button5.Text = "成功";
                KuaiboArea = m.Groups[1].Value;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Match m = ContentHtml.GetMatchGroup(txt_BaiduAreaRule.Text);
            if (m.Success)
            {
                Button6.Text = "成功";
                BaiduArea = m.Groups[1].Value;
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Match m = KuaiboArea.GetMatchGroup(txt_KuaibDramaRule.Text);
            if (m.Success)
            {
                Button7.Text = "成功";
                KuaiboPageUrl = m.Groups["playurl"].Value.AppendToDomain(contentUrl);
                KuaiboPageContnt = Url.GetHtml(KuaiboPageUrl, ddl_Encoding.SelectedValue);
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Match m = BaiduArea.GetMatchGroup(txt_BaiduDramaRule.Text);
            if (m.Success)
            {
                Button8.Text = "成功";
                BaiduPageUrl = m.Groups["url"].Value.AppendToDomain(contentUrl);
                BaiduPageContent = Url.GetHtml(BaiduPageUrl, ddl_Encoding.SelectedValue);
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //快播播放页面规则 url source
            Match m = KuaiboPageContnt.GetMatchGroup(txt_DramaPageKuaibRule.Text);
            if (m.Success)
            {
                Button9.Text = "成功";
                KuaibSourceUrl = m.Groups["source"].Value.AppendToDomain(KuaiboPageUrl);
                if (!KuaiboPageUrl.IsNullOrEmpty())
                {
                    KuaiboSourceContent = Url.GetHtml(KuaibSourceUrl, ddl_Encoding.SelectedValue);
                }

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Match m = BaiduPageContent.GetMatchGroup(txt_DramaPageKuaibRule.Text);
            if (m.Success)
            {
                Button10.Text = "成功";
                BaiduSourceUrl = m.Groups["source"].Value.AppendToDomain(BaiduPageUrl);
                if (!BaiduSourceUrl.IsNullOrEmpty())
                {
                    BaiduSourceContent = Url.GetHtml(BaiduSourceUrl, ddl_Encoding.SelectedValue);
                }

            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Match m = KuaiboSourceContent.GetMatchGroup(txt_SourceKuaibRule.Text);
            if (m.Success)
            {
                Button11.Text = "成功";
            }
        }


        protected void Button12_Click(object sender, EventArgs e)
        {
            Match m = BaiduSourceContent.GetMatchGroup(txt_SourceBaiduRule.Text);
            if (m.Success)
            {
                Button12.Text = "成功";
            }

        }
        #endregion

        #region 保存规则
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //修改或者新增
            MovieRule r = new MovieRule();

            if (ddl_RuleList.SelectedValue.IsNullOrEmpty() == false)
            {
                string FileName = Server.MapPath(string.Format("~/Config/MovieRule/{0}", ddl_RuleList.SelectedValue));

                r = (MovieRule)Voodoo.IO.XML.DeSerialize(typeof(MovieRule), Voodoo.IO.File.Read(FileName));
            }

            r.BaiduAreaRule = txt_BaiduAreaRule.Text;
            r.BaiduDramaRule = txt_BaiduDramaRule.Text;
            r.DefaultClass = txt_DefaultClass.Text;
            r.DramaPageBaiduRule = txt_DramaPageBaiduRule.Text;
            r.DramaPageKuaibRule = txt_DramaPageKuaibRule.Text;
            r.Encoding = ddl_Encoding.SelectedValue;
            r.InfoRule = txt_InfoRule.Text;
            r.IsMovie = chk_IsMovie.Checked;
            r.IsSearchRule = chk_IsSearchRule.Checked;
            r.KuaibAreaRule = txt_KuaibAreaRule.Text;
            r.KuaibDramaRule = txt_KuaibDramaRule.Text;
            r.ListInfoRule = txt_ListInfoRule.Text;
            r.ListPageUrl = txt_ListPageUrl.Text;
            r.Name = txt_Name.Text;
            r.NextListRule = txt_NextListRule.Text;
            r.SiteName = txt_SiteName.Text;
            r.SourceBaiduRule = txt_SourceBaiduRule.Text;
            r.SourceKuaibRule = txt_SourceKuaibRule.Text;
            r.UseLocationAsClass = chk_UseLocationAsClass.Checked;
            r.UseTagAsClass = chk_UseTagAsClass.Checked;

            Voodoo.IO.XML.SaveSerialize(r, Server.MapPath(string.Format("~/Config/MovieRule/{0}.xml", r.Name)));
        }
        #endregion

        #region 加载规则
        protected void ddl_RuleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_RuleList.SelectedValue.IsNullOrEmpty() == false)
            {
                string FileName = Server.MapPath(string.Format("~/Config/MovieRule/{0}",ddl_RuleList.SelectedValue));

                MovieRule r = (MovieRule)Voodoo.IO.XML.DeSerialize(typeof(MovieRule), Voodoo.IO.File.Read(FileName));


                txt_Name.Enabled = false;
                txt_SiteName.Enabled = false;

                txt_BaiduAreaRule.Text = r.BaiduAreaRule;
                txt_BaiduDramaRule.Text = r.BaiduDramaRule;
                txt_DefaultClass.Text = r.DefaultClass;
                txt_DramaPageBaiduRule.Text = r.DramaPageBaiduRule;
                txt_DramaPageKuaibRule.Text = r.DramaPageKuaibRule;
                ddl_Encoding.SelectedValue = r.Encoding;
                txt_InfoRule.Text = r.InfoRule;
                chk_IsMovie.Checked = r.IsMovie;
                chk_IsSearchRule.Checked = r.IsSearchRule;
                txt_KuaibAreaRule.Text = r.KuaibAreaRule;
                txt_KuaibDramaRule.Text = r.KuaibDramaRule;
                txt_ListInfoRule.Text = r.ListInfoRule;
                txt_ListPageUrl.Text = r.ListPageUrl;
                txt_Name.Text = r.Name;
                txt_NextListRule.Text = r.NextListRule;
                txt_SiteName.Text = r.SiteName;
                txt_SourceBaiduRule.Text = r.SourceBaiduRule;
                txt_SourceKuaibRule.Text = r.SourceKuaibRule;
                chk_UseLocationAsClass.Checked = r.UseLocationAsClass;
                chk_UseTagAsClass.Checked = r.UseTagAsClass;


            }
        }
        #endregion
    }
}