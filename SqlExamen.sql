/*Creacion de Base de datos*/
USE [master]
GO

/****** Object:  Database [examen_t]    Script Date: 03/11/2021 11:52:58 a. m. ******/
CREATE DATABASE [examen_t]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'examen_t', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\examen_t.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'examen_t_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\examen_t_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [examen_t].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [examen_t] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [examen_t] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [examen_t] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [examen_t] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [examen_t] SET ARITHABORT OFF 
GO

ALTER DATABASE [examen_t] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [examen_t] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [examen_t] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [examen_t] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [examen_t] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [examen_t] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [examen_t] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [examen_t] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [examen_t] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [examen_t] SET  DISABLE_BROKER 
GO

ALTER DATABASE [examen_t] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [examen_t] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [examen_t] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [examen_t] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [examen_t] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [examen_t] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [examen_t] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [examen_t] SET RECOVERY FULL 
GO

ALTER DATABASE [examen_t] SET  MULTI_USER 
GO

ALTER DATABASE [examen_t] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [examen_t] SET DB_CHAINING OFF 
GO

ALTER DATABASE [examen_t] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [examen_t] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [examen_t] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [examen_t] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [examen_t] SET QUERY_STORE = OFF
GO

ALTER DATABASE [examen_t] SET  READ_WRITE 
GO

/*Creacion de tablas*/


USE [examen_t]
GO

/****** Object:  Table [dbo].[Cuentas]    Script Date: 03/11/2021 11:49:04 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cuentas](
	[cuenta_id] [bigint] IDENTITY(1,1) NOT NULL,
	[cuenta_usuarioId] [bigint] NOT NULL,
	[cuenta_saldo] [numeric](13, 2) NOT NULL,
	[cuenta_descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[cuenta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [examen_t]
GO

/****** Object:  Table [dbo].[Historial]    Script Date: 03/11/2021 11:53:30 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Historial](
	[historial_id] [bigint] IDENTITY(1,1) NOT NULL,
	[cuenta_id] [bigint] NOT NULL,
	[usuario_id] [bigint] NOT NULL,
	[fecha_transaccion] [datetime] NOT NULL,
	[monto_trasaccion] [numeric](13, 2) NOT NULL,
	[descripcion_movimiento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[historial_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Cuentas] FOREIGN KEY([cuenta_id])
REFERENCES [dbo].[Cuentas] ([cuenta_id])
GO

ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Cuentas]
GO

ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Usuarios] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuarios] ([usuario_id])
GO

ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Usuarios]
GO


USE [examen_t]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 03/11/2021 11:53:46 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[usuario_id] [bigint] IDENTITY(1,1) NOT NULL,
	[usuario_nombre] [varchar](50) NOT NULL,
	[usuario_password] [varchar](50) NOT NULL,
	[usuario_fechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/*Creacion de SP*/

USE [examen_t]
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarCuenta]    Script Date: 03/11/2021 11:54:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_ActualizarCuenta]
@idCuenta bigint,
@idUsuario bigint,
@monto numeric(13,2)
as
begin
Update Cuentas
set cuenta_saldo = @monto
where cuenta_usuarioId = @idUsuario and cuenta_id = @idCuenta
end


USE [examen_t]
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultaCuentas]    Script Date: 03/11/2021 11:54:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_ConsultaCuentas]
@id_usuario bigint
as
begin
select * from Cuentas where cuenta_usuarioId = @id_usuario
end


USE [examen_t]
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarCuentaPorId]    Script Date: 03/11/2021 11:57:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_ConsultarCuentaPorId]
@id_cuenta bigint,
@id_Usuario bigint
as
begin
Select * from Cuentas where cuenta_id = @id_cuenta and cuenta_usuarioId = @id_usuario
end


USE [examen_t]
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarHistorialPorUsuario]    Script Date: 03/11/2021 11:57:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_ConsultarHistorialPorUsuario]
@idUsuario bigint
as
begin
select * from Historial where usuario_id = @idUsuario
end


USE [examen_t]
GO
/****** Object:  StoredProcedure [dbo].[SP_ConsultarUsuario]    Script Date: 03/11/2021 11:57:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_ConsultarUsuario]
@nombreUsuario varchar(50)
as
begin
select * from Usuarios where usuario_nombre = @nombreUsuario
end


USE [examen_t]
GO
/****** Object:  StoredProcedure [dbo].[SP_IngresarHistorial]    Script Date: 03/11/2021 11:58:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_IngresarHistorial]
@cuentaid bigint,
@usuarioid bigint,
@monto numeric(13,2),
@movimiento varchar(50)
as 
begin
insert into Historial(cuenta_id,usuario_id,fecha_transaccion,monto_trasaccion,descripcion_movimiento) values(@cuentaid,@usuarioid,GETDATE(),@monto,@movimiento)
end





