# HypernovaTest
Api Completa del Test...

Adjunto el Script de la Base de datos para correr la api

USE [master]
GO
/****** Object:  Database [HypernovaTest]    Script Date: 10/05/2021 12:58:00 a. m. ******/
CREATE DATABASE [HypernovaTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HypernovaTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HypernovaTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HypernovaTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HypernovaTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HypernovaTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HypernovaTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HypernovaTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HypernovaTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HypernovaTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HypernovaTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HypernovaTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [HypernovaTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HypernovaTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HypernovaTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HypernovaTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HypernovaTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HypernovaTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HypernovaTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HypernovaTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HypernovaTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HypernovaTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HypernovaTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HypernovaTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HypernovaTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HypernovaTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HypernovaTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HypernovaTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HypernovaTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HypernovaTest] SET RECOVERY FULL 
GO
ALTER DATABASE [HypernovaTest] SET  MULTI_USER 
GO
ALTER DATABASE [HypernovaTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HypernovaTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HypernovaTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HypernovaTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HypernovaTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HypernovaTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HypernovaTest', N'ON'
GO
ALTER DATABASE [HypernovaTest] SET QUERY_STORE = OFF
GO
USE [HypernovaTest]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 10/05/2021 12:58:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](50) NOT NULL,
	[Posicion] [varchar](50) NOT NULL,
	[Departamento] [varchar](50) NOT NULL,
	[Supervisor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 10/05/2021 12:58:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[Fecha] [varchar](50) NOT NULL,
	[NumeroCuenta] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Total] [float] NOT NULL,
	[AprobadoPor] [varchar](50) NOT NULL,
	[Concepto] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Pagos__FC851A3AB520E3BC] PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Empleado_Pago]    Script Date: 10/05/2021 12:58:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Empleado_Pago]
AS
SELECT dbo.Empleados.IdEmpleado AS Expr1, dbo.Empleados.NombreCompleto AS Expr2, dbo.Empleados.Posicion AS Expr3, dbo.Empleados.Departamento, dbo.Empleados.Supervisor, dbo.Pagos.IdPago, dbo.Pagos.Fecha, 
                  dbo.Pagos.NumeroCuenta, dbo.Pagos.AprobadoPor, dbo.Pagos.Descripcion, dbo.Pagos.Concepto, dbo.Pagos.Total
FROM     dbo.Empleados INNER JOIN
                  dbo.Pagos ON dbo.Empleados.IdEmpleado = dbo.Pagos.IdEmpleado
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (5, N'Elias Gabriel', N'Analista I', N'Informatica', N'Juan Torres')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (6, N'string', N'string', N'string', N'string')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (7, N'Maria Herrera', N'Secretaria', N'Compras', N'Ana Gomez')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (10, N'Ingrid Zambrano', N'Secretaria', N'Recursos Humanos', N'Lorena Garcia')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (12, N'Joel Peralta', N'Analista', N'Software', N'Mario Rivera')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (13, N'Juan', N'A', N'b', N'C')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (14, N'2', N'2', N'2', N'2')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (15, N'a', N'a', N'a', N'a')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (16, N'Jorge ', N'asd', N'aaaaa', N'asdasdasdasd')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (17, N'Jose', N'Manager', N'Logistica', N'Maria')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (18, N'Vladimir', N'A23`', N'23', N'Josias')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (19, N'Euribiades Quintero', N'Cuidador', N'Seguridad', N'Karla Perez')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (20, N'Juan', N'Doctor', N'Cirugia', N'Michael Mendoza')
GO
INSERT [dbo].[Empleados] ([IdEmpleado], [NombreCompleto], [Posicion], [Departamento], [Supervisor]) VALUES (21, N'Miranda', N'Vaquero', N'Ganaderia', N'Josefina')
GO
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Pagos] ON 
GO
INSERT [dbo].[Pagos] ([IdPago], [IdEmpleado], [Fecha], [NumeroCuenta], [Descripcion], [Total], [AprobadoPor], [Concepto]) VALUES (1, 6, N'25/12/2020', 123, N'pc', 100, N'JP', N'IMP')
GO
INSERT [dbo].[Pagos] ([IdPago], [IdEmpleado], [Fecha], [NumeroCuenta], [Descripcion], [Total], [AprobadoPor], [Concepto]) VALUES (3, 6, N'21/12/2020', 324, N'pc2', 100, N'JR', N'PSI')
GO
INSERT [dbo].[Pagos] ([IdPago], [IdEmpleado], [Fecha], [NumeroCuenta], [Descripcion], [Total], [AprobadoPor], [Concepto]) VALUES (4, 7, N'05/05/2121', 123, N'PC4', 50, N'AB', N'ASD')
GO
INSERT [dbo].[Pagos] ([IdPago], [IdEmpleado], [Fecha], [NumeroCuenta], [Descripcion], [Total], [AprobadoPor], [Concepto]) VALUES (7, 10, N'12/12/2020', 123132, N'a', 0, N'Juan', N'a')
GO
INSERT [dbo].[Pagos] ([IdPago], [IdEmpleado], [Fecha], [NumeroCuenta], [Descripcion], [Total], [AprobadoPor], [Concepto]) VALUES (8, 10, N'12/12/2020', 75, N'A', 250, N'A', N'A')
GO
SET IDENTITY_INSERT [dbo].[Pagos] OFF
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK__Pagos__IdEmplead__37A5467C] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK__Pagos__IdEmplead__37A5467C]
GO
/****** Object:  StoredProcedure [dbo].[USP_Nombre_Gasto]    Script Date: 10/05/2021 12:58:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Obtener Nombre Con Gastos y total
-- =============================================
CREATE PROCEDURE [dbo].[USP_Nombre_Gasto]
@IdEmpleado int
AS
BEGIN

	SELECT P.IdPago, E.NombreCompleto, E.Posicion, E.Departamento, E.Supervisor,
	P.Fecha, P.NumeroCuenta, P.Descripcion, P.AprobadoPor, P.Concepto, P.Total
	from Empleados E 
	Inner Join Pagos P on P.IdEmpleado = E.IdEmpleado
	where E.IdEmpleado = @IdEmpleado
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Empleados"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Pagos"
            Begin Extent = 
               Top = 7
               Left = 312
               Bottom = 170
               Right = 507
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Empleado_Pago'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Empleado_Pago'
GO
USE [master]
GO
ALTER DATABASE [HypernovaTest] SET  READ_WRITE 
GO
