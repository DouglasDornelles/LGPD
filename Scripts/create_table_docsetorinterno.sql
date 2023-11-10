CREATE TABLE [DocSetorInterno] (
  [SetorInternoId] INT    NOT NULL,
  [DocumentoId]    INT    NOT NULL,
     PRIMARY KEY ( [SetorInternoId],[DocumentoId] ))
CREATE NONCLUSTERED INDEX [IDOCSETORINTERNO1] ON [DocSetorInterno] (
      [DocumentoId])
ALTER TABLE [DocSetorInterno]
 ADD CONSTRAINT [IDOCSETORINTERNO2] FOREIGN KEY ( [SetorInternoId] ) REFERENCES [SetorInterno]([SetorInternoId])
ALTER TABLE [DocSetorInterno]
 ADD CONSTRAINT [IDOCSETORINTERNO1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])