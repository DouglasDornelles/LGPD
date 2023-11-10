CREATE TABLE [Campo] (
  [CampoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [CampoNome]  NVARCHAR(100)    NOT NULL,
  [CampoAtivo] BIT    NOT NULL,
  [TelaId]     INT    NOT NULL,
     PRIMARY KEY ( [CampoId] ))
CREATE NONCLUSTERED INDEX [ICAMPO1] ON [Campo] (
      [TelaId])
ALTER TABLE [Campo]
 ADD CONSTRAINT [ICAMPO1] FOREIGN KEY ( [TelaId] ) REFERENCES [Tela]([TelaId])