
CREATE TABLE [Pais] (
  [PaisId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [PaisNome]  NVARCHAR(100)    NOT NULL,
  [PaisAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [PaisId] ))
CREATE NONCLUSTERED INDEX [UPAIS1] ON [Pais] (
      [PaisNome])