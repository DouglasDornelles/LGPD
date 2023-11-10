
CREATE TABLE [DocAnexo] (
  [DocAnexoId]           INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [DocumentoId]          INT    NOT NULL,
  [DocAnexoDescricao]    NVARCHAR(100)    NOT NULL,
  [DocAnexoArquivo]      NVARCHAR(200)    NOT NULL,
  [DocAnexoDataInclusao] DATETIME    NOT NULL,
     PRIMARY KEY ( [DocAnexoId] ))
CREATE NONCLUSTERED INDEX [IDOCANEXO1] ON [DocAnexo] (
      [DocumentoId])
CREATE NONCLUSTERED INDEX [UDOCANEXO2] ON [DocAnexo] (
      [DocAnexoDescricao])
CREATE NONCLUSTERED INDEX [UDOCANEXO3] ON [DocAnexo] (
      [DocAnexoArquivo])
ALTER TABLE [DocAnexo]
 ADD CONSTRAINT [IDOCANEXO1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])