USE [master]
GO
/****** Object:  Database [BaseDatosObligatorio]    Script Date: 14/6/2023 20:43:38 ******/
CREATE DATABASE [BaseDatosObligatorio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDatosObligatorio', FILENAME = N'D:\SQLserver\MSSQL16.MSSQLSERVER\MSSQL\DATA\BaseDatosObligatorio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaseDatosObligatorio_log', FILENAME = N'D:\SQLserver\MSSQL16.MSSQLSERVER\MSSQL\DATA\BaseDatosObligatorio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BaseDatosObligatorio] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDatosObligatorio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDatosObligatorio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDatosObligatorio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDatosObligatorio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseDatosObligatorio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDatosObligatorio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET RECOVERY FULL 
GO
ALTER DATABASE [BaseDatosObligatorio] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDatosObligatorio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDatosObligatorio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDatosObligatorio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDatosObligatorio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaseDatosObligatorio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BaseDatosObligatorio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BaseDatosObligatorio', N'ON'
GO
ALTER DATABASE [BaseDatosObligatorio] SET QUERY_STORE = ON
GO
ALTER DATABASE [BaseDatosObligatorio] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BaseDatosObligatorio]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Figures]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Figures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[radius] [float] NOT NULL,
	[clientId] [int] NOT NULL,
 CONSTRAINT [PK_Figures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[Color] [int] NOT NULL,
	[clientId] [int] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[blurred] [float] NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[figureId] [int] NOT NULL,
	[materialId] [int] NOT NULL,
	[clientId] [int] NOT NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionedModels]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionedModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[modelId] [int] NOT NULL,
	[position] [nvarchar](max) NOT NULL,
	[sceneId] [int] NOT NULL,
 CONSTRAINT [PK_PositionedModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scenes]    Script Date: 14/6/2023 20:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
	[lastRendered] [datetime2](7) NOT NULL,
	[created] [datetime2](7) NOT NULL,
	[lookFrom] [nvarchar](max) NOT NULL,
	[lookAt] [nvarchar](max) NOT NULL,
	[fieldOfView] [int] NOT NULL,
	[aperture] [float] NOT NULL,
	[clientId] [int] NOT NULL,
 CONSTRAINT [PK_Scenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Figures_clientId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_Figures_clientId] ON [dbo].[Figures]
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Materials_clientId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_Materials_clientId] ON [dbo].[Materials]
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Models_clientId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_Models_clientId] ON [dbo].[Models]
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Models_figureId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_Models_figureId] ON [dbo].[Models]
(
	[figureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Models_materialId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_Models_materialId] ON [dbo].[Models]
(
	[materialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionedModels_modelId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_PositionedModels_modelId] ON [dbo].[PositionedModels]
(
	[modelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionedModels_sceneId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_PositionedModels_sceneId] ON [dbo].[PositionedModels]
(
	[sceneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Scenes_clientId]    Script Date: 14/6/2023 20:43:38 ******/
CREATE NONCLUSTERED INDEX [IX_Scenes_clientId] ON [dbo].[Scenes]
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Figures]  WITH CHECK ADD  CONSTRAINT [FK_Figures_Clients_clientId] FOREIGN KEY([clientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Figures] CHECK CONSTRAINT [FK_Figures_Clients_clientId]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Clients_clientId] FOREIGN KEY([clientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_Clients_clientId]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Clients_clientId] FOREIGN KEY([clientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Clients_clientId]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Figures_figureId] FOREIGN KEY([figureId])
REFERENCES [dbo].[Figures] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Figures_figureId]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Materials_materialId] FOREIGN KEY([materialId])
REFERENCES [dbo].[Materials] ([Id])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Materials_materialId]
GO
ALTER TABLE [dbo].[PositionedModels]  WITH CHECK ADD  CONSTRAINT [FK_PositionedModels_Models_modelId] FOREIGN KEY([modelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[PositionedModels] CHECK CONSTRAINT [FK_PositionedModels_Models_modelId]
GO
ALTER TABLE [dbo].[PositionedModels]  WITH CHECK ADD  CONSTRAINT [FK_PositionedModels_Scenes_sceneId] FOREIGN KEY([sceneId])
REFERENCES [dbo].[Scenes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PositionedModels] CHECK CONSTRAINT [FK_PositionedModels_Scenes_sceneId]
GO
ALTER TABLE [dbo].[Scenes]  WITH CHECK ADD  CONSTRAINT [FK_Scenes_Clients_clientId] FOREIGN KEY([clientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scenes] CHECK CONSTRAINT [FK_Scenes_Clients_clientId]
GO
USE [master]
GO
ALTER DATABASE [BaseDatosObligatorio] SET  READ_WRITE 
GO
