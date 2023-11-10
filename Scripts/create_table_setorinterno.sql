CREATE TABLE [SetorInterno] (
  [SetorInternoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [SetorInternoNome]  NVARCHAR(100)    NOT NULL,
  [SetorInternoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [SetorInternoId] ))
CREATE NONCLUSTERED INDEX [USETORINTERNO1] ON [SetorInterno] (
      [SetorInternoNome])