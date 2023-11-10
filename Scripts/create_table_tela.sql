CREATE TABLE [Tela] (
  [TelaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [TelaNome]  NVARCHAR(100)    NOT NULL,
  [TelaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [TelaId] ))