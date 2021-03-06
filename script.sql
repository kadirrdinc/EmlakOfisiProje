USE [master]
GO
/****** Object:  Database [EmlakOfisiDb]    Script Date: 13.12.2020 14:03:56 ******/
CREATE DATABASE [EmlakOfisiDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmlakOfisiDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmlakOfisiDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmlakOfisiDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmlakOfisiDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmlakOfisiDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmlakOfisiDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmlakOfisiDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmlakOfisiDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmlakOfisiDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmlakOfisiDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmlakOfisiDb] SET  MULTI_USER 
GO
ALTER DATABASE [EmlakOfisiDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmlakOfisiDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmlakOfisiDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmlakOfisiDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmlakOfisiDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmlakOfisiDb] SET QUERY_STORE = OFF
GO
USE [EmlakOfisiDb]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 13.12.2020 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 13.12.2020 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Agent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 13.12.2020 14:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[StatusType] [nvarchar](50) NOT NULL,
	[HouseType] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[SquareMeter] [int] NOT NULL,
	[NumberOfRooms] [nvarchar](10) NOT NULL,
	[HouseAge] [int] NOT NULL,
	[IsFurnished] [bit] NOT NULL,
	[AgentId] [int] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminUser] ON 

INSERT [dbo].[AdminUser] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsActive], [FirstName], [LastName], [UserName], [Password], [Role]) VALUES (11, CAST(N'2020-12-13T12:56:31.650' AS DateTime), N'admin', CAST(N'2020-12-13T12:56:31.650' AS DateTime), N'admin', 0, N'Admin Bey', N'Admin', N'admin', N'123456', N'Admin')
SET IDENTITY_INSERT [dbo].[AdminUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Agent] ON 

INSERT [dbo].[Agent] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsActive], [FirstName], [LastName], [UserName], [Password], [CompanyName], [Role]) VALUES (6, CAST(N'2020-12-13T13:55:03.103' AS DateTime), N'admin', CAST(N'2020-12-13T13:57:11.110' AS DateTime), N'emlakci', 1, N'Emlakçı Bey', N'Emlak', N'emlakci', N'123456', N'EMLAK A.Ş', N'Agent')
SET IDENTITY_INSERT [dbo].[Agent] OFF
GO
SET IDENTITY_INSERT [dbo].[Notice] ON 

INSERT [dbo].[Notice] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsActive], [StatusType], [HouseType], [Address], [Price], [SquareMeter], [NumberOfRooms], [HouseAge], [IsFurnished], [AgentId], [Description]) VALUES (5, CAST(N'2020-12-13T13:56:43.807' AS DateTime), N'emlakci', CAST(N'2020-12-13T13:56:43.807' AS DateTime), N'emlakci', 1, N'Satılık', N'Villa', N'Sakarya / Karasu / Aziziye Mah.', CAST(585000 AS Decimal(18, 0)), 160, N'3+1', 5, 0, 6, N'KARASU ARSLAN İNŞAAT MÜSTAKİL BAHÇELİ 3+1 TRİPLEKS VİLLA')
SET IDENTITY_INSERT [dbo].[Notice] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_UserName]    Script Date: 13.12.2020 14:03:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UN_UserName] ON [dbo].[Agent]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notice]  WITH CHECK ADD  CONSTRAINT [FK_Notice_Agent] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agent] ([Id])
GO
ALTER TABLE [dbo].[Notice] CHECK CONSTRAINT [FK_Notice_Agent]
GO
USE [master]
GO
ALTER DATABASE [EmlakOfisiDb] SET  READ_WRITE 
GO
