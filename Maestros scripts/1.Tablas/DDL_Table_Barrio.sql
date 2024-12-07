
IF OBJECT_ID('Barrio', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Barrio]
END
GO

CREATE TABLE [dbo].[Barrio] (
    [BarrioID]			BIGINT	IDENTITY (1,1) NOT NULL,
	[EmpresaID]			BIGINT			NOT NULL,
	[ComunaID]			BIGINT			NOT NULL,
    [Nombre]			VARCHAR (80)	NULL,
	[Descripcion]		VARCHAR (MAX)	NULL,
	CONSTRAINT [PK_Barrio] PRIMARY KEY CLUSTERED ([BarrioID] ASC),
    CONSTRAINT [FK_Barrio_Empresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
	CONSTRAINT [FK_Barrio_Comuna] FOREIGN KEY ([ComunaID]) REFERENCES [dbo].[Comuna] ([ComunaID])
);


