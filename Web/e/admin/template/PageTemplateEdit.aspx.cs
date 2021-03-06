﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.template
{
    public partial class PageTemplateEdit : AdminBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            if (!IsPostBack)
            {
                LoadInfo(id);
            }
        }

        protected void LoadInfo(int id)
        {
            if (id < 0)
            {
                return;
            }
            DataEntities ent = new DataEntities();
            TemplatePage tp = (from l in ent.TemplatePage where l.id == id select l).FirstOrDefault();
            ent.Dispose();
            chk_Enable.Checked = tp.Enable.ToBoolean();
            txt_pageName.Text = tp.PageName;
            txt_FileName.Text = tp.FileName;
            ddl_CreateWith.SelectedValue = tp.CreateWith.ToS();
            txt_Content.Text = tp.Content;
            FCKeditor1.Text = tp.TempVar;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            DataEntities ent = new DataEntities();
            TemplatePage tp = new TemplatePage();
            try
            {
                tp = (from l in ent.TemplatePage where l.id == id select l).First();
            }
            catch { }
            tp.Content = txt_Content.Text.ToSqlEnCode();
            tp.CreateWith = ddl_CreateWith.SelectedValue.ToInt32();
            tp.FileName = txt_FileName.Text;
            tp.PageName = txt_pageName.Text;
            tp.TempVar = FCKeditor1.Text;

            if (tp.id <= 0)
            {
                ent.AddToTemplatePage(tp);
            }
            ent.SaveChanges();

            ent.Dispose();
            CreatePage.CreatePages(tp);

            Js.AlertAndChangUrl("保存成功！", "PageTemplateList.aspx");
        }
    }
}