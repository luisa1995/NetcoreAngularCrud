------ Store procedure select ---------------------------
CREATE or alter PROCEDURE SELECTUSUARIOS
AS 
BEGIN
	SELECT * FROM USUARIOS order by fechacreacion desc
END
GO
----------------------------------------------------

------ Store procedure selectById ---------------------------
CREATE PROCEDURE SELECTUSUARIOSBYID
@USUARIO VARCHAR(150)
AS 
BEGIN
	SELECT * FROM USUARIOS WHERE USUARIO = @USUARIO
END
GO
----------------------------------------------------

------ Store procedure insert usuarios  ---------------------------
CREATE PROCEDURE INSERTUSUARIOS(
@USUARIO VARCHAR(150),
@PASSWORD VARCHAR (150)
)
AS
BEGIN
	INSERT INTO USUARIOS (USUARIO, [PASSWORD], FECHACREACION)
	VALUES (@USUARIO, @PASSWORD, GETDATE())
END
GO
----------------------------------------------------

------ Store procedure update usuarios  ---------------------------
CREATE PROCEDURE UPDATEUSUARIOS(
@USUARIO VARCHAR(150),
@IDENTIFICADOR INT,
@PASSWORD VARCHAR (150)
)
AS
BEGIN

	UPDATE USUARIOS
	SET [PASSWORD] = @PASSWORD
	WHERE USUARIO = @USUARIO AND IDENTIFICADOR = @IDENTIFICADOR
END
GO
----------------------------------------------------
------ Store procedure delete usuarios  ---------------------------
CREATE or alter PROCEDURE DELETEUSUARIOS(
@USUARIO VARCHAR(150),
@IDENTIFICADOR INT
)
AS
BEGIN

	DELETE USUARIOS 
	WHERE USUARIO = @USUARIO AND IDENTIFICADOR = @IDENTIFICADOR
END
GO
----------------------------------------------------