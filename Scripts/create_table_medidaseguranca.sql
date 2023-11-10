CREATE TABLE [MedidaSeguranca] (
  [MedidaSegurancaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [MedidaSegurancaNome]  NVARCHAR(100)    NOT NULL,
  [MedidaSegurancaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [MedidaSegurancaId] ))
CREATE NONCLUSTERED INDEX [UMEDIDASEGURANCA1] ON [MedidaSeguranca] (
      [MedidaSegurancaNome])