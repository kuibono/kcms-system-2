using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.news
{
    public partial class ClassEdit : AdminBase
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadList();
            }
        }

        protected void LoadList()
        {
           

            ddl_ModelID.DataSource = TemplateAction.AllSysModel;
            ddl_ModelID.DataTextField = "ModelName";
            ddl_ModelID.DataValueField = "ID";
            ddl_ModelID.DataBind();


            lbox_ParentID.Bind(NewsAction.NewsClass.ToDataTable(), "ClassName", "ID");
            lbox_ParentID.Items.Add(new ListItem("--根栏目--", "0"));
            lbox_ParentID.SelectedValue = "0";

            cbl_VisitRole.Bind(UserAction.GetUserGroups().ToDataTable(), "GroupName", "ID");
            cbl_PostRoles.Bind(UserAction.GetUserGroups().ToDataTable(), "GroupName", "ID");
            ddl_PostcreateList.DataSource = CreatePageOptions;
            ddl_PostcreateList.DataBind();

            ddl_EditcreateList.Bind(CreatePageOptions);

            ddl_PostManagement.Bind(CreatePageOptions);


            int id = WS.RequestInt("id");
            if (id <= 0)
            {
                return;
            }

            Class cls = //ClassView.GetModelByID(id.ToString());
                ObjectExtents.Class(id);

            txt_ClassName.Text = cls.ClassName;
            txt_Alter.Text = cls.Alter;
            lbox_ParentID.SelectedValue = cls.ParentID.ToString();
            chk_IsLeafClass.Checked = cls.IsLeafClass.ToBoolean();

            txt_ParentClassForder.Text = cls.ParentClassForder;
            txt_ClassForder.Text = cls.ClassForder;
            ddl_ModelID.SelectedValue = cls.ModelID.ToS();

            txt_ClassICON.Text = cls.ClassICON;
            txt_ClassKeywords.Text = cls.ClassKeywords;
            txt_ClassDescription.Text = cls.ClassDescription;

            chk_ShowInNav.Checked = cls.ShowInNav.ToBoolean();
            chk_EnablePost.Checked = cls.EnablePost.ToBoolean();
            txt_NavIndex.Text = cls.NavIndex.ToS();
            cbl_VisitRole.SetValue(cls.VisitRole.Split(','));

            cbl_PostRoles.SetValue(cls.PostRoles.Split(','));
            ddl_PostcreateList.SelectedValue = cls.PostcreateList.ToString();
            txt_PostAddCent.Text = cls.PostAddCent.ToS();
            ddl_PostManagement.SelectedValue = cls.PostManagement.ToS();

            ddl_EditcreateList.SelectedValue = cls.EditcreateList.ToS();
            chk_AutoAudt.Checked = cls.AutoAudt.ToBoolean();

            chk_EnableReply.Checked = cls.EnableReply.ToBoolean();
            chk_ReplyNeedAudit.Checked = cls.ReplyNeedAudit.ToBoolean();

            ddl_ModelID.SelectedValue = cls.ModelID.ToS();


        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            int id = WS.RequestInt("id");
            Class cls = (from l in ent.Class where l.ID == id select l).FirstOrDefault();

            cls.ClassName = txt_ClassName.Text;
            cls.Alter = txt_Alter.Text;
            if (cls.Alter.IsNullOrEmpty())
            {
                cls.Alter = txt_ClassName.Text;
            }
            cls.ParentID = lbox_ParentID.SelectedValue.ToInt32();
            cls.IsLeafClass = chk_IsLeafClass.Checked;

            cls.ParentClassForder = txt_ParentClassForder.Text;
            cls.ClassForder = txt_ClassForder.Text;
            cls.ModelID = ddl_ModelID.SelectedValue.ToInt32();

            cls.ClassICON = txt_ClassICON.Text;
            cls.ClassKeywords = txt_ClassKeywords.Text;
            cls.ClassDescription = txt_ClassDescription.Text;

            cls.ShowInNav = chk_ShowInNav.Checked;
            cls.EnablePost = chk_EnablePost.Checked;
            cls.NavIndex = txt_NavIndex.Text.ToInt32();

            cls.VisitRole = cbl_VisitRole.GetValues();
            //--cbl_VisitRole.SetValue(cls.VisitRole.Split(','));

            cls.PostRoles = cbl_PostRoles.GetValues();
            //--cbl_PostRoles.SetValue(cls.PostRoles.Split(','));

            cls.PostcreateList = ddl_PostcreateList.SelectedValue.ToInt32();
            cls.PostAddCent = txt_PostAddCent.Text.ToInt32();
            cls.PostManagement = ddl_PostManagement.SelectedValue.ToInt32();

            cls.EditcreateList = ddl_EditcreateList.SelectedValue.ToInt32();
            cls.AutoAudt = chk_AutoAudt.Checked;

            cls.EnableReply = chk_EnableReply.Checked;
            cls.ReplyNeedAudit = chk_ReplyNeedAudit.Checked;

            cls.ModelID = ddl_ModelID.SelectedValue.ToInt32();

            if (cls.ID <= 0)
            {
                ent.AddToClass(cls);
            }

            ent.SaveChanges();

            Voodoo.Cache.Cache.Clear("_NewClassList");
            Js.AlertAndChangUrl("保存成功！", "ClassList.aspx");
        }
    }
}
