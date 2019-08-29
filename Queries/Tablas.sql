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
  `Unidades` decimal(2,0) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Nombre_UNIQUE` (`Nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Movimiento` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Concepto` varchar(32) NOT NULL,
  `Importe` decimal(8,2) NOT NULL,
  `Fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Descripcion` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
