CREATE TABLE [DocFonteRetencao] (
  [FonteRetencaoId] INT    NOT NULL,
  [DocumentoId]     INT    NOT NULL,
     PRIMARY KEY ( [FonteRetencaoId],[DocumentoId] ))
CREATE NONCLUSTERED INDEX [IDOCFONTERETENCAO1] ON [DocFonteRetencao] (
      [DocumentoId])
ALTER TABLE [DocFonteRetencao]
 ADD CONSTRAINT [IDOCFONTERETENCAO2] FOREIGN KEY ( [FonteRetencaoId] ) REFERENCES [FonteRetencao]([FonteRetencaoId])
ALTER TABLE [DocFonteRetencao]
 ADD CONSTRAINT [IDOCFONTERETENCAO1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])