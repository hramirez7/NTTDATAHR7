--create database BaseData

use BaseData
create table dbo.Persona(
personaid int primary key IDENTITY(1,1) not null,
nombre varchar(150), 
genero varchar(1), 
edad int,
identificacion varchar(10),
dirección varchar(350),
teléfono varchar(15)
)

create table dbo.Cliente(
clienteid int primary key IDENTITY(1,1) not null, 
personaid int,
contrasena varchar(15), 
estado bit,
CONSTRAINT fkpersonas FOREIGN KEY (personaid) REFERENCES dbo.Persona(personaid)
)

create table dbo.Cuenta(
cuentaid int IDENTITY(1,1) not null,
clienteid int,
numerocuenta varchar(15),
tipocuenta varchar(20), 
saldoInicial decimal(15,2),
estado bit,
CONSTRAINT fkcliente FOREIGN KEY (clienteid) REFERENCES dbo.Cliente(clienteid)
)

create table dbo.Movimientos(
movimientoid int IDENTITY(1,1) not null,
clienteid int,
Fecha datetime, 
tipomovimiento varchar(30), 
valor decimal(15,2), 
saldo decimal(15,2),
saldoInicial decimal(15,2)
);



