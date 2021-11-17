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
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Talle, Estado, IdCategoria)
VALUES ('BAZINGA', 'Remera manga corta, roja con incripcion.', 1000, 'https://http2.mlstatic.com/D_NQ_NP_977245-MLA44576080247_012021-O.webp', 'S', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Talle, Estado, IdCategoria)
VALUES ('E=mc2', 'Remera manga corta, gris.', 800, 'https://http2.mlstatic.com/D_NQ_NP_744744-MLA47909475438_102021-W.webp', 'M', 1, 1)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Talle, Estado, IdCategoria)
VALUES ('STAR WARS', 'Remera manga corta, negra con bordado.', 4000, 'https://d26lpennugtm8s.cloudfront.net/stores/064/882/products/clasica2-ea8a431b2ba8eb128615132717760366-1024-1024.jpg', 'M', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Talle, Estado, IdCategoria)
VALUES ('MICKEY', 'Remera manga corta, negra de Mickey Mouse.', 4000, 'https://e7.pngegg.com/pngimages/386/738/png-clipart-t-shirt-mickey-mouse-minnie-mouse-baby-toddler-one-pieces-t-shirt-tshirt-smiley.png', 'L', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Talle, Estado, IdCategoria)
VALUES ('FLOPPY DISK', 'Remera manga corta, negra, "I am your father".', 3500, 'https://i.pinimg.com/564x/38/95/29/3895293082cb57a9d269cb7bf2836f01.jpg', 'L', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Talle, Estado, IdCategoria)
VALUES ('HONGO', 'Remera manga corta, negra.', 3600, 'https://i.pinimg.com/564x/a0/00/87/a00087c2dca3cf40d7fd137fbe62bbcb.jpg', 'L', 1, 2)
go


