USE `VentaPrenda`;

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
WHERE EXISTS(SELECT * FROM DatosHistorial WHERE Historial = H.ID AND Tabla = 'Nota' AND Columna = 'Estatus' AND Valor = 'Entregado')