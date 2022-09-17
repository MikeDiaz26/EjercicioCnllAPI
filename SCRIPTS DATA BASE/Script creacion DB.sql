CREATE TABLE vehiculo(
	placa VARCHAR(20) NOT NULL PRIMARY KEY,
	marca VARCHAR(30) NOT NULL,
	modelo VARCHAR(50) NOT NULL,
	anio INT NOT NULL,
	color VARCHAR(30) NOT NULL,
	precio_renta DECIMAL(10,2) NOT NULL
);


INSERT INTO vehiculo VALUES('P-297GSD', 'Mazda', '2', '2009', 'Blanco', '200.00');
INSERT INTO vehiculo VALUES('P-039HQT', 'Toyota', 'Corolla', '2015', 'Azul', '300.00');
INSERT INTO vehiculo VALUES('P-848PCX', 'Kia', 'Picanto', '2019', 'Negro', '350.00');




EXEC new_vehiculo 'P-485WIO', 'Mazda', 'Cx5', '2020', 'Negro', '600.00';

EXEC get_vehiculos;
EXEC get_vehiculo_by_placa 'P-297GSD';

EXEC update_vehiculo 'P-485WIO', 'Mazda', 'Cx9', '2020', 'Azul', '700.00';

EXEC delete_vehiculo 'P-485WIO';

