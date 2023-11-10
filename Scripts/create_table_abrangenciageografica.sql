
CREATE TABLE [AbrangenciaGeografica] (
  [AbrangenciaGeograficaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [AbrangenciaGeograficaNome]  NVARCHAR(100)    NOT NULL,
  [AbrangenciaGeograficaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [AbrangenciaGeograficaId] ))
CREATE NONCLUSTERED INDEX [UABRANGENCIAGEOGRAFICA1] ON [AbrangenciaGeografica] (
      [AbrangenciaGeograficaNome])