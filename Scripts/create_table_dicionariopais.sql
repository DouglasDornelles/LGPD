CREATE TABLE [DicionarioPais] (
  [PaisId]          INT    NOT NULL,
  [DocDicionarioId] INT    NOT NULL,
     PRIMARY KEY ( [PaisId],[DocDicionarioId] ))
CREATE NONCLUSTERED INDEX [IDICIONARIOPAIS1] ON [DicionarioPais] (
      [DocDicionarioId])
ALTER TABLE [DicionarioPais]
 ADD CONSTRAINT [IDICIONARIOPAIS2] FOREIGN KEY ( [PaisId] ) REFERENCES [Pais]([PaisId])
ALTER TABLE [DicionarioPais]
 ADD CONSTRAINT [IDICIONARIOPAIS1] FOREIGN KEY ( [DocDicionarioId] ) REFERENCES [DocDicionario]([DocDicionarioId])