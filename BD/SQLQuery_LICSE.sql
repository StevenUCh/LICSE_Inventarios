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

CREATE TABLE PROVEEDOR
(
	id_proveedor INT PRIMARY KEY,
	pro_nombre VARCHAR(35),
	pro_telefono VARCHAR(15),
	pro_correo VARCHAR(50)
)

CREATE TABLE USUARIO
(
	rol INT PRIMARY KEY, 
	id_usuario VARCHAR (35), 
	usu_nombre VARCHAR (35), 
	usu_apellido VARCHAR (35), 
	usu_telefono VARCHAR (15), 
	usu_correo VARCHAR (60), 
	contraseña VARCHAR (200),
	estado FOREIGN KEY REFERENCES  ESTADO_USUARIO(id_estado),

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
	tecnico VARCHAR(60)
)

CREATE TABLE ENTRADA_SOLICITUD
(
	entrada INT FOREIGN KEY REFERENCES  ENTRADA(id_registro),
	solicitud INT FOREIGN KEY REFERENCES  SOLICITUD(id_solicitud),
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
	(2	,773501,	 'María  ',	 'Martinez ',	 '3498675069 ',	 '  maria@hotmail.com ',	 '  1666067 ',	1),
	(2	,4618356,	 'José ',	 'Gonzales ',	 '3366383465 ',	 '  josia@hotmail.com ',	 '  2812540 ',	2),
	(1	,5079471,	 'Carmen ',	 'Rojas ',	 '3348261962 ',	 '  caria@hotmail.com ',	 '  8496167 ',	2),
	(2	,2520872,	 'Antonio ',	 'Mendez ',	 '3455382902 ',	 '  antia@hotmail.com ',	 '  2230141 ',	1),
	(1	,1669553,	 'Manuel ',	 'Rodriguez ',	 '3019987127 ',	 '  mania@hotmail.com ',	 '  1607266 ',	2),
	(2	,8527287,	 'Josefa ',	 'Arias ',	 '3002834434 ',	 '  josia@hotmail.com ',	 '  5834760 ',	2),
	(2	,1964314,	 'Ana ',	 'Garzon ',	 '3288819958 ',	 '  anaia@hotmail.com ',	 '  7715363 ',	1),
	(2	,5142806,	 'David  ',	 'Plazas ',	 '3129877614 ',	 '  davia@hotmail.com ',	 '  7710088 ',	2),
	(1	,1104331,	 'javier ',	 'Henao ',	 '3317461360 ',	 '  javia@hotmail.com ',	 '  1905572 ',	1),
	(2	,6150629,	 'Francisco ',	 'Perez ',	 '3118859366 ',	 '  fraia@hotmail.com ',	 '  4123955 ',	2),
	(1	,3857707,	 'carlos ',	 'Franco ',	 '3238389697 ',	 '  caria@hotmail.com ',	 '  5914000 ',	1)

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
