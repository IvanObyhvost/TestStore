USE [master]
GO
/****** Object:  Database [TestStore.mdf]    Script Date: 15.01.2016 11:45:35 ******/
CREATE DATABASE [TestStore.mdf]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestStore.mdf', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TestStore.mdf.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestStore.mdf_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TestStore.mdf_log.ldf' , SIZE = 3520KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestStore.mdf] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestStore.mdf].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestStore.mdf] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestStore.mdf] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestStore.mdf] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestStore.mdf] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestStore.mdf] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestStore.mdf] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TestStore.mdf] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestStore.mdf] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestStore.mdf] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestStore.mdf] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestStore.mdf] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestStore.mdf] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestStore.mdf] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestStore.mdf] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestStore.mdf] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestStore.mdf] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestStore.mdf] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestStore.mdf] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestStore.mdf] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestStore.mdf] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestStore.mdf] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestStore.mdf] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TestStore.mdf] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestStore.mdf] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestStore.mdf] SET  MULTI_USER 
GO
ALTER DATABASE [TestStore.mdf] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestStore.mdf] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestStore.mdf] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestStore.mdf] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TestStore.mdf]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 15.01.2016 11:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameCompany] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Descriptions]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descriptions](
	[Id] [int] NOT NULL,
	[RealEstateId] [int] NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[LongDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Descriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[FistName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonRoles]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[RolesId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PersonRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhotoForGalleries]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoForGalleries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RealEstateId] [int] NOT NULL,
	[UrlImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PhotoForGalleries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RealEstatePersonCompanies]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RealEstatePersonCompanies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RealEstateId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RealEstatePersonCompanies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RealEstates]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RealEstates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RealEstateID] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Postcode] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Area] [nvarchar](max) NULL,
	[SSTC] [bit] NOT NULL,
	[Bedrooms] [tinyint] NOT NULL,
	[LivingRooms] [tinyint] NOT NULL,
	[Bathrooms] [tinyint] NOT NULL,
	[Shower] [tinyint] NOT NULL,
	[Garden] [bit] NOT NULL,
	[Parking] [bit] NOT NULL,
	[SalesCorner] [nvarchar](max) NULL,
	[Tenure] [nvarchar](max) NULL,
	[PropertyStatus] [nvarchar](max) NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[LongDescription] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[ImageMimeType] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.RealEstates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 15.01.2016 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Id]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[Descriptions]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonId]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_PersonId] ON [dbo].[PersonRoles]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolesId]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_RolesId] ON [dbo].[PersonRoles]
(
	[RolesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RealEstateId]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_RealEstateId] ON [dbo].[PhotoForGalleries]
(
	[RealEstateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyId]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyId] ON [dbo].[RealEstatePersonCompanies]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonId]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_PersonId] ON [dbo].[RealEstatePersonCompanies]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RealEstateId]    Script Date: 15.01.2016 11:45:37 ******/
CREATE NONCLUSTERED INDEX [IX_RealEstateId] ON [dbo].[RealEstatePersonCompanies]
(
	[RealEstateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Descriptions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Descriptions_dbo.RealEstates_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[RealEstates] ([Id])
GO
ALTER TABLE [dbo].[Descriptions] CHECK CONSTRAINT [FK_dbo.Descriptions_dbo.RealEstates_Id]
GO
ALTER TABLE [dbo].[PersonRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PersonRoles_dbo.People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonRoles] CHECK CONSTRAINT [FK_dbo.PersonRoles_dbo.People_PersonId]
GO
ALTER TABLE [dbo].[PersonRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PersonRoles_dbo.Roles_RolesId] FOREIGN KEY([RolesId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonRoles] CHECK CONSTRAINT [FK_dbo.PersonRoles_dbo.Roles_RolesId]
GO
ALTER TABLE [dbo].[PhotoForGalleries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhotoForGalleries_dbo.RealEstates_RealEstateId] FOREIGN KEY([RealEstateId])
REFERENCES [dbo].[RealEstates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhotoForGalleries] CHECK CONSTRAINT [FK_dbo.PhotoForGalleries_dbo.RealEstates_RealEstateId]
GO
ALTER TABLE [dbo].[RealEstatePersonCompanies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RealEstatePersonCompanies_dbo.Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RealEstatePersonCompanies] CHECK CONSTRAINT [FK_dbo.RealEstatePersonCompanies_dbo.Companies_CompanyId]
GO
ALTER TABLE [dbo].[RealEstatePersonCompanies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RealEstatePersonCompanies_dbo.People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RealEstatePersonCompanies] CHECK CONSTRAINT [FK_dbo.RealEstatePersonCompanies_dbo.People_PersonId]
GO
ALTER TABLE [dbo].[RealEstatePersonCompanies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RealEstatePersonCompanies_dbo.RealEstates_RealEstateId] FOREIGN KEY([RealEstateId])
REFERENCES [dbo].[RealEstates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RealEstatePersonCompanies] CHECK CONSTRAINT [FK_dbo.RealEstatePersonCompanies_dbo.RealEstates_RealEstateId]
GO
USE [master]
GO
ALTER DATABASE [TestStore.mdf] SET  READ_WRITE 
GO
