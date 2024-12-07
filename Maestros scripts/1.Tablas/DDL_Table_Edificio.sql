

IF OBJECT_ID('Edificio', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Edificio]
END
GO

CREATE TABLE [dbo].[Edificio] (
    [EdificioID]		BIGINT	IDENTITY (1,1) NOT NULL,
	[EmpresaID]			BIGINT			NOT NULL,
	[BarrioID]			BIGINT			NOT NULL,
    [Nombre]			VARCHAR (80)	NULL,
	[Direccion]			VARCHAR (80)	NULL,
	CONSTRAINT [PK_Edificio] PRIMARY KEY CLUSTERED ([EdificioID] ASC),
    CONSTRAINT [FK_Edificio_Empresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Edificio_Barrio] FOREIGN KEY ([BarrioID]) REFERENCES [dbo].[Barrio] ([BarrioID])
);


