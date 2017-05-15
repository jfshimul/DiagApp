USE [DiagnosticAppDB]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 25/04/2017 6:09:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [numeric](18, 0) NOT NULL,
	[PatientName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[MobileNo] [nvarchar](33) NOT NULL,
	[BillDate] [date] NOT NULL CONSTRAINT [DF_Patients_BillDate]  DEFAULT (getdate()),
	[BillNo] [nvarchar](15) NOT NULL,
	[RecStatus] [nvarchar](1) NOT NULL CONSTRAINT [DF__TestPatie__RecSt__37A5467C]  DEFAULT ('A'),
 CONSTRAINT [PK__Patients__970EC3660A20E16A] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PatientTests]    Script Date: 25/04/2017 6:09:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientTests](
	[PatientTestId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[PatientId] [numeric](18, 0) NOT NULL,
	[TestId] [int] NOT NULL,
	[Fee] [decimal](18, 0) NULL CONSTRAINT [DF__PatientTest__Fee__440B1D61]  DEFAULT ((0)),
 CONSTRAINT [PK__PatientT__4E1498DA73B35187] PRIMARY KEY CLUSTERED 
(
	[PatientTestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tests]    Script Date: 25/04/2017 6:09:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nvarchar](100) NOT NULL,
	[Fee] [money] NULL CONSTRAINT [DF__TestSetup__Fee__173876EA]  DEFAULT ((0.0)),
	[TestTypeId] [int] NOT NULL,
 CONSTRAINT [Tests_Id_Pk] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 25/04/2017 6:09:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypes](
	[TestTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TestTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [TestType_Id_Pk] PRIMARY KEY CLUSTERED 
(
	[TestTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vwBillNo]    Script Date: 25/04/2017 6:09:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwBillNo] AS
SELECT CAST(YEAR(GETDATE()) AS VARCHAR(4))+
		RIGHT('00'+CAST(MONTH(GETDATE()) AS VARCHAR(2)),2)+
		RIGHT('00'+CAST(DAY(GETDATE()) AS VARCHAR(2)),2) +'-'+
		CAST( ISNULL( MAX(SUBSTRING(BillNo,10,4)+1),1000)AS VARCHAR(4)) as MaxBillNo FROM   Patients


GO
/****** Object:  View [dbo].[vwTests]    Script Date: 25/04/2017 6:09:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwTests] AS
SELECT        ts.TestId, ts.TestName, ts.Fee, ts.TestTypeId, t.TestTypeName
FROM            TestTypes AS t INNER JOIN
                         Tests AS ts ON t.TestTypeId = ts.TestTypeId



GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(1 AS Numeric(18, 0)), N'Md. Samiul', CAST(N'2017-04-25' AS Date), N'53453', CAST(N'2017-04-25' AS Date), N'20170425-1002', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(2 AS Numeric(18, 0)), N'Md. Mehedi Hasan', CAST(N'2017-04-25' AS Date), N'01716102262', CAST(N'2017-04-25' AS Date), N'20170425-1000', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(3 AS Numeric(18, 0)), N'Md. Mehedi Hasan', CAST(N'2017-04-26' AS Date), N'43243', CAST(N'2017-04-25' AS Date), N'', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(4 AS Numeric(18, 0)), N'Md. Mehedi Hasan', CAST(N'2017-04-24' AS Date), N'14546', CAST(N'2017-04-25' AS Date), N'', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(5 AS Numeric(18, 0)), N'Md. Mehedi Hasan', CAST(N'2017-04-24' AS Date), N'14546', CAST(N'2017-04-25' AS Date), N'', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(6 AS Numeric(18, 0)), N'Md. Mehedi Hasan', CAST(N'2017-04-24' AS Date), N'14546', CAST(N'2017-04-25' AS Date), N'', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(7 AS Numeric(18, 0)), N'Md. Mehedi Hasan', CAST(N'2017-04-24' AS Date), N'14546', CAST(N'2017-04-25' AS Date), N'', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(9 AS Numeric(18, 0)), N'Md. Samiul', CAST(N'2017-04-25' AS Date), N'53453', CAST(N'2017-04-25' AS Date), N'20170425-1001', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(10 AS Numeric(18, 0)), N'Md. Samiul', CAST(N'2017-04-25' AS Date), N'53453', CAST(N'2017-04-25' AS Date), N'20170425-1003', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(11 AS Numeric(18, 0)), N'Md. Ariful', CAST(N'2017-04-26' AS Date), N'416541351', CAST(N'2017-04-25' AS Date), N'20170425-1004', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(12 AS Numeric(18, 0)), N'Md. Ariful', CAST(N'2017-04-26' AS Date), N'416541351', CAST(N'2017-04-25' AS Date), N'20170425-1005', N'A')
GO
INSERT [dbo].[Patients] ([PatientId], [PatientName], [DateOfBirth], [MobileNo], [BillDate], [BillNo], [RecStatus]) VALUES (CAST(13 AS Numeric(18, 0)), N'Md. Samiul', CAST(N'2017-04-18' AS Date), N'432432', CAST(N'2017-04-25' AS Date), N'20170425-1006', N'A')
GO
SET IDENTITY_INSERT [dbo].[PatientTests] ON 

GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), 3, CAST(3 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), 2, CAST(200 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 3, CAST(3 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 1, CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)), 3, CAST(3 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)), 1, CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), 13, CAST(13 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), 1, CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), 13, CAST(13 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), 1, CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[PatientTests] ([PatientTestId], [PatientId], [TestId], [Fee]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), 14, CAST(14 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[PatientTests] OFF
GO
SET IDENTITY_INSERT [dbo].[Tests] ON 

GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (1, N'whole abdomen', 200.0000, 1)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (2, N'pregnancy profile', 300.0000, 1)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (3, N'Urine C/S-200', 5000.0000, 1)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (4, N'X-Ray LS Spine', 600.0000, 1)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (5, N'a', 4234.0000, 1)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (6, N'asdfs', 0.0000, 1)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (12, N'afdf', 2233.0000, 2)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (13, N'sdfsdadfsf', 100.0000, 2)
GO
INSERT [dbo].[Tests] ([TestId], [TestName], [Fee], [TestTypeId]) VALUES (14, N'dsfsd', 0.0000, 4)
GO
SET IDENTITY_INSERT [dbo].[Tests] OFF
GO
SET IDENTITY_INSERT [dbo].[TestTypes] ON 

GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName]) VALUES (1, N'Blood')
GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName]) VALUES (2, N'Urine')
GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName]) VALUES (3, N'ECG')
GO
INSERT [dbo].[TestTypes] ([TestTypeId], [TestTypeName]) VALUES (4, N'X-Ray')
GO
SET IDENTITY_INSERT [dbo].[TestTypes] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__TestSetu__2AF07A7D559F2FC7]    Script Date: 25/04/2017 6:09:36 PM ******/
ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [UQ__TestSetu__2AF07A7D559F2FC7] UNIQUE NONCLUSTERED 
(
	[TestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PatientTests]  WITH CHECK ADD  CONSTRAINT [PatientTests_PatientId_fk] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[PatientTests] CHECK CONSTRAINT [PatientTests_PatientId_fk]
GO
ALTER TABLE [dbo].[PatientTests]  WITH CHECK ADD  CONSTRAINT [PatientTests_TestId_fk] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([TestId])
GO
ALTER TABLE [dbo].[PatientTests] CHECK CONSTRAINT [PatientTests_TestId_fk]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [Tests_TestTypeId_Fk] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[TestTypes] ([TestTypeId])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [Tests_TestTypeId_Fk]
GO
