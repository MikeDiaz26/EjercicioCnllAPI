USE prueba_tecnica
GO 
--- CRUD
ALTER PROCEDURE new_vehiculo
	@placa VARCHAR(20),
	@marca VARCHAR(30),
	@modelo VARCHAR(50),
	@anio INT,
	@color VARCHAR(30),
	@preciorenta DECIMAL(10,2)
AS
BEGIN
	INSERT INTO vehiculo(placa, marca, modelo, anio, color, precio_renta) 
	VALUES(@placa, @marca, @modelo, @anio, @color, @preciorenta);
END
GO


ALTER PROCEDURE get_vehiculos
AS
BEGIN
	SELECT placa
		,marca
		,modelo
		,anio
		,color
		,precio_renta
	FROM vehiculo
	ORDER BY marca;
END
GO

ALTER PROCEDURE get_vehiculo_by_placa
	@placa VARCHAR(20)
AS
BEGIN
	SELECT placa
		,marca
		,modelo
		,anio
		,color
		,precio_renta
	FROM vehiculo
	WHERE placa=@placa;
END
GO


ALTER PROCEDURE update_vehiculo
	@placa VARCHAR(20),
	@marca VARCHAR(30),
	@modelo VARCHAR(50),
	@anio INT,
	@color VARCHAR(30),
	@preciorenta DECIMAL(10,2)
AS
BEGIN
	UPDATE vehiculo
	SET marca=@marca
		,modelo=@modelo
		,anio=@anio
		,color=@color
		,precio_renta=@preciorenta
	WHERE placa=@placa;
END
GO


ALTER PROCEDURE delete_vehiculo
	@placa VARCHAR(20)
AS
BEGIN
	DELETE FROM vehiculo
	WHERE placa=@placa;
END
GO
