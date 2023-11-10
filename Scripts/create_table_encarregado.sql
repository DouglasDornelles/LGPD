
CREATE TABLE [Encarregado] (
  [EncarregadoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [EncarregadoNome]  NVARCHAR(100)    NOT NULL,
  [EncarregadoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [EncarregadoId] ))
CREATE NONCLUSTERED INDEX [UENCARREGADO1] ON [Encarregado] (
      [EncarregadoNome])
	  