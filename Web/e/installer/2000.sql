if exists (select * from dbo.sysobjects where id = object_id(N'[Answer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Answer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Class]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Class]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[File]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [File]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[GroupRole]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [GroupRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[ImageAlbum]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [ImageAlbum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Images]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Images]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Link]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Link]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[News]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [News]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Question]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Question]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Relpy]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Relpy]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SysDepartment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SysDepartment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SysGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SysGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SysKeyword]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SysKeyword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SysModel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SysModel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SysRole]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SysRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[SysUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [SysUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplTags]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplTags]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateContent]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateContent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateFace]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateFace]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateList]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplatePublic]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplatePublic]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateReply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateReply]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateSearch]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateSearch]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TemplateVar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TemplateVar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [User]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[UserClassRelation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [UserClassRelation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[UserForm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [UserForm]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[UserGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [UserGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[UserRerm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [UserRerm]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Zt]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Zt]
GO

CREATE TABLE [Answer] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[QuestionID] [int] NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[UserID] [int] NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[AnswerTime] [datetime] NULL ,
	[Agree] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Class] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Alter] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ParentID] [int] NULL ,
	[IsLeafClass] [bit] NULL ,
	[ParentClassForder] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ClassForder] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ModelID] [int] NULL ,
	[ClassKeywords] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ClassDescription] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[ClassICON] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ShowInNav] [bit] NULL ,
	[NavIndex] [int] NULL ,
	[VisitRole] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[EnablePost] [bit] NULL ,
	[EnableVCode] [bit] NULL ,
	[PostRoles] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[PostcreateList] [int] NULL ,
	[PostAddCent] [int] NULL ,
	[NeedAudit] [bit] NULL ,
	[PostManagement] [int] NULL ,
	[EditcreateList] [int] NULL ,
	[EnableSameTitle] [bit] NULL ,
	[AutoAudt] [bit] NULL ,
	[EnableReply] [bit] NULL ,
	[ReplyNeedAudit] [bit] NULL ,
	[ListModel] [int] NULL ,
	[ContentModel] [int] NULL ,
	[ReplyModel] [int] NULL ,
	[SearchModel] [int] NULL ,
	[ClassPageMode] [int] NULL ,
	[ContentPageMode] [int] NULL ,
	[ManagementOrder] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[ListPageOrder] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[ClassPageExtName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ListPageSize] [int] NULL ,
	[ContentPageForder] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[ContentPageExtName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ContentPageNameMode] [int] NULL ,
	[ContentPageDirMode] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [File] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassID] [int] NULL ,
	[UpTime] [datetime] NULL ,
	[FileType] [int] NULL ,
	[FileSize] [bigint] NULL ,
	[FileDirectory] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[FileName] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[FileExtName] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[FilePath] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[SmallPath] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [GroupRole] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NULL ,
	[RoleID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [ImageAlbum] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassID] [int] NULL ,
	[ZtID] [int] NULL ,
	[AuthorID] [int] NULL ,
	[Author] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Title] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[CreateTime] [datetime] NULL ,
	[UpdateTime] [datetime] NULL ,
	[Intro] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[Size] [int] NULL ,
	[Folder] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ClickCount] [int] NULL ,
	[ReplyCount] [int] NULL ,
	[SetTop] [bit] NULL ,
	[ShotCut] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[KeyWords] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [Images] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AlbumID] [int] NULL ,
	[Title] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Intro] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[UploadTime] [datetime] NULL ,
	[ClickCount] [int] NULL ,
	[ReplyCount] [int] NULL ,
	[FilePath] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[SmallPath] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[FileSize] [int] NULL ,
	[ExtName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [Link] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[LinkTitle] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[Url] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Index] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [News] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[NewsTime] [datetime] NULL ,
	[Title] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[TitleB] [bit] NULL ,
	[TitleI] [bit] NULL ,
	[TitleS] [bit] NULL ,
	[TitleColor] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[FTitle] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[Audit] [bit] NULL ,
	[Tuijian] [bit] NULL ,
	[Toutiao] [bit] NULL ,
	[KeyWords] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[NavUrl] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[TitleImage] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Description] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[Author] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[AutorID] [int] NULL ,
	[Content] [ntext] COLLATE Chinese_PRC_CI_AS NULL ,
	[SetTop] [bit] NULL ,
	[ModelID] [int] NULL ,
	[ClickCount] [int] NULL ,
	[DownCount] [int] NULL ,
	[FileForder] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[FileName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ZtID] [int] NULL ,
	[ClassID] [int] NULL ,
	[ReplyCount] [int] NULL ,
	[Source] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[EnableReply] [bit] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Question] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassID] [int] NULL ,
	[ZtID] [int] NULL ,
	[Title] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[UserID] [int] NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[AskTime] [datetime] NULL ,
	[ClickCount] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Relpy] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[NewsID] [int] NULL ,
	[UserID] [int] NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[IP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ReplyTime] [datetime] NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [SysDepartment] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DepartName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [SysGroup] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [SysKeyword] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Keyword] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ModelID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [SysModel] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ModelName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[TableName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SonClass] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [SysRole] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[RoleName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[RoleGroup] [int] NULL ,
	[URL] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[AddRole] [bit] NULL ,
	[EditRole] [bit] NULL ,
	[DelRole] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [SysUser] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[UserPass] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Logincount] [bigint] NULL ,
	[LastLoginTime] [datetime] NULL ,
	[LastLoginIP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SafeQuestion] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SafeAnswer] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Department] [int] NULL ,
	[ChineseName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[UserGroup] [int] NULL ,
	[Email] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[TelNumber] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Enabled] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [TemplTags] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[TagName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[TagCode] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[FunctionName] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[TagFormat] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Remark] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[Enable] [bit] NULL ,
	[TagIndex] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplateContent] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[SysModel] [int] NULL ,
	[TempName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[TimeFormat] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplateFace] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplateGroup] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[IsDefault] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [TemplateList] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[TempName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SysModel] [int] NULL ,
	[CutKeywords] [int] NULL ,
	[CutTitle] [int] NULL ,
	[ShowRecordCount] [int] NULL ,
	[TimeFormat] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[ListVar] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplatePublic] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[IndexContent] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[Controlcontent] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[SiteSearchContent] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[AdvancedSearch] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[HorizontaSearch] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[VerticalSearch] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[RelationInfo] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[MessageBoard] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[Reply] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[FinalDown] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[DownAddress] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[OLPlayaddress] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[ListPager] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[LoginStatus] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[JSLogin] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[ImageList] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[AnswerList] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplateReply] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplateSearch] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[TempName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SysModel] [int] NULL ,
	[CutKeywords] [int] NULL ,
	[CutTitle] [int] NULL ,
	[ShowRecordCount] [int] NULL ,
	[TimeFormat] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[ListVar] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [TemplateVar] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupID] [int] NULL ,
	[VarName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [User] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[UserPass] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Email] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ChineseName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[QQ] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[MSN] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Tel] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Mobile] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[WebSite] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Image] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Address] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ZipCode] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Intro] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[RegTime] [datetime] NULL ,
	[RegIP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[LoginCount] [int] NULL ,
	[LastLoginTime] [datetime] NULL ,
	[LastLoginIP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Cent] [int] NULL ,
	[PostCount] [int] NULL ,
	[GTalk] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Twitter] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[weibo] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ICQ] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Group] [int] NULL ,
	[Enable] [bit] NULL ,
	[StudentNo] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[TeachNo] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [UserClassRelation] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NULL ,
	[ClassID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [UserForm] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[FormName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[Content] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [UserGroup] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Grade] [int] NULL ,
	[MaxPost] [int] NULL ,
	[PostAotuAudit] [bit] NULL ,
	[RegForm] [int] NULL ,
	[EnableReg] [bit] NULL ,
	[RegAutoAudit] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [UserRerm] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[FormName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[FormContent] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[Remark] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Zt] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassID] [int] NULL ,
	[ZtName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Forder] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ExtName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ICON] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[KeyWords] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Description] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[LtIndex] [int] NULL ,
	[ShowInNav] [bit] NULL ,
	[FaceModel] [int] NULL ,
	[ListModel] [int] NULL ,
	[ListOrder] [int] NULL ,
	[ListPageSize] [int] NULL 
) ON [PRIMARY]
GO

