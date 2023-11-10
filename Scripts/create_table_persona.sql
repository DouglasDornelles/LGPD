
CREATE TABLE [Persona] (
  [PersonaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [PersonaNome]  NVARCHAR(100)    NOT NULL,
  [PersonaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [PersonaId] ))
CREATE NONCLUSTERED INDEX [UPERSONA2] ON [Persona] (
      [PersonaNome])