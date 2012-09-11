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
    public partial class InfoTypeEdit : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            DataEntities ent=new DataEntities();

            int id = WS.RequestInt("id");
            var i = //InfoTypeView.GetModelByID(id.ToS());
                (from l in ent.InfoType where l.id == id select l).FirstOrDefault();
            txt_TypeName.Text = i.TypeName;
            txt_TemplateIndex.Text = i.TemplateIndex;
            txt_TemplateList.Text = i.TemplateList;
            txt_TemplateContent.Text = i.TemplateContent;

            txt_TemplateForm.Text = i.TemplateForm;
            txt_TemplateAdminForm.Text = i.TemlateAdminForm;

            txt_Num1.Text = i.num1;
            txt_Num2.Text = i.num2;
            txt_Num3.Text = i.num3;
            txt_Num4.Text = i.num4;
            txt_Num5.Text = i.num5;
            txt_Num6.Text = i.num6;
            txt_Num7.Text = i.num7;
            txt_Num8.Text = i.num8;
            txt_Num9.Text = i.num9;
            txt_Num10.Text = i.num10;

            txt_Nvarchar1.Text = i.nvarchar1;
            txt_Nvarchar2.Text = i.nvarchar2;
            txt_Nvarchar3.Text = i.nvarchar3;
            txt_Nvarchar4.Text = i.nvarchar4;
            txt_Nvarchar5.Text = i.nvarchar5;
            txt_Nvarchar6.Text = i.nvarchar6;
            txt_Nvarchar7.Text = i.nvarchar7;
            txt_Nvarchar8.Text = i.nvarchar8;
            txt_Nvarchar9.Text = i.nvarchar9;
            txt_Nvarchar10.Text = i.nvarchar10;
            txt_Nvarchar11.Text = i.nvarchar11;
            txt_Nvarchar12.Text = i.nvarchar12;
            txt_Nvarchar13.Text = i.nvarchar13;
            txt_Nvarchar14.Text = i.nvarchar14;
            txt_Nvarchar15.Text = i.nvarchar15;

            txt_Decimal1.Text = i.decimal1;
            txt_Decimal2.Text = i.decimal2;
            txt_Decimal3.Text = i.decimal3;
            txt_Decimal4.Text = i.decimal4;
            txt_Decimal5.Text = i.decimal5;

            txt_Text1.Text = i.text1;
            txt_Text2.Text = i.text2;
            txt_Text3.Text = i.text3;
            txt_Text4.Text = i.text4;
            txt_Text5.Text = i.text5;

            txt_Bit1.Text = i.bit1;
            txt_Bit2.Text = i.bit2;
            txt_Bit3.Text = i.bit3;
            txt_Bit4.Text = i.bit4;
            txt_Bit5.Text = i.bit5;


            ent.Dispose();

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            var i = //InfoTypeView.GetModelByID(id.ToS());
                (from l in ent.InfoType where l.id == id select l).FirstOrDefault();
            i.TypeName = txt_TypeName.Text.ToSqlEnCode();
            i.TemplateIndex = txt_TemplateIndex.Text.ToSqlEnCode();
            i.TemplateList = txt_TemplateList.Text.ToSqlEnCode();
            i.TemplateContent = txt_TemplateContent.Text.ToSqlEnCode();

            i.TemplateForm = txt_TemplateForm.Text.ToSqlEnCode();
            i.TemlateAdminForm = txt_TemplateAdminForm.Text.ToSqlEnCode();

            i.num1 = txt_Num1.Text;
            i.num2 = txt_Num2.Text;
            i.num3 = txt_Num3.Text;
            i.num4 = txt_Num4.Text;
            i.num5 = txt_Num5.Text;
            i.num6 = txt_Num6.Text;
            i.num7 = txt_Num7.Text;
            i.num8 = txt_Num8.Text;
            i.num9 = txt_Num9.Text;
            i.num10 = txt_Num10.Text;

            i.nvarchar1 = txt_Nvarchar1.Text;
            i.nvarchar2 = txt_Nvarchar2.Text;
            i.nvarchar3 = txt_Nvarchar3.Text;
            i.nvarchar4 = txt_Nvarchar4.Text;
            i.nvarchar5 = txt_Nvarchar5.Text;
            i.nvarchar6 = txt_Nvarchar6.Text;
            i.nvarchar7 = txt_Nvarchar7.Text;
            i.nvarchar8 = txt_Nvarchar8.Text;
            i.nvarchar9 = txt_Nvarchar9.Text;
            i.nvarchar10 = txt_Nvarchar10.Text;
            i.nvarchar11 = txt_Nvarchar11.Text;
            i.nvarchar12 = txt_Nvarchar12.Text;
            i.nvarchar13 = txt_Nvarchar13.Text;
            i.nvarchar14 = txt_Nvarchar14.Text;
            i.nvarchar15 = txt_Nvarchar15.Text;

            i.decimal1 = txt_Decimal1.Text;
            i.decimal2 = txt_Decimal2.Text;
            i.decimal3 = txt_Decimal3.Text;
            i.decimal4 = txt_Decimal4.Text;
            i.decimal5 = txt_Decimal5.Text;

            i.text1 = txt_Text1.Text;
            i.text2 = txt_Text2.Text;
            i.text3 = txt_Text3.Text;
            i.text4 = txt_Text4.Text;
            i.text5 = txt_Text5.Text;

            i.bit1 = txt_Bit1.Text;
            i.bit2 = txt_Bit2.Text;
            i.bit3 = txt_Bit3.Text;
            i.bit4 = txt_Bit4.Text;
            i.bit5 = txt_Bit5.Text;

            if (id < 0)
            {
                ent.AddToInfoType(i);
            }
            ent.SaveChanges();
            ent.Dispose();
            Response.Redirect("InfoTypeList.aspx");
        }
    }
}