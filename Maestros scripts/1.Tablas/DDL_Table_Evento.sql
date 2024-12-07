


IF OBJECT_ID('Evento', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Evento]
END
GO

CREATE TABLE [dbo].[Evento] (
    [EventoID]		BIGINT	IDENTITY (1,1) NOT NULL,
	[EmpresaID]		BIGINT			NOT NULL,
	[SalaID]		BIGINT			NOT NULL,
    [Nombre]		VARCHAR (80)	NULL,
	[FechaHora]		DATETIME		NULL,
	[Lugar]			VARCHAR (80)	NULL,
	[Direccion]		VARCHAR (80)	NULL,
	CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([EventoID] ASC),
    CONSTRAINT [FK_Evento_Empresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Evento_SalaID] FOREIGN KEY ([SalaID]) REFERENCES [dbo].[Sala] ([SalaID])
);


