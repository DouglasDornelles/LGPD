
CREATE TABLE [DocCompartInterno] (
  [CompartInternoId] INT    NOT NULL,
  [DocumentoId]      INT    NOT NULL,
     PRIMARY KEY ( [CompartInternoId],[DocumentoId] ))
CREATE NONCLUSTERED INDEX [IDOCCOMPARTINTERNO1] ON [DocCompartInterno] (
      [DocumentoId])
ALTER TABLE [DocCompartInterno]
 ADD CONSTRAINT [IDOCCOMPARTINTERNO2] FOREIGN KEY ( [CompartInternoId] ) REFERENCES [CompartInterno]([CompartInternoId])
ALTER TABLE [DocCompartInterno]
 ADD CONSTRAINT [IDOCCOMPARTINTERNO1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])