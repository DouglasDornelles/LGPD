CREATE TABLE [CompartInterno] (
  [CompartInternoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [CompartInternoNome]  NVARCHAR(100)    NOT NULL,
  [CompartInternoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [CompartInternoId] ))
CREATE NONCLUSTERED INDEX [UCOMPARTINTERNO1] ON [CompartInterno] (
      [CompartInternoNome])