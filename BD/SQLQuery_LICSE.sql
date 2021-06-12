-- Query database LICSE Inventarios

CREATE DATABASE LICSE_Inventarios

USE LICSE_Inventarios 
GO

CREATE TABLE ROL
(
	id_rol INT IDENTITY (1,1) NOT NULL PRIMARY KEY,	
	nombre VARCHAR (15) NOT NULL
)

CREATE TABLE ESTADO_USUARIO
(
	id_estado INT IDENTITY (1,1) NOT NULL PRIMARY KEY,	
	nombre VARCHAR (15) NOT NULL
)

CREATE TABLE TIPO_SEDE	
(
	id_tipo INT IDENTITY (1,1) NOT NULL PRIMARY KEY,	
	nombre VARCHAR (15) NOT NULL
)

CREATE TABLE CATEGORIA	
(
	id_categoria INT IDENTITY (1,1) NOT NULL PRIMARY KEY,	
	nombre VARCHAR (15) NOT NULL
)

CREATE TABLE TECNICO
(
	id_tecnico INT PRIMARY KEY,
	tec_nom VARCHAR(35),
	tec_tel VARCHAR(15)
)

CREATE TABLE PROVEEDOR
(
	id_proveedor INT PRIMARY KEY,
	pro_nombre VARCHAR(35),
	pro_telefono VARCHAR(15),
	pro_correo VARCHAR(50)
)

CREATE TABLE USUARIO
(
	rol int FOREIGN KEY REFERENCES  ROL(id_rol), 
	id_usuario INT PRIMARY KEY, 
	usu_nombre VARCHAR (35), 
	usu_apellido VARCHAR (35), 
	usu_telefono VARCHAR (15), 
	usu_correo VARCHAR (60), 
	contraseña VARCHAR (200),
	estado int FOREIGN KEY REFERENCES  ESTADO_USUARIO(id_estado),
)

CREATE TABLE SEDE
(
	id_sede INT IDENTITY(1,1) PRIMARY KEY,
	sede_nombre VARCHAR(40),
	sede_direccion VARCHAR(50),
	tipo INT FOREIGN KEY REFERENCES TIPO_SEDE (id_tipo),
	sede_encargado VARCHAR(50)
)

CREATE TABLE ELEMENTO
(
	id_elem INT IDENTITY(1,1) PRIMARY KEY,
	elem_ref VARCHAR(50),
	elem_nom VARCHAR(60),
	categoria INT FOREIGN KEY REFERENCES CATEGORIA(id_categoria),
	Proveedor INT FOREIGN KEY REFERENCES PROVEEDOR(id_proveedor)
)

CREATE TABLE ENTRADA
(
	id_registro INT IDENTITY(1,1) PRIMARY KEY,
	elemento INT FOREIGN KEY REFERENCES  ELEMENTO (id_elem),
	cant INT,
	fecha DATE,
	usuario INT FOREIGN KEY REFERENCES USUARIO(id_usuario)
)

CREATE TABLE SOLICITUD
(
	id_solicitud INT IDENTITY(1,1) PRIMARY KEY,
	sol_fecha  DATE NOT NULL,
	usuario INT NOT NULL FOREIGN KEY REFERENCES  USUARIO(id_usuario),
	fecha_progra DATETIME NOT NULL,
	solicitante VARCHAR(60),
	sede INT NOT NULL FOREIGN KEY REFERENCES SEDE(id_sede),
	tecnico INT NOT NULL FOREIGN KEY REFERENCES TECNICO(id_tecnico)
)

CREATE TABLE ENTRADA_SOLICITUD
(	
	id INT IDENTITY(1,1) PRIMARY KEY,
	entrada INT FOREIGN KEY REFERENCES  ENTRADA(id_registro),
	solicitud INT FOREIGN KEY REFERENCES  SOLICITUD(id_solicitud),
	cant INT NOT NULL
)


INSERT INTO ROL 
( nombre )
VALUES 
	('Administrador'),
	('Auxiliar')

INSERT INTO ESTADO_USUARIO 
( nombre )
VALUES 
	('Activo'),
	('Inactivo')
	
INSERT INTO TIPO_SEDE 
( nombre )
VALUES 
	('CAV')
	
INSERT INTO CATEGORIA 
( nombre )
VALUES 
	('Camaras'),
	('Microfonos'),
	('Sensores'),
	('Alarmas')


INSERT INTO PROVEEDOR 
(id_proveedor, pro_nombre, pro_telefono, pro_correo)
VALUES 
	('10123456', 'Soltec', '7214365', 'soltec@email.com'),
	('123456789', 'Security SAS', '4538790', 'security@sas.com')


INSERT INTO USUARIO 
(rol, id_usuario, usu_nombre, usu_apellido, usu_telefono, usu_correo, contraseña ,estado)
VALUES 
	(1	,1000123283,'Julian','Tunjuelo','3195413609','julianestebanth2001@gmail.com','1880c06b79d0c0f81db9896397c41195fcc073a10b98d69dfbb0194ab3c375ed',1)
	

	-- MOVIMIENTO ENTRADA

	SELECT * FROM ENTRADA

	SELECT 
		EN.id_registro,
		EL.elem_ref,
		EL.elem_nom,
		EN.cant,
		EN.fecha,
		US.usu_nombre 
	FROM ENTRADA EN  INNER JOIN ELEMENTO EL ON EN.elemento = EL.id_elem 
	INNER JOIN USUARIO US ON EN.usuario = US.id_usuario 


	SELECT  dbo.ENTRADA.id_registro, dbo.ELEMENTO.elem_ref, dbo.ELEMENTO.elem_nom, dbo.ENTRADA.cant, dbo.ENTRADA.fecha, dbo.USUARIO.usu_nombre
	FROM    dbo.ELEMENTO INNER JOIN
            dbo.ENTRADA ON dbo.ELEMENTO.id_elem = dbo.ENTRADA.elemento INNER JOIN
            dbo.USUARIO ON dbo.ENTRADA.usuario = dbo.USUARIO.id_usuario

	-- MOVIMIENTO SALIDA 

	SELECT		dbo.SOLICITUD.id_solicitud, dbo.SOLICITUD.fecha_progra, dbo.SOLICITUD.usuario, dbo.ENTRADA_SOLICITUD.cant, dbo.ELEMENTO.elem_ref, dbo.ELEMENTO.elem_nom, dbo.SOLICITUD.sede
	FROM        dbo.ENTRADA INNER JOIN
                dbo.ENTRADA_SOLICITUD ON dbo.ENTRADA.id_registro = dbo.ENTRADA_SOLICITUD.entrada INNER JOIN
                dbo.SOLICITUD ON dbo.ENTRADA_SOLICITUD.solicitud = dbo.SOLICITUD.id_solicitud INNER JOIN
                dbo.ELEMENTO ON dbo.ENTRADA.elemento = dbo.ELEMENTO.id_elem
	GROUP BY dbo.SOLICITUD.id_solicitud, dbo.SOLICITUD.fecha_progra, dbo.SOLICITUD.usuario, dbo.ENTRADA_SOLICITUD.cant, dbo.ELEMENTO.elem_ref, dbo.ELEMENTO.elem_nom, dbo.SOLICITUD.sede

-- Stock 
