USE [master]
GO
/****** Object:  Database [DataModeling]    Script Date: 22.8.2014 г. 0:18:42 ******/
CREATE DATABASE [DataModeling]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModeling', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLTRIAL\MSSQL\DATA\DataModeling.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModeling_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLTRIAL\MSSQL\DATA\DataModeling_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataModeling] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataModeling].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataModeling] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataModeling] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataModeling] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataModeling] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataModeling] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataModeling] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataModeling] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataModeling] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataModeling] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataModeling] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataModeling] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataModeling] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataModeling] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataModeling] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataModeling] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataModeling] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataModeling] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataModeling] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataModeling] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataModeling] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataModeling] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataModeling] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataModeling] SET RECOVERY FULL 
GO
ALTER DATABASE [DataModeling] SET  MULTI_USER 
GO
ALTER DATABASE [DataModeling] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataModeling] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataModeling] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataModeling] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DataModeling] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataModeling', N'ON'
GO
USE [DataModeling]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 22.8.2014 г. 0:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [ntext] NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 22.8.2014 г. 0:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 22.8.2014 г. 0:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 22.8.2014 г. 0:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 22.8.2014 г. 0:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (2, N'5th Avenue', 6)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (3, N'Broadway', 6)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Africa')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Antarctica')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Asia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (4, N'Australia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (5, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (6, N'North America')
INSERT [dbo].[Continent] ([id], [name]) VALUES (7, N'South America')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'China', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'India', 3)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'United States', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (4, N'Brazil', 7)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (5, N'Nigeria', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (6, N'Germany', 5)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (7, N'Australia', 4)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Gosho', N'Otpochivkov', 2)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Penka', N'Menkova', 3)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Beijing', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Shanghai', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'New Delhi', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (4, N'Mumbai', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (5, N'Washington, D.C.', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (6, N'New York City', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (7, N'Brasília', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (8, N'Sao Paulo City', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (9, N'Abuja', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (10, N'Lagos', 5)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (11, N'Berlin', 6)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (12, N'Cologne', 6)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (13, N'Canberra', 7)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (14, N'Sydney', 7)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [DataModeling] SET  READ_WRITE 
GO
