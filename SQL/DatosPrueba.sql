use Consultorio

--Puestos
BEGIN TRANSACTION TCREACION
BEGIN TRY
	INSERT INTO Puestos (PuestoNombre, SalarioBase, NivelAcceso) 
	VALUES  ('Conserje','2500',0),
			('Recepcionista','8000', 1), 
			('Practicante','4000', 1),
			('Control Inventarios','14000', 2),
			('Medico','19000', 3),
			('Director','30000', 4),
			('Administrador', '17000', 5)

	--Servicios
	INSERT INTO TiposServicio (Descripcion, PrecioBase, DuracionProm)
	VALUES  ('Consulta general', 50, 20),
			('Analisis de orina', 120, 10),
			('Radiografia', 250, 10)

	--Especialidad
	INSERT INTO Especialidades(Nombre)
	VALUES  ('Medico Familiar'),
			('Biomedico'),
			('Urologo'),
			('Radiologo')

	--Empleado
	INSERT INTO Empleados (Usuario, Pass, Nombre, Apellidos, FechaNacimiento, FechaContratado, Salario, Telefono, CodigoPostal, Calle, NumeroExterior, NumeroInterior, Puesto_id, CURP, HoraEntrada, HoraSalida)
	VALUES  ('Julian', '123', 'Julian Enrique', 'Ramirez Garza', '2002-12-28', ('2022-01-17'), 17000, 8127724359, 66636, 'Pinos', '#105', null, 7, 'RAGJ021228HNLMRLA5',  ('12:00:00.0000000'), ('19:00:00.0000000')),
			('Pedro', '4598', 'Pedro', 'Marquez Simental', '1984-08-17', ('2022-03-08'), 19000, 8156324598, 55874, 'Magnolias', '#87', null, 5, 'MASP840817HMXR',  ('07:00:00.0000000'), ('19:00:00.0000000')),
			('Antonio', '043', 'Antonio Eduardo', 'Estrada Mancilla', '1995-02-26', ('2020-01-02'), 8000, 8564972519, 57668, 'Nogales', '#348', null, 2, 'ESMA950226HOXMRT8',  ('06:00:00.0000000'), ('18:00:00.0000000')),
			('Roberto', '558', 'Roberto', 'Padilla Tobar', '1986-05-13', ('2022-02-26'), 14000, 8659481526, 26678, 'Pelicanos', '#208', null, 4, 'PATR860513HPLMRWA8',  ('19:00:00.0000000'), ('7:00:00.0000000')),
			('Maria', '987', 'Maria', 'Gonzalez Hernandez', '2001-09-03', ('2022-02-19'), 4000, 8110814795, 65126, 'Enramada', '#267', null, 5, 'GOHM010903MNLMTYA5',  ('12:05:06.0000000'), ('19:05:06.0000000'))

	--Doctor
	INSERT INTO Doctores (Empleado_Id, Cedula, Especialidad_id)
	VALUES	(2, 655492, 4)

	--Especialidad-Servicio (NO PIENSO HACERLO)
	INSERT INTO Especialidad_Servicio (Especialidad_id, TipoServicio_id, Prioridad)
	VALUES (1, 1, 1)

	--Citas
	INSERT INTO Citas (FechaRegistro, Empleado_id, Telefono, Contacto, TiposServicio, HoraProgramada)
	VALUES  ('2022-05-01 13:00:00.000',3, 8478651232, 'jaime_rdz@gmail.com', 1, '2022-05-01 15:00:00.000'),
			('2022-05-02 13:40:00.000',3, 8569471235, 'JuaMan.MTZ@gmail.com', 2, '2022-05-02 18:40:00.000'),
			('2022-05-03 15:15:00.000',3, 8478651232, 'jaime_rdz@gmail.com', 3, '2022-05-03 17:15:00.000'),
			('2022-05-04 07:45:00.000',3, 8547962132, 'EdRiver_03@hotmail.com',2 , '2022-05-04 09:45:00.000'),
			('2022-05-05 10:27:00.000',3, 8257852545, 'Diego_Knela@gmail.com', 1, '2022-05-05 13:27:00.000')

	--Pacientes
	INSERT INTO Pacientes VALUES('GOTA820521HVZMLP02', 'Arturo', 'Gomez Tamayo', '8147238421', '1972-08-19')
	INSERT INTO Pacientes VALUES('AUAM630703HGTGRR02', 'Martin', 'Aguirre Arriaga', '8146328840', '1990-01-25')
	INSERT INTO Pacientes VALUES('HEMJ820709MMIRNS08', 'Jose', 'Hernandez Mendoza', '8157228491', '1984-12-09')
	INSERT INTO Pacientes VALUES('ZUNA540308MNELTN05', 'Angeline', 'Zuleyka Netan', '8185931124', '1998-04-30')
	INSERT INTO Pacientes VALUES('SASO750909HDFNNS05', 'Oscar', 'Sachez Santos', '8174392946', '1965-09-07')

	--Apartado B
	insert into [dbo].[Reporte] (Empleado_id, Cita_id, Paciente_id, Fecha, Diagnostico, Altura, Peso) values 
	(2, 1,'GOTA820521HVZMLP02', '2022-04-26', 'Cancer', 1.80, 100), 
	(2, 2,'AUAM630703HGTGRR02', '2022-03-12', 'Gripa', 1.58, 60), 
	(2, 3,'HEMJ820709MMIRNS08', '2022-03-27', 'Conjuntivitis', 1.88, 70), 
	(2, 4,'ZUNA540308MNELTN05', '2022-04-23', 'Fractura', 1.74, 89), 
	(2, 5,'SASO750909HDFNNS05', '2022-05-30', 'Colesterol Alto', 1.82, 130)


	insert into [dbo].[Observaciones] (Reporte_id, Observacion) values 
	(1, 'Poco desarrollado, muy tratable'), 
	(2, 'Dejo pasasr mucho tiempo la gripa, se preescribio medicamento fuerte'), 
	(3, 'Zona externa del ojo muy afectada'), 
	(4, 'Se encargo rayos X y yeso en la zona'), 
	(5, 'Se recomienda hacer ejercicios y medicamentos hasta bajarlo')



	insert into [dbo].[Medicamentos] (Nombre) values 
	('Paracetamol'), 
	('Simvastatina'), 
	('Aspirina'), 
	('Omeprazol'), 
	('Ramipril'), 
	('Amlodipina'), 
	('Tramadol')



	insert into [dbo].[Receta_conceptos] (Reporte_id, Medicamento_id, Cantidad) values 
	(1, 7, 1), 
	(2, 1, 2),
	(3, 1, 6), 
	(4, 7, 2), 
	(5, 2, 4)


	--Apartado A
	INSERT INTO TiposCondicion(NombreCondicion)
	VALUES 
	('Artritis'),
	('Fractura'), 
	('Conjuntivitis'),
	('Asma'),
	('Gripa'),
	('Cancer'),
	('Diabetes'),
	('Colesterol alto'),
	('Enfermedad del Corazon')


	INSERT INTO Condicion_Pac (Descripcion, FechaInicio, TipoCondicion_id, Paciente_id)
	VALUES ('Sufre de Artritis con dolor moderado', '2021-09-30', '1', 'GOTA820521HVZMLP02')
	INSERT INTO Condicion_Pac (Descripcion, FechaInicio, TipoCondicion_id, Paciente_id)
	VALUES ('Dolor punzante en el torax', '2022-04-29', '5', 'AUAM630703HGTGRR02')
	INSERT INTO Condicion_Pac (Descripcion, FechaInicio, TipoCondicion_id, Paciente_id)
	VALUES ('Insuficiencia respiratoria, necesidad de inhalador', '2021-05-03', '2', 'HEMJ820709MMIRNS08')
	INSERT INTO Condicion_Pac (Descripcion, FechaInicio, TipoCondicion_id, Paciente_id)
	VALUES ('Posible tumor en pulmon, revision necesaria', '2021-05-01', '3', 'ZUNA540308MNELTN05')
	INSERT INTO Condicion_Pac (Descripcion, FechaInicio, TipoCondicion_id, Paciente_id)
	VALUES ('Revisión por bajos niveles de azucar', '2021-05-14', '4', 'SASO750909HDFNNS05')


	INSERT INTO Adeudos(FechaExpedido, NumeroTarjeta, empleado_id, Precio, IVA, CURP_Paciente, Cita_id)
	VALUES	('2022-05-12', '4332758319305331', 3, 50, (50*.16), 'GOTA820521HVZMLP02', 2),
			('2022-05-13', '6372849204821840', 3, 120, (120*.16), 'AUAM630703HGTGRR02', 1),
			('2022-05-14', '6492018493621195', 3, 250, (250*.16), 'HEMJ820709MMIRNS08', 3),
			('2022-05-15', '4720475932057692', 3, 120, (120*.16), 'ZUNA540308MNELTN05', 5),
			('2022-05-16', '4729442947210403', 3, 50, (50*.16), 'SASO750909HDFNNS05', 4)

	INSERT INTO Pago (Monto, Fecha, NumeroTransaccion, Adeudo_id)
	VALUES	('58', '2022-05-12', NULL, 1),
			('139', '2022-05-13', NULL, 2),
			('290', '2022-05-14', NULL, 3),
			('139', '2022-05-15', NULL, 4),
			('58', '2022-05-16', NULL, 5)


	--Apartado C
	insert into [dbo].[Proveedores] (Nombre, Telefono, Correo, Direccion) 
	values  ('Profarma', '8115569642', 'profarma@yahoo.com', 'Gonzales Camarena #451'), 
			('Astrazeneca', '8156845232', 'aztra@gmail.com', 'bolivia #206'), 
			('Novartis', '8169364525', 'novartis@hotmail.com', 'los olivos #380'), 
			('boehringer', '8145756325', 'boeh@yahoo.com', 'Manzano #108'), 
			('Pfizer', '8153264845', 'pfizer', 'Fresnos #47')

	insert into [dbo].[Catalogo_Insumos] (Descripcion) 
	values  ('Algodon'), 
			('Tubos de ensayo'), 
			('Hilo dental'), 
			('Hojas de maquina'), 
			('Tiras de pH')

	insert into [dbo].[Insumo_Proveedor] (Insumo_id, Proveedor_id, Cantidad, Precio) values 
	(1, 5, 250, 15), 
	(2, 2, 10, 160), 
	(3, 4, 75, 10), 
	(4, 3, 500, 1), 
	(5, 1, 40, 5), 
	(2, 4, 10, 160)


	insert into [dbo].[OrdenCompra] (Proveedor_id, Fecha) 
	values  (1, '2022-02-04'), 
			(2, '2022-03-14'), 
			(3, '2022-02-26'), 
			(4, '2022-04-22'), 
			(5, '2022-03-17')

	insert into [dbo].[Inventario] (Insumo_id, Cantidad, Orden_id, Caducidad)
	values  (1, 180, 1, '2024-08-04'),
			(2, 150, 2, '2050-09-15'),
			(3, 200, 3, '2026-01-23'),
			(4, 150, 4, null),
			(5, 150, 5, '2024-09-24')

	insert into [dbo].[OrdenCompra_Conceptos] (Orden_id, Insumo_id, Cantidad, Costo, IVA)
	VALUES  (1, 1, 50, 600, (600*0.16)),
			(2, 2, 50, 200, (200*0.16)),
			(3, 3, 25, 800, (800*0.16)),
			(4, 4, 70, 55, (55*0.16)),
			(5, 5, 80, 98, (98*0.16))

	INSERT INTO Adeudo_Insumos
	VALUES	(1, 4, '2'),
			(2, 3, '1'),
			(3, 5, '3'),
			(4, 1, '4'),
			(5, 2, '1')
	COMMIT TRANSACTION TCREACION
END TRY

BEGIN CATCH
	SELECT ERROR_MESSAGE() AS Error
	ROLLBACK TRANSACTION TCREACION
END CATCH