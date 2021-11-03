create database NEBULA
go
use NEBULA
go
create table Direccion (
	Id int not null primary key identity(1,1),
	CalleNum varchar(200) not null,
	CodigoPostal varchar(5) not null,
	Provincia varchar(50) not null,
	Pais varchar(50) not null,
)
go
create table FOP (
	Id int not null primary key identity(1,1),
	Tipo varchar(50) not null
)
go
create table Usuario(
	Id int not null primary key identity(1,1),
	NombreUsuario varchar(100) not null unique,
	Contraseña varchar(10) not null 
)
go
create table Categoria(
	Id int not null primary key identity(1,1),
	Descripcion varchar(50) not null
)
go
create table Articulo (
	Id int not null primary key identity(1,1),
	Nombre varchar(50) not null,
	Descripcion varchar(200) null,
	Precio decimal(10,2),
	UrlImagen varchar(300),
	Talle varchar(3) not null,
	Estado bit not null,
	IdCategoria int not null foreign key references Categoria(Id)
)
go
create table Cliente(
	Id int not null primary key identity(1,1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Dni varchar(30) not null unique,
	FechaNac date null,
	Celular varchar(20) null,
	Email varchar(120) not null,
	IdDireccion int not null foreign key references Direccion(Id),
	IdUsuario int not null foreign key references Usuario(Id)
)
go
create table Venta(
	Id bigint not null primary key identity(1,1),
	Total money not null,
	FechaCompra Date not null
)
go

--FOP
INSERT INTO FOP(Tipo)
VALUES ('Efectivo')
INSERT INTO FOP(Tipo)
VALUES ('Mercado Pago')
INSERT INTO FOP(Tipo)
VALUES ('Transferencia Bancaria')
go

--CATEGORÍA
INSERT INTO Categoria(Descripcion)
VALUES ('Manga Larga')
INSERT INTO Categoria(Descripcion)
VALUES ('Manga Corta')
go

--ARTICULO
INSERT INTO Articulo(Nombre, Descripcion, Precio, Talle, Estado, IdCategoria)
VALUES ('BAZINGA', 'Remera manga corta, roja con incripcion bbtg', 1000, 'S', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, Talle, Estado, IdCategoria)
VALUES ('NERD', 'Remera manga larga, azul y rojo', 800, 'M', 1, 1)
INSERT INTO Articulo(Nombre, Descripcion, Precio, Talle, Estado, IdCategoria)
VALUES ('STAR WARS', 'Remera manga corta, amarilla con bordado', 4000, 'M', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, Talle, Estado, IdCategoria)
VALUES ('DISNEY', 'Remera manga corta, rosa, importada', 4000, 'L', 1, 2)
go


