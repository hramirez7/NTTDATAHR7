USE [BaseData]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Realizar_Movimientos]    Script Date: 11/07/2022 19:52:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Realizar_Movimientos] (@identificaccion varchar(15),@TipoCuenta varchar(10), @movimientoValor decimal(15,2),@tipoMovimiento varchar(1) ) 
AS
declare @estado1 bit
declare @estado2 bit
declare @cuentaid int
declare @saldoInicial decimal(15,2)
declare @saldo decimal(15,2)
declare @cuenta varchar(10);
declare @tipoMovimiento1 varchar(15);
BEGIN
	select @estado1 = b.estado ,
@estado2 =c.estado,
@cuentaid =c.cuentaid, 
@saldoInicial = saldoInicial,
@cuenta = c.numerocuenta
from [dbo].[Persona] a
inner join [dbo].[Cliente] b
on a.personaid = b.personaid
inner join [dbo].[Cuenta] c
on c.clienteid = b.clienteid
where a.identificacion =@identificaccion
and c.tipocuenta =@TipoCuenta

if (@tipoMovimiento = 'R')
begin

set @saldo = sum(@saldoInicial + Convert(int,@movimientoValor))
set @tipoMovimiento1='Retiro'
end
else
begin
set @saldo = sum(@saldoInicial + @movimientoValor)
set @tipoMovimiento1='Depositvo'

end

if ( (@movimientoValor < 0 and @tipoMovimiento ='R') or (@movimientoValor >= 0 and @tipoMovimiento ='D'))
begin
if(@estado1 = 1)
begin
if (@saldoInicial <= 0 and @tipoMovimiento ='R')
begin
select 'Saldo no disponible' as mensaje, '001' as codigo

end
else
begin
if(@saldo >= 0 and @saldoInicial >= 0)
begin

if(@saldo <= 0)
  begin
set @saldo = 0
  end

insert into [dbo].[Movimientos] values(@cuentaid,GETDATE(),@tipoMovimiento1,@movimientoValor,@saldo,@saldoInicial)

update a
set a.saldoInicial =@saldo
from [dbo].[Cuenta] a, [dbo].[Cliente] b,[dbo].[Persona] c
where a.clienteid = b.clienteid
and b.personaid = c.personaid
and c.identificacion = @identificaccion
and a.numerocuenta = @cuenta
and b.estado = '1'
and a.estado = '1'
and a.tipocuenta =@TipoCuenta
select 'Se realizo el movimiento' as mensaje, '000' as codigo

end
else
 begin
 select 'El valor a retirar es mayor a su saldo disponible' as mensaje, '001' as codigo

 end

end
end
else
begin
select 'No existe usuario ' as mensaje, '002' as codigo
end

end
else
begin
select 'Parametros incorrectos' as mensaje, '002' as codigo

end




END
GO


