using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

using Voodoo.IO;
namespace Web.e.admin.Info
{
    public partial class InfoEdit : AdminBase
    {

        protected int TypeID = WS.RequestInt("type");
        protected string TypeHtml = "";

        protected string ValueString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("submit").Length>0)
            {
                //保存数据
                SaveData();
            }
            else
            {
                LoadInfo();
            }
        }

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        protected void SaveData()
        {
            DataEntities ent = new DataEntities();

            int id = WS.RequestInt("id");
            var i = (from l in ent.Info where l.id == id select l).FirstOrDefault();

            i.Address = WS.RequestString("address");
            i.bit1 = WS.RequestString("bit1").ToBoolean();
            i.bit2 = WS.RequestString("bit2").ToBoolean();
            i.bit3 = WS.RequestString("bit3").ToBoolean();
            i.bit4 = WS.RequestString("bit4").ToBoolean();
            i.bit5 = WS.RequestString("bit5").ToBoolean();

            var cls = NewsAction.NewsClass.Where(p => p.ID == WS.RequestInt("class")).First();
            i.ClassID = cls.ID;
            i.ClassName = cls.ClassName;
            i.ClickCount = WS.RequestInt("clickcount",0);
            i.Contact = WS.RequestString("contact");
            i.ContactType = WS.RequestString("contacttype", "个人");

            i.decimal1 = WS.RequestString("decimal1").ToDecimal(0);
            i.decimal2 = WS.RequestString("decimal2").ToDecimal(0);
            i.decimal3 = WS.RequestString("decimal3").ToDecimal(0);
            i.decimal4 = WS.RequestString("decimal4").ToDecimal(0);
            i.decimal5 = WS.RequestString("decimal5").ToDecimal(0);

            i.ImageCount = WS.RequestInt("imagecount",0);
            i.InfoTypeID = TypeID.ToS();
            i.Intro = WS.RequestString("intro");
            i.IsSetTop = WS.RequestString("issettop").ToBoolean();

            i.num1 = WS.RequestInt("num1",0);
            i.num2 = WS.RequestInt("num2", 0);
            i.num3 = WS.RequestInt("num3", 0);
            i.num4 = WS.RequestInt("num4", 0);
            i.num5 = WS.RequestInt("num5", 0);
            i.num6 = WS.RequestInt("num6", 0);
            i.num7 = WS.RequestInt("num7", 0);
            i.num8 = WS.RequestInt("num8", 0);
            i.num9 = WS.RequestInt("num9", 0);
            i.num10 = WS.RequestInt("num10", 0);

            i.nvarchar1 = WS.RequestString("nvarchar1");
            i.nvarchar2 = WS.RequestString("nvarchar2");
            i.nvarchar3 = WS.RequestString("nvarchar3");
            i.nvarchar4 = WS.RequestString("nvarchar4");
            i.nvarchar5 = WS.RequestString("nvarchar5");
            i.nvarchar6 = WS.RequestString("nvarchar6");
            i.nvarchar7 = WS.RequestString("nvarchar7");
            i.nvarchar8 = WS.RequestString("nvarchar8");
            i.nvarchar9 = WS.RequestString("nvarchar9");
            i.nvarchar10 = WS.RequestString("nvarchar10");
            i.nvarchar11 = WS.RequestString("nvarchar11");
            i.nvarchar12 = WS.RequestString("nvarchar12");
            i.nvarchar13 = WS.RequestString("nvarchar13");
            i.nvarchar14 = WS.RequestString("nvarchar14");
            i.nvarchar15 = WS.RequestString("nvarchar15");

            i.OutTime = WS.RequestString("outtime").ToDateTime();
            i.PostTime = WS.RequestString("posttime").ToDateTime();
            i.ReplyCount = WS.RequestInt("replycount",0);
            i.Tel = WS.RequestString("tel");
            i.TelLocation = WS.RequestString("tellocation");

            i.text1 = WS.RequestString("text1");
            i.text2 = WS.RequestString("text2");
            i.text3 = WS.RequestString("text3");
            i.text4 = WS.RequestString("text4");
            i.text5 = WS.RequestString("text5");

            i.Title = WS.RequestString("title");
            i.UserID = SysUserAction.LocalUser.ID;
            i.UserName = SysUserAction.LocalUser.UserName;
            i.ZtID = 0;
            i.ZtName = "";

            if (id <=0)
            {
                ent.AddToInfo(i);
            }
            ent.SaveChanges();
            ent.Dispose();
            Response.Redirect("InfoList.aspx?type=" + TypeID);

        }
        #endregion 

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        protected void LoadInfo()
        {
            DataEntities ent=new DataEntities();
            InfoType it = //InfoTypeView.GetModelByID(TypeID.ToS());
                (from l in ent.InfoType where l.id == TypeID select l).FirstOrDefault();
            TypeHtml = it.TemlateAdminForm;

            int id = WS.RequestInt("id");
            var i = //InfoView.GetModelByID(id.ToS());
                (from l in ent.Info where l.id == id select l).FirstOrDefault();
            ValueString = i.ToJson();

            TypeHtml = TypeHtml.Replace("{address}", i.Address);
            TypeHtml = TypeHtml.Replace("{bit1}", i.bit1.ToS());
            TypeHtml = TypeHtml.Replace("{address}", i.bit2.ToS());
            TypeHtml = TypeHtml.Replace("{address}", i.bit3.ToS());
            TypeHtml = TypeHtml.Replace("{address}", i.bit4.ToS());
            TypeHtml = TypeHtml.Replace("{address}", i.bit5.ToS());
            TypeHtml = TypeHtml.Replace("{classid}", i.ClassID.ToS());
            TypeHtml = TypeHtml.Replace("{classname}", i.ClassName);
            TypeHtml = TypeHtml.Replace("{clickcount}", i.ClickCount.ToS());
            TypeHtml = TypeHtml.Replace("{contact}", i.Contact);
            TypeHtml = TypeHtml.Replace("{contacttype}", i.ContactType);
            TypeHtml = TypeHtml.Replace("{decimal1}", i.decimal1.ToS());
            TypeHtml = TypeHtml.Replace("{decimal2}", i.decimal2.ToS());
            TypeHtml = TypeHtml.Replace("{decimal3}", i.decimal3.ToS());
            TypeHtml = TypeHtml.Replace("{decimal4}", i.decimal4.ToS());
            TypeHtml = TypeHtml.Replace("{decimal5}", i.decimal5.ToS());

            TypeHtml = TypeHtml.Replace("{id}", i.id.ToS());
            TypeHtml = TypeHtml.Replace("{imagecount}", i.ImageCount.ToS());
            TypeHtml = TypeHtml.Replace("{infotypeid}", i.InfoTypeID.ToS());
            TypeHtml = TypeHtml.Replace("{intro}", i.Intro);
            TypeHtml = TypeHtml.Replace("{issettop}", i.IsSetTop.ToS());
            TypeHtml = TypeHtml.Replace("{num1}", i.num1.ToS());
            TypeHtml = TypeHtml.Replace("{num2}", i.num2.ToS());
            TypeHtml = TypeHtml.Replace("{num3}", i.num3.ToS());
            TypeHtml = TypeHtml.Replace("{num4}", i.num4.ToS());
            TypeHtml = TypeHtml.Replace("{num5}", i.num5.ToS());
            TypeHtml = TypeHtml.Replace("{num6}", i.num6.ToS());
            TypeHtml = TypeHtml.Replace("{num7}", i.num7.ToS());
            TypeHtml = TypeHtml.Replace("{num8}", i.num8.ToS());
            TypeHtml = TypeHtml.Replace("{num9}", i.num9.ToS());
            TypeHtml = TypeHtml.Replace("{num10}", i.num10.ToS());

            TypeHtml = TypeHtml.Replace("{nvarchar1}", i.nvarchar1);
            TypeHtml = TypeHtml.Replace("{nvarchar2}", i.nvarchar2);
            TypeHtml = TypeHtml.Replace("{nvarchar3}", i.nvarchar3);
            TypeHtml = TypeHtml.Replace("{nvarchar4}", i.nvarchar4.IsNullOrEmpty()?"随时入住":i.nvarchar4);
            TypeHtml = TypeHtml.Replace("{nvarchar5}", i.nvarchar5);
            TypeHtml = TypeHtml.Replace("{nvarchar6}", i.nvarchar6);
            TypeHtml = TypeHtml.Replace("{nvarchar7}", i.nvarchar7);
            TypeHtml = TypeHtml.Replace("{nvarchar8}", i.nvarchar8);
            TypeHtml = TypeHtml.Replace("{nvarchar9}", i.nvarchar9);
            TypeHtml = TypeHtml.Replace("{nvarchar10}", i.nvarchar10);
            TypeHtml = TypeHtml.Replace("{nvarchar11}", i.nvarchar11);
            TypeHtml = TypeHtml.Replace("{nvarchar12}", i.nvarchar12);
            TypeHtml = TypeHtml.Replace("{nvarchar13}", i.nvarchar13);
            TypeHtml = TypeHtml.Replace("{nvarchar14}", i.nvarchar14);
            TypeHtml = TypeHtml.Replace("{nvarchar15}", i.nvarchar15);

            TypeHtml = TypeHtml.Replace("{outtime}", i.OutTime.ToS());
            TypeHtml = TypeHtml.Replace("{posttime}", i.PostTime.ToS());
            TypeHtml = TypeHtml.Replace("{replycount}", i.ReplyCount.ToS());
            TypeHtml = TypeHtml.Replace("{tel}", i.Tel);
            TypeHtml = TypeHtml.Replace("{tellocation}", i.TelLocation);
            TypeHtml = TypeHtml.Replace("{text1}", i.text1);
            TypeHtml = TypeHtml.Replace("{text2}", i.text2);
            TypeHtml = TypeHtml.Replace("{text3}", i.text3);
            TypeHtml = TypeHtml.Replace("{text4}", i.text4);
            TypeHtml = TypeHtml.Replace("{text5}", i.text5);

            TypeHtml = TypeHtml.Replace("{title}", i.Title);
            TypeHtml = TypeHtml.Replace("{userid}", i.UserID.ToS());
            TypeHtml = TypeHtml.Replace("{username}", i.UserName);
            TypeHtml = TypeHtml.Replace("{ztid}", i.ZtID.ToS());
            TypeHtml = TypeHtml.Replace("{ztname}", i.ZtName);

            ent.Dispose();
        }
        #endregion
    }
}