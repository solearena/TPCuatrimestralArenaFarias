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
VALUES ('SCIENCE', 'Remera manga corta, gris estampa Ciencia', 2000, 'data:image/jpeg;base64,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', 1, 2)
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

