DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Login`(IN p_Username VARCHAR(32), IN p_Password VARCHAR(64))
BEGIN
	UPDATE Usuario SET IntentosFallidos = 0, UltimoIngreso = NOW() WHERE Username = p_Username AND Password = p_Password AND NOT Bloqueado;
    UPDATE Usuario SET Bloqueado = IntentosFallidos > 2, IntentosFallidos = IntentosFallidos + 1, UltimoIngreso = NOW() WHERE Username = p_Username AND Password != p_Password;
    SELECT U.*, (U.Password = p_Password AND NOT Bloqueado) AS Logged, BIT_OR(P.Permisos) AS Permisos FROM Usuario U JOIN Perfil_Usuario PU ON (PU.Usuario = U.ID) JOIN Perfil P ON(PU.Perfil = P.ID) WHERE Username = p_Username;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteCatalogo`(p_ID SMALLINT, p_Cat VARCHAR(16))
BEGIN
	START TRANSACTION;
		SET @select_sql = CONCAT("SELECT * FROM ", p_Cat, " WHERE ID = ", p_ID);
        
		PREPARE selectStmt FROM @select_sql;
		EXECUTE selectStmt;
		DEALLOCATE PREPARE selectStmt;
		
        SET @delete_sql = CONCAT("DELETE FROM ", p_Cat, " WHERE ID = ", p_ID);
        PREPARE deleteStmt FROM @delete_sql;
		EXECUTE deleteStmt;
		DEALLOCATE PREPARE deleteStmt;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteCliente`(p_ID INT)
BEGIN
	START TRANSACTION;
		SELECT * FROM Cliente WHERE ID = p_ID;
		DELETE FROM Cliente WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteDescuento`(p_ID INT)
BEGIN
	START TRANSACTION;
		SELECT * FROM Descuento WHERE ID = p_ID;
		DELETE FROM Descuento WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteMovimiento`(p_ID BIGINT)
BEGIN
	START TRANSACTION;
		SELECT * FROM Movimiento WHERE ID = p_ID;
		DELETE FROM Movimiento WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePerfil`(p_Perfil TINYINT)
BEGIN
	START TRANSACTION;
		DELETE FROM Perfil_Usuario WHERE Perfil = p_Perfil;
		SELECT * FROM Perfil WHERE ID = p_Perfil;
		DELETE FROM Perfil WHERE ID = p_Perfil;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteServicio`(p_ID INT)
BEGIN
	START TRANSACTION;
		SELECT * FROM Servicio WHERE ID = p_ID;
		DELETE FROM Servicio WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteUsuario`(p_ID BIGINT)
BEGIN
	START TRANSACTION;
		SELECT U.*, 0 AS Logged, BIT_OR(P.Permisos) AS Permisos FROM Usuario U JOIN Perfil_Usuario PU ON (PU.Usuario = U.ID) JOIN Perfil P ON(PU.Perfil = P.ID) WHERE U.ID = p_ID;
		DELETE FROM Perfil_Usuario WHERE Usuario = p_ID;
		DELETE FROM Usuario WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdatePerfiles`(p_Usuario BIGINT, p_Perfiles VARCHAR(64))
BEGIN
	IF p_Perfiles IS NULL OR LENGTH(p_Perfiles) = 0 THEN
		DELETE FROM Perfil_Usuario WHERE Usuario = p_Usuario;
    ELSE
		SET @delete_sql = CONCAT('DELETE FROM Perfil_Usuario WHERE Usuario = ', p_Usuario, ' AND Perfil NOT IN(', p_Perfiles ,')');
		SET @insert_sql = 'INSERT IGNORE INTO Perfil_Usuario (Usuario,Perfil) VALUES ';

		PREPARE delStmt FROM @delete_sql;
		EXECUTE delStmt;
		DEALLOCATE PREPARE delStmt;

		WHILE LENGTH(p_Perfiles) > 0 DO
			SET @perfil = SUBSTRING_INDEX(p_Perfiles,',',1);
			SET @insert_sql = CONCAT(@insert_sql, '(',p_Usuario,',',@perfil,'), ');
			SET p_Perfiles = SUBSTR(p_Perfiles, LENGTH(@perfil) + 2, LENGTH(p_Perfiles) - LENGTH(@perfil) - 1);
		END WHILE;
		SET @insert_sql = SUBSTR(@insert_sql, 1, LENGTH(@insert_sql) - 2);
		
		PREPARE insStmt FROM @insert_sql;
		EXECUTE insStmt;
		DEALLOCATE PREPARE insStmt;
	END	IF;
	SELECT P.* FROM Perfil P JOIN Perfil_Usuario PU ON(PU.Perfil = P.ID) WHERE PU.Usuario = p_Usuario;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteNota`(p_ID BIGINT)
BEGIN
	START TRANSACTION;
		DELETE FROM ServicioItem WHERE PrendaItem IN( SELECT ID FROM PrendaItem  WHERE Nota = p_ID );
		DELETE FROM PrendaItem WHERE Nota = p_ID;
        DELETE FROM Pago WHERE Nota = p_ID;
        DELETE FROM Nota WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;
