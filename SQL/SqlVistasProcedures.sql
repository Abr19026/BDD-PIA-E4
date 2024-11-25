USE Consultorio

--VISTA DOCTORES
GO
CREATE VIEW VistaDoctoresD (Empleado_id, Especialidad_id, Doctor, Cedula, HoraEntrada, HoraSalida, Especialidad)
AS SELECT E.Empleado_id, ES.Especialidad_id, E.Nombre, D.Cedula, E.HoraEntrada, E.HoraSalida, ES.Nombre
FROM Doctores D
INNER JOIN Empleados E ON E.Empleado_id = D.Empleado_Id
INNER JOIN Especialidades ES ON ES.Especialidad_id = D.Especialidad_id
GO
--SP VALIDAR DOCTOR TIPO MEDICO
CREATE PROCEDURE ValidarDoctorMed(
@EmpleadoID BIGINT,
@Cedula NCHAR(25),
@EspecialidadID INT
)
AS BEGIN
	IF ((SELECT Puesto_id FROM Empleados WHERE Empleado_id = @EmpleadoID) = 3)
	BEGIN
		INSERT INTO Doctores(Empleado_Id, Cedula, Especialidad_id) VALUES (@EmpleadoID, @Cedula, @EspecialidadID)
	END
END
GO
--VISTA RECETA
CREATE VIEW RecetaVista (Reporte_id, Paciente, Empleadp, Medicamento_id, Medicamento, Dosis)
AS SELECT R.Reporte_id, R.Paciente_id, R.Empleado_id, M.Medicamento_id, M.Nombre, RC.Cantidad
FROM Receta_conceptos RC
INNER JOIN Reporte R ON R.Reporte_id = RC.Reporte_id
INNER JOIN Medicamentos M ON M.Medicamento_id = RC.Medicamento_id
GO
--VISTA ESPECIALIDAD-SERVICIO
CREATE VIEW VistaEspecialidadServicio(Especialidad_id, TipoServicio_id, Doctor, Especialidad, Descripcion, Prioridad)
AS SELECT ES.Especialidad_id, T.TipoServicio_id, EM.Nombre, E.Nombre, T.Descripcion, ES.Prioridad
FROM Especialidad_Servicio ES
INNER JOIN Especialidades E ON E.Especialidad_id = ES.Especialidad_id
INNER JOIN TiposServicio T ON T.TipoServicio_id = ES.TipoServicio_id
INNER JOIN Doctores D ON D.Especialidad_id = E.Especialidad_id
INNER JOIN Empleados EM ON EM.Empleado_id = D.Empleado_Id
GO
--PagarAdeudo
CREATE PROCEDURE PagarAdeudo(
	@PagoID BIGINT,
	@AdeudoID BIGINT
)
AS BEGIN
	DECLARE @Pagado Money
	DECLARE @Adeudo	Money


	SET @Pagado = (SELECT Monto FROM Pago WHERE Pago_id = @PagoID)
	SET @Adeudo = (SELECT Precio FROM Adeudos WHERE Adeudo_id = @AdeudoID)



	UPDATE Adeudos SET Precio = @Adeudo-@Pagado WHERE Adeudo_id = @PagoID
	UPDATE Adeudos SET IVA = (@Adeudo-@Pagado)*0.16 WHERE Adeudo_id = @PagoID

	IF(@Adeudo-@Pagado < 0)
	BEGIN
		UPDATE Adeudos SET Precio = 0 WHERE Adeudo_id = @PagoID
		UPDATE Adeudos SET IVA = 0 WHERE Adeudo_id = @PagoID
	END

END
GO
--Vista Adeudo servicio  insumos
CREATE VIEW AdeudoServicioInsumos(Lote_id, Adeudo_id, cantidad, cantidadTotal)
AS SELECT Ai.Lote_id, A.Adeudo_id, Ai.Cantidad, I.Cantidad 
FROM Adeudo_Insumos Ai
INNER JOIN Adeudos A ON A.Adeudo_id = Ai.Adeudo_id
INNER JOIN Inventario I ON I.Lote_id = Ai.Lote_id

GO
--Eliminar del Inventario los insumos usados en la consulta
CREATE PROCEDURE ActualizarInventario(
@LoteID BIGINT,
@AdeudoID BIGINT)
AS BEGIN
	
	DECLARE @CantidadTotal INT 
	DECLARE @CantidadReducir INT
	SET @CantidadTotal = (SELECT cantidadTotal FROM AdeudoServicioInsumos WHERE Lote_id = @LoteID AND Adeudo_id = @AdeudoID)
	SET @CantidadReducir = (SELECT cantidad FROM AdeudoServicioInsumos WHERE Lote_id = @LoteID AND Adeudo_id = @AdeudoID)
	Select @CantidadTotal
	Select @CantidadReducir
	UPDATE Inventario SET Cantidad = @CantidadTotal-@CantidadReducir WHERE Lote_id = @LoteID
END
GO
--VISTA PARA OBTENER EL NIVEL DE ACCESO
CREATE VIEW Acceso_Empleado (Empleado_id, Usuario, Pass, NivelAcceso) 
AS SELECT E.Empleado_id, E.Usuario, E.Pass, P.NivelAcceso
FROM Empleados E
INNER JOIN Puestos P ON P.Puesto_id = E.Puesto_id

--VISTA PARA Consultar adeudos
GO
CREATE VIEW Adeudos_Paciente (Paciente, Cita_ID, Fecha_Expedido, Precio)
AS SELECT P.Nombre + '' + P.Apellidos, A.Cita_id, A.FechaExpedido, A.Precio 
FROM Pacientes P
INNER JOIN Adeudos A ON A.CURP_Paciente = P.CURP

GO
--Vista Mostrar insumos adeudo con nombre
CREATE VIEW VInsumos(Adeudo_id, Lote_id, Cantidad, Descripcion)
AS 
SELECT AI.Adeudo_id, AI.Lote_id, AI.Cantidad, CI.Descripcion
FROM Adeudo_Insumos AI
INNER JOIN Inventario I ON I.Lote_id = AI.Lote_id
INNER JOIN Catalogo_Insumos CI ON I.Insumo_id = CI.Insumo_id

GO
CREATE VIEW Cita_Datos (Cita_id, [Fecha de Registro], [Recepcionista_id], [Nombre Recepcionista], [Tel馭ono Llamada], [Servicio_id], [Servicio Asignado], [Contacto], [Fecha Programada], [Hora llegada], [Cancelado])
AS 
	SELECT Cita_id,FechaRegistro,c.Empleado_id, e.Nombre + ' ' + e.Apellidos,c.Telefono, ts.TipoServicio_id,ts.Descripcion,Contacto,HoraProgramada,c.HoraEntrada,Cancelado 
	FROM Citas c
	INNER JOIN Empleados e ON c.Empleado_id = e.Empleado_id
	INNER JOIN TiposServicio ts ON c.TiposServicio = ts.TipoServicio_id


GO
CREATE VIEW Citas_Activas_Hoy (Cita_id, [Fecha de Registro], [Recepcionista_id], [Teléfono Llamada], [Servicio Asignado], [Contacto])
AS
	SELECT Cita_id, [FechaRegistro], [Empleado_id], [Telefono], [TiposServicio], [Contacto]
	FROM Citas c 
	WHERE DAY(c.[FechaRegistro]) = DAY(GETDATE())
	AND [HoraEntrada] IS NULL
	AND Cancelado = 0

GO


CREATE VIEW ESTATUS_ADEUDO (Adeudo_id,Cita_id,FechaExpedido,NumeroTarjeta,empleado_asignador,Monto,Iva,Total,Pagado,Paciente,NombrePaciente)AS
SELECT a.Adeudo_id,a.Cita_id,a.FechaExpedido,a.NumeroTarjeta,a.empleado_id,a.Precio,a.IVA,a.Precio + a.IVA,SUM(P.Monto),a.CURP_Paciente,pac.Nombre FROM Adeudos a
LEFT JOIN Pago P
ON P.Adeudo_id = a.Adeudo_id
INNER JOIN Pacientes pac
ON pac.CURP = a.CURP_Paciente
GROUP BY a.Adeudo_id,a.Cita_id,a.FechaExpedido,a.NumeroTarjeta,a.empleado_id,a.Precio,a.IVA,a.CURP_Paciente,pac.Nombre

GO
CREATE PROCEDURE ACEPTAR_CITA_NOW
(@id_cita BIGINT)
AS BEGIN
	SET NOCOUNT ON
	DECLARE @cancelado AS BIT
	DECLARE @FechaAceptada AS DATETIME

	BEGIN TRY
		SELECT @FechaAceptada = HoraEntrada, @cancelado = Cancelado FROM Citas WHERE Cita_id = @id_cita

		IF @cancelado = 1
			THROW 50001,'Cita Ya cancelada',1
		IF @FechaAceptada IS NOT NULL
			THROW 50002, 'Cita ya estaba aceptada',1
		IF @cancelado IS NULL
			THROW 50003,'No existe cita con ese id',1

		UPDATE citas
		SET HoraEntrada = GETDATE()
		WHERE cita_id = @id_cita
	END TRY
	BEGIN CATCH
		THROW
	END CATCH
END
GO

CREATE PROCEDURE INSERTAR_CITA
(@EmpleadoID BIGINT,@Telefono NCHAR(12),@TipoServicio INT,@Contacto NVARCHAR(64),@HoraProgramada DATETIME)
AS BEGIN
	SET NOCOUNT ON
	INSERT INTO Citas (FechaRegistro,Empleado_id,Telefono,TiposServicio,Contacto,HoraProgramada) VALUES
	(getdate(),@EmpleadoID,@Telefono,@TipoServicio,@Contacto,@HoraProgramada)
END

GO

CREATE PROCEDURE MODIFICAR_CITA
(@citaID BIGINT,@Telefono NCHAR(12),@TipoServicio INT,@Contacto NVARCHAR(64),@HoraProgramada DATETIME)
AS BEGIN
	SET NOCOUNT ON
	UPDATE citas
	SET Telefono = @Telefono,Contacto = @Contacto, TiposServicio = @TipoServicio,HoraProgramada = @HoraProgramada
	WHERE Cita_id = @citaID
END

GO
CREATE PROCEDURE ELIMINAR_CITA
(@Cita_id BIGINT)
AS BEGIN
	DECLARE @Entrada DATETIME
	DECLARE @Cancelado BIT
	SELECT @Entrada = HoraEntrada, @Cancelado = Cancelado FROM Citas WHERE Cita_id = @Cita_id
	BEGIN TRY	
		--No dejar si no existe
		IF @Cancelado IS NULL
			THROW 50003,'No existe cita con ese id',1 
		--No dejar si ya hubo entrada
		IF @Entrada IS NOT NULL
			THROW 50012,'No se puede eliminar cita con entrada',1
		--No dejar si est・cancelada
		IF @Cancelado = 1
			THROW 50011,'No se puede eliminar cita cancelada',1

		DELETE FROM Citas
		WHERE Cita_id = @Cita_id
	END TRY
	BEGIN CATCH
		THROW
	END CATCH
END

GO
CREATE PROCEDURE CANCELAR_CITA
(@Cita_id BIGINT)
AS BEGIN
	DECLARE @Entrada DATETIME
	DECLARE @Cancelado BIT
	SELECT @Entrada = HoraEntrada, @Cancelado = Cancelado FROM Citas WHERE Cita_id = @Cita_id
	BEGIN TRY	
		--No dejar si no existe
		IF @Cancelado IS NULL
			THROW 50003,'Cita No existe',1 
		--No dejar si ya hubo entrada
		IF @Entrada IS NOT NULL
			THROW 50012,'No se puede Cancelar cita con entrada',1
		--No dejar si est・cancelada
		IF @Cancelado = 1
			THROW 50011,'Cita ya estaba cancelada',1

		UPDATE Citas
		SET Cancelado = 1
		WHERE Cita_id = @Cita_id
	END TRY
	BEGIN CATCH
		THROW
	END CATCH
END

GO
CREATE PROCEDURE ACTIVAR_CITA
(@Cita_id BIGINT)
AS BEGIN
	DECLARE @Cancelado BIT
	SELECT @Cancelado = Cancelado FROM Citas WHERE Cita_id = @Cita_id
	BEGIN TRY	
		--No dejar si no existe
		IF @Cancelado IS NULL
			THROW 50003,'Cita No existe',1 
		--No dejar si est・cancelada
		IF @Cancelado = 0
			THROW 50011,'Cita ya estaba activada',1

		UPDATE Citas
		SET Cancelado = 0
		WHERE Cita_id = @Cita_id
	END TRY
	BEGIN CATCH
		THROW
	END CATCH
END
