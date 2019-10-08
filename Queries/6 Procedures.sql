DROP PROCEDURE IF EXISTS sp_Login;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Login`(IN p_Username VARCHAR(32), IN p_Password VARCHAR(64))
BEGIN
	UPDATE Usuario SET IntentosFallidos = 0, UltimoIngreso = NOW() WHERE Username = p_Username AND Password = p_Password AND NOT Bloqueado;
    UPDATE Usuario SET Bloqueado = IntentosFallidos > 2, IntentosFallidos = IntentosFallidos + 1, UltimoIngreso = NOW() WHERE Username = p_Username AND Password != p_Password;
    SELECT U.*, (U.Password = p_Password AND NOT Bloqueado) AS Logged, BIT_OR(P.Permisos) AS Permisos FROM Usuario U JOIN Perfil_Usuario PU ON (PU.Usuario = U.ID) JOIN Perfil P ON(PU.Perfil = P.ID) WHERE Username = p_Username;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_DeleteCatalogo;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteCatalogo`(p_ID SMALLINT, p_Cat VARCHAR(16))
BEGIN
	START TRANSACTION;
		SET @exists_sql = CONCAT("SET @referenced = EXISTS(SELECT * FROM PrendaItem WHERE ", p_Cat," = ", p_ID, ")");
		PREPARE existsStmt FROM @exists_sql;
        EXECUTE existsStmt;
        DEALLOCATE PREPARE existsStmt;

		IF(@referenced) THEN
			SET @update_sql = CONCAT("UPDATE ", p_Cat, " SET Habilitado = 0 WHERE ID = ", p_ID);
			PREPARE updateStmt FROM @update_sql;
			EXECUTE updateStmt;
			DEALLOCATE PREPARE updateStmt;
        END IF;
        
		SET @select_sql = CONCAT("SELECT * FROM ", p_Cat, " WHERE ID = ", p_ID);
		PREPARE selectStmt FROM @select_sql;
		EXECUTE selectStmt;
		DEALLOCATE PREPARE selectStmt;
		
        IF( NOT @referenced) THEN
			IF(p_Cat = "Prenda") THEN
				DELETE FROM Servicio_Prenda WHERE Prenda = p_ID;
			END IF;
			SET @delete_sql = CONCAT("DELETE FROM ", p_Cat, " WHERE ID = ", p_ID);
			PREPARE deleteStmt FROM @delete_sql;
			EXECUTE deleteStmt;
			DEALLOCATE PREPARE deleteStmt;
		END IF;
	COMMIT;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_DeleteCliente;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteCliente`(p_ID INT)
BEGIN
	START TRANSACTION;
		UPDATE Cliente SET Habilitado = 0 WHERE ID = p_ID AND EXISTS(SELECT * FROM Nota WHERE Cliente = p_ID);
		SELECT * FROM Cliente WHERE ID = p_ID;
        IF(NOT EXISTS(SELECT * FROM Nota WHERE Cliente = p_ID)) THEN
			DELETE FROM Cliente WHERE ID = p_ID;
		END IF;
	COMMIT;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteDescuento`(p_ID INT)
BEGIN
	START TRANSACTION;
		UPDATE Descuento SET Habilitado = 0 WHERE ID = p_ID AND (EXISTS(SELECT * FROM ServicioItem WHERE Descuento = p_ID) OR EXISTS(SELECT * FROM Nota WHERE Descuento = p_ID));
		SELECT * FROM Descuento WHERE ID = p_ID;
        IF(NOT (EXISTS(SELECT * FROM ServicioItem WHERE Descuento = p_ID) OR EXISTS(SELECT * FROM Nota WHERE Descuento = p_ID))) THEN
			DELETE FROM Descuento WHERE ID = p_ID;
        END IF;
	COMMIT;
END$$
DELIMITER ;


DROP PROCEDURE IF EXISTS sp_DeleteMovimiento;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteMovimiento`(p_ID BIGINT)
BEGIN
	START TRANSACTION;
		SELECT * FROM Movimiento WHERE ID = p_ID;
		DELETE FROM Movimiento WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_DeletePerfil;
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

DROP PROCEDURE IF EXISTS sp_DeleteServicio;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteServicio`(p_ID INT)
BEGIN
	START TRANSACTION;
		UPDATE Servicio SET Habilitado = 0 WHERE ID = p_ID AND EXISTS(SELECT * FROM ServicioItem WHERE Servicio = p_ID);
		SELECT * FROM Servicio WHERE ID = p_ID;
        IF(NOT EXISTS(SELECT * FROM ServicioItem WHERE Servicio = p_ID)) THEN
			DELETE FROM Servicio_Prenda WHERE Servicio = p_ID;
			DELETE FROM Servicio WHERE ID = p_ID;
		END IF;
	COMMIT;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_DeleteUsuario;
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

DROP PROCEDURE IF EXISTS sp_UpdatePerfiles;
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
		SELECT N.ID NotaID, N.Estatus, N.Cliente ClienteID, C.Nombre ClienteNombre, C.Domicilio, C.Colonia, C.CP, C.Telefono, C.Email, C.Habilitado ClienteHabilitado, Recibido, Entregado, Observaciones, N.Descuento DescuentoID, D.Nombre DescuentoNombre, D.VigenciaInicio, D.VigenciaFin, D.MontoMinimo, D.CantMinima, D.Porcentaje, D.Unidades, D.SoloNota, PI.ID PrendaItemID, PI.Cantidad PrendaItemCantidad, PI.Prenda PrendaID, P.Nombre PrendaNombre, P.Habilitado PrendaHabilitado, PI.TipoPrenda TipoID, T.Nombre TipoNombre, T.Habilitado TipoHabilitado, PI.Color ColorID, Co.Nombre ColorNombre, Co.Habilitado ColorHabilitado, SI.ID ServicioItemID, SI.Cantidad ServicioItemCantidad, SI.Servicio ServicioID, S.Nombre ServicioNombre, S.Descripcion ServicioDescripcion, S.Costo ServicioCosto, S.Habilitado ServicioHabilitado, SI.Monto ServicioItemMonto, SI.Descuento ServicioItemDescuento, D2.Nombre SIDescNombre, D2.VigenciaInicio SIDescVigenciaInicio, D2.VigenciaFin SIDescVigenciaFin, D2.MontoMinimo SIDescMontoMinimo, D2.CantMinima SIDescCantMinima, D2.Porcentaje SIDescPorcentaje, D2.Unidades SIDescUnidades, D2.SoloNota SIDescSoloNota, SI.Encargado EncargadoID, E.Nombre EncargadoNombre, E.Username EncargadoUsername, H.Usuario RecibioID, R.Nombre RecibioNombre, R.Username RecibioUsername FROM Nota N JOIN Cliente C ON(C.ID = N.Cliente) LEFT JOIN Descuento D ON(D.ID = N.Descuento) JOIN PrendaItem PI ON(PI.Nota = N.ID) JOIN Prenda P ON(P.ID = PI.Prenda) LEFT JOIN TipoPrenda T ON(T.ID = PI.TipoPrenda) JOIN Color Co ON(Co.ID = PI.Color) JOIN ServicioItem SI ON(SI.PrendaItem = PI.ID) JOIN Servicio S ON(S.ID = SI.Servicio) LEFT JOIN Descuento D2 ON(D2.ID = SI.Descuento) LEFT JOIN Usuario E ON(E.ID = SI.Encargado) LEFT JOIN DatosHistorial DH ON(DH.Valor = N.ID AND DH.Tabla = 'Nota' AND DH.Columna = 'ID' AND Operacion = 'I') LEFT JOIN Historial H ON(H.ID = DH.Historial) LEFT JOIN Usuario R ON(R.ID = H.Usuario) WHERE N.ID = p_ID;
		DELETE FROM ServicioItem WHERE PrendaItem IN( SELECT ID FROM PrendaItem  WHERE Nota = p_ID );
		DELETE FROM PrendaItem WHERE Nota = p_ID;
        DELETE FROM Pago WHERE Nota = p_ID;
        DELETE FROM Nota WHERE ID = p_ID;
	COMMIT;
END$$
DELIMITER ;



DROP procedure IF EXISTS `sp_ReporteNotas`;
DELIMITER $$
CREATE PROCEDURE `sp_ReporteNotas` (p_Inicio DATETIME, p_Fin DATETIME)
BEGIN
	SELECT 
		Notas.Nota, 
		SUM(Prendas) Prendas, 
		SUM(Servicios) Servicios, 
		SUM(Monto) Monto, 
		IF(Descuento IS NULL, 0, SUM(Monto)*Descuento) Descuento, 
		IF(Descuento IS NULL, SUM(Monto), SUM(Monto) * (1 - Descuento)) 'Total a pagar', 
		Efectivo,
		Tarjeta,
		`Total ingresos`,
		IF(Descuento IS NULL, SUM(Monto), SUM(Monto) * (1 - Descuento)) - `Total ingresos` 'Por cobrar'
	FROM
	(
	SELECT N.ID Nota, N.Recibido Fecha, P.Cantidad Prendas, SUM(P.Cantidad*S.Cantidad) Servicios, SUM(P.Cantidad*S.Monto) Monto, D.Porcentaje * 0.01 Descuento
	FROM Nota N
	JOIN PrendaItem P ON(P.Nota = N.ID)
	JOIN ServicioItem S ON(S.PrendaItem = P.ID)
	LEFT JOIN Descuento D ON(D.ID = N.Descuento)
	GROUP BY N.ID, P.ID
	) Notas
	JOIN
	(
	SELECT 
		Nota, 
		SUM(IF(Metodo = 'Efectivo', Monto, 0)) Efectivo, 
		SUM(IF(Metodo = 'Tarjeta', Monto,0)) Tarjeta,
		SUM(IF(Metodo = 'Efectivo', Monto, 0))+SUM(IF(Metodo = 'Tarjeta', Monto,0)) 'Total ingresos'
	FROM Pago
	WHERE Fecha BETWEEN p_Inicio AND p_Fin
	GROUP BY Nota
	) Pagos ON(Pagos.Nota = Notas.Nota)
	GROUP BY Notas.Nota;
END$$

DELIMITER ;


DROP procedure IF EXISTS `sp_UpdateServicioPrenda`;
DELIMITER $$
USE `VentaPrenda`$$
CREATE PROCEDURE `sp_UpdateServicioPrenda` (p_Servicio INT, p_Prendas VARCHAR(64))
BEGIN
	IF p_Prendas IS NULL OR LENGTH(p_Prendas) = 0 THEN
		DELETE FROM Servicio_Prenda WHERE Servicio = p_Servicio;
    ELSE
		SET @delete_sql = CONCAT('DELETE FROM Servicio_Prenda WHERE Servicio = ', p_Servicio, ' AND Prenda NOT IN(', p_Prendas ,')');
		SET @insert_sql = 'INSERT IGNORE INTO Servicio_Prenda (Servicio,Prenda) VALUES ';

		PREPARE delStmt FROM @delete_sql;
		EXECUTE delStmt;
		DEALLOCATE PREPARE delStmt;

		WHILE LENGTH(p_Prendas) > 0 DO
			SET @Prenda = SUBSTRING_INDEX(p_Prendas,',',1);
			SET @insert_sql = CONCAT(@insert_sql, '(',p_Servicio,',',@Prenda,'), ');
			SET p_Prendas = SUBSTR(p_Prendas, LENGTH(@Prenda) + 2, LENGTH(p_Prendas) - LENGTH(@Prenda) - 1);
		END WHILE;
		SET @insert_sql = SUBSTR(@insert_sql, 1, LENGTH(@insert_sql) - 2);
		
		PREPARE insStmt FROM @insert_sql;
		EXECUTE insStmt;
		DEALLOCATE PREPARE insStmt;
	END	IF;
	SELECT P.* FROM Prenda P JOIN Servicio_Prenda SP ON(SP.Prenda = P.ID) WHERE SP.Servicio = p_Servicio;
END$$
DELIMITER ;

