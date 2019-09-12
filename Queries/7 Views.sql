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
