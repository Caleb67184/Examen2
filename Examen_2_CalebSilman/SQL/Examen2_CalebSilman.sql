create database base_de_datos

use base_de_datos

create table Cajeros
(
	Codigo_cajero int identity (1,1) primary key,
	Nombre_cajero nvarchar(100) not null,
	Apellidos nvarchar(100) not null
)

create table Productos
(
	Codigo_productos int identity (1,1) primary key,
	Nombre_producto nvarchar(100) not null,
	Precio float
)

create table Venta
(
	Codigo_venta int identity (1,1) primary key,
	Cajero int,
	Maquina int,
	Producto int,
	constraint PK_Cajero foreign key(Cajero) references Cajeros(Codigo_cajero),
	constraint PK_Maquina foreign key(Maquina) references Maquinas_Registradoras (Codigo_MaquinaReg),
	constraint PK_Producto foreign key(Producto) references Productos(Codigo_productos),
	Fecha date constraint Def_fecha Default Getdate()
)

create table Maquinas_Registradoras
(
	Codigo_MaquinaReg int identity (1,1) primary key,
	Piso int
)

insert into Cajeros values ('Manuel','Solis Rios'),('Manuela','Vargas Azofeifa')

insert into Productos values ('Hotwheels',5600),('Botella Agua',700),('Balon basketball',16500)

insert into Maquinas_Registradoras values (1),(2)

update Cajeros set Nombre_cajero = ('Carlos') where Codigo_cajero = 1

update Productos set Precio = (7900) where Nombre_producto = 'Hotwheels'

select Venta.Fecha, Nombre_cajero, Productos.Nombre_producto, Productos.Precio, Maquinas_Registradoras.Piso
from (((Venta
inner join Productos on Venta.Producto = Productos.Codigo_productos)
inner join Maquinas_Registradoras on Venta.Maquina = Maquinas_Registradoras.Codigo_MaquinaReg)
inner join Cajeros on Venta.Cajero = Cajeros.Codigo_cajero)

