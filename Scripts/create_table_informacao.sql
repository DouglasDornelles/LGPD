CREATE TABLE [Informacao] (
  [InformacaoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [InformacaoNome]  NVARCHAR(100)    NOT NULL,
  [InformacaoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [InformacaoId] ))
CREATE NONCLUSTERED INDEX [UINFORMACAO1] ON [Informacao] (
      [InformacaoNome])