
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/11/2012 20:34:37
-- Generated from EDMX file: E:\代码\KCMS2\trunk\Voodoo.Basement\Data.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KCMS2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ad];
GO
IF OBJECT_ID(N'[dbo].[AdGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdGroup];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[Area]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Area];
GO
IF OBJECT_ID(N'[dbo].[Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Book];
GO
IF OBJECT_ID(N'[dbo].[BookChapter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookChapter];
GO
IF OBJECT_ID(N'[dbo].[BookRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookRole];
GO
IF OBJECT_ID(N'[dbo].[BookVolume]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookVolume];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Class]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Class];
GO
IF OBJECT_ID(N'[dbo].[File]', 'U') IS NOT NULL
    DROP TABLE [dbo].[File];
GO
IF OBJECT_ID(N'[dbo].[GroupRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupRole];
GO
IF OBJECT_ID(N'[dbo].[ImageAlbum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageAlbum];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Info];
GO
IF OBJECT_ID(N'[dbo].[InfoImage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InfoImage];
GO
IF OBJECT_ID(N'[dbo].[InfoType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InfoType];
GO
IF OBJECT_ID(N'[dbo].[JobApplicationRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobApplicationRecord];
GO
IF OBJECT_ID(N'[dbo].[JobCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobCompany];
GO
IF OBJECT_ID(N'[dbo].[JobEduSpecialty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobEduSpecialty];
GO
IF OBJECT_ID(N'[dbo].[JobIndustry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobIndustry];
GO
IF OBJECT_ID(N'[dbo].[JobPost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobPost];
GO
IF OBJECT_ID(N'[dbo].[JobResumeCertificate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeCertificate];
GO
IF OBJECT_ID(N'[dbo].[JobResumeEdu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeEdu];
GO
IF OBJECT_ID(N'[dbo].[JobResumeExperience]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeExperience];
GO
IF OBJECT_ID(N'[dbo].[JobResumeFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeFile];
GO
IF OBJECT_ID(N'[dbo].[JobResumeInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeInfo];
GO
IF OBJECT_ID(N'[dbo].[JobResumeLanguage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeLanguage];
GO
IF OBJECT_ID(N'[dbo].[JobResumeTrain]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobResumeTrain];
GO
IF OBJECT_ID(N'[dbo].[JobType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobType];
GO
IF OBJECT_ID(N'[dbo].[Link]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Link];
GO
IF OBJECT_ID(N'[dbo].[MovieDrama]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieDrama];
GO
IF OBJECT_ID(N'[dbo].[MovieDramaUrl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieDramaUrl];
GO
IF OBJECT_ID(N'[dbo].[MovieInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieInfo];
GO
IF OBJECT_ID(N'[dbo].[MovieUrl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieUrl];
GO
IF OBJECT_ID(N'[dbo].[MovieUrlBaidu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieUrlBaidu];
GO
IF OBJECT_ID(N'[dbo].[MovieUrlKuaib]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieUrlKuaib];
GO
IF OBJECT_ID(N'[dbo].[MovieUrlMag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieUrlMag];
GO
IF OBJECT_ID(N'[dbo].[News]', 'U') IS NOT NULL
    DROP TABLE [dbo].[News];
GO
IF OBJECT_ID(N'[dbo].[Province]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Province];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[Relpy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Relpy];
GO
IF OBJECT_ID(N'[dbo].[SysDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysDepartment];
GO
IF OBJECT_ID(N'[dbo].[SysGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysGroup];
GO
IF OBJECT_ID(N'[dbo].[SysKeyword]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysKeyword];
GO
IF OBJECT_ID(N'[dbo].[SysModel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysModel];
GO
IF OBJECT_ID(N'[dbo].[SysNavPanel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysNavPanel];
GO
IF OBJECT_ID(N'[dbo].[SysNavTree]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysNavTree];
GO
IF OBJECT_ID(N'[dbo].[SysRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysRole];
GO
IF OBJECT_ID(N'[dbo].[SysUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SysUser];
GO
IF OBJECT_ID(N'[dbo].[TemplateContent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateContent];
GO
IF OBJECT_ID(N'[dbo].[TemplateFace]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateFace];
GO
IF OBJECT_ID(N'[dbo].[TemplateGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateGroup];
GO
IF OBJECT_ID(N'[dbo].[TemplateList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateList];
GO
IF OBJECT_ID(N'[dbo].[TemplatePage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplatePage];
GO
IF OBJECT_ID(N'[dbo].[TemplatePublic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplatePublic];
GO
IF OBJECT_ID(N'[dbo].[TemplateReply]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateReply];
GO
IF OBJECT_ID(N'[dbo].[TemplateSearch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateSearch];
GO
IF OBJECT_ID(N'[dbo].[TemplateVar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateVar];
GO
IF OBJECT_ID(N'[dbo].[TemplTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplTags];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserClassRelation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserClassRelation];
GO
IF OBJECT_ID(N'[dbo].[UserForm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserForm];
GO
IF OBJECT_ID(N'[dbo].[UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup];
GO
IF OBJECT_ID(N'[dbo].[UserRerm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRerm];
GO
IF OBJECT_ID(N'[dbo].[ViewHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ViewHistory];
GO
IF OBJECT_ID(N'[dbo].[Zt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zt];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Answer'
CREATE TABLE [dbo].[Answer] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [QuestionID] int  NULL,
    [Content] nvarchar(max)  NULL,
    [UserID] int  NULL,
    [UserName] nvarchar(50)  NULL,
    [AnswerTime] datetime  NULL,
    [Agree] int  NULL
);
GO

-- Creating table 'Book'
CREATE TABLE [dbo].[Book] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NOT NULL,
    [ClassName] nvarchar(50)  NULL,
    [ZtID] int  NULL,
    [ZtName] nvarchar(50)  NULL,
    [Title] nvarchar(100)  NULL,
    [Author] nvarchar(100)  NULL,
    [Intro] nvarchar(max)  NULL,
    [Length] bigint  NULL,
    [ReplyCount] bigint  NULL,
    [ClickCount] bigint  NULL,
    [Addtime] datetime  NULL,
    [Status] tinyint  NULL,
    [IsVip] bit  NULL,
    [FaceImage] nvarchar(100)  NULL,
    [SaveCount] bigint  NULL,
    [Enable] bit  NULL,
    [IsFirstPost] bit  NULL,
    [LastChapterID] bigint  NULL,
    [LastChapterTitle] nvarchar(100)  NULL,
    [UpdateTime] datetime  NULL,
    [LastVipChapterID] bigint  NULL,
    [LastVipChapterTitle] nvarchar(100)  NULL,
    [VipUpdateTime] datetime  NULL,
    [CorpusID] int  NULL,
    [CorpusTitle] nvarchar(200)  NULL,
    [TjCount] int  NULL
);
GO

-- Creating table 'BookChapter'
CREATE TABLE [dbo].[BookChapter] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [BookID] int  NOT NULL,
    [BookTitle] nvarchar(200)  NULL,
    [ClassID] bigint  NOT NULL,
    [ClassName] nvarchar(100)  NULL,
    [ValumeID] bigint  NOT NULL,
    [ValumeName] nvarchar(100)  NULL,
    [Title] nvarchar(200)  NULL,
    [IsVipChapter] bit  NULL,
    [TextLength] int  NULL,
    [UpdateTime] datetime  NOT NULL,
    [Enable] bit  NULL,
    [IsTemp] bit  NULL,
    [IsFree] bit  NULL,
    [ChapterIndex] int  NOT NULL,
    [IsImageChapter] bit  NULL,
    [Content] nvarchar(max)  NULL,
    [ClickCount] int  NULL
);
GO

-- Creating table 'BookRole'
CREATE TABLE [dbo].[BookRole] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [BookID] int  NULL,
    [RoleName] nvarchar(50)  NULL,
    [Intro] nvarchar(2000)  NULL
);
GO

-- Creating table 'BookVolume'
CREATE TABLE [dbo].[BookVolume] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [BookID] int  NOT NULL,
    [booktitle] nvarchar(100)  NULL,
    [booknclass] nvarchar(50)  NULL
);
GO

-- Creating table 'Class'
CREATE TABLE [dbo].[Class] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassName] nvarchar(50)  NULL,
    [Alter] nvarchar(50)  NULL,
    [ParentID] int  NULL,
    [IsLeafClass] bit  NULL,
    [ParentClassForder] nvarchar(50)  NULL,
    [ClassForder] nvarchar(50)  NULL,
    [ModelID] int  NULL,
    [ClassKeywords] nvarchar(255)  NULL,
    [ClassDescription] nvarchar(512)  NULL,
    [ClassICON] nvarchar(255)  NULL,
    [ShowInNav] bit  NULL,
    [NavIndex] int  NULL,
    [VisitRole] nvarchar(512)  NULL,
    [EnablePost] bit  NULL,
    [EnableVCode] bit  NULL,
    [PostRoles] nvarchar(512)  NULL,
    [PostcreateList] int  NULL,
    [PostAddCent] int  NULL,
    [NeedAudit] bit  NULL,
    [PostManagement] int  NULL,
    [EditcreateList] int  NULL,
    [EnableSameTitle] bit  NULL,
    [AutoAudt] bit  NULL,
    [EnableReply] bit  NULL,
    [ReplyNeedAudit] bit  NULL,
    [ListModel] int  NULL,
    [ContentModel] int  NULL,
    [ReplyModel] int  NULL,
    [SearchModel] int  NULL,
    [ClassPageMode] int  NULL,
    [ContentPageMode] int  NULL,
    [ManagementOrder] nvarchar(512)  NULL,
    [ListPageOrder] nvarchar(512)  NULL,
    [ClassPageExtName] nvarchar(50)  NULL,
    [ListPageSize] int  NULL,
    [ContentPageForder] nvarchar(512)  NULL,
    [ContentPageExtName] nvarchar(50)  NULL,
    [ContentPageNameMode] int  NULL,
    [ContentPageDirMode] nvarchar(50)  NULL
);
GO

-- Creating table 'File'
CREATE TABLE [dbo].[File] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NULL,
    [UpTime] datetime  NULL,
    [FileType] int  NULL,
    [FileSize] bigint  NULL,
    [FileDirectory] nvarchar(255)  NULL,
    [FileName] nvarchar(255)  NULL,
    [FileExtName] nvarchar(255)  NULL,
    [FilePath] nvarchar(500)  NULL,
    [SmallPath] nvarchar(500)  NULL
);
GO

-- Creating table 'GroupRole'
CREATE TABLE [dbo].[GroupRole] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [RoleID] int  NULL
);
GO

-- Creating table 'ImageAlbum'
CREATE TABLE [dbo].[ImageAlbum] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NULL,
    [ZtID] int  NULL,
    [AuthorID] int  NULL,
    [Author] nvarchar(50)  NULL,
    [Title] nvarchar(255)  NULL,
    [CreateTime] datetime  NULL,
    [UpdateTime] datetime  NULL,
    [Intro] nvarchar(500)  NULL,
    [Size] int  NULL,
    [Folder] nvarchar(255)  NULL,
    [ClickCount] int  NULL,
    [ReplyCount] int  NULL,
    [SetTop] bit  NULL,
    [ShotCut] nvarchar(255)  NULL,
    [KeyWords] nvarchar(255)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AlbumID] int  NULL,
    [Title] nvarchar(255)  NULL,
    [Intro] nvarchar(500)  NULL,
    [UploadTime] datetime  NULL,
    [ClickCount] int  NULL,
    [ReplyCount] int  NULL,
    [FilePath] nvarchar(255)  NULL,
    [SmallPath] nvarchar(255)  NULL,
    [FileSize] int  NULL,
    [ExtName] nvarchar(50)  NULL
);
GO

-- Creating table 'Info'
CREATE TABLE [dbo].[Info] (
    [id] int IDENTITY(1,1) NOT NULL,
    [InfoTypeID] nvarchar(50)  NULL,
    [ClassID] int  NULL,
    [ClassName] nvarchar(50)  NULL,
    [ZtID] int  NULL,
    [ZtName] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [UserID] int  NULL,
    [Contact] nvarchar(50)  NULL,
    [ContactType] nvarchar(50)  NULL,
    [Tel] nvarchar(50)  NULL,
    [TelLocation] nvarchar(50)  NULL,
    [Address] nvarchar(255)  NULL,
    [Intro] nvarchar(1000)  NULL,
    [ImageCount] int  NULL,
    [ReplyCount] int  NULL,
    [ClickCount] int  NULL,
    [IsSetTop] bit  NULL,
    [OutTime] datetime  NULL,
    [PostTime] datetime  NULL,
    [num1] int  NULL,
    [num2] int  NULL,
    [num3] int  NULL,
    [num4] int  NULL,
    [num5] int  NULL,
    [num6] int  NULL,
    [num7] int  NULL,
    [num8] int  NULL,
    [num9] int  NULL,
    [num10] int  NULL,
    [nvarchar1] nvarchar(255)  NULL,
    [nvarchar2] nvarchar(255)  NULL,
    [nvarchar3] nvarchar(255)  NULL,
    [nvarchar4] nvarchar(255)  NULL,
    [nvarchar5] nvarchar(255)  NULL,
    [nvarchar6] nvarchar(255)  NULL,
    [nvarchar7] nvarchar(255)  NULL,
    [nvarchar8] nvarchar(255)  NULL,
    [nvarchar9] nvarchar(255)  NULL,
    [nvarchar10] nvarchar(255)  NULL,
    [nvarchar11] nvarchar(50)  NULL,
    [nvarchar12] nvarchar(50)  NULL,
    [nvarchar13] nvarchar(50)  NULL,
    [nvarchar14] nvarchar(50)  NULL,
    [nvarchar15] nvarchar(50)  NULL,
    [decimal1] decimal(18,2)  NULL,
    [decimal2] decimal(18,2)  NULL,
    [decimal3] decimal(18,2)  NULL,
    [decimal4] decimal(18,2)  NULL,
    [decimal5] decimal(18,2)  NULL,
    [text1] nvarchar(1000)  NULL,
    [text2] nvarchar(1000)  NULL,
    [text3] nvarchar(1000)  NULL,
    [text4] nvarchar(1000)  NULL,
    [text5] nvarchar(1000)  NULL,
    [bit1] bit  NULL,
    [bit2] bit  NULL,
    [bit3] bit  NULL,
    [bit4] bit  NULL,
    [bit5] bit  NULL
);
GO

-- Creating table 'InfoImage'
CREATE TABLE [dbo].[InfoImage] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ModelID] int  NULL,
    [InfoID] int  NULL,
    [Title] nvarchar(255)  NULL,
    [Url] nvarchar(500)  NULL
);
GO

-- Creating table 'InfoType'
CREATE TABLE [dbo].[InfoType] (
    [id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(50)  NULL,
    [TemplateIndex] varchar(max)  NULL,
    [TemplateList] varchar(max)  NULL,
    [TemlateAdminForm] varchar(max)  NULL,
    [TemplateForm] varchar(max)  NULL,
    [TemplateContent] varchar(max)  NULL,
    [num1] nvarchar(50)  NULL,
    [num2] nvarchar(50)  NULL,
    [num3] nvarchar(50)  NULL,
    [num4] nvarchar(50)  NULL,
    [num5] nvarchar(50)  NULL,
    [num6] nvarchar(50)  NULL,
    [num7] nvarchar(50)  NULL,
    [num8] nvarchar(50)  NULL,
    [num9] nvarchar(50)  NULL,
    [num10] nvarchar(50)  NULL,
    [nvarchar1] nvarchar(50)  NULL,
    [nvarchar2] nvarchar(50)  NULL,
    [nvarchar3] nvarchar(50)  NULL,
    [nvarchar4] nvarchar(50)  NULL,
    [nvarchar5] nvarchar(50)  NULL,
    [nvarchar6] nvarchar(50)  NULL,
    [nvarchar7] nvarchar(50)  NULL,
    [nvarchar8] nvarchar(50)  NULL,
    [nvarchar9] nvarchar(50)  NULL,
    [nvarchar10] nvarchar(50)  NULL,
    [nvarchar11] nvarchar(50)  NULL,
    [nvarchar12] nvarchar(50)  NULL,
    [nvarchar13] nvarchar(50)  NULL,
    [nvarchar14] nvarchar(50)  NULL,
    [nvarchar15] nvarchar(50)  NULL,
    [decimal1] nvarchar(50)  NULL,
    [decimal2] nvarchar(50)  NULL,
    [decimal3] nvarchar(50)  NULL,
    [decimal4] nvarchar(50)  NULL,
    [decimal5] nvarchar(50)  NULL,
    [text1] nvarchar(50)  NULL,
    [text2] nvarchar(50)  NULL,
    [text3] nvarchar(50)  NULL,
    [text4] nvarchar(50)  NULL,
    [text5] nvarchar(50)  NULL,
    [bit1] nvarchar(50)  NULL,
    [bit2] nvarchar(50)  NULL,
    [bit3] nvarchar(50)  NULL,
    [bit4] nvarchar(50)  NULL,
    [bit5] nvarchar(50)  NULL
);
GO

-- Creating table 'Link'
CREATE TABLE [dbo].[Link] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LinkTitle] nvarchar(100)  NULL,
    [Url] nvarchar(255)  NULL,
    [Index] int  NULL
);
GO

-- Creating table 'MovieDrama'
CREATE TABLE [dbo].[MovieDrama] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [MovieID] int  NULL,
    [MovieTitle] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [UpdateTime] datetime  NULL,
    [Enable] bit  NULL
);
GO

-- Creating table 'MovieDramaUrl'
CREATE TABLE [dbo].[MovieDramaUrl] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [MovieID] int  NULL,
    [MovieTitle] nvarchar(50)  NULL,
    [MovieDramaID] bigint  NULL,
    [MovieDramaTitle] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [UpdateTime] datetime  NULL,
    [Enable] bit  NULL,
    [Url] nvarchar(500)  NULL,
    [SourceSite] nvarchar(50)  NULL
);
GO

-- Creating table 'MovieInfo'
CREATE TABLE [dbo].[MovieInfo] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NULL,
    [ClassName] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [Director] nvarchar(50)  NULL,
    [Actors] nvarchar(500)  NULL,
    [Tags] nvarchar(50)  NULL,
    [Location] nvarchar(50)  NULL,
    [PublicYear] nvarchar(50)  NULL,
    [Intro] nvarchar(4000)  NULL,
    [IsMove] bit  NULL,
    [FaceImage] nvarchar(500)  NULL,
    [InsertTime] datetime  NULL,
    [LastDramaTitle] nvarchar(500)  NULL,
    [LastDramaID] bigint  NULL,
    [UpdateTime] datetime  NULL,
    [Status] int  NULL,
    [Enable] bit  NULL,
    [ReplyCount] bigint  NULL,
    [TjCount] bigint  NULL,
    [ScoreAvg] decimal(18,0)  NULL,
    [ScoreTime] bigint  NULL,
    [Info] nvarchar(max)  NULL,
    [ClickCount] bigint  NULL,
    [MonthClick] bigint  NULL,
    [WeekClick] bigint  NULL,
    [DayClick] bigint  NULL,
    [LastClickTime] datetime  NULL,
    [StandardTitle] nvarchar(50)  NULL
);
GO

-- Creating table 'MovieUrl'
CREATE TABLE [dbo].[MovieUrl] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [MoviewID] int  NULL,
    [MoviewTitle] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [UpdateTime] datetime  NULL,
    [Enable] bit  NULL,
    [HttpUrl] nvarchar(1000)  NULL,
    [MagUrl] nvarchar(1000)  NULL,
    [KuaibUrl] nvarchar(1000)  NULL,
    [BaiduUrl] nvarchar(1000)  NULL
);
GO

-- Creating table 'MovieUrlBaidu'
CREATE TABLE [dbo].[MovieUrlBaidu] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [MovieID] int  NULL,
    [MovieTitle] nvarchar(255)  NULL,
    [Title] nvarchar(255)  NULL,
    [UpdateTime] datetime  NULL,
    [Enable] bit  NULL,
    [Url] nvarchar(500)  NULL
);
GO

-- Creating table 'MovieUrlKuaib'
CREATE TABLE [dbo].[MovieUrlKuaib] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [MovieID] int  NULL,
    [MovieTitle] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [UpdateTime] datetime  NULL,
    [Enable] bit  NULL,
    [Url] nvarchar(500)  NULL
);
GO

-- Creating table 'MovieUrlMag'
CREATE TABLE [dbo].[MovieUrlMag] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [MovieID] int  NULL,
    [MovieTitle] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [UpdateTime] datetime  NULL,
    [Enable] bit  NULL,
    [Url] nvarchar(500)  NULL
);
GO

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NewsTime] datetime  NULL,
    [Title] nvarchar(100)  NULL,
    [TitleB] bit  NULL,
    [TitleI] bit  NULL,
    [TitleS] bit  NULL,
    [TitleColor] nvarchar(50)  NULL,
    [FTitle] nvarchar(100)  NULL,
    [Audit] bit  NULL,
    [Tuijian] bit  NULL,
    [Toutiao] bit  NULL,
    [KeyWords] nvarchar(200)  NULL,
    [NavUrl] nvarchar(255)  NULL,
    [TitleImage] nvarchar(255)  NULL,
    [Description] nvarchar(512)  NULL,
    [Author] nvarchar(50)  NULL,
    [AutorID] int  NULL,
    [Content] nvarchar(max)  NULL,
    [SetTop] bit  NULL,
    [ModelID] int  NULL,
    [ClickCount] int  NULL,
    [DownCount] int  NULL,
    [FileForder] nvarchar(50)  NULL,
    [FileName] nvarchar(50)  NULL,
    [ZtID] int  NULL,
    [ClassID] int  NULL,
    [ReplyCount] int  NULL,
    [Source] nvarchar(50)  NULL,
    [EnableReply] bit  NULL,
    [ContentEn] nvarchar(max)  NULL
);
GO

-- Creating table 'Question'
CREATE TABLE [dbo].[Question] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NULL,
    [ZtID] int  NULL,
    [Title] nvarchar(255)  NULL,
    [Content] nvarchar(max)  NULL,
    [UserID] int  NULL,
    [UserName] nvarchar(50)  NULL,
    [AskTime] datetime  NULL,
    [ClickCount] int  NULL
);
GO

-- Creating table 'Relpy'
CREATE TABLE [dbo].[Relpy] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ModelID] int  NULL,
    [NewsID] int  NULL,
    [UserID] int  NULL,
    [UserName] nvarchar(50)  NULL,
    [IP] nvarchar(50)  NULL,
    [ReplyTime] datetime  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'SysDepartment'
CREATE TABLE [dbo].[SysDepartment] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DepartName] nvarchar(50)  NULL
);
GO

-- Creating table 'SysGroup'
CREATE TABLE [dbo].[SysGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(50)  NULL
);
GO

-- Creating table 'SysKeyword'
CREATE TABLE [dbo].[SysKeyword] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Keyword] nvarchar(50)  NULL,
    [ModelID] int  NULL,
    [ClickCount] int  NULL
);
GO

-- Creating table 'SysModel'
CREATE TABLE [dbo].[SysModel] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ModelName] nvarchar(50)  NULL,
    [TableName] nvarchar(50)  NULL,
    [SonClass] nvarchar(255)  NULL
);
GO

-- Creating table 'SysRole'
CREATE TABLE [dbo].[SysRole] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL,
    [RoleGroup] int  NULL,
    [URL] nvarchar(255)  NULL,
    [AddRole] bit  NULL,
    [EditRole] bit  NULL,
    [DelRole] bit  NULL
);
GO

-- Creating table 'SysUser'
CREATE TABLE [dbo].[SysUser] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [UserPass] nvarchar(50)  NULL,
    [Logincount] bigint  NULL,
    [LastLoginTime] datetime  NULL,
    [LastLoginIP] nvarchar(50)  NULL,
    [SafeQuestion] nvarchar(50)  NULL,
    [SafeAnswer] nvarchar(50)  NULL,
    [Department] int  NULL,
    [ChineseName] nvarchar(50)  NULL,
    [UserGroup] int  NULL,
    [Email] nvarchar(50)  NULL,
    [TelNumber] nvarchar(50)  NULL,
    [Enabled] bit  NULL
);
GO

-- Creating table 'TemplateContent'
CREATE TABLE [dbo].[TemplateContent] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [SysModel] int  NULL,
    [TempName] nvarchar(50)  NULL,
    [TimeFormat] nvarchar(50)  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplateFace'
CREATE TABLE [dbo].[TemplateFace] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplateGroup'
CREATE TABLE [dbo].[TemplateGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(50)  NULL,
    [IsDefault] bit  NULL
);
GO

-- Creating table 'TemplateList'
CREATE TABLE [dbo].[TemplateList] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [TempName] nvarchar(50)  NULL,
    [SysModel] int  NULL,
    [CutKeywords] int  NULL,
    [CutTitle] int  NULL,
    [ShowRecordCount] int  NULL,
    [TimeFormat] nvarchar(50)  NULL,
    [Content] nvarchar(max)  NULL,
    [ListVar] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplatePage'
CREATE TABLE [dbo].[TemplatePage] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Enable] bit  NULL,
    [PageName] nvarchar(500)  NULL,
    [FileName] nvarchar(255)  NULL,
    [Content] nvarchar(max)  NULL,
    [CreateWith] int  NULL,
    [TempVar] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplatePublic'
CREATE TABLE [dbo].[TemplatePublic] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [IndexContent] nvarchar(max)  NULL,
    [Controlcontent] nvarchar(max)  NULL,
    [SiteSearchContent] nvarchar(max)  NULL,
    [AdvancedSearch] nvarchar(max)  NULL,
    [HorizontaSearch] nvarchar(max)  NULL,
    [VerticalSearch] nvarchar(max)  NULL,
    [RelationInfo] nvarchar(max)  NULL,
    [MessageBoard] nvarchar(max)  NULL,
    [Reply] nvarchar(max)  NULL,
    [FinalDown] nvarchar(max)  NULL,
    [DownAddress] nvarchar(max)  NULL,
    [OLPlayaddress] nvarchar(max)  NULL,
    [ListPager] nvarchar(max)  NULL,
    [LoginStatus] nvarchar(max)  NULL,
    [JSLogin] nvarchar(max)  NULL,
    [ImageList] nvarchar(max)  NULL,
    [AnswerList] nvarchar(max)  NULL,
    [ChapterList] nvarchar(max)  NULL,
    [BookChapter] nvarchar(max)  NULL,
    [KuaiboPage] nvarchar(max)  NULL,
    [BaiduPage] nvarchar(max)  NULL,
    [SingleDrama] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplateReply'
CREATE TABLE [dbo].[TemplateReply] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplateSearch'
CREATE TABLE [dbo].[TemplateSearch] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [TempName] nvarchar(50)  NULL,
    [SysModel] int  NULL,
    [CutKeywords] int  NULL,
    [CutTitle] int  NULL,
    [ShowRecordCount] int  NULL,
    [TimeFormat] nvarchar(50)  NULL,
    [Content] nvarchar(max)  NULL,
    [ListVar] nvarchar(max)  NULL
);
GO

-- Creating table 'TemplateVar'
CREATE TABLE [dbo].[TemplateVar] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [VarName] nvarchar(50)  NULL,
    [Content] nvarchar(max)  NULL,
    [IsPublic] bit  NULL
);
GO

-- Creating table 'TemplTags'
CREATE TABLE [dbo].[TemplTags] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TagName] nvarchar(50)  NULL,
    [TagCode] nvarchar(50)  NULL,
    [FunctionName] nvarchar(255)  NULL,
    [TagFormat] nvarchar(255)  NULL,
    [Remark] nvarchar(max)  NULL,
    [Enable] bit  NULL,
    [TagIndex] int  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [UserPass] nvarchar(50)  NULL,
    [Email] nvarchar(255)  NULL,
    [ChineseName] nvarchar(50)  NULL,
    [QQ] nvarchar(50)  NULL,
    [MSN] nvarchar(50)  NULL,
    [Tel] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [WebSite] nvarchar(255)  NULL,
    [Image] nvarchar(255)  NULL,
    [Address] nvarchar(255)  NULL,
    [ZipCode] nvarchar(50)  NULL,
    [Intro] nvarchar(512)  NULL,
    [RegTime] datetime  NULL,
    [RegIP] nvarchar(50)  NULL,
    [LoginCount] int  NULL,
    [LastLoginTime] datetime  NULL,
    [LastLoginIP] nvarchar(50)  NULL,
    [Cent] int  NULL,
    [PostCount] int  NULL,
    [GTalk] nvarchar(255)  NULL,
    [Twitter] nvarchar(255)  NULL,
    [weibo] nvarchar(255)  NULL,
    [ICQ] nvarchar(255)  NULL,
    [Group] int  NULL,
    [Enable] bit  NULL,
    [StudentNo] nvarchar(50)  NULL,
    [TeachNo] nvarchar(50)  NULL
);
GO

-- Creating table 'UserClassRelation'
CREATE TABLE [dbo].[UserClassRelation] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [ClassID] int  NULL
);
GO

-- Creating table 'UserForm'
CREATE TABLE [dbo].[UserForm] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FormName] nvarchar(100)  NULL,
    [Content] nvarchar(max)  NULL
);
GO

-- Creating table 'UserGroup'
CREATE TABLE [dbo].[UserGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(50)  NULL,
    [Grade] int  NULL,
    [MaxPost] int  NULL,
    [PostAotuAudit] bit  NULL,
    [RegForm] int  NULL,
    [EnableReg] bit  NULL,
    [RegAutoAudit] bit  NULL
);
GO

-- Creating table 'UserRerm'
CREATE TABLE [dbo].[UserRerm] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FormName] nvarchar(50)  NULL,
    [FormContent] nvarchar(max)  NULL,
    [Remark] nvarchar(max)  NULL
);
GO

-- Creating table 'Zt'
CREATE TABLE [dbo].[Zt] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NULL,
    [ZtName] nvarchar(50)  NULL,
    [Forder] nvarchar(255)  NULL,
    [ExtName] nvarchar(50)  NULL,
    [ICON] nvarchar(255)  NULL,
    [KeyWords] nvarchar(255)  NULL,
    [Description] nvarchar(255)  NULL,
    [LtIndex] int  NULL,
    [ShowInNav] bit  NULL,
    [FaceModel] int  NULL,
    [ListModel] int  NULL,
    [ListOrder] int  NULL,
    [ListPageSize] int  NULL
);
GO

-- Creating table 'JobCompany'
CREATE TABLE [dbo].[JobCompany] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(100)  NULL,
    [Industry] nvarchar(500)  NULL,
    [CompanyType] int  NULL,
    [EmployeeCount] int  NULL,
    [Intro] nvarchar(max)  NULL,
    [UserID] int  NULL,
    [DayClick] int  NULL,
    [IsSetTop] bit  NULL,
    [SetTopTime] datetime  NULL
);
GO

-- Creating table 'JobPost'
CREATE TABLE [dbo].[JobPost] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [CompanyID] int  NULL,
    [Title] nvarchar(200)  NULL,
    [Province] int  NULL,
    [City] int  NULL,
    [Salary] int  NULL,
    [PostTime] datetime  NULL,
    [Expressions] int  NULL,
    [Edu] int  NULL,
    [EmployNumber] int  NULL,
    [Intro] nvarchar(max)  NULL,
    [Industry] int  NULL,
    [IsSetTop] bit  NULL,
    [SetTopTime] datetime  NULL
);
GO

-- Creating table 'JobResumeCertificate'
CREATE TABLE [dbo].[JobResumeCertificate] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [ResumeID] bigint  NULL,
    [CertificateName] nvarchar(50)  NULL,
    [GetTime] datetime  NULL,
    [Intro] nvarchar(max)  NULL
);
GO

-- Creating table 'JobResumeEdu'
CREATE TABLE [dbo].[JobResumeEdu] (
    [ID] bigint  NOT NULL,
    [ResumeID] bigint  NULL,
    [SchoolName] nvarchar(50)  NULL,
    [StartTime] datetime  NULL,
    [LeftTime] datetime  NULL,
    [Edu] int  NULL,
    [Specialty] int  NULL,
    [Intro] nvarchar(max)  NULL
);
GO

-- Creating table 'JobResumeExperience'
CREATE TABLE [dbo].[JobResumeExperience] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [ResumeID] bigint  NULL,
    [CompanyName] nvarchar(200)  NULL,
    [StartTime] datetime  NULL,
    [LeftTime] datetime  NULL,
    [Post] int  NULL,
    [Intro] nvarchar(max)  NULL
);
GO

-- Creating table 'JobResumeInfo'
CREATE TABLE [dbo].[JobResumeInfo] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [Title] nvarchar(200)  NULL,
    [Birthday] datetime  NULL,
    [IsMale] bit  NULL,
    [Province] int  NULL,
    [City] int  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [WorkPlace] int  NULL,
    [IsResumeOpen] bit  NULL,
    [Address] nvarchar(500)  NULL,
    [Tel] nvarchar(50)  NULL,
    [Image] nvarchar(255)  NULL,
    [Country] nvarchar(50)  NULL,
    [CardType] int  NULL,
    [CardNumber] nvarchar(100)  NULL,
    [HomeCity] int  NULL,
    [Marriage] int  NULL,
    [Nation] nvarchar(50)  NULL,
    [Political] int  NULL,
    [QQ] nvarchar(50)  NULL,
    [MSN] nvarchar(255)  NULL,
    [Intro] nvarchar(max)  NULL,
    [ChineseName] nvarchar(50)  NULL
);
GO

-- Creating table 'JobResumeLanguage'
CREATE TABLE [dbo].[JobResumeLanguage] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [ResumeID] bigint  NULL,
    [LanguageType] int  NULL,
    [SpeakingAbility] int  NULL,
    [WritingAbility] int  NULL
);
GO

-- Creating table 'JobResumeTrain'
CREATE TABLE [dbo].[JobResumeTrain] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [ResumeID] bigint  NULL,
    [Title] nvarchar(200)  NULL,
    [StartTime] datetime  NULL,
    [LeftTime] datetime  NULL,
    [OrganizationName] nvarchar(200)  NULL,
    [CertificateName] nvarchar(200)  NULL,
    [Intro] nvarchar(max)  NULL
);
GO

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [id] int IDENTITY(1,1) NOT NULL,
    [state] nvarchar(30)  NOT NULL,
    [city1] nvarchar(30)  NOT NULL,
    [sz_code] nvarchar(6)  NOT NULL,
    [Rome] nvarchar(50)  NULL,
    [zm_code] nvarchar(50)  NULL,
    [ProvinceID] int  NULL,
    [Hot] bigint  NULL,
    [ShowInIndex] bit  NULL,
    [ShowInNav] bit  NULL
);
GO

-- Creating table 'JobApplicationRecord'
CREATE TABLE [dbo].[JobApplicationRecord] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [ResumeID] bigint  NULL,
    [PostID] bigint  NULL,
    [CompanyID] int  NULL,
    [Message] nvarchar(max)  NULL,
    [ApplicationTime] datetime  NULL,
    [Status] int  NULL
);
GO

-- Creating table 'JobEduSpecialty'
CREATE TABLE [dbo].[JobEduSpecialty] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [ParentID] bigint  NULL
);
GO

-- Creating table 'JobIndustry'
CREATE TABLE [dbo].[JobIndustry] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [ParentID] int  NULL,
    [IsLeaf] bit  NULL,
    [Hot] int  NULL
);
GO

-- Creating table 'JobType'
CREATE TABLE [dbo].[JobType] (
    [ID] int  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [IndustryID] int  NULL
);
GO

-- Creating table 'Province'
CREATE TABLE [dbo].[Province] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [province1] nvarchar(30)  NOT NULL,
    [sz_code] nvarchar(6)  NOT NULL,
    [Rome] nvarchar(50)  NULL,
    [zm_code] nvarchar(50)  NULL,
    [AreaID] int  NULL,
    [ShowInIndex] bit  NULL
);
GO

-- Creating table 'JobResumeFile'
CREATE TABLE [dbo].[JobResumeFile] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [ResumeID] bigint  NULL,
    [FileName] nvarchar(50)  NULL,
    [FilePath] nvarchar(255)  NULL
);
GO

-- Creating table 'SysNavPanel'
CREATE TABLE [dbo].[SysNavPanel] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Icon] nvarchar(255)  NULL,
    [OrderIndex] int  NULL,
    [Group] nvarchar(500)  NULL
);
GO

-- Creating table 'SysNavTree'
CREATE TABLE [dbo].[SysNavTree] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ParentID] int  NULL,
    [PanelID] int  NULL,
    [Icon] nvarchar(255)  NULL,
    [OrderIndex] int  NULL,
    [Url] nvarchar(255)  NULL,
    [InnerHtml] nvarchar(255)  NULL,
    [Group] nvarchar(500)  NULL,
    [Title] nvarchar(50)  NULL
);
GO

-- Creating table 'Ad'
CREATE TABLE [dbo].[Ad] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [Title] nvarchar(200)  NULL,
    [Image] nvarchar(255)  NULL,
    [Url] nvarchar(255)  NULL,
    [height] int  NULL,
    [width] int  NULL
);
GO

-- Creating table 'AdGroup'
CREATE TABLE [dbo].[AdGroup] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [width] int  NULL,
    [height] int  NULL
);
GO

-- Creating table 'Area'
CREATE TABLE [dbo].[Area] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [ShowInIndex] bit  NULL
);
GO

-- Creating table 'ViewHistory'
CREATE TABLE [dbo].[ViewHistory] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [ModelID] int  NULL,
    [ItemID] bigint  NULL,
    [UserID] int  NULL,
    [ViewTime] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Answer'
ALTER TABLE [dbo].[Answer]
ADD CONSTRAINT [PK_Answer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Book'
ALTER TABLE [dbo].[Book]
ADD CONSTRAINT [PK_Book]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookChapter'
ALTER TABLE [dbo].[BookChapter]
ADD CONSTRAINT [PK_BookChapter]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'BookRole'
ALTER TABLE [dbo].[BookRole]
ADD CONSTRAINT [PK_BookRole]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'BookVolume'
ALTER TABLE [dbo].[BookVolume]
ADD CONSTRAINT [PK_BookVolume]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Class'
ALTER TABLE [dbo].[Class]
ADD CONSTRAINT [PK_Class]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'File'
ALTER TABLE [dbo].[File]
ADD CONSTRAINT [PK_File]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GroupRole'
ALTER TABLE [dbo].[GroupRole]
ADD CONSTRAINT [PK_GroupRole]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ImageAlbum'
ALTER TABLE [dbo].[ImageAlbum]
ADD CONSTRAINT [PK_ImageAlbum]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'Info'
ALTER TABLE [dbo].[Info]
ADD CONSTRAINT [PK_Info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InfoImage'
ALTER TABLE [dbo].[InfoImage]
ADD CONSTRAINT [PK_InfoImage]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InfoType'
ALTER TABLE [dbo].[InfoType]
ADD CONSTRAINT [PK_InfoType]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'Link'
ALTER TABLE [dbo].[Link]
ADD CONSTRAINT [PK_Link]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'MovieDrama'
ALTER TABLE [dbo].[MovieDrama]
ADD CONSTRAINT [PK_MovieDrama]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MovieDramaUrl'
ALTER TABLE [dbo].[MovieDramaUrl]
ADD CONSTRAINT [PK_MovieDramaUrl]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MovieInfo'
ALTER TABLE [dbo].[MovieInfo]
ADD CONSTRAINT [PK_MovieInfo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MovieUrl'
ALTER TABLE [dbo].[MovieUrl]
ADD CONSTRAINT [PK_MovieUrl]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MovieUrlBaidu'
ALTER TABLE [dbo].[MovieUrlBaidu]
ADD CONSTRAINT [PK_MovieUrlBaidu]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MovieUrlKuaib'
ALTER TABLE [dbo].[MovieUrlKuaib]
ADD CONSTRAINT [PK_MovieUrlKuaib]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MovieUrlMag'
ALTER TABLE [dbo].[MovieUrlMag]
ADD CONSTRAINT [PK_MovieUrlMag]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Question'
ALTER TABLE [dbo].[Question]
ADD CONSTRAINT [PK_Question]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Relpy'
ALTER TABLE [dbo].[Relpy]
ADD CONSTRAINT [PK_Relpy]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysDepartment'
ALTER TABLE [dbo].[SysDepartment]
ADD CONSTRAINT [PK_SysDepartment]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysGroup'
ALTER TABLE [dbo].[SysGroup]
ADD CONSTRAINT [PK_SysGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysKeyword'
ALTER TABLE [dbo].[SysKeyword]
ADD CONSTRAINT [PK_SysKeyword]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysModel'
ALTER TABLE [dbo].[SysModel]
ADD CONSTRAINT [PK_SysModel]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysRole'
ALTER TABLE [dbo].[SysRole]
ADD CONSTRAINT [PK_SysRole]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysUser'
ALTER TABLE [dbo].[SysUser]
ADD CONSTRAINT [PK_SysUser]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateContent'
ALTER TABLE [dbo].[TemplateContent]
ADD CONSTRAINT [PK_TemplateContent]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateFace'
ALTER TABLE [dbo].[TemplateFace]
ADD CONSTRAINT [PK_TemplateFace]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateGroup'
ALTER TABLE [dbo].[TemplateGroup]
ADD CONSTRAINT [PK_TemplateGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateList'
ALTER TABLE [dbo].[TemplateList]
ADD CONSTRAINT [PK_TemplateList]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'TemplatePage'
ALTER TABLE [dbo].[TemplatePage]
ADD CONSTRAINT [PK_TemplatePage]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'TemplatePublic'
ALTER TABLE [dbo].[TemplatePublic]
ADD CONSTRAINT [PK_TemplatePublic]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateReply'
ALTER TABLE [dbo].[TemplateReply]
ADD CONSTRAINT [PK_TemplateReply]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateSearch'
ALTER TABLE [dbo].[TemplateSearch]
ADD CONSTRAINT [PK_TemplateSearch]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplateVar'
ALTER TABLE [dbo].[TemplateVar]
ADD CONSTRAINT [PK_TemplateVar]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TemplTags'
ALTER TABLE [dbo].[TemplTags]
ADD CONSTRAINT [PK_TemplTags]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserClassRelation'
ALTER TABLE [dbo].[UserClassRelation]
ADD CONSTRAINT [PK_UserClassRelation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserForm'
ALTER TABLE [dbo].[UserForm]
ADD CONSTRAINT [PK_UserForm]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserGroup'
ALTER TABLE [dbo].[UserGroup]
ADD CONSTRAINT [PK_UserGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserRerm'
ALTER TABLE [dbo].[UserRerm]
ADD CONSTRAINT [PK_UserRerm]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Zt'
ALTER TABLE [dbo].[Zt]
ADD CONSTRAINT [PK_Zt]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobCompany'
ALTER TABLE [dbo].[JobCompany]
ADD CONSTRAINT [PK_JobCompany]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobPost'
ALTER TABLE [dbo].[JobPost]
ADD CONSTRAINT [PK_JobPost]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeCertificate'
ALTER TABLE [dbo].[JobResumeCertificate]
ADD CONSTRAINT [PK_JobResumeCertificate]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeEdu'
ALTER TABLE [dbo].[JobResumeEdu]
ADD CONSTRAINT [PK_JobResumeEdu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeExperience'
ALTER TABLE [dbo].[JobResumeExperience]
ADD CONSTRAINT [PK_JobResumeExperience]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeInfo'
ALTER TABLE [dbo].[JobResumeInfo]
ADD CONSTRAINT [PK_JobResumeInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeLanguage'
ALTER TABLE [dbo].[JobResumeLanguage]
ADD CONSTRAINT [PK_JobResumeLanguage]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeTrain'
ALTER TABLE [dbo].[JobResumeTrain]
ADD CONSTRAINT [PK_JobResumeTrain]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'JobApplicationRecord'
ALTER TABLE [dbo].[JobApplicationRecord]
ADD CONSTRAINT [PK_JobApplicationRecord]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobEduSpecialty'
ALTER TABLE [dbo].[JobEduSpecialty]
ADD CONSTRAINT [PK_JobEduSpecialty]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobIndustry'
ALTER TABLE [dbo].[JobIndustry]
ADD CONSTRAINT [PK_JobIndustry]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobType'
ALTER TABLE [dbo].[JobType]
ADD CONSTRAINT [PK_JobType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Province'
ALTER TABLE [dbo].[Province]
ADD CONSTRAINT [PK_Province]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'JobResumeFile'
ALTER TABLE [dbo].[JobResumeFile]
ADD CONSTRAINT [PK_JobResumeFile]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysNavPanel'
ALTER TABLE [dbo].[SysNavPanel]
ADD CONSTRAINT [PK_SysNavPanel]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SysNavTree'
ALTER TABLE [dbo].[SysNavTree]
ADD CONSTRAINT [PK_SysNavTree]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [PK_Ad]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AdGroup'
ALTER TABLE [dbo].[AdGroup]
ADD CONSTRAINT [PK_AdGroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Area'
ALTER TABLE [dbo].[Area]
ADD CONSTRAINT [PK_Area]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ViewHistory'
ALTER TABLE [dbo].[ViewHistory]
ADD CONSTRAINT [PK_ViewHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------