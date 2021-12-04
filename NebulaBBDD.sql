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
	Contraseña varchar(10) not null, 
	TipoUsuario int not null check(TipoUsuario between 1 and 2)
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
	Estado bit not null,
	IdCategoria int not null foreign key references Categoria(Id)
)
go
create table Stock(
	Id int not null primary key identity(1,1),
	IdArticulo int not null foreign key references Articulo(Id),
	StockArticulo int not null,
	Talle varchar(3) not null 
)
go
create table ElementoCarrito(
IdArticulo int not null foreign key references Articulo(Id),
Cantidad int not null check(Cantidad > 0),
Talle varchar(3) not null,
PrecioUnitario money not null
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
	IdUsuario int not null foreign key references Usuario(Id),
)
go
create table Venta(
	Id bigint not null primary key identity(1,1),
	Total money not null,
	FechaCompra Date not null,
	IdFOP int not null foreign key references FOP(Id),
	IdCliente int not null foreign key references Cliente(Id)
)
go

create table Carrito(
	Id int not null primary key identity(1,1),
	IdVenta bigint not null foreign key references Venta(Id),
	IdArticulo int not null foreign key references Articulo(Id),
	Cantidad int not null check(Cantidad > 0),
	Talle varchar(3) not null
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
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('BAZINGA', 'Remera manga corta, roja con incripcion.', 1000, 'https://http2.mlstatic.com/D_NQ_NP_977245-MLA44576080247_012021-O.webp', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('E=mc2', 'Remera manga corta, gris.', 800, 'https://http2.mlstatic.com/D_NQ_NP_744744-MLA47909475438_102021-W.webp', 1, 1)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('STAR WARS', 'Remera manga corta, negra con bordado.', 4000, 'https://d26lpennugtm8s.cloudfront.net/stores/064/882/products/clasica2-ea8a431b2ba8eb128615132717760366-1024-1024.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('MICKEY', 'Remera manga corta, negra de Mickey Mouse.', 4000, 'https://e7.pngegg.com/pngimages/386/738/png-clipart-t-shirt-mickey-mouse-minnie-mouse-baby-toddler-one-pieces-t-shirt-tshirt-smiley.png', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('FLOPPY DISK', 'Remera manga corta, negra, "I am your father".', 3500, 'https://i.pinimg.com/564x/38/95/29/3895293082cb57a9d269cb7bf2836f01.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('HONGO', 'Remera manga corta, negra.', 3600, 'https://i.pinimg.com/564x/a0/00/87/a00087c2dca3cf40d7fd137fbe62bbcb.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('SUPER NERD', 'Remera manga corta, amarilla de Milhouse', 3000, 'https://d3ugyf2ht6aenh.cloudfront.net/stores/856/490/products/reme-retro-estampa071-d0be348203fe5b922716115913184313-1024-1024.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('SCIENCE', 'Remera manga corta, roja estampa Because Science', 2000, 'https://images.lookhuman.com/render/standard/0255010648449256/3600-red-md-t-because-science.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('GET OUT', 'Remera manga corta, gris, get out of here.', 3600, 'https://http2.mlstatic.com/D_NQ_NP_915799-MLA27210830713_042018-O.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('PHP CODE', 'Remera manga corta, blanca con codigo php.', 3600, 'http://www.puertopixel.com/wp-content/uploads/2012/05/40-remeras-geek-10.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('BIG BANG THEORY', 'Remera manga corta, blanca con cabezas de los personajes.', 5000, 'https://img.elo7.com.br/product/zoom/24F6995/camiseta-the-big-bang-theory-sheldom-leonard-bazinga-sheldom.jpg', 1, 2)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('PLANET NERD', 'Remera manga larga, negra con estampa.', 5000, 'https://d3ugyf2ht6aenh.cloudfront.net/stores/001/039/673/products/91-a2e9732e3f438a83ae16190282957471-640-01-3d9e36b492d89efe3216292322790438-1024-1024.jpg', 1, 1)
INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria)
VALUES ('TEAM NERD', 'Remera manga larga, negra con estampa.', 3000, 'https://image.spreadshirtmedia.net/image-server/v1/mp/products/T1235A2MPA4255PT17X1Y8D160403613FS2710/views/1,width=378,height=378,appearanceId=2,backgroundColor=F2F2F2/equipo-nerd-nerds-camiseta-organica-de-manga-larga-mujer.jpg', 1, 1)
go

--USUARIO ADMIN
INSERT INTO Usuario(TipoUsuario, NombreUsuario, Contraseña)
VALUES(2, 'solear', '1234')
go
INSERT INTO Direccion(CalleNum,CodigoPostal,Provincia,Pais)
VALUES('Parana 3250','1636','Buenos Aires','Argentina')
go
set Dateformat 'dmy'
INSERT INTO Cliente(Nombre,Apellido,Dni,FechaNac,Celular,Email,IdDireccion,IdUsuario)
VALUES('Maria Soledad','Arena','31205206','20/08/1984','1165666037','solearena@gmail.com',1,1)

--USUARIO CLIENTE
INSERT INTO Usuario(TipoUsuario, NombreUsuario, Contraseña)
VALUES(1, 'florchus', '5678')
go
INSERT INTO Direccion(CalleNum,CodigoPostal,Provincia,Pais)
VALUES('Cramer 345','1400','Buenos Aires','Argentina')
go
set Dateformat 'dmy'
INSERT INTO Cliente(Nombre,Apellido,Dni,FechaNac,Celular,Email,IdDireccion,IdUsuario)
VALUES('Florencia Esther','Farias','35216436','09/05/1990','1140857479','florfarias@gmail.com',2,2)
go

--STOCK
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(1, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(2, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(3, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(4, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(5, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(6, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(7, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(8, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(9, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(10, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(11, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(12, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(13, 200, 'S')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(1, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(2, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(3, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(4, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(5, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(6, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(7, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(8, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(9, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(10, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(11, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(12, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(13, 200, 'M')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(1, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(2, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(3, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(4, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(5, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(6, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(7, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(8, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(9, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(10, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(11, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(12, 200, 'L')
INSERT INTO Stock(IdArticulo, StockArticulo, Talle)
VALUES(13, 200, 'L')
go

