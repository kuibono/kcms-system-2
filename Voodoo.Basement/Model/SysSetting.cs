/*
*本代码由代码生成器自动生成，请不要更改此文件的任何代码。
*生成时间：2011-11-7 9:46:11
*生成者：kuibono
*/
using System;
namespace Voodoo.Basement
{
	///<summary>
	///表SysSetting的实体类
	///</summary>
	public class SysSetting
	{
        /// <summary>
        /// 默认模型
        /// </summary>
        public int DefaultModel { get; set; }

        /// <summary>
        /// 是否启用静态
        /// </summary>
        public bool EnableStatic { get; set; }

        public bool EnableReWrite { get; set; }

        /// <summary>
        /// 是否显示信息管理菜单
        /// </summary>
        public bool ShowMenuMessage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SiteUrl{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool SiteOpen{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string KeyWords{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string Description{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string Copyright{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string CountCode{get ; set; }

        /// <summary>
        /// 分類页面存放目录
        /// </summary>
        public string ClassFolder { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string FileDirString{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string ExtName{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string SiteCloseMsg{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string SiteName{get ; set; }

        public bool EnablePing { get; set; }

        public string PingAddress { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string SiteEmail{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string EmailUser{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string EmailNickName{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string SmtpServer{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string SmtpPort{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string EmailPass{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool EnableReg{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int RegisterDefaultGroup{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int RegCent{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int MaxUserName{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int MinUserName{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int MaxPassword{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int MinPassword{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool EmailCheck{get ; set; }

        /// <summary>
        /// 允许注册时间间隔检查
        /// </summary>
        public bool EnableRegTimeCheck { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int RegTimeSpan{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string UserNameFilter{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool BackLoginUseVCode{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int BackLoginErrorSize{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int BackLoginErrorTimeSpan{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public int BackCookieTimeOut{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string FileDir{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public long MaxFileSize{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public long MaxPostFileSize{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string PostfileExtName{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool EnablePost{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public long PostImageSize{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string PostImageExtName{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool EnablePostImage{get ; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public string FileExtNameFilter{get ; set; }

        /// <summary>
        /// 后台列表每页条数
        /// </summary>
        public int MagageListSize { get; set; }



        //联系方式

        public string ContactEmail { get; set; }

        public string QQ { get; set; }

        public string Msn { get; set; }

        public string Weibo { get; set; }

        public string Renren { get; set; }

		
		///实体复制
		public SysSetting Clone()
        {
            return (SysSetting)this.MemberwiseClone();
        }
	}
	 
}


