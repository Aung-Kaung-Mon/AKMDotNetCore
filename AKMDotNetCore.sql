USE [master]
GO
/****** Object:  Database [AKMDotNetCore]    Script Date: 5/1/2024 10:48:06 PM ******/
CREATE DATABASE [AKMDotNetCore] ON  PRIMARY 
( NAME = N'AKMDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AKMDotNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AKMDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AKMDotNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AKMDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AKMDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AKMDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AKMDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AKMDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AKMDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AKMDotNetCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AKMDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [AKMDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AKMDotNetCore] SET DB_CHAINING OFF 
GO
USE [AKMDotNetCore]
GO
/****** Object:  Table [dbo].[Tbl_Blogs]    Script Date: 5/1/2024 10:48:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blogs](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogArthur] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blogs] ON 

INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (1, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (2, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (3, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (4, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (5, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (6, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (7, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (8, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (9, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (10, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (11, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (12, N'Test Title', N'Test Arthur', N'Test Content')
INSERT [dbo].[Tbl_Blogs] ([BlogID], [BlogTitle], [BlogArthur], [BlogContent]) VALUES (13, N'title', N'author name', N'content')
SET IDENTITY_INSERT [dbo].[Tbl_Blogs] OFF
GO
USE [master]
GO
ALTER DATABASE [AKMDotNetCore] SET  READ_WRITE 
GO
