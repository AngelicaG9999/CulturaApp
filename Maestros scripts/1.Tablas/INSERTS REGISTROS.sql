
-- Insertando 5 registros en la tabla Comuna 
INSERT INTO [dbo].[Comuna] ([EmpresaID], [Nombre], [Descripcion])
VALUES 
(80063, 'Popular', 'Comuna ubicada al sur de Medell�n, conocida por su car�cter tradicional y el comercio local.'),
(80063, 'Santa Cruz', 'Comuna situada al nororiente de Medell�n, con una fuerte identidad barrial y un importante desarrollo comercial.'),
(80063, 'Manrique', 'Comuna del oriente de Medell�n, con un crecimiento urbano y un car�cter residencial y comercial.'),
(80063, 'Aranjuez', 'Comuna al norte de Medell�n, famosa por su cercan�a a parques y zonas industriales.'),
(80063, 'Castilla', 'Comuna de la zona occidental de Medell�n, conocida por su tradici�n cultural, vida urbana y comercio.');

-- Insertando 5 registros en la tabla Barrio 
INSERT INTO [dbo].[Barrio] ([EmpresaID], [ComunaID], [Nombre], [Descripcion])
VALUES 
(80063, 2, 'El Trapiche', 'Barrio tradicional de la Comuna Popular, conocido por su mercado local y su ambiente residencial.'),
(80063, 3, 'La Sierra', 'Barrio ubicado en la Comuna Santa Cruz, conocido por sus viviendas y comercio local, con un paisaje monta�oso.'),
(80063, 4, 'Manrique Norte', 'Barrio en la Comuna Manrique, caracterizado por su vida comercial y su cercan�a con el Parque de los Deseos.'),
(80063, 5, 'Aranjuez Norte', 'Barrio en la Comuna Aranjuez, conocido por su fuerte actividad comercial y su cercan�a con la zona industrial de Medell�n.'),
(80063, 6, 'La Floresta', 'Barrio en la Comuna Castilla, conocido por su ambiente residencial, su comercio local y su acceso a servicios p�blicos.');

-- Insertando 5 registros en la tabla Edificio 
INSERT INTO [dbo].[Edificio] ([EmpresaID], [BarrioID], [Nombre], [Direccion])
VALUES 
(80063, 2, 'Edificio Trapiche Tower', 'Calle 50 # 80-25, Comuna Popular'),
(80063, 3, 'Edificio Sierra Suites', 'Carrera 35 # 90-10, Comuna Santa Cruz'),
(80063, 4, 'Edificio Manrique Plaza', 'Avenida San Juan # 90-20, Comuna Manrique'),
(80063, 5, 'Edificio Aranjuez 360', 'Calle 75 # 70-30, Comuna Aranjuez'),
(80063, 6, 'Edificio La Floresta Plaza', 'Carrera 80 # 30-10, Comuna Castilla');

-- Insertando 5 registros en la tabla Sala 
INSERT INTO [dbo].[Sala] ([EmpresaID], [EdificioID], [Nombre], [Capacidad], [Descripcion])
VALUES 
(80063, 1, 'Sala El Trapiche', 50, 'Sala de conferencias moderna ubicada en el Edificio Trapiche Tower. Ideal para eventos corporativos y presentaciones.'),
(80063, 2, 'Sala Sierra Lounge', 35, 'Sala lounge de descanso y reuniones en el Edificio Sierra Suites. Equipado con c�modos asientos y tecnolog�a avanzada para videoconferencias.'),
(80063, 3, 'Sala Manrique Creativa', 25, 'Espacio creativo en el Edificio Manrique Plaza, dise�ado para actividades colaborativas y sesiones de brainstorming.'),
(80063, 4, 'Sala Aranjuez 360', 40, 'Sala de reuniones con vista panor�mica en el Edificio Aranjuez 360. Perfecta para talleres, seminarios y sesiones de equipo.'),
(80063, 5, 'Sala La Floresta', 30, 'Sala moderna y elegante en el Edificio La Floresta Plaza. Espacio ideal para reuniones ejecutivas y capacitaciones corporativas.');

-- Insertando 5 registros en la tabla Evento 
INSERT INTO [dbo].[Evento] ([EmpresaID], [SalaID], [Nombre], [FechaHora], [Lugar], [Direccion])
VALUES 
(80063, 6, 'Conferencia de Innovaci�n', '2024-12-15 09:00', 'Centro de Convenciones Trapiche', 'Calle 50 # 80-25, Comuna Popular'),
(80063, 7, 'Reuni�n Corporativa Internacional', '2024-12-16 11:00', 'Sierra Suites Lounge', 'Carrera 35 # 90-10, Comuna Santa Cruz'),
(80063, 8, 'Taller de Creatividad y Liderazgo', '2024-12-17 10:00', 'Manrique Plaza Creativa', 'Avenida San Juan # 90-20, Comuna Manrique'),
(80063, 9, 'Seminario sobre Nuevas Tecnolog�as', '2024-12-18 13:00', 'Aranjuez 360 - Sala de Innovaci�n', 'Calle 75 # 70-30, Comuna Aranjuez'),
(80063, 10, 'Cumbre Empresarial 2024', '2024-12-19 15:00', 'La Floresta Plaza', 'Carrera 80 # 30-10, Comuna Castilla');


