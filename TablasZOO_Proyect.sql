--Crear Base de Datos
CREATE DATABASE bdZOO
GO

--Activar la Base de Datos
USE bdZOO
GO

--Crear Tabla

--Tabla Alimentacion
if(not exists(select 1 from sys.tables WHERE name = 'Alimentacion'))
	CREATE TABLE dbo.Alimentacion(
		id_alimentacion int identity(1,1) NOT NULL,
		nombre as ('ALI'+RIGHT('00'+CONVERT(VARCHAR, id_alimentacion),(2))),
		clasificacion_alimentaria varchar(100) NOT NULL,
		descripcion text NULL,
		PRIMARY KEY(id_alimentacion)
	)
GO

--Tabla Usuario
if(not exists(select 1 from sys.tables WHERE name = 'Usuario'))
	CREATE TABLE dbo.Usuario(
		id_usuario int identity(1,1) NOT NULL,
		nombre_usuario varchar(50) NOT NULL,
		nombre_completo varchar(140) NOT NULL,
		clave varchar(100) NULL,
		rol varchar(20) NOT NULL,
		estado char(1) NOT NULL,
		dni varchar(8) NOT NULL UNIQUE,
		celular varchar(15) NULL,
		email varchar(250) NULL UNIQUE,
		PRIMARY KEY (id_usuario)
	)
GO

--Tabla Actividad
if(not exists(select 1 from sys.tables WHERE name = 'Actividad'))
	CREATE TABLE dbo.Actividad(
		id_actividad int identity(1,1) NOT NULL,
		id_usuario int NOT NULL,
		nombre varchar(100) NOT NULL,
		descripcion text NULL,
		PRIMARY KEY(id_actividad),
		FOREIGN KEY (id_usuario) REFERENCES Usuario (id_usuario)
	)
GO

--Tabla Habitat Especie

if(not exists(select 1 from sys.tables WHERE name = 'Habitat_Especie'))
	CREATE TABLE dbo.Habitat_Especie(
		id_habitat_especie int identity(1,1) NOT NULL,
		id_actividad int NOT NULL,
		nombre varchar(100) NOT NULL,
		bioma varchar(150) NOT NULL,
		PRIMARY KEY(id_habitat_especie),
		FOREIGN KEY (id_actividad) REFERENCES Actividad
	)
GO

--Tabla Especie
if(not exists(select 1 from sys.tables WHERE name = 'Especie'))
	CREATE TABLE dbo.Especie(
		id_especie int identity(1,1) NOT NULL,
		id_habitat_especie int NOT NULL,
		id_alimentacion int NOT NULL,
		nombre_comun varchar(100) NOT NULL,
		nombre_cientifico varchar(100) NOT NULL,
		categoria varchar(150) NOT NULL,
		dias_gestacion int NULL,
		horas_exhibicion int NULL,
		horas_contencion int NULL,
		en_extincion char(2) NOT NULL,
		PRIMARY KEY(id_especie),
		FOREIGN KEY (id_habitat_especie) REFERENCES Habitat_Especie,
		FOREIGN KEY (id_alimentacion) REFERENCES Alimentacion
	)
GO

--Tabla Animal
if(not exists(select 1 from sys.tables WHERE name = 'Animal'))
	CREATE TABLE dbo.Animal(
		id_animal int identity(1,1) NOT NULL,
		id_especie int NOT NULL,
		nombre varchar(100) NOT NULL,
		sexo varchar(10) NOT NULL,
		fecha_obtencion varchar(50) NULL,
		lugar_origen varchar(150) NOT NULL,
		en_prestamo char(2) NOT NULL,
		PRIMARY KEY(id_animal),
		FOREIGN KEY (id_especie) REFERENCES Especie
	)
GO


drop table dbo.Alimentacion
drop table dbo.Usuario
drop table dbo.Actividad
drop table dbo.Habitat_Especie
drop table dbo.Especie
drop table dbo.Animal