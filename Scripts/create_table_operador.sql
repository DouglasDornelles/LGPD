CREATE TABLE [Operador] (
  [OperadorId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [OperadorNome]  NVARCHAR(100)    NOT NULL,
  [OperadorAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [OperadorId] ))
CREATE NONCLUSTERED INDEX [UOPERADOR1] ON [Operador] (
      [OperadorNome])