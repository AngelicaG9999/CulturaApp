

IF OBJECT_ID('Sala', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Sala]
END
GO

CREATE TABLE [dbo].[Sala] (
    [SalaID]		BIGINT	IDENTITY (1,1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
	[EdificioID]	BIGINT			NOT NULL,
    [Nombre]		VARCHAR (80)	NULL,
	[Capacidad]		INT				NOT NULL,
	[Descripcion]	VARCHAR (MAX)	NULL,
	CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED ([SalaID] ASC),
    CONSTRAINT [FK_Sala_Empresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Sala_Edificio] FOREIGN KEY ([EdificioID]) REFERENCES [dbo].[Edificio] ([EdificioID])
);


