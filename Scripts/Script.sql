CREATE database db_restaurante;
GO

USE db_restaurante;
GO

create table estado_empresa (
  estado_empresa_id int identity primary key NOT NULL,
  nombre varchar(100)
);
GO

CREATE TABLE empresa (
  empresa_id  int identity PRIMARY KEY NOT NULL,
  estado_empresa_id_fk int foreign key references estado_empresa(estado_empresa_id) not null,
  nombre varchar(100) NOT NULL,
  descripcion text
);
GO

CREATE TABLE tipo_restaurante (
  tipo_restaurante_id  int identity PRIMARY KEY NOT NULL,
  descripcion varchar(100) NOT NULL
);
GO

CREATE TABLE restaurante (
  restaurante_id  int identity PRIMARY KEY NOT NULL,
  empresa_id_fk int FOREIGN KEY REFERENCES empresa(empresa_id) NOT NULL,
  nombre varchar(100) NOT NULL,
  foto varchar(100)
);
GO

CREATE TABLE estado_usuario (
  estado_usuario_id  int identity PRIMARY KEY NOT NULL,
  nombre varchar(100) not null
);
GO

CREATE TABLE usuario_tipo (
  usuario_tipo_id  int identity PRIMARY KEY NOT NULL,
  descripcion varchar(100) NOT NULL,
);
GO

CREATE TABLE usuario (
  usuario_id  int identity PRIMARY KEY NOT NULL,
  usuario_tipo_id_fk int FOREIGN KEY REFERENCES usuario_tipo(usuario_tipo_id) NOT NULL,
  estado_usuario_id_fk int FOREIGN KEY REFERENCES estado_usuario(estado_usuario_id) NOT NULL,
  usuario varchar(100) NOT NULL,
  usuario_password varchar(100) NOT NULL,
  nombre varchar(100) NOT NULL,
  email varchar(100) NOT NULL,
  dni varchar(8) NOT NULL,
);
GO

CREATE table empresa_restaurante_usuario(
  restaurante_usuario_id INT IDENTITY PRIMARY KEY not null,
  empresa_id_fk int FOREIGN KEY REFERENCES empresa(empresa_id) NOT NULL,
  resturante_id_fk int foreign KEY references  restaurante(restaurante_id),
  usuario_id_fk int foreign key references usuario(usuario_id) NOT NULL
);
GO



create table plato_categoria(
  plato_categoria_id int identity Primary Key not null,
  nombre varchar(100) not null,
)
go

CREATE TABLE mesa (
  mesa_id  int identity PRIMARY KEY NOT NULL,
  restaurante_id_fk int FOREIGN KEY REFERENCES restaurante(restaurante_id) NOT NULL,
  estado varchar(100) NOT NULL,
);
GO

create table pedido_cabecera(
  pedido_cabecera_id int identity PRIMARY KEY NOT NULL,
  mesa_id_fk int foreign key references mesa(mesa_id) not null,
  fecha date not null,
  precio_final money not null
)
go

create table plato(
  plato_id int identity primary key  NOT NULL,
  restaurante_id_fk int foreign key references restaurante(restaurante_id) NOT null,
  nombre varchar(100) NOT NULL,
  precio money NOT null,
  categoria_plato_id_fk int foreign key references plato_categoria(plato_categoria_id) not null,
  descripcion text NOT null,
  foto varchar(100) not null ,
  estado varchar(100) not null
);
GO

create table pedido_detalle(
  pedido_detalle_id int identity Primary Key not null,
  pedido_cabecera_id_fk  int FOREIGN KEY REFERENCES pedido_cabecera(pedido_cabecera_id) NOT NULL,
  plato_id_fk int foreign key references plato(plato_id) not null,
  cantidad int not null,
  precio money not null
)
go

CREATE TABLE restaurante_tipo (
  restaurante_tipo_id  int identity PRIMARY KEY NOT NULL,
  restaurante_id_fk int FOREIGN KEY REFERENCES restaurante(restaurante_id) NOT NULL,
  tipo_restaurante_id_fk int FOREIGN KEY REFERENCES tipo_restaurante(tipo_restaurante_id) NOT NULL,
);
GO
