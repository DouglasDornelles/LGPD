
CREATE TABLE [Controlador] (
  [ControladorId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [ControladorNome]  NVARCHAR(100)    NOT NULL,
  [ControladorAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [ControladorId] ))
CREATE NONCLUSTERED INDEX [UCONTROLADOR1] ON [Controlador] (
      [ControladorNome])