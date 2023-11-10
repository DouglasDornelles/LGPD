
CREATE TABLE [TipoDescarte] (
  [TipoDescarteId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [TipoDescarteNome]  NVARCHAR(100)    NOT NULL,
  [TipoDescarteAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [TipoDescarteId] ))
CREATE NONCLUSTERED INDEX [UTIPODESCARTE] ON [TipoDescarte] (
      [TipoDescarteNome])