
CREATE TABLE [FrequenciaTratamento] (
  [FrequenciaTratamentoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [FrequenciaTratamentoNome]  NVARCHAR(100)    NOT NULL,
  [FrequenciaTratamentoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [FrequenciaTratamentoId] ))
CREATE NONCLUSTERED INDEX [UFREQUENCIATRATAMENTO1] ON [FrequenciaTratamento] (
      [FrequenciaTratamentoNome])