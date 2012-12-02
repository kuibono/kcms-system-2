



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 12/02/2012 19:41:37
-- Generated from EDMX file: E:\代码\KCMS2\trunk\Voodoo.Basement\Data.edmx
-- Target version: 1.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `Ad`;
    DROP TABLE IF EXISTS `AdGroup`;
    DROP TABLE IF EXISTS `Answer`;
    DROP TABLE IF EXISTS `Area`;
    DROP TABLE IF EXISTS `Book`;
    DROP TABLE IF EXISTS `BookChapter`;
    DROP TABLE IF EXISTS `BookRole`;
    DROP TABLE IF EXISTS `BookVolume`;
    DROP TABLE IF EXISTS `City`;
    DROP TABLE IF EXISTS `Class`;
    DROP TABLE IF EXISTS `File`;
    DROP TABLE IF EXISTS `GroupRole`;
    DROP TABLE IF EXISTS `ImageAlbum`;
    DROP TABLE IF EXISTS `Images`;
    DROP TABLE IF EXISTS `Info`;
    DROP TABLE IF EXISTS `InfoImage`;
    DROP TABLE IF EXISTS `InfoType`;
    DROP TABLE IF EXISTS `JobApplicationRecord`;
    DROP TABLE IF EXISTS `JobCompany`;
    DROP TABLE IF EXISTS `JobEduSpecialty`;
    DROP TABLE IF EXISTS `JobIndustry`;
    DROP TABLE IF EXISTS `JobPost`;
    DROP TABLE IF EXISTS `JobResumeCertificate`;
    DROP TABLE IF EXISTS `JobResumeEdu`;
    DROP TABLE IF EXISTS `JobResumeExperience`;
    DROP TABLE IF EXISTS `JobResumeFile`;
    DROP TABLE IF EXISTS `JobResumeInfo`;
    DROP TABLE IF EXISTS `JobResumeLanguage`;
    DROP TABLE IF EXISTS `JobResumeTrain`;
    DROP TABLE IF EXISTS `JobType`;
    DROP TABLE IF EXISTS `Link`;
    DROP TABLE IF EXISTS `Message`;
    DROP TABLE IF EXISTS `MovieDrama`;
    DROP TABLE IF EXISTS `MovieDramaUrl`;
    DROP TABLE IF EXISTS `MovieInfo`;
    DROP TABLE IF EXISTS `MovieUrl`;
    DROP TABLE IF EXISTS `MovieUrlBaidu`;
    DROP TABLE IF EXISTS `MovieUrlKuaib`;
    DROP TABLE IF EXISTS `MovieUrlMag`;
    DROP TABLE IF EXISTS `News`;
    DROP TABLE IF EXISTS `Product`;
    DROP TABLE IF EXISTS `Province`;
    DROP TABLE IF EXISTS `Question`;
    DROP TABLE IF EXISTS `Relpy`;
    DROP TABLE IF EXISTS `SysDepartment`;
    DROP TABLE IF EXISTS `SysGroup`;
    DROP TABLE IF EXISTS `SysKeyword`;
    DROP TABLE IF EXISTS `SysModel`;
    DROP TABLE IF EXISTS `SysNavPanel`;
    DROP TABLE IF EXISTS `SysNavTree`;
    DROP TABLE IF EXISTS `SysRole`;
    DROP TABLE IF EXISTS `SysUser`;
    DROP TABLE IF EXISTS `TemplateContent`;
    DROP TABLE IF EXISTS `TemplateFace`;
    DROP TABLE IF EXISTS `TemplateGroup`;
    DROP TABLE IF EXISTS `TemplateList`;
    DROP TABLE IF EXISTS `TemplatePage`;
    DROP TABLE IF EXISTS `TemplatePublic`;
    DROP TABLE IF EXISTS `TemplateReply`;
    DROP TABLE IF EXISTS `TemplateSearch`;
    DROP TABLE IF EXISTS `TemplateVar`;
    DROP TABLE IF EXISTS `TemplTags`;
    DROP TABLE IF EXISTS `User`;
    DROP TABLE IF EXISTS `UserClassRelation`;
    DROP TABLE IF EXISTS `UserForm`;
    DROP TABLE IF EXISTS `UserGroup`;
    DROP TABLE IF EXISTS `UserRegorm`;
    DROP TABLE IF EXISTS `UserRerm`;
    DROP TABLE IF EXISTS `ViewHistory`;
    DROP TABLE IF EXISTS `Zt`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Ad'

CREATE TABLE `Ad` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `Title` nchar(200)  NULL,
    `Image` nchar(255)  NULL,
    `Url` nchar(255)  NULL,
    `height` int  NULL,
    `width` int  NULL
);

-- Creating table 'AdGroup'

CREATE TABLE `AdGroup` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` nchar(50)  NULL,
    `width` int  NULL,
    `height` int  NULL
);

-- Creating table 'Answer'

CREATE TABLE `Answer` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `QuestionID` int  NULL,
    `Content` nvarchar(65535)  NULL,
    `UserID` int  NULL,
    `UserName` nchar(50)  NULL,
    `AnswerTime` datetime  NULL,
    `Agree` int  NULL
);

-- Creating table 'Area'

CREATE TABLE `Area` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` nchar(50)  NULL,
    `ShowInIndex` bool  NULL
);

-- Creating table 'Book'

CREATE TABLE `Book` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NOT NULL,
    `ClassName` nchar(50)  NULL,
    `ZtID` int  NULL,
    `ZtName` nchar(50)  NULL,
    `Title` nchar(100)  NULL,
    `Author` nchar(100)  NULL,
    `Intro` nvarchar(65535)  NULL,
    `Length` bigint  NULL,
    `ReplyCount` bigint  NULL,
    `ClickCount` bigint  NULL,
    `Addtime` datetime  NULL,
    `Status` tinyint  NULL,
    `IsVip` bool  NULL,
    `FaceImage` nchar(100)  NULL,
    `SaveCount` bigint  NULL,
    `Enable` bool  NULL,
    `IsFirstPost` bool  NULL,
    `LastChapterID` bigint  NULL,
    `LastChapterTitle` nchar(100)  NULL,
    `UpdateTime` datetime  NULL,
    `LastVipChapterID` bigint  NULL,
    `LastVipChapterTitle` nchar(100)  NULL,
    `VipUpdateTime` datetime  NULL,
    `CorpusID` int  NULL,
    `CorpusTitle` nchar(200)  NULL,
    `TjCount` int  NULL
);

-- Creating table 'BookChapter'

CREATE TABLE `BookChapter` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `BookID` int  NOT NULL,
    `BookTitle` nchar(200)  NULL,
    `ClassID` bigint  NOT NULL,
    `ClassName` nchar(100)  NULL,
    `ValumeID` bigint  NOT NULL,
    `ValumeName` nchar(100)  NULL,
    `Title` nchar(200)  NULL,
    `IsVipChapter` bool  NULL,
    `TextLength` int  NULL,
    `UpdateTime` datetime  NOT NULL,
    `Enable` bool  NULL,
    `IsTemp` bool  NULL,
    `IsFree` bool  NULL,
    `ChapterIndex` int  NOT NULL,
    `IsImageChapter` bool  NULL,
    `Content` nvarchar(65535)  NULL,
    `ClickCount` int  NULL,
    `TxtPath` nvarchar(500)  NULL
);

-- Creating table 'BookRole'

CREATE TABLE `BookRole` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `BookID` int  NULL,
    `RoleName` nchar(50)  NULL,
    `Intro` nvarchar(2000)  NULL
);

-- Creating table 'BookVolume'

CREATE TABLE `BookVolume` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `BookID` int  NOT NULL,
    `booktitle` nchar(100)  NULL,
    `booknclass` nchar(50)  NULL
);

-- Creating table 'City'

CREATE TABLE `City` (
    `id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `state` nchar(30)  NOT NULL,
    `city1` nchar(30)  NOT NULL,
    `sz_code` nchar(6)  NOT NULL,
    `Rome` nchar(50)  NULL,
    `zm_code` nchar(50)  NULL,
    `ProvinceID` int  NULL,
    `Hot` bigint  NULL,
    `ShowInIndex` bool  NULL,
    `ShowInNav` bool  NULL
);

-- Creating table 'Class'

CREATE TABLE `Class` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassName` nchar(50)  NULL,
    `Alter` nchar(50)  NULL,
    `ParentID` int  NULL,
    `IsLeafClass` bool  NULL,
    `ParentClassForder` nchar(50)  NULL,
    `ClassForder` nchar(50)  NULL,
    `ModelID` int  NULL,
    `ClassKeywords` nchar(255)  NULL,
    `ClassDescription` nvarchar(512)  NULL,
    `ClassICON` nchar(255)  NULL,
    `ShowInNav` bool  NULL,
    `NavIndex` int  NULL,
    `VisitRole` nvarchar(512)  NULL,
    `EnablePost` bool  NULL,
    `EnableVCode` bool  NULL,
    `PostRoles` nvarchar(512)  NULL,
    `PostcreateList` int  NULL,
    `PostAddCent` int  NULL,
    `NeedAudit` bool  NULL,
    `PostManagement` int  NULL,
    `EditcreateList` int  NULL,
    `EnableSameTitle` bool  NULL,
    `AutoAudt` bool  NULL,
    `EnableReply` bool  NULL,
    `ReplyNeedAudit` bool  NULL,
    `ListModel` int  NULL,
    `ContentModel` int  NULL,
    `ReplyModel` int  NULL,
    `SearchModel` int  NULL,
    `ClassPageMode` int  NULL,
    `ContentPageMode` int  NULL,
    `ManagementOrder` nvarchar(512)  NULL,
    `ListPageOrder` nvarchar(512)  NULL,
    `ClassPageExtName` nchar(50)  NULL,
    `ListPageSize` int  NULL,
    `ContentPageForder` nvarchar(512)  NULL,
    `ContentPageExtName` nchar(50)  NULL,
    `ContentPageNameMode` int  NULL,
    `ContentPageDirMode` nchar(50)  NULL,
    `ImageWidth` int  NULL,
    `ImageHeight` int  NULL,
    `ManagementUrl` nchar(255)  NULL,
    `ListTemplateID` int  NULL,
    `ContentTemplateID` int  NULL
);

-- Creating table 'File'

CREATE TABLE `File` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NULL,
    `UpTime` datetime  NULL,
    `FileType` int  NULL,
    `FileSize` bigint  NULL,
    `FileDirectory` nchar(255)  NULL,
    `FileName` nchar(255)  NULL,
    `FileExtName` nchar(255)  NULL,
    `FilePath` nvarchar(500)  NULL,
    `SmallPath` nvarchar(500)  NULL
);

-- Creating table 'GroupRole'

CREATE TABLE `GroupRole` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserID` int  NULL,
    `RoleID` int  NULL
);

-- Creating table 'ImageAlbum'

CREATE TABLE `ImageAlbum` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NULL,
    `ZtID` int  NULL,
    `AuthorID` int  NULL,
    `Author` nchar(50)  NULL,
    `Title` nchar(255)  NULL,
    `CreateTime` datetime  NULL,
    `UpdateTime` datetime  NULL,
    `Intro` nvarchar(500)  NULL,
    `Size` int  NULL,
    `Folder` nchar(255)  NULL,
    `ClickCount` int  NULL,
    `ReplyCount` int  NULL,
    `SetTop` bool  NULL,
    `ShotCut` nchar(255)  NULL,
    `KeyWords` nchar(255)  NULL
);

-- Creating table 'Images'

CREATE TABLE `Images` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `AlbumID` int  NULL,
    `Title` nchar(255)  NULL,
    `Intro` nvarchar(500)  NULL,
    `UploadTime` datetime  NULL,
    `ClickCount` int  NULL,
    `ReplyCount` int  NULL,
    `FilePath` nchar(255)  NULL,
    `SmallPath` nchar(255)  NULL,
    `FileSize` int  NULL,
    `ExtName` nchar(50)  NULL
);

-- Creating table 'Info'

CREATE TABLE `Info` (
    `id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `InfoTypeID` nchar(50)  NULL,
    `ClassID` int  NULL,
    `ClassName` nchar(50)  NULL,
    `ZtID` int  NULL,
    `ZtName` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `UserName` nchar(50)  NULL,
    `UserID` int  NULL,
    `Contact` nchar(50)  NULL,
    `ContactType` nchar(50)  NULL,
    `Tel` nchar(50)  NULL,
    `TelLocation` nchar(50)  NULL,
    `Address` nchar(255)  NULL,
    `Intro` nvarchar(1000)  NULL,
    `ImageCount` int  NULL,
    `ReplyCount` int  NULL,
    `ClickCount` int  NULL,
    `IsSetTop` bool  NULL,
    `OutTime` datetime  NULL,
    `PostTime` datetime  NULL,
    `num1` int  NULL,
    `num2` int  NULL,
    `num3` int  NULL,
    `num4` int  NULL,
    `num5` int  NULL,
    `num6` int  NULL,
    `num7` int  NULL,
    `num8` int  NULL,
    `num9` int  NULL,
    `num10` int  NULL,
    `nvarchar1` nchar(255)  NULL,
    `nvarchar2` nchar(255)  NULL,
    `nvarchar3` nchar(255)  NULL,
    `nvarchar4` nchar(255)  NULL,
    `nvarchar5` nchar(255)  NULL,
    `nvarchar6` nchar(255)  NULL,
    `nvarchar7` nchar(255)  NULL,
    `nvarchar8` nchar(255)  NULL,
    `nvarchar9` nchar(255)  NULL,
    `nvarchar10` nchar(255)  NULL,
    `nvarchar11` nchar(50)  NULL,
    `nvarchar12` nchar(50)  NULL,
    `nvarchar13` nchar(50)  NULL,
    `nvarchar14` nchar(50)  NULL,
    `nvarchar15` nchar(50)  NULL,
    `decimal1` decimal(18,2)  NULL,
    `decimal2` decimal(18,2)  NULL,
    `decimal3` decimal(18,2)  NULL,
    `decimal4` decimal(18,2)  NULL,
    `decimal5` decimal(18,2)  NULL,
    `text1` nvarchar(1000)  NULL,
    `text2` nvarchar(1000)  NULL,
    `text3` nvarchar(1000)  NULL,
    `text4` nvarchar(1000)  NULL,
    `text5` nvarchar(1000)  NULL,
    `bit1` bool  NULL,
    `bit2` bool  NULL,
    `bit3` bool  NULL,
    `bit4` bool  NULL,
    `bit5` bool  NULL
);

-- Creating table 'InfoImage'

CREATE TABLE `InfoImage` (
    `id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ModelID` int  NULL,
    `InfoID` int  NULL,
    `Title` nchar(255)  NULL,
    `Url` nvarchar(500)  NULL
);

-- Creating table 'InfoType'

CREATE TABLE `InfoType` (
    `id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `TypeName` nchar(50)  NULL,
    `TemplateIndex` varchar(65535)  NULL,
    `TemplateList` varchar(65535)  NULL,
    `TemlateAdminForm` varchar(65535)  NULL,
    `TemplateForm` varchar(65535)  NULL,
    `TemplateContent` varchar(65535)  NULL,
    `num1` nchar(50)  NULL,
    `num2` nchar(50)  NULL,
    `num3` nchar(50)  NULL,
    `num4` nchar(50)  NULL,
    `num5` nchar(50)  NULL,
    `num6` nchar(50)  NULL,
    `num7` nchar(50)  NULL,
    `num8` nchar(50)  NULL,
    `num9` nchar(50)  NULL,
    `num10` nchar(50)  NULL,
    `nvarchar1` nchar(50)  NULL,
    `nvarchar2` nchar(50)  NULL,
    `nvarchar3` nchar(50)  NULL,
    `nvarchar4` nchar(50)  NULL,
    `nvarchar5` nchar(50)  NULL,
    `nvarchar6` nchar(50)  NULL,
    `nvarchar7` nchar(50)  NULL,
    `nvarchar8` nchar(50)  NULL,
    `nvarchar9` nchar(50)  NULL,
    `nvarchar10` nchar(50)  NULL,
    `nvarchar11` nchar(50)  NULL,
    `nvarchar12` nchar(50)  NULL,
    `nvarchar13` nchar(50)  NULL,
    `nvarchar14` nchar(50)  NULL,
    `nvarchar15` nchar(50)  NULL,
    `decimal1` nchar(50)  NULL,
    `decimal2` nchar(50)  NULL,
    `decimal3` nchar(50)  NULL,
    `decimal4` nchar(50)  NULL,
    `decimal5` nchar(50)  NULL,
    `text1` nchar(50)  NULL,
    `text2` nchar(50)  NULL,
    `text3` nchar(50)  NULL,
    `text4` nchar(50)  NULL,
    `text5` nchar(50)  NULL,
    `bit1` nchar(50)  NULL,
    `bit2` nchar(50)  NULL,
    `bit3` nchar(50)  NULL,
    `bit4` nchar(50)  NULL,
    `bit5` nchar(50)  NULL
);

-- Creating table 'JobApplicationRecord'

CREATE TABLE `JobApplicationRecord` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserID` int  NULL,
    `ResumeID` bigint  NULL,
    `PostID` bigint  NULL,
    `CompanyID` int  NULL,
    `Message` nvarchar(65535)  NULL,
    `ApplicationTime` datetime  NULL,
    `Status` int  NULL
);

-- Creating table 'JobCompany'

CREATE TABLE `JobCompany` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `CompanyName` nchar(100)  NULL,
    `Industry` nvarchar(500)  NULL,
    `CompanyType` int  NULL,
    `EmployeeCount` int  NULL,
    `Intro` nvarchar(65535)  NULL,
    `UserID` int  NULL,
    `DayClick` int  NULL,
    `IsSetTop` bool  NULL,
    `SetTopTime` datetime  NULL
);

-- Creating table 'JobEduSpecialty'

CREATE TABLE `JobEduSpecialty` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` nchar(50)  NULL,
    `ParentID` bigint  NULL
);

-- Creating table 'JobIndustry'

CREATE TABLE `JobIndustry` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` nchar(100)  NULL,
    `ParentID` int  NULL,
    `IsLeaf` bool  NULL,
    `Hot` int  NULL
);

-- Creating table 'JobPost'

CREATE TABLE `JobPost` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `CompanyID` int  NULL,
    `Title` nchar(200)  NULL,
    `Province` int  NULL,
    `City` int  NULL,
    `Industry` int  NULL,
    `Salary` int  NULL,
    `PostTime` datetime  NULL,
    `Expressions` int  NULL,
    `Edu` int  NULL,
    `EmployNumber` int  NULL,
    `Intro` nvarchar(65535)  NULL,
    `IsSetTop` bool  NULL,
    `SetTopTime` datetime  NULL,
    `Ext1` nvarchar(65535)  NULL,
    `ExpireTime` datetime  NULL
);

-- Creating table 'JobResumeCertificate'

CREATE TABLE `JobResumeCertificate` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ResumeID` bigint  NULL,
    `CertificateName` nchar(50)  NULL,
    `GetTime` datetime  NULL,
    `Intro` nvarchar(65535)  NULL
);

-- Creating table 'JobResumeEdu'

CREATE TABLE `JobResumeEdu` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ResumeID` bigint  NULL,
    `SchoolName` nchar(50)  NULL,
    `StartTime` datetime  NULL,
    `LeftTime` datetime  NULL,
    `Edu` int  NULL,
    `Specialty` int  NULL,
    `Intro` nvarchar(65535)  NULL
);

-- Creating table 'JobResumeExperience'

CREATE TABLE `JobResumeExperience` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ResumeID` bigint  NULL,
    `CompanyName` nchar(200)  NULL,
    `StartTime` datetime  NULL,
    `LeftTime` datetime  NULL,
    `Post` int  NULL,
    `Intro` nvarchar(65535)  NULL
);

-- Creating table 'JobResumeFile'

CREATE TABLE `JobResumeFile` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserID` int  NULL,
    `ResumeID` bigint  NULL,
    `FileName` nchar(50)  NULL,
    `FilePath` nchar(255)  NULL
);

-- Creating table 'JobResumeInfo'

CREATE TABLE `JobResumeInfo` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserID` int  NULL,
    `Title` nchar(200)  NULL,
    `Birthday` datetime  NULL,
    `IsMale` bool  NULL,
    `Province` int  NULL,
    `City` int  NULL,
    `Mobile` nchar(50)  NULL,
    `Email` nchar(50)  NULL,
    `WorkPlace` int  NULL,
    `IsResumeOpen` bool  NULL,
    `Address` nvarchar(500)  NULL,
    `Tel` nchar(50)  NULL,
    `Image` nchar(255)  NULL,
    `Country` nchar(50)  NULL,
    `CardType` int  NULL,
    `CardNumber` nchar(100)  NULL,
    `HomeCity` int  NULL,
    `Marriage` int  NULL,
    `Nation` nchar(50)  NULL,
    `Political` int  NULL,
    `QQ` nchar(50)  NULL,
    `MSN` nchar(255)  NULL,
    `Intro` nvarchar(65535)  NULL,
    `ChineseName` nchar(50)  NULL
);

-- Creating table 'JobResumeLanguage'

CREATE TABLE `JobResumeLanguage` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ResumeID` bigint  NULL,
    `LanguageType` int  NULL,
    `SpeakingAbility` int  NULL,
    `WritingAbility` int  NULL
);

-- Creating table 'JobResumeTrain'

CREATE TABLE `JobResumeTrain` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ResumeID` bigint  NULL,
    `Title` nchar(200)  NULL,
    `StartTime` datetime  NULL,
    `LeftTime` datetime  NULL,
    `OrganizationName` nchar(200)  NULL,
    `CertificateName` nchar(200)  NULL,
    `Intro` nvarchar(65535)  NULL
);

-- Creating table 'JobType'

CREATE TABLE `JobType` (
    `ID` int  NOT NULL,
    `Name` nchar(50)  NULL,
    `IndustryID` int  NULL
);

-- Creating table 'Link'

CREATE TABLE `Link` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `LinkTitle` nchar(100)  NULL,
    `Url` nchar(255)  NULL,
    `Index` int  NULL
);

-- Creating table 'MovieDrama'

CREATE TABLE `MovieDrama` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MovieID` int  NULL,
    `MovieTitle` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `UpdateTime` datetime  NULL,
    `Enable` bool  NULL
);

-- Creating table 'MovieDramaUrl'

CREATE TABLE `MovieDramaUrl` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MovieID` int  NULL,
    `MovieTitle` nchar(50)  NULL,
    `MovieDramaID` bigint  NULL,
    `MovieDramaTitle` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `UpdateTime` datetime  NULL,
    `Enable` bool  NULL,
    `Url` nvarchar(500)  NULL,
    `SourceSite` nchar(50)  NULL
);

-- Creating table 'MovieInfo'

CREATE TABLE `MovieInfo` (
    `id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NULL,
    `ClassName` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `Director` nchar(50)  NULL,
    `Actors` nvarchar(500)  NULL,
    `Tags` nchar(50)  NULL,
    `Location` nchar(50)  NULL,
    `PublicYear` nchar(50)  NULL,
    `Intro` nvarchar(4000)  NULL,
    `IsMove` bool  NULL,
    `FaceImage` nvarchar(500)  NULL,
    `InsertTime` datetime  NULL,
    `LastDramaTitle` nvarchar(500)  NULL,
    `LastDramaID` bigint  NULL,
    `UpdateTime` datetime  NULL,
    `Status` int  NULL,
    `Enable` bool  NULL,
    `ReplyCount` bigint  NULL,
    `TjCount` bigint  NULL,
    `ScoreAvg` decimal(18,0)  NULL,
    `ScoreTime` bigint  NULL,
    `Info` nvarchar(65535)  NULL,
    `ClickCount` bigint  NULL,
    `MonthClick` bigint  NULL,
    `WeekClick` bigint  NULL,
    `DayClick` bigint  NULL,
    `LastClickTime` datetime  NULL,
    `StandardTitle` nchar(50)  NULL
);

-- Creating table 'MovieUrl'

CREATE TABLE `MovieUrl` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MoviewID` int  NULL,
    `MoviewTitle` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `UpdateTime` datetime  NULL,
    `Enable` bool  NULL,
    `HttpUrl` nvarchar(1000)  NULL,
    `MagUrl` nvarchar(1000)  NULL,
    `KuaibUrl` nvarchar(1000)  NULL,
    `BaiduUrl` nvarchar(1000)  NULL
);

-- Creating table 'MovieUrlBaidu'

CREATE TABLE `MovieUrlBaidu` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MovieID` int  NULL,
    `MovieTitle` nchar(255)  NULL,
    `Title` nchar(255)  NULL,
    `UpdateTime` datetime  NULL,
    `Enable` bool  NULL,
    `Url` nvarchar(500)  NULL
);

-- Creating table 'MovieUrlKuaib'

CREATE TABLE `MovieUrlKuaib` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MovieID` int  NULL,
    `MovieTitle` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `UpdateTime` datetime  NULL,
    `Enable` bool  NULL,
    `Url` nvarchar(500)  NULL
);

-- Creating table 'MovieUrlMag'

CREATE TABLE `MovieUrlMag` (
    `id` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MovieID` int  NULL,
    `MovieTitle` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `UpdateTime` datetime  NULL,
    `Enable` bool  NULL,
    `Url` nvarchar(500)  NULL
);

-- Creating table 'News'

CREATE TABLE `News` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `NewsTime` datetime  NULL,
    `Title` nchar(100)  NULL,
    `TitleB` bool  NULL,
    `TitleI` bool  NULL,
    `TitleS` bool  NULL,
    `TitleColor` nchar(50)  NULL,
    `FTitle` nchar(100)  NULL,
    `Audit` bool  NULL,
    `Tuijian` bool  NULL,
    `Toutiao` bool  NULL,
    `KeyWords` nchar(200)  NULL,
    `NavUrl` nchar(255)  NULL,
    `TitleImage` nchar(255)  NULL,
    `Description` nvarchar(512)  NULL,
    `Author` nchar(50)  NULL,
    `AutorID` int  NULL,
    `ContentEn` nvarchar(65535)  NULL,
    `Content` nvarchar(65535)  NULL,
    `SetTop` bool  NULL,
    `ModelID` int  NULL,
    `ClickCount` int  NULL,
    `DownCount` int  NULL,
    `FileForder` nchar(50)  NULL,
    `FileName` nchar(50)  NULL,
    `ZtID` int  NULL,
    `ClassID` int  NULL,
    `ReplyCount` int  NULL,
    `Source` nchar(50)  NULL,
    `EnableReply` bool  NULL
);

-- Creating table 'Province'

CREATE TABLE `Province` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `province1` nchar(30)  NOT NULL,
    `sz_code` nchar(6)  NOT NULL,
    `Rome` nchar(50)  NULL,
    `zm_code` nchar(50)  NULL,
    `AreaID` int  NULL,
    `ShowInIndex` bool  NULL
);

-- Creating table 'Question'

CREATE TABLE `Question` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NULL,
    `ZtID` int  NULL,
    `Title` nchar(255)  NULL,
    `Content` nvarchar(65535)  NULL,
    `UserID` int  NULL,
    `UserName` nchar(50)  NULL,
    `AskTime` datetime  NULL,
    `ClickCount` int  NULL
);

-- Creating table 'Relpy'

CREATE TABLE `Relpy` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ModelID` int  NULL,
    `NewsID` int  NULL,
    `UserID` int  NULL,
    `UserName` nchar(50)  NULL,
    `IP` nchar(50)  NULL,
    `ReplyTime` datetime  NULL,
    `Content` nvarchar(65535)  NULL
);

-- Creating table 'SysDepartment'

CREATE TABLE `SysDepartment` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `DepartName` nchar(50)  NULL
);

-- Creating table 'SysGroup'

CREATE TABLE `SysGroup` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupName` nchar(50)  NULL
);

-- Creating table 'SysKeyword'

CREATE TABLE `SysKeyword` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Keyword` nchar(50)  NULL,
    `ModelID` int  NULL,
    `ClickCount` int  NULL
);

-- Creating table 'SysModel'

CREATE TABLE `SysModel` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ModelName` nchar(50)  NULL,
    `TableName` nchar(50)  NULL,
    `SonClass` nchar(255)  NULL
);

-- Creating table 'SysNavPanel'

CREATE TABLE `SysNavPanel` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Title` nchar(50)  NULL,
    `Icon` nchar(255)  NULL,
    `OrderIndex` int  NULL,
    `Group` nvarchar(500)  NULL
);

-- Creating table 'SysNavTree'

CREATE TABLE `SysNavTree` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ParentID` int  NULL,
    `PanelID` int  NULL,
    `Icon` nchar(255)  NULL,
    `Title` nchar(50)  NULL,
    `OrderIndex` int  NULL,
    `Url` nchar(255)  NULL,
    `InnerHtml` nchar(255)  NULL,
    `Group` nvarchar(500)  NULL
);

-- Creating table 'SysRole'

CREATE TABLE `SysRole` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `RoleName` nchar(50)  NULL,
    `RoleGroup` int  NULL,
    `URL` nchar(255)  NULL,
    `AddRole` bool  NULL,
    `EditRole` bool  NULL,
    `DelRole` bool  NULL
);

-- Creating table 'SysUser'

CREATE TABLE `SysUser` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserName` nchar(50)  NULL,
    `UserPass` nchar(50)  NULL,
    `Logincount` bigint  NULL,
    `LastLoginTime` datetime  NULL,
    `LastLoginIP` nchar(50)  NULL,
    `SafeQuestion` nchar(50)  NULL,
    `SafeAnswer` nchar(50)  NULL,
    `Department` int  NULL,
    `ChineseName` nchar(50)  NULL,
    `UserGroup` int  NULL,
    `Email` nchar(50)  NULL,
    `TelNumber` nchar(50)  NULL,
    `Enabled` bool  NULL
);

-- Creating table 'TemplateContent'

CREATE TABLE `TemplateContent` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `SysModel` int  NULL,
    `TempName` nchar(50)  NULL,
    `TimeFormat` nchar(50)  NULL,
    `Content` nvarchar(65535)  NULL
);

-- Creating table 'TemplateFace'

CREATE TABLE `TemplateFace` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `Content` nvarchar(65535)  NULL
);

-- Creating table 'TemplateGroup'

CREATE TABLE `TemplateGroup` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupName` nchar(50)  NULL,
    `IsDefault` bool  NULL
);

-- Creating table 'TemplateList'

CREATE TABLE `TemplateList` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `TempName` nchar(50)  NULL,
    `SysModel` int  NULL,
    `CutKeywords` int  NULL,
    `CutTitle` int  NULL,
    `ShowRecordCount` int  NULL,
    `TimeFormat` nchar(50)  NULL,
    `Content` nvarchar(65535)  NULL,
    `ListVar` nvarchar(65535)  NULL
);

-- Creating table 'TemplatePage'

CREATE TABLE `TemplatePage` (
    `id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Enable` bool  NULL,
    `PageName` nvarchar(500)  NULL,
    `FileName` nchar(255)  NULL,
    `Content` nvarchar(65535)  NULL,
    `CreateWith` int  NULL,
    `TempVar` nvarchar(65535)  NULL
);

-- Creating table 'TemplatePublic'

CREATE TABLE `TemplatePublic` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `IndexContent` nvarchar(65535)  NULL,
    `Controlcontent` nvarchar(65535)  NULL,
    `SiteSearchContent` nvarchar(65535)  NULL,
    `AdvancedSearch` nvarchar(65535)  NULL,
    `HorizontaSearch` nvarchar(65535)  NULL,
    `VerticalSearch` nvarchar(65535)  NULL,
    `RelationInfo` nvarchar(65535)  NULL,
    `MessageBoard` nvarchar(65535)  NULL,
    `Reply` nvarchar(65535)  NULL,
    `FinalDown` nvarchar(65535)  NULL,
    `DownAddress` nvarchar(65535)  NULL,
    `OLPlayaddress` nvarchar(65535)  NULL,
    `ListPager` nvarchar(65535)  NULL,
    `LoginStatus` nvarchar(65535)  NULL,
    `JSLogin` nvarchar(65535)  NULL,
    `ImageList` nvarchar(65535)  NULL,
    `AnswerList` nvarchar(65535)  NULL,
    `ChapterList` nvarchar(65535)  NULL,
    `BookChapter` nvarchar(65535)  NULL,
    `KuaiboPage` nvarchar(65535)  NULL,
    `BaiduPage` nvarchar(65535)  NULL,
    `SingleDrama` nvarchar(65535)  NULL,
    `BookIndex` nvarchar(65535)  NULL,
    `NewIndex` nvarchar(65535)  NULL,
    `ImageIndex` nvarchar(65535)  NULL,
    `QuestionIndex` nvarchar(65535)  NULL,
    `JobIndex` nvarchar(65535)  NULL,
    `MovieIndex` nvarchar(65535)  NULL
);

-- Creating table 'TemplateReply'

CREATE TABLE `TemplateReply` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `Content` nvarchar(65535)  NULL
);

-- Creating table 'TemplateSearch'

CREATE TABLE `TemplateSearch` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `TempName` nchar(50)  NULL,
    `SysModel` int  NULL,
    `CutKeywords` int  NULL,
    `CutTitle` int  NULL,
    `ShowRecordCount` int  NULL,
    `TimeFormat` nchar(50)  NULL,
    `Content` nvarchar(65535)  NULL,
    `ListVar` nvarchar(65535)  NULL
);

-- Creating table 'TemplateVar'

CREATE TABLE `TemplateVar` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupID` int  NULL,
    `VarName` nchar(50)  NULL,
    `Content` nvarchar(65535)  NULL,
    `IsPublic` bool  NULL
);

-- Creating table 'TemplTags'

CREATE TABLE `TemplTags` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `TagName` nchar(50)  NULL,
    `TagCode` nchar(50)  NULL,
    `FunctionName` nchar(255)  NULL,
    `TagFormat` nchar(255)  NULL,
    `Remark` nvarchar(65535)  NULL,
    `Enable` bool  NULL,
    `TagIndex` int  NULL
);

-- Creating table 'User'

CREATE TABLE `User` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserName` nchar(50)  NULL,
    `UserPass` nchar(50)  NULL,
    `Email` nchar(255)  NULL,
    `ChineseName` nchar(50)  NULL,
    `QQ` nchar(50)  NULL,
    `MSN` nchar(50)  NULL,
    `Tel` nchar(50)  NULL,
    `Mobile` nchar(50)  NULL,
    `WebSite` nchar(255)  NULL,
    `Image` nchar(255)  NULL,
    `Address` nchar(255)  NULL,
    `ZipCode` nchar(50)  NULL,
    `Intro` nvarchar(512)  NULL,
    `RegTime` datetime  NULL,
    `RegIP` nchar(50)  NULL,
    `LoginCount` int  NULL,
    `LastLoginTime` datetime  NULL,
    `LastLoginIP` nchar(50)  NULL,
    `Cent` int  NULL,
    `PostCount` int  NULL,
    `GTalk` nchar(255)  NULL,
    `Twitter` nchar(255)  NULL,
    `weibo` nchar(255)  NULL,
    `ICQ` nchar(255)  NULL,
    `Group` int  NULL,
    `Enable` bool  NULL,
    `StudentNo` nchar(50)  NULL,
    `TeachNo` nchar(50)  NULL
);

-- Creating table 'UserClassRelation'

CREATE TABLE `UserClassRelation` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserID` int  NULL,
    `ClassID` int  NULL
);

-- Creating table 'UserForm'

CREATE TABLE `UserForm` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `FormName` nchar(100)  NULL,
    `Content` nvarchar(65535)  NULL
);

-- Creating table 'UserGroup'

CREATE TABLE `UserGroup` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `GroupName` nchar(50)  NULL,
    `Grade` int  NULL,
    `MaxPost` int  NULL,
    `PostAotuAudit` bool  NULL,
    `RegForm` int  NULL,
    `EnableReg` bool  NULL,
    `RegAutoAudit` bool  NULL
);

-- Creating table 'UserRegorm'

CREATE TABLE `UserRegorm` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `FormName` char(50)  NULL,
    `FormContent` varchar(4000)  NULL,
    `Remark` varchar(2000)  NULL
);

-- Creating table 'UserRerm'

CREATE TABLE `UserRerm` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `FormName` nchar(50)  NULL,
    `FormContent` nvarchar(65535)  NULL,
    `Remark` nvarchar(65535)  NULL
);

-- Creating table 'ViewHistory'

CREATE TABLE `ViewHistory` (
    `ID` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ModelID` int  NULL,
    `ItemID` bigint  NULL,
    `UserID` int  NULL,
    `ViewTime` datetime  NULL
);

-- Creating table 'Zt'

CREATE TABLE `Zt` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NULL,
    `ZtName` nchar(50)  NULL,
    `Forder` nchar(255)  NULL,
    `ExtName` nchar(50)  NULL,
    `ICON` nchar(255)  NULL,
    `KeyWords` nchar(255)  NULL,
    `Description` nchar(255)  NULL,
    `LtIndex` int  NULL,
    `ShowInNav` bool  NULL,
    `FaceModel` int  NULL,
    `ListModel` int  NULL,
    `ListOrder` int  NULL,
    `ListPageSize` int  NULL
);

-- Creating table 'Product'

CREATE TABLE `Product` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `ClassID` int  NULL,
    `ClassName` nchar(50)  NULL,
    `Name` nchar(255)  NULL,
    `Specification` nchar(255)  NULL,
    `Units` nchar(50)  NULL,
    `Price` decimal(18,2)  NULL,
    `ProduceLocation` nchar(255)  NULL,
    `FaceImage` nvarchar(500)  NULL,
    `Contact` nchar(50)  NULL,
    `Tel` nvarchar(500)  NULL,
    `Intro` nvarchar(65535)  NULL,
    `AddTime` datetime  NULL,
    `Enable` bool  NULL,
    `SetTop` bool  NULL,
    `ClickCount` int  NULL,
    `OrderIndex` int  NULL
);

-- Creating table 'Message'

CREATE TABLE `Message` (
    `ID` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `MessageTime` datetime  NULL,
    `UserName` nchar(50)  NULL,
    `Email` nchar(50)  NULL,
    `Tel` nchar(50)  NULL,
    `Title` nchar(50)  NULL,
    `Chat` nchar(50)  NULL,
    `Content` nvarchar(65535)  NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on `ID` in table 'JobType'

ALTER TABLE `JobType`
ADD CONSTRAINT `PK_JobType`
    PRIMARY KEY (`ID` );



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
