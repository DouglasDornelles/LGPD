
CREATE TABLE [FerramentaColeta] (
  [FerramentaColetaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [FerramentaColetaNome]  NVARCHAR(100)    NOT NULL,
  [FerramentaColetaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [FerramentaColetaId] ))
CREATE NONCLUSTERED INDEX [UFERRAMENTACOLETA1] ON [FerramentaColeta] (
      [FerramentaColetaNome])