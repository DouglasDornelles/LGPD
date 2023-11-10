CREATE TABLE [DocOperador] (
  [DocOperadorId]               INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [DocumentoId]                 INT    NOT NULL,
  [OperadorId]                  INT    NOT NULL,
  [DocOperadorColeta]           BIT    NOT NULL,
  [DocOperadorRetencao]         BIT    NOT NULL,
  [DocOperadorCompartilhamento] BIT    NOT NULL,
  [DocOperadorEliminacao]       BIT    NOT NULL,
  [DocOperadorProcessamento]    BIT    NOT NULL,
  [DocOperadorDataInclusao]     DATETIME    NOT NULL,
     PRIMARY KEY ( [DocOperadorId] ))
CREATE NONCLUSTERED INDEX [IDOCOPERADOR1] ON [DocOperador] (
      [OperadorId])
CREATE NONCLUSTERED INDEX [IDOCOPERADOR2] ON [DocOperador] (
      [DocumentoId])
ALTER TABLE [DocOperador]
 ADD CONSTRAINT [IDOCOPERADOR2] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])
ALTER TABLE [DocOperador]
 ADD CONSTRAINT [IDOCOPERADOR1] FOREIGN KEY ( [OperadorId] ) REFERENCES [Operador]([OperadorId])