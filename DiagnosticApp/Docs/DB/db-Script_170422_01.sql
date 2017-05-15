USE [DiagnosticAppDB]
GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 22/04/2017 4:37:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypes](
	[TestTypeId] [int] NOT NULL,
	[TestTypeName] [nvarchar](100) NOT NULL,
	[IsActive] [nvarchar](1) NOT NULL DEFAULT ('A'),
 CONSTRAINT [TestType_Id_Pk] PRIMARY KEY CLUSTERED 
(
	[TestTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName], [IsActive]) VALUES (1, N'Blood', N'A')
GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName], [IsActive]) VALUES (2, N'Urine', N'A')
GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName], [IsActive]) VALUES (3, N'X-Ray', N'A')
GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName], [IsActive]) VALUES (4, N'Ultra', N'A')
GO
