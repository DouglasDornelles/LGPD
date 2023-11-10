
CREATE TABLE [Processo] (
  [ProcessoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [ProcessoNome]  NVARCHAR(100)    NOT NULL,
  [ProcessoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [ProcessoId] ))
CREATE NONCLUSTERED INDEX [UPROCESSO2] ON [Processo] (
      [ProcessoNome])