
CREATE TABLE [RevisaoLog] (
  [RevisaoLogId]               INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [RevisaoLogUsuarioAlteracao] NVARCHAR(100)    NOT NULL,
  [RevisaoLogObservacao]       NVARCHAR(MAX)    NOT NULL,
  [RevisaoLogDataAlteracao]    DATETIME    NOT NULL,
  [DocumentoId]                INT    NOT NULL,
     PRIMARY KEY ( [RevisaoLogId] ))
CREATE NONCLUSTERED INDEX [IREVISAOLOG1] ON [RevisaoLog] (
      [DocumentoId])
ALTER TABLE [RevisaoLog]
 ADD CONSTRAINT [IREVISAOLOG1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])