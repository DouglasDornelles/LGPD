CREATE TABLE [EnvolvidosColeta] (
  [EnvolvidosColetaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [EnvolvidosColetaNome]  NVARCHAR(100)    NOT NULL,
  [EnvolvidosColetaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [EnvolvidosColetaId] ))
CREATE NONCLUSTERED INDEX [UENVOLVIDOSCOLETA1] ON [EnvolvidosColeta] (
      [EnvolvidosColetaNome])