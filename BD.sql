CREATE DATABASE JSANCHEZGN3
USE JSANCHEZGN3
GO

CREATE TABLE DEPARTAMENTO
(
IDDEPARTAMENTO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DESCRIPCION VARCHAR(250) NOT NULL
)
GO

CREATE TABLE SUELDO
(
IDSUELDO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
SUELDO DECIMAL(20,2) NOT NULL,
FORMAPAGO VARCHAR(250)
)
GO

CREATE TABLE EMPLEADO
(
IDEMPLEADO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NOMBRE VARCHAR(250) NOT NULL,
FECHAINGRESO DATE NOT NULL,
FECHANACIMIENTO DATE NOT NULL,
IDDEPARTAMENTO INT NOT NULL,
IDSUELDO INT NOT NULL,
CONSTRAINT FK_DepartamentoEmpleado FOREIGN KEY (IDDEPARTAMENTO) REFERENCES DEPARTAMENTO(IDDEPARTAMENTO),
CONSTRAINT FK_SueldoEmpleado FOREIGN KEY (IDSUELDO) REFERENCES SUELDO(IDSUELDO)
)
GO

CREATE PROCEDURE DepartamentoAdd --'Tecnologia'
@DESCRIPCION VARCHAR(250)
AS
INSERT INTO DEPARTAMENTO(DESCRIPCION) VALUES(@DESCRIPCION) 
GO

CREATE PROCEDURE DepartamentoUpdate
@IDDEPARTAMENTO INT,
@DESCRIPCION VARCHAR(250)
AS
UPDATE DEPARTAMENTO SET DESCRIPCION=@DESCRIPCION WHERE IDDEPARTAMENTO=@IDDEPARTAMENTO
GO

CREATE PROCEDURE DepartamentoDelete
@IDDEPARTAMENTO INT
AS
DELETE FROM DEPARTAMENTO WHERE IDDEPARTAMENTO=@IDDEPARTAMENTO
GO

CREATE PROCEDURE DepartamentoGetAll
AS
SELECT IDDEPARTAMENTO,DESCRIPCION FROM DEPARTAMENTO
GO

CREATE PROCEDURE DepartamentoGetById
@IDDEPARTAMENTO INT
AS
SELECT IDDEPARTAMENTO,DESCRIPCION FROM DEPARTAMENTO WHERE IDDEPARTAMENTO=@IDDEPARTAMENTO
GO

CREATE PROCEDURE EmpleadoAdd --'Jose','22-01-2024','15-08-1999',1,18000,'Nomina'
@NOMBRE VARCHAR(250),
@FECHAINGRESO VARCHAR(250),
@FECHANACIMIENTO VARCHAR(250),
@IDDEPARTAMENTO INT,
@SUELDO DECIMAL(20,2),
@FORMAPAGO VARCHAR(250)
AS
INSERT INTO SUELDO (SUELDO,FORMAPAGO)
VALUES (@SUELDO,@FORMAPAGO)

INSERT INTO EMPLEADO (NOMBRE,FECHAINGRESO,FECHANACIMIENTO,IDDEPARTAMENTO,IDSUELDO)
VALUES (@NOMBRE,CONVERT(date,@FECHAINGRESO,105),CONVERT(date,@FECHANACIMIENTO,105),@IDDEPARTAMENTO,@@IDENTITY)
GO

CREATE PROCEDURE EmpleadoUpdate
@IDEMPLEADO INT,
@NOMBRE VARCHAR(250),
@FECHAINGRESO VARCHAR(250),
@FECHANACIMIENTO VARCHAR(250),
@IDDEPARTAMENTO INT,
@IDSUELDO INT,
@SUELDO DECIMAL(20,2),
@FORMAPAGO VARCHAR(250)
AS
UPDATE SUELDO SET SUELDO=@SUELDO,FORMAPAGO=@FORMAPAGO WHERE IDSUELDO=@IDSUELDO

UPDATE EMPLEADO SET NOMBRE=@NOMBRE,FECHAINGRESO=CONVERT(date,@FECHAINGRESO,105),FECHANACIMIENTO=CONVERT(date,@FECHANACIMIENTO,105),
IDDEPARTAMENTO=@IDDEPARTAMENTO,IDSUELDO=@IDSUELDO
WHERE IDEMPLEADO=@IDEMPLEADO
GO

CREATE PROCEDURE EmpleadoDelete
@IDEMPLEADO INT,
@IDSUELDO INT
AS
DELETE FROM EMPLEADO WHERE IDEMPLEADO=@IDEMPLEADO

DELETE FROM SUELDO WHERE IDSUELDO=@IDSUELDO
GO

CREATE PROCEDURE EmpleadoGetAll
AS
SELECT IDEMPLEADO,NOMBRE,FECHAINGRESO,FECHANACIMIENTO,
D.IDDEPARTAMENTO,D.DESCRIPCION,S.IDSUELDO,S.SUELDO,S.FORMAPAGO
FROM EMPLEADO E
INNER JOIN DEPARTAMENTO D ON E.IDDEPARTAMENTO = D.IDDEPARTAMENTO
INNER JOIN SUELDO S ON E.IDSUELDO = S.IDSUELDO
GO

CREATE PROCEDURE EmpleadoGetById
@IDEMPLEADO INT
AS
SELECT IDEMPLEADO,NOMBRE,FECHAINGRESO,FECHANACIMIENTO,
D.IDDEPARTAMENTO,D.DESCRIPCION,S.IDSUELDO,S.SUELDO,S.FORMAPAGO
FROM EMPLEADO E
INNER JOIN DEPARTAMENTO D ON E.IDDEPARTAMENTO = D.IDDEPARTAMENTO
INNER JOIN SUELDO S ON E.IDSUELDO = S.IDSUELDO
WHERE IDEMPLEADO = @IDEMPLEADO
GO
