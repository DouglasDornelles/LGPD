
CREATE TABLE [TipoDado] (
  [TipoDadoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [TipoDadoNome]  NVARCHAR(100)    NOT NULL,
  [TipoDadoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [TipoDadoId] ))
CREATE NONCLUSTERED INDEX [UTIPODADO1] ON [TipoDado] (
      [TipoDadoNome])