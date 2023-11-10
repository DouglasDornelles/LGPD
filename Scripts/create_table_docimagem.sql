CREATE TABLE [DocImagem] (
  [DocImagemId]      INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [DocumentoId]      INT    NOT NULL,
  [DocImagemArquivo] NVARCHAR(MAX)    NOT NULL,
     PRIMARY KEY ( [DocImagemId] ))
CREATE NONCLUSTERED INDEX [IDOCIMAGEM1] ON [DocImagem] (
      [DocumentoId])
ALTER TABLE [DocImagem]
 ADD CONSTRAINT [IDOCIMAGEM1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])