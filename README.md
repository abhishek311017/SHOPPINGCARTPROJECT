# SHOPPINGCARTPROJECT
Database:
CREATE TABLE [dbo].[Product](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](150) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Image] [nvarchar](600) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Price] [decimal](18, 2) NOT NULL
);

CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
));


CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
))

CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserRole_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
));

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[EmailId] [nvarchar](100) NOT NULL,
	[MobileNumber] [varchar](10) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
), CONSTRAINT [IX_User] UNIQUE NONCLUSTERED 
(
	[RoleId] ASC
));
