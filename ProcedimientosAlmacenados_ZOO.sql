--Activar la Base de Datos
USE bdZOO
GO

--Creacion de Procedimientos Almacenados

--Procedimientos Almacenados para Alimentacion
-- 1.Insertar Alimentacion

CREATE PROCEDURE SP_Alimentacion_INSERTAR
	@pclasificacion_alimentaria varchar(100),
	@pdescripcion text
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            INSERT INTO dbo.Alimentacion
	        VALUES (@pclasificacion_alimentaria, @pdescripcion)
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 2.Actualizar Alimentacion

CREATE PROCEDURE SP_Alimentacion_ACTUALIZAR
    @pid_alimentacion int,
	@pclasificacion_alimentaria varchar(100),
	@pdescripcion text
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Alimentacion SET
			clasificacion_alimentaria = @pclasificacion_alimentaria,
			descripcion = @pdescripcion
			WHERE id_alimentacion = @pid_alimentacion
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 3.Eliminar Alimentacion

CREATE PROCEDURE SP_Alimentacion_ELIMINAR
     @pid_alimentacion int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            DELETE FROM dbo.Alimentacion 
			WHERE id_alimentacion = @pid_alimentacion
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.Listar Todas las Alimentacion

CREATE PROCEDURE SP_Alimentacion_LISTAR

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Alimentacion
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.Listar Todas las Alimentacion que coincidan con un parametro de busqueda

CREATE PROCEDURE SP_Alimentacion_LISTAR_BUSCAR
    @pbusqueda varchar(100)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Alimentacion
			WHERE nombre LIKE @pbusqueda + '%' OR id_alimentacion LIKE @pbusqueda + '%'
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 6.Verificar Alimentacion
CREATE PROCEDURE SP_Alimentacion_VERIFICAR
	@pvalor text,
	@pexiste bit output
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (
			SELECT descripcion FROM dbo.Alimentacion
			WHERE descripcion LIKE @pvalor
			)
			BEGIN
				SET @pexiste = 1
			END
			ELSE
			BEGIN
				SET @pexiste = 0
			END
		COMMIT 
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

--Procedimientos Almacenados para usuario
-- 1.Insertar Usuario

CREATE PROCEDURE SP_Usuario_INSERTAR
	@pnombre_usuario varchar(30),
	@pnombre_completo varchar(140),
    @pclave varchar(100),
    @prol varchar(20),
    @pestado char(1),
	@pdni varchar(8),
    @pcelular varchar(15),
    @pemail varchar(250)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            INSERT INTO dbo.Usuario
	        VALUES (@pnombre_usuario, @pnombre_completo, @pclave, @prol, @pestado, @pdni, @pcelular, @pemail)
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 2.Actualizar Usuario

CREATE PROCEDURE SP_Usuario_ACTUALIZAR
    @pid_usuario int,
	@pnombre_usuario varchar(30),
	@pnombre_completo varchar(140),
    @pclave varchar(100),
    @prol varchar(20),
    @pestado char(1),
	@pdni varchar(8),
    @pcelular varchar(15),
    @pemail varchar(250)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Usuario SET
            nombre_usuario = @pnombre_usuario,
			nombre_completo = @pnombre_completo,
            clave = @pclave,
            rol = @prol,
            estado = @pestado,
			dni = @pdni,
			celular = @pcelular,
			email = @pemail
			WHERE id_usuario = @pid_usuario
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 3.Eliminar Usuario

CREATE PROCEDURE SP_Usuario_ELIMINAR
    @pid_usuario int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            DELETE FROM dbo.Usuario 
			WHERE id_usuario = @pid_usuario
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.Listar Todas los Usuarios
CREATE PROCEDURE SP_Usuario_LISTAR

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Usuario
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.Listar Todos los Usuarios que coincidan con un parametro de busqueda
CREATE PROCEDURE SP_Usuario_LISTAR_BUSCAR
    @pbusqueda varchar(50)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Usuario
			WHERE nombre_usuario LIKE @pbusqueda + '%'
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.1 Listar Todos los Usuarios que coincidan con un parametro de busqueda
CREATE PROCEDURE SP_Usuario_LISTAR_BUSCAR_ID
    @pbusqueda varchar(50)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Usuario
			WHERE nombre_usuario LIKE @pbusqueda + '%'
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 6.Activar Usuario

CREATE PROCEDURE SP_Usuario_ACTIVAR
    @pid_usuario int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Usuario SET
			estado = 'A'
			WHERE id_usuario = @pid_usuario
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO


-- 7.Desactivar Usuario

CREATE PROCEDURE SP_Usuario_DESACTIVAR
    @pid_usuario int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Usuario SET
			estado = 'I'
			WHERE id_usuario = @pid_usuario
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 8.Verificar Usuario
CREATE PROCEDURE SP_Usuario_VERIFICAR
	@pvalor varchar(30),
	@pexiste bit output
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (
			SELECT nombre_usuario FROM Usuario 
			WHERE nombre_usuario = LTRIM(RTRIM(@pvalor))
			)
			BEGIN
				SET @pexiste = 1
			END
			ELSE
			BEGIN
				SET @pexiste = 0
			END
		COMMIT 
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

-- 9. Login de Usuarios
CREATE PROCEDURE SP_Usuario_LOGIN
	@pnombre_usuario varchar(30),
	@ppassword varchar(100)
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			SELECT u.id_usuario, u.nombre_usuario, u.rol, u.estado 
			FROM dbo.Usuario as u
			WHERE u.nombre_usuario = @pnombre_usuario AND u.clave = @ppassword 
		COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

--Procedimientos Almacenados para Actividad
-- 1.Insertar Actividad

CREATE PROCEDURE SP_Actividad_INSERTAR
    @pid_usuario int,
	@pnombre varchar(100),
    @pdescripcion text
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            INSERT INTO dbo.Actividad
	        VALUES (@pid_usuario, @pnombre, @pdescripcion)
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 2.Actualizar Actividad

CREATE PROCEDURE SP_Actividad_ACTUALIZAR
	@pid_actividad int,
	@pid_usuario varchar(50),
	@pnombre varchar(100),
    @pdescripcion text
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Actividad SET
	        id_usuario = @pid_usuario,
			nombre = @pnombre,
			descripcion = @pdescripcion
			WHERE id_actividad = @pid_actividad
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 3.Eliminar Actividad

CREATE PROCEDURE SP_Actividad_ELIMINAR
     @pid_actividad int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            DELETE FROM dbo.Actividad
			WHERE id_actividad = @pid_actividad
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.Listar Todas las Actividades

CREATE PROCEDURE SP_Actividad_LISTAR

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_actividad, nombre_usuario, nombre, descripcion FROM dbo.Actividad
			INNER JOIN dbo.Usuario ON dbo.Actividad.id_usuario LIKE dbo.Usuario.id_usuario
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.2 Listar Auxiliares
CREATE PROCEDURE SP_Usuario_LISTAR_AUXILIARES

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_usuario, nombre_usuario FROM dbo.Usuario
			WHERE rol LIKE 'Auxiliar'
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.Listar Todas las Actividades que coincidan con un parametro de busqueda

CREATE PROCEDURE SP_Actividad_LISTAR_BUSCAR
    @pbusqueda varchar(100)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Actividad
			WHERE nombre LIKE @pbusqueda + '%'
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 6.Verificar Actividad
CREATE PROCEDURE SP_Actividad_VERIFICAR
	@pvalor varchar(100),
	@pexiste bit output
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (
			SELECT nombre FROM dbo.Habitat_Especie
			WHERE nombre = LTRIM(RTRIM(@pvalor))
			)
			BEGIN
				SET @pexiste = 1
			END
			ELSE
			BEGIN
				SET @pexiste = 0
			END
		COMMIT 
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO


--Procedimientos Almacenados para Habitat Especie
-- 1.Insertar Habitat Especie

CREATE PROCEDURE SP_Habitat_Especie_INSERTAR
    @pid_actividad int,
	@pnombre varchar(100),
    @pbioma varchar(150)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            INSERT INTO dbo.Habitat_Especie
	        VALUES (@pid_actividad, @pnombre, @pbioma)
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 2.Actualizar Habitat Especie

CREATE PROCEDURE SP_Habitat_Especie_ACTUALIZAR
    @pid_habitat_especie int,
	@pid_actividad int,
	@pnombre varchar(100),
    @pbioma varchar(150)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Habitat_Especie SET
	        id_actividad = @pid_actividad,
			nombre = @pnombre,
			bioma = @pbioma
			WHERE id_habitat_especie = @pid_habitat_especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 3.Eliminar Habitat Especie

CREATE PROCEDURE SP_Habitat_Especie_ELIMINAR
     @pid_habitat_especie int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            DELETE FROM dbo.Habitat_Especie
			WHERE id_habitat_especie = @pid_habitat_especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.Listar Todas las Habitat Especie

CREATE PROCEDURE SP_Habitat_Especie_LISTAR

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_habitat_especie, dbo.Actividad.nombre, dbo.Habitat_Especie.nombre, bioma FROM dbo.Habitat_Especie
			INNER JOIN dbo.Actividad ON dbo.Habitat_Especie.id_actividad = dbo.Actividad.id_actividad
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.1 Listar Actividades
CREATE PROCEDURE SP_Habitat_Especie_LISTAR_ACTIVIDADES

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_actividad, nombre FROM dbo.Actividad
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.Listar Todas las Habitat Especie que coincidan con un parametro de busqueda

CREATE PROCEDURE SP_Habitat_Especie_LISTAR_BUSCAR
    @pbusqueda varchar(100)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Habitat_Especie
			WHERE nombre LIKE '%' + @pbusqueda + '%' OR bioma = @pbusqueda
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 6.Verificar Habitat Especie
CREATE PROCEDURE SP_Habitat_Especie_VERIFICAR
	@pvalor varchar(100),
	@pexiste bit output
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (
			SELECT nombre FROM dbo.Habitat_Especie
			WHERE nombre = LTRIM(RTRIM(@pvalor))
			)
			BEGIN
				SET @pexiste = 1
			END
			ELSE
			BEGIN
				SET @pexiste = 0
			END
		COMMIT 
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO


--Procedimientos Almacenados para Especie
-- 1.Insertar Especie

CREATE PROCEDURE SP_Especie_INSERTAR
    @pid_habitat_especie int,
    @pid_alimentacion int,
	@pnombre_comun varchar(100),
	@pnombre_cientifico varchar(100),
	@pcategoria varchar(150),
	@pdias_gestacion int,
    @phoras_exhibicion int,
    @phoras_contencion int,
    @pen_extincion char(2)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            INSERT INTO dbo.Especie
	        VALUES (@pid_habitat_especie, @pid_alimentacion, @pnombre_comun, @pnombre_cientifico, 
			@pcategoria, @pdias_gestacion, @phoras_exhibicion, @phoras_contencion, @pen_extincion)
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 2.Actualizar Especie

CREATE PROCEDURE SP_Especie_ACTUALIZAR
    @pid_especie int,
    @pid_habitat_especie int,
    @pid_alimentacion int,
	@pnombre_comun varchar(100),
	@pnombre_cientifico varchar(100),
	@pcategoria varchar(150),
	@pdias_gestacion int,
    @phoras_exhibicion int,
    @phoras_contencion int,
    @pen_extincion char(2)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Especie SET
	        id_habitat_especie = @pid_habitat_especie,
			id_alimentacion = @pid_alimentacion,
			nombre_comun = @pnombre_comun,
			nombre_cientifico = @pnombre_cientifico,
			categoria = @pcategoria,
			dias_gestacion = @pdias_gestacion,
			horas_exhibicion = @phoras_exhibicion,
			horas_contencion = @phoras_contencion,
			en_extincion = @pen_extincion
			WHERE id_especie = @pid_especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 3.Eliminar Especie

CREATE PROCEDURE SP_Especie_ELIMINAR
    @pid_especie int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            DELETE FROM dbo.Especie 
			WHERE id_especie = @pid_especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.Listar Todas las Especies

CREATE PROCEDURE SP_Especie_LISTAR

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_especie, dbo.Habitat_Especie.nombre, dbo.Alimentacion.nombre, nombre_comun, nombre_cientifico, 
			categoria, dias_gestacion, horas_exhibicion, horas_contencion, en_extincion 
			FROM dbo.Especie 
			INNER JOIN dbo.Habitat_Especie ON dbo.Especie.id_habitat_especie = dbo.Habitat_Especie.id_habitat_especie 
			INNER JOIN dbo.Alimentacion ON dbo.Especie.id_alimentacion = dbo.Alimentacion.id_alimentacion
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.1 Listar Habitats
CREATE PROCEDURE SP_Especie_LISTAR_HABITATS

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_habitat_especie, nombre FROM dbo.Habitat_Especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.2 Listar Habitats
CREATE PROCEDURE SP_Especie_LISTAR_ALIMENTACIONES

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_alimentacion, nombre FROM dbo.Alimentacion
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.Listar Todas las Especies que coincidan con un parametro de busqueda

CREATE PROCEDURE SP_Especie_LISTAR_BUSCAR
    @pbusqueda varchar(100)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Especie
			WHERE (nombre_comun LIKE '%' + @pbusqueda + '%' OR nombre_cientifico = @pbusqueda) OR (categoria LIKE '%' + @pbusqueda + '%')
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 6.Verificar Especie
CREATE PROCEDURE SP_Especie_VERIFICAR
	@pvalor varchar(100),
	@pexiste bit output
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (
			SELECT nombre_cientifico FROM Especie 
			WHERE nombre_cientifico = LTRIM(RTRIM(@pvalor))
			)
			BEGIN
				SET @pexiste = 1
			END
			ELSE
			BEGIN
				SET @pexiste = 0
			END
		COMMIT 
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO


--Procedimientos Almacenados para Animal
-- 1.Insertar Animal

CREATE PROCEDURE SP_Animal_INSERTAR
    @pid_especie int,
    @pnombre varchar(100),
	@psexo char(10),
	@pfecha_obtencion varchar(50),
    @plugar_origen varchar(150),
    @pen_prestamo char(2)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            INSERT INTO dbo.Animal
	        VALUES (@pid_especie, @pnombre, @psexo, @pfecha_obtencion, @plugar_origen, @pen_prestamo)
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 2.Actualizar Animal

CREATE PROCEDURE SP_Animal_ACTUALIZAR
    @pid_animal int,
    @pid_especie int,
    @pnombre varchar(100),
	@psexo char(10),
	@pfecha_obtencion varchar(50),
    @plugar_origen varchar(150),
    @pen_prestamo char(2)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            UPDATE dbo.Animal SET
	        id_especie = @pid_especie,
			nombre = @pnombre,
			sexo = @psexo,
			fecha_obtencion = @pfecha_obtencion,
			lugar_origen = @plugar_origen,
			en_prestamo = @pen_prestamo
			WHERE id_animal = @pid_animal
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 3.Eliminar Animal

CREATE PROCEDURE SP_Animal_ELIMINAR
    @pid_animal int
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            DELETE FROM dbo.Animal 
			WHERE id_animal = @pid_animal
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.Listar Todos los Animales

CREATE PROCEDURE SP_Animal_LISTAR

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_animal, dbo.Especie.nombre_comun, nombre, sexo, fecha_obtencion, lugar_origen, en_prestamo FROM dbo.Animal
			INNER JOIN dbo.Especie ON dbo.Animal.id_especie = dbo.Animal.id_especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 4.1 Listar Especies
CREATE PROCEDURE SP_Animal_LISTAR_ESPECIES

AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT id_especie, nombre_comun FROM dbo.Especie
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 5.Listar Todos los Animales que coincidan con un parametro de busqueda

CREATE PROCEDURE SP_Animal_LISTAR_BUSCAR
    @pbusqueda varchar(100)
AS
BEGIN
    BEGIN TRAN
	    BEGIN TRY
            SELECT * FROM dbo.Animal
			WHERE (nombre LIKE '%' + @pbusqueda + '%' OR sexo = @pbusqueda) OR en_prestamo LIKE '%' + @pbusqueda + '%'
        COMMIT
		END TRY
		BEGIN CATCH
		    ROLLBACK
		END CATCH
END
GO

-- 6.Verificar Animal
CREATE PROCEDURE SP_Animal_VERIFICAR
	@pvalor varchar(100),
	@pexiste bit output
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			IF EXISTS (
			SELECT nombre FROM Animal 
			WHERE nombre = LTRIM(RTRIM(@pvalor))
			)
			BEGIN
				SET @pexiste = 1
			END
			ELSE
			BEGIN
				SET @pexiste = 0
			END
		COMMIT 
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO


