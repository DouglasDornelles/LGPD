
CREATE TABLE [CompartTercExterno] (
  [CompartTercExternoId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [CompartTercExternoNome]  NVARCHAR(100)    NOT NULL,
  [CompartTercExternoAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [CompartTercExternoId] ))
CREATE NONCLUSTERED INDEX [UCOMPARTTERCEXTERNO1] ON [CompartTercExterno] (
      [CompartTercExternoNome])