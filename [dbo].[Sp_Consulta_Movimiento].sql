USE [BaseData]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Consulta_Movimiento]    Script Date: 11/07/2022 19:51:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Consulta_Movimiento] @fechaI varchar(15), @fechaf varchar(15), @identificacion varchar(15)
AS
declare @fecha1 date
declare @fecha2 date

BEGIN
set @fecha1 = COnvert(date,@fechaI);
set @fecha2 = COnvert(date,@fechaF);

	select a.fecha ,d.nombre as Cliente, b.numerocuenta as NumeroCuenta,
b.tipocuenta as Tipo,a.saldoinicial,c.estado, a.valor as Movimiento,a.saldo as SaldoDisponible 
from [dbo].[Movimientos] a
inner join [dbo].[Cuenta] b
on a.clienteid = b.cuentaid
inner join [dbo].[Cliente] c
on c.clienteid = b.clienteid
inner join [dbo].[Persona] d
on d.personaid = c.personaid
where d.identificacion = @identificacion
and Convert(date,a.fecha) between @fecha1 and @fecha2
order by a.fecha, b.tipocuenta asc
END
GO


