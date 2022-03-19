--Activar la Base de Datos
USE bdZOO
GO

-- Gestionar registros mediante los procedimientos Almacenados


-- Alimentacion
-- Alimentacion INSERTAR
EXEC SP_Alimentacion_INSERTAR 'Herbívoro','raíces, cortezas de árboles y arbustos, frutas y tallos'
EXEC SP_Alimentacion_INSERTAR 'Carnívoro','grandes trozos de carne fresca de vaca'
-- Alimentacion ACTUALIZAR
EXEC SP_Alimentacion_ACTUALIZAR 6, 'Herbívoro', 'raíces, cortezas de árboles y arbustos, frutas y tallos'
-- Alimentacion ELIMINAR
EXEC SP_Alimentacion_ELIMINAR
-- Alimentacion LISTAR
EXEC SP_Alimentacion_LISTAR
-- Alimentacion LISTAR BUSCAR
EXEC SP_Alimentacion_LISTAR_BUSCAR ALI

-- Usuario
-- Usuario INSERTAR
EXEC SP_Usuario_INSERTAR 'arturo', 'Arturo Mendoza Gómez','123', 'Administrador', 'A','00123445', '92143211', 'arturokl@gmail.com'
EXEC SP_Usuario_INSERTAR 'carlos', 'Carlos José Vasquez Abril', '123', 'Auxiliar', 'I', '00123415', '92143213', 'carlos15@gmail.com'
EXEC SP_Usuario_INSERTAR 'pedro', 'Pedro Raul Ponce Lopez', '3245', 'Auxiliar', 'A', '00123430', '92345287','pedro24@gmail.com'
-- Usuario ACTUALIZAR
EXEC SP_Usuario_ACTUALIZAR 1, 'arturo', '12345', 'Administrador', 'A','00123445', '92143211', 'arturokl@gmail.com'
EXEC SP_Usuario_ACTUALIZAR 1, 'carlos', 'Carlos José Vasquez Abril', '123', 'Auxiliar', 'I', '00123415', '92143213', 'carlos15@gmail.com'
-- Usuario ELIMINAR
EXEC SP_Usuario_ELIMINAR 1
-- Usuario LISTAR
EXEC SP_Usuario_LISTAR
-- Usuario ACTIVAR
EXEC SP_Usuario_ACTIVAR 1
-- Usuario LISTAR BUSCAR
EXEC SP_Usuario_LISTAR_BUSCAR 'arturo'


-- Actividad
-- Actividad INSERTAR
EXEC SP_Actividad_INSERTAR 1,'Nacimiento de Animales', 'Identificar animales recientemente nacidos' 
-- Actividad ACTUALIZAR
EXEC SP_Actividad_ACTUALIZAR 1,1,'Nacimiento de Animales', 'Identificar animales recientemente nacidos' 
-- Actividad ELIMINAR
EXEC SP_Actividad_ELIMINAR 1
-- Actividad LISTAR
EXEC SP_Actividad_LISTAR
-- Actividad LISTAR BUSCAR
EXEC SP_Actividad_LISTAR_BUSCAR 'carlos'
-- Actividad LISTAR AUXILIARES
EXEC SP_Usuario_LISTAR_AUXILIARES

-- Habitat Especie
-- Habitat Especie INSERTAR
EXEC SP_Habitat_Especie_INSERTAR 1, 'Savana Africana', 'Savana'
-- Habitat Especie ACTUALIZAR
EXEC SP_Habitat_Especie_ACTUALIZAR 
-- Habitat Especie ELIMINAR
EXEC SP_Habitat_Especie_ELIMINAR 2
-- Habitat Especie LISTAR
EXEC SP_Habitat_Especie_LISTAR
-- Habitat Especie LISTAR ACTIVIDADES
EXEC SP_Habitat_Especie_LISTAR_ACTIVIDADES
-- Habitat Especie LISTAR BUSCAR
EXEC SP_Habitat_Especie_LISTAR_BUSCAR

-- Especie
-- Especie INSERTAR
EXEC SP_Especie_INSERTAR
-- Especie ACTUALIZAR
EXEC SP_Especie_ACTUALIZAR
-- Especie ELIMINAR
EXEC SP_Especie_ELIMINAR 1
-- Especie LISTAR
EXEC SP_Especie_LISTAR
-- Especie LISTAR HABITATS
EXEC SP_Especie_LISTAR_HABITATS
-- Especie LISTAR ALIMENTACIONES
EXEC SP_Especie_LISTAR_ALIMENTACIONES
-- Especie LISTAR BUSCAR
EXEC SP_Especie_LISTAR_BUSCAR Elefante

-- Animal
-- Animal INSERTAR
EXEC SP_Animal_INSERTAR 1, 'Grandulón', 'Macho', '12/08/2021', 'Zoológico Huachipa', 'No'
-- Animal ACTUALIZAR
EXEC SP_Animal_ACTUALIZAR
-- Animal ELIMINAR
EXEC SP_Animal_ELIMINAR 1
-- Animal LISTAR
EXEC SP_Animal_LISTAR 
-- Animal LISTAR ESPECIES
EXEC SP_Animal_LISTAR_ESPECIES
-- Animal LISTAR BUSCAR
EXEC SP_Especie_LISTAR_BUSCAR Elefante