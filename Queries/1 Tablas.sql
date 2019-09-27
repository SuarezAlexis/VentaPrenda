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
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Nombre_UNIQUE` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
