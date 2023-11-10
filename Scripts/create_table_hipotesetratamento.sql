
CREATE TABLE [HipoteseTratamento] (
  [HipoteseTratamentoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [HipoteseTratamentoNome]  NVARCHAR(100)    NOT NULL,
  [HipoteseTratamentoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [HipoteseTratamentoId] ))
CREATE NONCLUSTERED INDEX [UHIPOTESETRATAMENTO1] ON [HipoteseTratamento] (
      [HipoteseTratamentoNome])