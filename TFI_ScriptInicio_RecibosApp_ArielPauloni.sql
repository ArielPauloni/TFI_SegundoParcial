USE [master]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE DATABASE [TFI_RecibosApp_Pauloni]
GO
USE [TFI_RecibosApp_Pauloni]
GO
SET NOCOUNT ON
GO
/*****************************/
PRINT 'TABLAS'
GO
/*****************************/
/****** Object:  Table [dbo].[Categoria]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CodigoCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionCategoria] [varchar](100) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CodigoCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concepto](
	[CodigoConcepto] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionConcepto] [varchar](100) NULL,
	[Porcentaje] [smallint] NULL,
	[EsDescuento] [bit] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED 
(
	[CodigoConcepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Legajo] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](100) NULL,
	[Nombre] [varchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadoRecibo]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoRecibo](
	[Legajo] [int] NOT NULL,
	[CodigoRecibo] [int] NOT NULL,
 CONSTRAINT [PK_EmpleadoRecibo] PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC,
	[CodigoRecibo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadoSueldo]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoSueldo](
	[Legajo] [int] NOT NULL,
	[CodigoSueldo] [int] NOT NULL,
 CONSTRAINT [PK_EmpleadoSueldo] PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC,
	[CodigoSueldo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibo]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibo](
	[CodigoRecibo] [int] IDENTITY(1,1) NOT NULL,
	[Anio] [int] NULL,
	[Mes] [smallint] NULL,
	[FechaPago] [datetime] NULL,
	[MontoTotal] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Recibo] PRIMARY KEY CLUSTERED 
(
	[CodigoRecibo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReciboDetalle]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReciboDetalle](
	[CodigoRecibo] [int] NOT NULL,
	[CodigoConcepto] [int] NOT NULL,
	[MontoParcial] [decimal](12, 2) NULL,
	[Porcentaje] [int] NULL,
 CONSTRAINT [PK_ReciboDetalle] PRIMARY KEY CLUSTERED 
(
	[CodigoRecibo] ASC,
	[CodigoConcepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sueldo]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sueldo](
	[CodigoSueldo] [int] IDENTITY(1,1) NOT NULL,
	[SueldoBase] [decimal](12, 2) NULL,
	[Puesto] [varchar](100) NULL,
 CONSTRAINT [PK_Sueldo] PRIMARY KEY CLUSTERED 
(
	[CodigoSueldo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SueldoCategoria]    Script Date: 16/11/2021 21:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SueldoCategoria](
	[CodigoSueldo] [int] NOT NULL,
	[CodigoCategoria] [int] NOT NULL,
 CONSTRAINT [PK_SueldoCategoria] PRIMARY KEY CLUSTERED 
(
	[CodigoSueldo] ASC,
	[CodigoCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([CodigoCategoria], [DescripcionCategoria]) VALUES (1, N'Senior')
GO
INSERT [dbo].[Categoria] ([CodigoCategoria], [DescripcionCategoria]) VALUES (2, N'Semi Senior')
GO
INSERT [dbo].[Categoria] ([CodigoCategoria], [DescripcionCategoria]) VALUES (3, N'Junior')
GO
INSERT [dbo].[Categoria] ([CodigoCategoria], [DescripcionCategoria]) VALUES (4, N'Fuera de Convenio')
GO
INSERT [dbo].[Categoria] ([CodigoCategoria], [DescripcionCategoria]) VALUES (5, N'Senior Experto')
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Concepto] ON 
GO
INSERT [dbo].[Concepto] ([CodigoConcepto], [DescripcionConcepto], [Porcentaje], [EsDescuento], [Activo]) VALUES (1, N'Jubilación', 10, 1, 1)
GO
INSERT [dbo].[Concepto] ([CodigoConcepto], [DescripcionConcepto], [Porcentaje], [EsDescuento], [Activo]) VALUES (2, N'Obra social', 4, 1, 1)
GO
INSERT [dbo].[Concepto] ([CodigoConcepto], [DescripcionConcepto], [Porcentaje], [EsDescuento], [Activo]) VALUES (3, N'Sindicato', 1, 1, 1)
GO
INSERT [dbo].[Concepto] ([CodigoConcepto], [DescripcionConcepto], [Porcentaje], [EsDescuento], [Activo]) VALUES (4, N'Acuerdo Marzo 2021', 20, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Concepto] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 
GO
INSERT [dbo].[Empleado] ([Legajo], [Apellido], [Nombre], [FechaIngreso]) VALUES (1, N'Becerra', N'Juan', CAST(N'2021-04-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Empleado] ([Legajo], [Apellido], [Nombre], [FechaIngreso]) VALUES (2, N'Smith', N'Tom', CAST(N'2021-05-03T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Empleado] ([Legajo], [Apellido], [Nombre], [FechaIngreso]) VALUES (3, N'Gomez', N'Jose', CAST(N'2021-06-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Empleado] ([Legajo], [Apellido], [Nombre], [FechaIngreso]) VALUES (4, N'Ibañez', N'Pepe', CAST(N'2021-01-04T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (1, 1)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (1, 2)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (1, 3)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (1, 4)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (1, 5)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (1, 7)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (2, 8)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (2, 9)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (2, 10)
GO
INSERT [dbo].[EmpleadoRecibo] ([Legajo], [CodigoRecibo]) VALUES (2, 11)
GO
INSERT [dbo].[EmpleadoSueldo] ([Legajo], [CodigoSueldo]) VALUES (1, 1)
GO
INSERT [dbo].[EmpleadoSueldo] ([Legajo], [CodigoSueldo]) VALUES (2, 3)
GO
INSERT [dbo].[EmpleadoSueldo] ([Legajo], [CodigoSueldo]) VALUES (3, 2)
GO
INSERT [dbo].[EmpleadoSueldo] ([Legajo], [CodigoSueldo]) VALUES (4, 6)
GO
SET IDENTITY_INSERT [dbo].[Recibo] ON 
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (1, 2021, 4, CAST(N'2021-11-15T03:00:44.563' AS DateTime), CAST(105000.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (2, 2021, 5, CAST(N'2021-11-15T03:24:30.520' AS DateTime), CAST(105000.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (3, 2021, 6, CAST(N'2021-11-15T03:24:48.120' AS DateTime), CAST(105000.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (4, 2021, 7, CAST(N'2021-11-15T03:24:51.783' AS DateTime), CAST(105000.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (5, 2021, 8, CAST(N'2021-11-15T03:24:55.773' AS DateTime), CAST(105000.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (7, 2021, 9, CAST(N'2021-11-15T03:27:53.990' AS DateTime), CAST(105000.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (8, 2021, 5, CAST(N'2021-11-16T02:11:13.893' AS DateTime), CAST(68250.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (9, 2021, 6, CAST(N'2021-11-16T02:11:18.313' AS DateTime), CAST(68250.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (10, 2021, 7, CAST(N'2021-11-16T02:11:21.663' AS DateTime), CAST(68250.00 AS Decimal(12, 2)))
GO
INSERT [dbo].[Recibo] ([CodigoRecibo], [Anio], [Mes], [FechaPago], [MontoTotal]) VALUES (11, 2021, 8, CAST(N'2021-11-16T02:11:29.163' AS DateTime), CAST(68250.00 AS Decimal(12, 2)))
GO
SET IDENTITY_INSERT [dbo].[Recibo] OFF
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (1, 1, CAST(-10000.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (1, 2, CAST(-4000.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (1, 3, CAST(-1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (1, 4, CAST(20000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (2, 1, CAST(-10000.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (2, 2, CAST(-4000.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (2, 3, CAST(-1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (2, 4, CAST(20000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (3, 1, CAST(-10000.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (3, 2, CAST(-4000.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (3, 3, CAST(-1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (3, 4, CAST(20000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (4, 1, CAST(-10000.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (4, 2, CAST(-4000.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (4, 3, CAST(-1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (4, 4, CAST(20000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (5, 1, CAST(-10000.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (5, 2, CAST(-4000.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (5, 3, CAST(-1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (5, 4, CAST(20000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (7, 1, CAST(-10000.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (7, 2, CAST(-4000.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (7, 3, CAST(-1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (7, 4, CAST(20000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (8, 1, CAST(-6500.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (8, 2, CAST(-2600.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (8, 3, CAST(-650.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (8, 4, CAST(13000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (9, 1, CAST(-6500.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (9, 2, CAST(-2600.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (9, 3, CAST(-650.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (9, 4, CAST(13000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (10, 1, CAST(-6500.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (10, 2, CAST(-2600.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (10, 3, CAST(-650.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (10, 4, CAST(13000.00 AS Decimal(12, 2)), 20)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (11, 1, CAST(-6500.00 AS Decimal(12, 2)), 10)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (11, 2, CAST(-2600.00 AS Decimal(12, 2)), 4)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (11, 3, CAST(-650.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[ReciboDetalle] ([CodigoRecibo], [CodigoConcepto], [MontoParcial], [Porcentaje]) VALUES (11, 4, CAST(13000.00 AS Decimal(12, 2)), 20)
GO
SET IDENTITY_INSERT [dbo].[Sueldo] ON 
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (1, CAST(100000.00 AS Decimal(12, 2)), N'Desarrollador')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (2, CAST(80000.00 AS Decimal(12, 2)), N'Desarrollador')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (3, CAST(65000.00 AS Decimal(12, 2)), N'QA Tester')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (4, CAST(130000.00 AS Decimal(12, 2)), N'Desarrollador')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (5, CAST(70000.00 AS Decimal(12, 2)), N'Analista Funcional')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (6, CAST(90000.00 AS Decimal(12, 2)), N'Analista Funcional')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (7, CAST(120000.00 AS Decimal(12, 2)), N'Analista Funcional')
GO
INSERT [dbo].[Sueldo] ([CodigoSueldo], [SueldoBase], [Puesto]) VALUES (8, CAST(120000.00 AS Decimal(12, 2)), N'Analista Funcional')
GO
SET IDENTITY_INSERT [dbo].[Sueldo] OFF
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (1, 2)
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (2, 3)
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (3, 3)
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (4, 1)
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (5, 3)
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (6, 2)
GO
INSERT [dbo].[SueldoCategoria] ([CodigoSueldo], [CodigoCategoria]) VALUES (7, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Concepto_Descripcion]    Script Date: 16/11/2021 21:08:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Concepto_Descripcion] ON [dbo].[Concepto]
(
	[DescripcionConcepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Concepto] ADD  CONSTRAINT [DF_ConceptoActivo]  DEFAULT ((0)) FOR [Activo]
GO
ALTER TABLE [dbo].[EmpleadoRecibo]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoRecibo_Empleado] FOREIGN KEY([Legajo])
REFERENCES [dbo].[Empleado] ([Legajo])
GO
ALTER TABLE [dbo].[EmpleadoRecibo] CHECK CONSTRAINT [FK_EmpleadoRecibo_Empleado]
GO
ALTER TABLE [dbo].[EmpleadoRecibo]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoRecibo_Recibo] FOREIGN KEY([CodigoRecibo])
REFERENCES [dbo].[Recibo] ([CodigoRecibo])
GO
ALTER TABLE [dbo].[EmpleadoRecibo] CHECK CONSTRAINT [FK_EmpleadoRecibo_Recibo]
GO
ALTER TABLE [dbo].[EmpleadoSueldo]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoSueldo_Empleado] FOREIGN KEY([Legajo])
REFERENCES [dbo].[Empleado] ([Legajo])
GO
ALTER TABLE [dbo].[EmpleadoSueldo] CHECK CONSTRAINT [FK_EmpleadoSueldo_Empleado]
GO
ALTER TABLE [dbo].[EmpleadoSueldo]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoSueldo_Sueldo] FOREIGN KEY([CodigoSueldo])
REFERENCES [dbo].[Sueldo] ([CodigoSueldo])
GO
ALTER TABLE [dbo].[EmpleadoSueldo] CHECK CONSTRAINT [FK_EmpleadoSueldo_Sueldo]
GO
ALTER TABLE [dbo].[ReciboDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ReciboDetalle_Concepto] FOREIGN KEY([CodigoConcepto])
REFERENCES [dbo].[Concepto] ([CodigoConcepto])
GO
ALTER TABLE [dbo].[ReciboDetalle] CHECK CONSTRAINT [FK_ReciboDetalle_Concepto]
GO
ALTER TABLE [dbo].[ReciboDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ReciboDetalle_Recibo] FOREIGN KEY([CodigoRecibo])
REFERENCES [dbo].[Recibo] ([CodigoRecibo])
GO
ALTER TABLE [dbo].[ReciboDetalle] CHECK CONSTRAINT [FK_ReciboDetalle_Recibo]
GO
ALTER TABLE [dbo].[SueldoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_SueldoCategoria_Categoria] FOREIGN KEY([CodigoCategoria])
REFERENCES [dbo].[Categoria] ([CodigoCategoria])
GO
ALTER TABLE [dbo].[SueldoCategoria] CHECK CONSTRAINT [FK_SueldoCategoria_Categoria]
GO
ALTER TABLE [dbo].[SueldoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_SueldoCategoria_Sueldo] FOREIGN KEY([CodigoSueldo])
REFERENCES [dbo].[Sueldo] ([CodigoSueldo])
GO
ALTER TABLE [dbo].[SueldoCategoria] CHECK CONSTRAINT [FK_SueldoCategoria_Sueldo]
GO
/*****************************/
PRINT 'VISTAS'
GO
/*****************************/
/****** Object:  View [dbo].[vRecibo]    Script Date: 16/11/2021 21:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vRecibo]
AS
SELECT	r.CodigoRecibo, r.Anio, r.Mes, r.FechaPago, r.MontoTotal, 
		rd.CodigoConcepto, rd.MontoParcial, rd.Porcentaje, c.EsDescuento, 
		c.Activo, c.DescripcionConcepto
FROM	dbo.Recibo r
JOIN	dbo.ReciboDetalle rd ON r.CodigoRecibo = rd.CodigoRecibo
JOIN	dbo.Concepto c ON rd.CodigoConcepto = c.CodigoConcepto
GO
/****** Object:  View [dbo].[vSueldo]    Script Date: 16/11/2021 21:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vSueldo]
AS
SELECT	s.CodigoSueldo, s.SueldoBase, s.Puesto, c.CodigoCategoria, c.DescripcionCategoria
FROM	dbo.Sueldo s
JOIN	dbo.SueldoCategoria sc ON s.CodigoSueldo = sc.CodigoSueldo
JOIN	dbo.Categoria c ON sc.CodigoCategoria = c.CodigoCategoria
GO
/*****************************/
PRINT 'PROCEDIMIENTOS'
GO
/*****************************/
/****** Object:  StoredProcedure [dbo].[pr_Actualizar_Categoria]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Actualizar_Categoria]
@CodigoCategoria INT,
@DescripcionCategoria VARCHAR(100)
AS
UPDATE dbo.Categoria 
SET  DescripcionCategoria = @DescripcionCategoria
WHERE CodigoCategoria = @CodigoCategoria
GO
/****** Object:  StoredProcedure [dbo].[pr_Actualizar_Concepto]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Actualizar_Concepto]
@CodigoConcepto INT,
@DescripcionConcepto VARCHAR(100),
@Porcentaje SMALLINT,
@EsDescuento VARCHAR(100),
@Activo BIT
AS
UPDATE dbo.Concepto 
SET  DescripcionConcepto = @DescripcionConcepto,  
	 Porcentaje = @Porcentaje, 
	 EsDescuento = @EsDescuento,
	 Activo = @Activo
WHERE CodigoConcepto = @CodigoConcepto
GO
/****** Object:  StoredProcedure [dbo].[pr_Actualizar_Empleado]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Actualizar_Empleado]
@Legajo INT,
@Apellido VARCHAR(100),
@Nombre VARCHAR(100),
@FechaIngreso DATETIME,
@CodigoSueldo INT
AS
UPDATE dbo.Empleado 
SET  Apellido = @Apellido,  Nombre = @Nombre, FechaIngreso = @FechaIngreso
WHERE Legajo = @Legajo

UPDATE dbo.EmpleadoSueldo SET CodigoSueldo = @CodigoSueldo WHERE Legajo = @Legajo
GO
/****** Object:  StoredProcedure [dbo].[pr_Actualizar_Sueldo]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Actualizar_Sueldo]
@CodigoSueldo INT,
@CodigoCategoria INT,
@SueldoBase DECIMAL(12,2),
@Puesto VARCHAR(100)
AS
UPDATE dbo.Sueldo 
SET  SueldoBase = @SueldoBase, Puesto = @Puesto
WHERE CodigoSueldo = @CodigoSueldo

UPDATE dbo.SueldoCategoria SET CodigoCategoria = @CodigoCategoria WHERE CodigoSueldo = @CodigoSueldo
GO
/****** Object:  StoredProcedure [dbo].[pr_Eliminar_Recibo]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Eliminar_Recibo]
@CodigoRecibo INT
AS

DELETE FROM ReciboDetalle WHERE CodigoRecibo = @CodigoRecibo
DELETE FROM EmpleadoRecibo WHERE CodigoRecibo = @CodigoRecibo
DELETE FROM Recibo WHERE CodigoRecibo = @CodigoRecibo
GO
/****** Object:  StoredProcedure [dbo].[pr_Insertar_Categoria]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Insertar_Categoria]
@DescripcionCategoria VARCHAR(100)
AS

INSERT INTO dbo.Categoria(DescripcionCategoria) 
VALUES (@DescripcionCategoria)
GO
/****** Object:  StoredProcedure [dbo].[pr_Insertar_Concepto]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Insertar_Concepto]
@DescripcionConcepto VARCHAR(100),
@Porcentaje SMALLINT,
@EsDescuento VARCHAR(100)
AS

INSERT INTO dbo.Concepto(DescripcionConcepto, Porcentaje, EsDescuento, Activo) 
VALUES (@DescripcionConcepto, @Porcentaje, @EsDescuento, 1)
GO
/****** Object:  StoredProcedure [dbo].[pr_Insertar_Empleado]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Insertar_Empleado]
@Apellido VARCHAR(100),
@Nombre VARCHAR(100),
@FechaIngreso DATETIME,
@CodigoSueldo INT
AS

INSERT INTO dbo.Empleado(Apellido, Nombre, FechaIngreso) 
VALUES (@Apellido, @Nombre, @FechaIngreso)

INSERT INTO dbo.EmpleadoSueldo(Legajo, CodigoSueldo)
VALUES (IDENT_CURRENT('Empleado'), @CodigoSueldo)
GO
/****** Object:  StoredProcedure [dbo].[pr_Insertar_Recibo]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Insertar_Recibo]
@Anio INT,
@Mes SMALLINT,
@MontoTotal DECIMAL(12,2),
@Legajo INT
AS

IF NOT EXISTS (SELECT 1 
			   FROM Recibo r 
				JOIN EmpleadoRecibo er ON r.CodigoRecibo = er.CodigoRecibo
			   WHERE r.Anio = @Anio AND r.Mes = @Mes AND er.Legajo = @Legajo)
BEGIN
	INSERT INTO dbo.Recibo(Anio, Mes, FechaPago, MontoTotal) 
	VALUES (@Anio, @Mes, GETDATE(), @MontoTotal)

	INSERT INTO dbo.EmpleadoRecibo(Legajo, CodigoRecibo)
	VALUES (@Legajo, IDENT_CURRENT('Recibo'))

	SELECT IDENT_CURRENT('Recibo') AS CodigoRecibo
END
GO
/****** Object:  StoredProcedure [dbo].[pr_Insertar_ReciboDetalle]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Insertar_ReciboDetalle]
@CodigoRecibo INT,
@CodigoConcepto INT,
@MontoParcial DECIMAL(12,2),
@Porcentaje INT
AS

INSERT INTO dbo.ReciboDetalle(CodigoRecibo, CodigoConcepto, MontoParcial, Porcentaje) 
VALUES (@CodigoRecibo, @CodigoConcepto, @MontoParcial, @Porcentaje)
GO
/****** Object:  StoredProcedure [dbo].[pr_Insertar_Sueldo]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Insertar_Sueldo]
@CodigoCategoria VARCHAR(100),
@SueldoBase DECIMAL(12,2),
@Puesto VARCHAR(100)
AS

INSERT INTO dbo.Sueldo(SueldoBase, Puesto) VALUES (@SueldoBase, @Puesto)
INSERT INTO dbo.SueldoCategoria(CodigoSueldo, CodigoCategoria) 
VALUES (IDENT_CURRENT('Sueldo'),@CodigoCategoria)
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_Categorias]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_Categorias]
AS
SELECT CodigoCategoria, DescripcionCategoria
FROM dbo.Categoria
ORDER BY DescripcionCategoria ASC
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_Conceptos]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_Conceptos]
AS
SELECT CodigoConcepto, DescripcionConcepto, Porcentaje, EsDescuento, Activo
FROM dbo.Concepto
ORDER BY DescripcionConcepto ASC
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_Empleados]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_Empleados]
AS
SELECT e.Legajo, e.Apellido, e.Nombre, e.FechaIngreso, s.CodigoSueldo,
	   s.SueldoBase, s.Puesto,  s.CodigoCategoria, s.DescripcionCategoria
FROM dbo.Empleado e
JOIN dbo.EmpleadoSueldo es ON e.Legajo = es.Legajo
JOIN dbo.vSueldo s ON es.CodigoSueldo = s.CodigoSueldo
ORDER BY e.Legajo ASC
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_EmpleadosRecibos]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_EmpleadosRecibos]
AS

SELECT e.Legajo, e.Apellido, e.Nombre, e.FechaIngreso, s.CodigoSueldo, s.SueldoBase, 
	   s.Puesto, s.CodigoCategoria,s.DescripcionCategoria, r.CodigoRecibo, r.Anio, 
	   r.Mes, r.FechaPago, r.MontoTotal
FROM Empleado e
JOIN EmpleadoSueldo es ON e.Legajo = es.Legajo
JOIN vSueldo s ON es.CodigoSueldo = s.CodigoSueldo
JOIN EmpleadoRecibo er ON e.Legajo = er.Legajo
JOIN Recibo r ON er.CodigoRecibo = r.CodigoRecibo
ORDER BY e.Legajo ASC, r.Anio ASC, r.Mes ASC
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_Recibo]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_Recibo]
@CodigoRecibo INT
AS

SELECT e.Legajo, e.Apellido, e.Nombre, e.FechaIngreso, s.CodigoSueldo, s.SueldoBase, 
	   s.Puesto, s.CodigoCategoria,s.DescripcionCategoria, r.CodigoRecibo, r.Anio, 
	   r.Mes, r.FechaPago, r.MontoTotal
FROM Empleado e
JOIN EmpleadoSueldo es ON e.Legajo = es.Legajo
JOIN vSueldo s ON es.CodigoSueldo = s.CodigoSueldo
JOIN EmpleadoRecibo er ON e.Legajo = er.Legajo
JOIN Recibo r ON er.CodigoRecibo = r.CodigoRecibo
WHERE r.CodigoRecibo = @CodigoRecibo
ORDER BY e.Legajo ASC, r.Anio ASC, r.Mes ASC
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_ReciboDetalles]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_ReciboDetalles]
@CodigoRecibo INT
AS

SELECT r.MontoParcial, r.Porcentaje, r.CodigoConcepto, r.DescripcionConcepto, r.EsDescuento,
	   r.Activo 
FROM vRecibo r
WHERE r.CodigoRecibo = @CodigoRecibo
GO
/****** Object:  StoredProcedure [dbo].[pr_Listar_Sueldos]    Script Date: 16/11/2021 21:10:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_Listar_Sueldos]
AS
SELECT s.CodigoSueldo, c.CodigoCategoria, c.DescripcionCategoria, SueldoBase, Puesto
FROM dbo.Sueldo s
JOIN dbo.SueldoCategoria sc ON s.CodigoSueldo = sc.CodigoSueldo
JOIN dbo.Categoria c ON sc.CodigoCategoria = c.CodigoCategoria
ORDER BY DescripcionCategoria ASC, Puesto ASC
GO
/*******************/
PRINT 'FINAL SCRIPT'
GO
/*******************/