CREATE TABLE [DocMedidaSeguranca] (
  [MedidaSegurancaId] INT    NOT NULL,
  [DocumentoId]       INT    NOT NULL,
     PRIMARY KEY ( [MedidaSegurancaId],[DocumentoId] ))
CREATE NONCLUSTERED INDEX [IDOCMEDIDASEGURANCA1] ON [DocMedidaSeguranca] (
      [DocumentoId])
ALTER TABLE [DocMedidaSeguranca]
 ADD CONSTRAINT [IDOCMEDIDASEGURANCA2] FOREIGN KEY ( [MedidaSegurancaId] ) REFERENCES [MedidaSeguranca]([MedidaSegurancaId])
ALTER TABLE [DocMedidaSeguranca]
 ADD CONSTRAINT [IDOCMEDIDASEGURANCA1] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])