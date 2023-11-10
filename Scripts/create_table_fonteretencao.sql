
CREATE TABLE [FonteRetencao] (
  [FonteRetencaoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [FonteRetencaoNome]  NVARCHAR(100)    NOT NULL,
  [FonteRetencaoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [FonteRetencaoId] ))
CREATE NONCLUSTERED INDEX [UFONTERETENCAO1] ON [FonteRetencao] (
      [FonteRetencaoNome])