CREATE TABLE [SubProcesso] (
  [SubprocessoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [SubprocessoNome]  NVARCHAR(100)    NOT NULL,
  [SubprocessoAtivo] BIT    NOT NULL,
  [ProcessoId]       INT    NULL,
     PRIMARY KEY ( [SubprocessoId] ))
CREATE NONCLUSTERED INDEX [ISUBPROCESSO2] ON [SubProcesso] (
      [ProcessoId])
CREATE NONCLUSTERED INDEX [USUBPROCESSO3] ON [SubProcesso] (
      [SubprocessoNome])
ALTER TABLE [SubProcesso]
 ADD CONSTRAINT [ISUBPROCESSO2] FOREIGN KEY ( [ProcessoId] ) REFERENCES [Processo]([ProcessoId])