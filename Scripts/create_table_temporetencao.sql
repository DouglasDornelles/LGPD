
CREATE TABLE [TempoRetencao] (
  [TempoRetencaoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [TempoRetencaoNome]  NVARCHAR(100)    NOT NULL,
  [TempoRetencaoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [TempoRetencaoId] ))
CREATE NONCLUSTERED INDEX [UTEMPORETANCAO1] ON [TempoRetencao] (
      [TempoRetencaoNome])