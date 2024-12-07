

IF OBJECT_ID('Comuna', 'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Comuna]
END
GO

CREATE TABLE [dbo].[Comuna] (
    [ComunaID]			BIGINT	IDENTITY (1, 1) NOT NULL,
	[EmpresaID]			BIGINT			NOT NULL,
	[Nombre]			VARCHAR (80)	NULL,
    [Descripcion]		VARCHAR (Max)	NULL,
	CONSTRAINT [PK_Comuna] PRIMARY KEY CLUSTERED ([ComunaID] ASC),
    CONSTRAINT [FK_Comuna_Empresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[Empresa] ([EmpresaID]),
);


