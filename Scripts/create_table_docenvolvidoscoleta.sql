CREATE TABLE [DocEnvolvidosColeta] (
  [EnvolvidosColetaId] INT    NOT NULL,
  [DocumentoId]        INT    NOT NULL,
     PRIMARY KEY ( [EnvolvidosColetaId],[DocumentoId] ))
CREATE NONCLUSTERED INDEX [IDOCENVOLVIDOSCOLETA1] ON [DocEnvolvidosColeta] (
      [DocumentoId])
ALTER TABLE [DocEnvolvidosColeta]
 ADD CONSTRAINT [IDOCENVOLVIDOSCOLETA2] FOREIGN KEY ( [EnvolvidosColetaId] ) REFERENCES [EnvolvidosColeta]([EnvolvidosColetaId])
ALTER TABLE [DocEnvolvidosColeta]
 ADD CONSTRAINT [IDOCENVOLVIDOSCOLETA1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])