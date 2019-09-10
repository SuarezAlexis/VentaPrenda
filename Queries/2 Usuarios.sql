/*
-- Query: SELECT * FROM Usuario
LIMIT 0, 1000

-- Date: 2019-08-29 12:05
*/
INSERT INTO `Usuario` (`ID`,`Nombre`,`Username`,`Password`,`Bloqueado`,`IntentosFallidos`,`UltimoIngreso`) VALUES (1,'Usuario de desarrollo','dev','tuc1aXUxAUY2EXHP/k6Bew==',b'0',0,'2019-08-29 11:10:36');
INSERT INTO `Usuario` (`ID`,`Nombre`,`Username`,`Password`,`Bloqueado`,`IntentosFallidos`,`UltimoIngreso`) VALUES (2,'Administrador del sistema','admin','tuc1aXUxAUY2EXHP/k6Bew==',b'0',0,'2019-08-27 18:19:24');
INSERT INTO `Usuario` (`ID`,`Nombre`,`Username`,`Password`,`Bloqueado`,`IntentosFallidos`,`UltimoIngreso`) VALUES (3,'Usuario','user','tuc1aXUxAUY2EXHP/k6Bew==',b'0',0,'2019-08-26 11:15:28');

INSERT INTO Perfil(ID,Nombre,Permisos) VALUES(1,'Desarrollo',262143),(2,'Admin',247848),(3,'Notas',30723);

INSERT INTO Perfil_Usuario(Perfil,Usuario) VALUES(1,1),(2,2),(3,3);


