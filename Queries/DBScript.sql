/*****************************************************************************/
/* BASE DE DATOS															 */
/*****************************************************************************/
CREATE DATABASE `VentaPrenda` 
/*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE VentaPrenda;

/*****************************************************************************/
/* TABLAS																	 */
/*****************************************************************************/

CREATE TABLE `Cliente` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(128) NOT NULL,
  `Domicilio` varchar(128) DEFAULT NULL,
  `Colonia` varchar(64) DEFAULT NULL,
  `CP` varchar(5) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL,
  `Email` varchar(64) DEFAULT NULL,
  `Habilitado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Color` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(32) NOT NULL,
  `Habilitado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Nombre_UNIQUE` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Descuento` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(32) NOT NULL,
  `VigenciaInicio` datetime NOT NULL,
  `VigenciaFin` datetime NOT NULL,
  `MontoMinimo` decimal(8,2) DEFAULT NULL,
  `CantMinima` decimal(2,0) DEFAULT NULL,
  `Porcentaje` decimal(3,0) DEFAULT NULL,
  `Unidades` decimal(4,2) DEFAULT NULL,
  `SoloNota` bit(1) NOT NULL DEFAULT b'0',
  `Habilitado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Nombre_UNIQUE` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `Movimiento` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Concepto` varchar(32) NOT NULL,
  `Importe` decimal(8,2) NOT NULL,
  `Fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Descripcion` varchar(256) DEFAULT NULL,
  `NumFactura` varchar(64) DEFAULT NULL,
  `RFC` varchar(15) DEFAULT NULL,
  `FechaFactura` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Perfil` (
  `ID` tinyint(4) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(32) NOT NULL,
  `Permisos` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Prenda` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(32) NOT NULL,
  `Habilitado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Servicio` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(64) NOT NULL,
  `Descripcion` varchar(128) DEFAULT NULL,
  `Costo` decimal(8,2) NOT NULL,
  `Habilitado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Nombre_UNIQUE` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `TipoPrenda` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(32) NOT NULL,
  `Habilitado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Usuario` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(128) NOT NULL,
  `Username` varchar(32) NOT NULL,
  `Password` varchar(64) NOT NULL,
  `Bloqueado` bit(1) NOT NULL DEFAULT b'0',
  `IntentosFallidos` tinyint(4) NOT NULL DEFAULT '0',
  `UltimoIngreso` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Perfil_Usuario` (
  `Perfil` tinyint(4) NOT NULL,
  `Usuario` bigint(20) NOT NULL,
  PRIMARY KEY (`Perfil`,`Usuario`),
  KEY `PerfilUsuario_Ref_Usuario_idx` (`Usuario`),
  CONSTRAINT `PerfilUsuario_Ref_Perfil` FOREIGN KEY (`Perfil`) REFERENCES `perfil` (`ID`),
  CONSTRAINT `PerfilUsuario_Ref_Usuario` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Nota` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Estatus` tinyint(4) NOT NULL DEFAULT '0',
  `Cliente` int(11) DEFAULT NULL,
  `Recibido` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Entregado` datetime NOT NULL,
  `Observaciones` varchar(256) DEFAULT NULL,
  `Descuento` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Nota_Ref_Cliente_idx` (`Cliente`),
  CONSTRAINT `Nota_Ref_Cliente` FOREIGN KEY (`Cliente`) REFERENCES `cliente` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Pago` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nota` bigint(20) NOT NULL,
  `Metodo` varchar(32) NOT NULL DEFAULT 'Efectivo',
  `Monto` decimal(8,2) NOT NULL DEFAULT '0.00',
  `Fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `Pago_Ref_Nota_idx` (`Nota`),
  CONSTRAINT `Pago_Ref_Nota` FOREIGN KEY (`Nota`) REFERENCES `nota` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `PrendaItem` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Nota` bigint(20) NOT NULL,
  `Cantidad` tinyint(4) NOT NULL DEFAULT '1',
  `Prenda` smallint(6) NOT NULL,
  `TipoPrenda` smallint(6) DEFAULT NULL,
  `Color` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PrendaItem_Ref_Nota_idx` (`Nota`),
  KEY `PrendaItem_Ref_Prenda_idx` (`Prenda`),
  KEY `PrendaItem_Ref_Tipo_idx` (`TipoPrenda`),
  KEY `PrendaItem_Ref_Color_idx` (`Color`),
  CONSTRAINT `PrendaItem_Ref_Color` FOREIGN KEY (`Color`) REFERENCES `color` (`ID`),
  CONSTRAINT `PrendaItem_Ref_Nota` FOREIGN KEY (`Nota`) REFERENCES `nota` (`ID`),
  CONSTRAINT `PrendaItem_Ref_Prenda` FOREIGN KEY (`Prenda`) REFERENCES `prenda` (`ID`),
  CONSTRAINT `PrendaItem_Ref_Tipo` FOREIGN KEY (`TipoPrenda`) REFERENCES `tipoprenda` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `ServicioItem` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `PrendaItem` bigint(20) DEFAULT NULL,
  `Cantidad` tinyint(4) DEFAULT NULL,
  `Servicio` int(11) DEFAULT NULL,
  `Monto` decimal(8,2) DEFAULT NULL,
  `Descuento` int(11) DEFAULT NULL,
  `Encargado` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ServicioItem_Ref_PrendaItem_idx` (`PrendaItem`),
  KEY `ServicioItem_Ref_Servicio_idx` (`Servicio`),
  KEY `ServicioItem_Ref_Descuento_idx` (`Descuento`),
  KEY `ServicioItem_Ref_Usuario_idx` (`Encargado`),
  CONSTRAINT `ServicioItem_Ref_Descuento` FOREIGN KEY (`Descuento`) REFERENCES `descuento` (`ID`),
  CONSTRAINT `ServicioItem_Ref_PrendaItem` FOREIGN KEY (`PrendaItem`) REFERENCES `prendaitem` (`ID`),
  CONSTRAINT `ServicioItem_Ref_Servicio` FOREIGN KEY (`Servicio`) REFERENCES `servicio` (`ID`),
  CONSTRAINT `ServicioItem_Ref_Usuario` FOREIGN KEY (`Encargado`) REFERENCES `usuario` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Servicio_Prenda` (
  `Servicio` int(11) NOT NULL,
  `Prenda` smallint(6) NOT NULL,
  PRIMARY KEY (`Servicio`,`Prenda`),
  KEY `ServicioPrenda_Ref_Prenda_idx` (`Prenda`),
  CONSTRAINT `ServicioPrenda_Ref_Prenda` FOREIGN KEY (`Prenda`) REFERENCES `prenda` (`ID`),
  CONSTRAINT `ServicioPrenda_Ref_Servicio` FOREIGN KEY (`Servicio`) REFERENCES `servicio` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Ticket` (
  `ID` tinyint(4) NOT NULL DEFAULT '1',
  `Impresora` varchar(256) DEFAULT NULL,
  `Encabezado` varchar(1024) DEFAULT NULL,
  `Pie` varchar(1024) DEFAULT NULL,
  `Logo` mediumblob,
  `Ancho` smallint(6) NOT NULL DEFAULT '200',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  CONSTRAINT `Ticket_chck` CHECK ((`ID` = 1))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Historial` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Usuario` bigint(20) NOT NULL,
  `Concepto` varchar(64) NOT NULL,
  `Fecha` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Historial_Ref_Usuario_idx` (`Usuario`),
  CONSTRAINT `Historial_Ref_Usuario` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `DatosHistorial` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Historial` bigint(20) NOT NULL,
  `Operacion` char(1) NOT NULL,
  `Tabla` varchar(32) NOT NULL,
  `Columna` varchar(32) NOT NULL,
  `Valor` varchar(256) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `DatosHist_Ref_Historial_idx` (`Historial`),
  CONSTRAINT `DatosHist_Ref_Historial` FOREIGN KEY (`Historial`) REFERENCES `historial` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `ColoresGUI` (
  `Usuario` bigint(20) NOT NULL,
  `FondoVentana` int(11) NOT NULL DEFAULT '-986896',
  `FondoBoton` int(11) NOT NULL DEFAULT '-1842205',
  `FondoBotonActivo` int(11) NOT NULL DEFAULT '-6250336',
  `FondoLista` int(11) NOT NULL DEFAULT '-5526613',
  `Cancelado` int(11) NOT NULL DEFAULT '-16181',
  `Terminado` int(11) NOT NULL DEFAULT '-2031617',
  `Pendiente` int(11) NOT NULL DEFAULT '-32',
  `Entregado` int(11) NOT NULL DEFAULT '-983056',
  `Caducado` int(11) NOT NULL DEFAULT '-2572328',
  PRIMARY KEY (`Usuario`),
  CONSTRAINT `Colores_Ref_Usuario` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


/*****************************************************************************/
/* PROCEDIMIENTOS															 */
/*****************************************************************************/
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

DROP PROCEDURE IF EXISTS sp_DeleteDescuento;
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
		UPDATE Usuario SET Bloqueado = 1 WHERE ID = p_ID AND (EXISTS(SELECT * FROM Historial WHERE Usuario = p_ID) OR EXISTS(SELECT * FROM ServicioItem WHERE Encargado = p_ID));
		SELECT U.*, 0 AS Logged, BIT_OR(P.Permisos) AS Permisos FROM Usuario U JOIN Perfil_Usuario PU ON (PU.Usuario = U.ID) JOIN Perfil P ON(PU.Perfil = P.ID) WHERE U.ID = p_ID;
		DELETE FROM Perfil_Usuario WHERE Usuario = p_ID AND NOT (EXISTS(SELECT * FROM Historial WHERE Usuario = p_ID) OR EXISTS(SELECT * FROM ServicioItem WHERE Encargado = p_ID));
        	DELETE FROM ColoresGUI WHERE Usuario = p_ID AND NOT (EXISTS(SELECT * FROM Historial WHERE Usuario = p_ID) OR EXISTS(SELECT * FROM ServicioItem WHERE Encargado = p_ID));
		DELETE FROM Usuario WHERE ID = p_ID AND NOT (EXISTS(SELECT * FROM Historial WHERE Usuario = p_ID) OR EXISTS(SELECT * FROM ServicioItem WHERE Encargado = p_ID));
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

DROP PROCEDURE IF EXISTS sp_DeleteNota;
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

/*****************************************************************************/
/* VISTAS																	 */
/*****************************************************************************/
CREATE  OR REPLACE VIEW `ClienteStatsView` AS
SELECT Servicios.Nota, Fecha, Monto, SUM(Prendas) Prendas, SUM(Servicios) Servicios, ID
FROM
(SELECT N.ID Nota, N.Recibido Fecha, P.Cantidad Prendas, SUM(P.Cantidad*S.Cantidad) Servicios, C.ID
FROM Nota N
JOIN Cliente C ON(C.ID = N.Cliente)
JOIN PrendaItem P ON(P.Nota = N.ID)
JOIN ServicioItem S ON(S.PrendaItem = P.ID)
GROUP BY N.ID, P.ID) Servicios
LEFT JOIN 
(SELECT Nota, SUM(Monto) Monto FROM Pago GROUP BY Nota) Pagos ON(Pagos.Nota = Servicios.Nota)
GROUP BY Nota;

CREATE  OR REPLACE VIEW `ReporteProduccion` AS
SELECT H.Fecha, N.ID Nota, P.Nombre Prenda, C.Nombre Color, PI.Cantidad * SI.Cantidad Cantidad, S.Nombre Servicio, U.Nombre 'Elaboró', SI.Monto * PI.Cantidad Precio 
FROM Nota N 
LEFT JOIN PrendaItem PI ON(PI.Nota = N.ID) 
LEFT JOIN Prenda P ON(P.ID = PI.Prenda) 
LEFT JOIN Color C ON(C.ID = PI.Color) 
LEFT JOIN ServicioItem SI ON(SI.PrendaItem = PI.ID) 
LEFT JOIN Servicio S ON(S.ID = SI.Servicio) 
LEFT JOIN Usuario U ON(U.ID = SI.Encargado) 
LEFT JOIN DatosHistorial DH ON(DH.Valor = N.ID AND Columna = 'ID' AND DH.Tabla = 'Nota' AND DH.Operacion = 'U') 
LEFT JOIN Historial H ON(H.ID = DH.Historial) 
WHERE EXISTS(SELECT * FROM DatosHistorial WHERE Historial = H.ID AND Tabla = 'Nota' AND Columna = 'Estatus' AND Valor = 'Entregado');

/*****************************************************************************/
/* DATOS 																	 */
/*****************************************************************************/
INSERT INTO Ticket(Impresora,Encabezado,Pie) VALUES(NULL,NULL,NULL);

INSERT INTO 
`Usuario` 
(`ID`,`Nombre`,`Username`,`Password`,`Bloqueado`,`IntentosFallidos`,`UltimoIngreso`) 
VALUES 
(1,'Usuario de desarrollo','dev','tuc1aXUxAUY2EXHP/k6Bew==',b'0',0,'2019-08-29 11:10:36'),
(2,'Administrador del sistema','admin','tuc1aXUxAUY2EXHP/k6Bew==',b'0',0,'2019-08-27 18:19:24');

INSERT INTO Perfil(ID,Nombre,Permisos) VALUES(1,'Desarrollo',262143),(2,'Admin',247848);

INSERT INTO Perfil_Usuario(Perfil,Usuario) VALUES(1,1),(2,2);

INSERT INTO ColoresGUI(Usuario) SELECT ID FROM Usuario;

INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (1,'Aguamarina',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (2,'Amarillo',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (3,'Azul',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (4,'Arena',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (5,'Azul claro',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (6,'Azul cielo',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (7,'Azul ultramar',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (8,'Azul pastel',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (9,'Blanco',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (10,'Café',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (11,'Dorado',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (12,'Fucsia',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (13,'Guinda',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (14,'Naranja',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (15,'Negro',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (16,'Gris',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (17,'Palo rosa',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (18,'Plateado',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (19,'Rojo',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (21,'Salmón',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (22,'Turquesa',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (23,'Verde',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (24,'Rosa pastel',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (25,'Rosa mexicano',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (26,'Verde claro',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (27,'Verde obscuro',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (28,'Café claro',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (29,'Beige',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (30,'Rosa claro',b'1');
INSERT INTO `Color` (`ID`,`Nombre`,`Habilitado`) VALUES (31,'Violeta',b'1');

INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (1,'Abrigo',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (2,'Bermuda',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (3,'Bikini',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (4,'Blusa',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (5,'Boina',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (6,'Bufanda',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (7,'Camisa',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (8,'Camiseta',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (9,'Camisón',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (10,'Disfraz',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (11,'Falda',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (12,'Guantes',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (13,'Gorro',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (14,'Guayabera',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (15,'Kimono',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (16,'Pantalón',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (17,'Pijama',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (18,'Saco',b'1');
INSERT INTO `Prenda` (`ID`,`Nombre`,`Habilitado`) VALUES (19,'Chaleco',b'1');

INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (1,'Dobladillo a mano','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (2,'Dobladillo a máquina','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (3,'Dobladillo valenciana','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (4,'Forrado','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (5,'Dobladillo con bies','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (6,'Cierre de nylon','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (7,'Cierre invisible','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (8,'Cierre metálico','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (9,'Ajuste de cintura','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (10,'Ajuste de cadera','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (11,'Ajuste de piernas','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (12,'Ajuste de cintura y cadera','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (13,'Subir tiro','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (14,'Bajar pretina','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (15,'Aberturas laterales en dobladillo','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (16,'Cambiar elástico en cintura','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (17,'Eliminar pinzas y bolsas','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (18,'Dobladillo a mano forrado','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (21,'Ajustar costados','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (22,'Ajustar tirantes','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (23,'Ajustar mangas','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (24,'Voltear cuello','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (25,'Ajustar costados sin mangas','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (26,'Subir puños','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (27,'Cambiar hombreras','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (28,'Cortar mangas','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (29,'Hacer aberturas laterales','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (30,'Subir hombros','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (31,'Ajustar largo de hombros','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (33,'Hacer ojales','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (34,'Colocar botones','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (35,'Cambiar forro','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (36,'Ajustar solapa','',0.00,b'1');
INSERT INTO `Servicio` (`ID`,`Nombre`,`Descripcion`,`Costo`,`Habilitado`) VALUES (37,'Transformaciones de solapa','',0.00,b'1');

