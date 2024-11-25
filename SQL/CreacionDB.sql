--Consultorio v2
GO
CREATE DATABASE Consultorio

GO
USE Consultorio


/***********	CHECAR LOS 2 ERRORES DE TRIGGER		**********/

--Datos paciente
CREATE TABLE Pacientes (
CURP NCHAR(18) PRIMARY KEY,
Nombre NVARCHAR(64) NOT NULL,
Apellidos NVARCHAR(64) NOT NULL,
Telefono NCHAR(12) NOT NULL,
FechaNacimiento DATE NOT NULL
)


--Historial MÈdico
CREATE TABLE TiposCondicion (
TipoCondicion_id INT IDENTITY(1,1) PRIMARY KEY,
NombreCondicion NVARCHAR(64) NOT NULL,
)

CREATE TABLE Condicion_Pac (
Condicion_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Descripcion NVARCHAR(128) NOT NULL,
FechaInicio DATE check(FechaInicio > '1900-01-01'),
TipoCondicion_id INT FOREIGN KEY REFERENCES TiposCondicion(TipoCondicion_id) NOT NULL,
Paciente_id NCHAR(18) FOREIGN KEY REFERENCES Pacientes(CURP) ON UPDATE CASCADE NOT NULL
)

--Datos de empleado
CREATE TABLE Puestos (
Puesto_id INT IDENTITY(1,1) PRIMARY KEY,
PuestoNombre NVARCHAR(128) NOT NULL,
NivelAcceso INT,
SalarioBase MONEY
)

CREATE TABLE Empleados (
Empleado_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Usuario NVARCHAR(15) NOT NULL,
Pass NVARCHAR(15) NOT NULL,
Nombre NVARCHAR(64) NOT NULL,
Apellidos NVARCHAR(64) NOT NULL,
FechaNacimiento DATE NOT NULL,
FechaContratado DATE NOT NULL,
Salario MONEY NOT NULL check(Salario > 0),
Telefono NCHAR(12) NOT NULL,
CodigoPostal NCHAR(10) NOT NULL,
Calle NVARCHAR(64) NOT NULL,
NumeroExterior NCHAR(6) NOT NULL,
NumeroInterior NCHAR(6),
Puesto_id INT FOREIGN KEY REFERENCES Puestos(Puesto_id) NOT NULL,
CURP NCHAR(20) NOT NULL,
HoraEntrada TIME,
HoraSalida TIME,
)


--Datos Doctor
CREATE TABLE Especialidades (
Especialidad_id INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(64) NOT NULL
)


CREATE TABLE Doctores (
Empleado_Id BIGINT PRIMARY KEY,
Cedula NCHAR(25) NOT NULL,
Especialidad_id INT FOREIGN KEY REFERENCES Especialidades(Especialidad_id),
CONSTRAINT fk_Doc_emp FOREIGN KEY (Empleado_Id) REFERENCES Empleados(Empleado_Id)
)

--Servicios
CREATE TABLE TiposServicio (
TipoServicio_id INT IDENTITY(1,1) PRIMARY KEY,
Descripcion NVARCHAR(64) NOT NULL,
PrecioBase MONEY NOT NULL,
DuracionProm INT NOT NULL, --En minutos
)

CREATE TABLE Especialidad_Servicio(
Especialidad_id INT FOREIGN KEY REFERENCES Especialidades(Especialidad_id) NOT NULL,
TipoServicio_id INT FOREIGN KEY REFERENCES TiposServicio(TipoServicio_id) NOT NULL,
Prioridad INT NOT NULL, --Mientras mayor sea el numero, mayor es su prioridad para esa especialidad
CONSTRAINT pk_Especialidad_servicio PRIMARY KEY (Especialidad_id,TipoServicio_id)
)

CREATE TABLE Citas(
Cita_id BIGINT IDENTITY(1,1) PRIMARY KEY,
FechaRegistro DATETIME NOT NULL,
Empleado_id BIGINT FOREIGN KEY REFERENCES Empleados(Empleado_id) NOT NULL,
Telefono NCHAR(12),
TiposServicio INT FOREIGN KEY REFERENCES TiposServicio(TipoServicio_id),
Contacto NVARCHAR(64),
HoraProgramada DATETIME NOT NULL,
HoraEntrada DATETIME,
Cancelado BIT Check(Cancelado IN (0,1))	NOT NULL DEFAULT 0--Indica si se cancelÅEla cita
)

--Adeudos Clientes (Cuentas o recibos)
CREATE TABLE Adeudos(
Adeudo_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Cita_id BIGINT FOREIGN KEY REFERENCES Citas(Cita_ID) NOT NULL,
FechaExpedido DATE NOT NULL,
NumeroTarjeta NCHAR(64),	--Se pide si no puede pagar al momento
empleado_id BIGINT FOREIGN KEY REFERENCES Empleados(Empleado_id) /*ON UPDATE CASCADE ON DELETE NO ACTION*/  NOT NULL, --Empleado que expide el adeudo
Precio MONEY NOT NULL,
IVA MONEY NOT NULL,
CURP_Paciente NCHAR(18) FOREIGN KEY REFERENCES Pacientes(CURP) ON UPDATE CASCADE NOT NULL,
)


CREATE TABLE Pago(
Pago_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Monto MONEY NOT NULL,
Fecha DATETIME NOT NULL,
NumeroTransaccion NVARCHAR(100), --Pudo no haber sido transferencia
Adeudo_id BIGINT FOREIGN KEY REFERENCES Adeudos(Adeudo_id)
)

--Medicamentos
CREATE TABLE Medicamentos(
Medicamento_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL
)


--SERVICIO DADO POR DOCTOR
CREATE TABLE Reporte (
Reporte_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Cita_id BIGINT FOREIGN KEY REFERENCES Citas(Cita_id) NOT NULL,
Empleado_id BIGINT FOREIGN KEY REFERENCES doctores(Empleado_ID) NOT NULL,--Autor del Reporte
Paciente_id NCHAR(18) FOREIGN KEY REFERENCES Pacientes(CURP) ON UPDATE CASCADE NOT NULL,
Fecha DATE NOT NULL,
Diagnostico NVARCHAR(1024),
--Datos Generales
Altura INT, --En centimetros
Peso INT,	--En Kilogramos

)

CREATE TABLE Observaciones(
Observacion_id BIGINT IDENTITY (1,1) PRIMARY KEY,
Reporte_id BIGINT FOREIGN KEY REFERENCES Reporte(Reporte_id) NOT NULL,
Observacion NVARCHAR(1024) NOT NULL, 
)

CREATE TABLE Receta_conceptos (
Reporte_id BIGINT FOREIGN KEY REFERENCES Reporte(Reporte_id) NOT NULL,
Medicamento_id BIGINT FOREIGN KEY REFERENCES Medicamentos(Medicamento_id) NOT NULL,
Cantidad FLOAT(53) NOT NULL,
CONSTRAINT pk_Receta_Medicamentos PRIMARY KEY (Reporte_id,Medicamento_id)
)

--Proveedores e inventario

CREATE TABLE Catalogo_Insumos (
Insumo_id INT IDENTITY(1,1) PRIMARY KEY,
Descripcion NVARCHAR(128) NOT NULL
)

CREATE TABLE Proveedores (
Proveedor_id BIGINT IDENTITY (1,1) PRIMARY KEY,
Nombre NVARCHAR(64) NOT NULL,
Telefono NCHAR(12) NOT NULL,
Correo NVARCHAR(100) NOT NULL,
Direccion NVARCHAR(100) NOT NULL
)

CREATE TABLE Insumo_Proveedor (
Insumo_id INT FOREIGN KEY REFERENCES Catalogo_Insumos(Insumo_id) NOT NULL,
Proveedor_id BIGINT FOREIGN KEY REFERENCES Proveedores(Proveedor_id) NOT NULL,
Cantidad FLOAT(53) NOT NULL,
Precio MONEY NOT NULL,
CONSTRAINT pk_Insumo_Proveedor PRIMARY KEY (Insumo_id, Proveedor_id)
)

CREATE TABLE OrdenCompra (
Orden_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Proveedor_id BIGINT FOREIGN KEY REFERENCES Proveedores(Proveedor_id) NOT NULL,
Fecha DATE NOT NULL,
)

CREATE TABLE OrdenCompra_Conceptos (
Orden_id BIGINT FOREIGN KEY REFERENCES OrdenCompra(Orden_Id) NOT NULL,
Insumo_id INT FOREIGN KEY REFERENCES Catalogo_Insumos(Insumo_id) NOT NULL,
Cantidad FLOAT(53) NOT NULL,
Costo MONEY NOT NULL,
IVA MONEY NOT NULL,
CONSTRAINT pk_OrdenCompra_conceptos PRIMARY KEY (Orden_id, Insumo_id),
)

CREATE TABLE Inventario (
Lote_id BIGINT IDENTITY(1,1) PRIMARY KEY,
Insumo_id INT FOREIGN KEY REFERENCES Catalogo_Insumos(Insumo_id) NOT NULL,
Cantidad FLOAT(53) NOT NULL,
Orden_id BIGINT FOREIGN KEY REFERENCES OrdenCompra(Orden_id), --Orden de compra de la cual proviene el lote
Caducidad DATE
)


--Insumos usados en un servicio
CREATE TABLE Adeudo_Insumos (
Adeudo_id BIGINT FOREIGN KEY REFERENCES Adeudos(Adeudo_ID) NOT NULL,
Lote_id BIGINT FOREIGN KEY REFERENCES Inventario(Lote_id) NOT NULL,
Cantidad FLOAT(53) NOT NULL
CONSTRAINT pk_servicio_insumo PRIMARY KEY (Adeudo_id,Lote_id)
)

