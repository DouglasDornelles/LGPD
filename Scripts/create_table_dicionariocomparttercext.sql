
CREATE TABLE [DicionarioCompartTercExt] (
  [CompartTercExternoId] INT    NOT NULL,
  [DocDicionarioId]      INT    NOT NULL,
     PRIMARY KEY ( [CompartTercExternoId],[DocDicionarioId] ))
CREATE NONCLUSTERED INDEX [IDICIONARIOCOMPARTTERCEXT1] ON [DicionarioCompartTercExt] (
      [DocDicionarioId])
ALTER TABLE [DicionarioCompartTercExt]
 ADD CONSTRAINT [IDICIONARIOCOMPARTTERCEXT2] FOREIGN KEY ( [CompartTercExternoId] ) REFERENCES [CompartTercExterno]([CompartTercExternoId])
ALTER TABLE [DicionarioCompartTercExt]
 ADD CONSTRAINT [IDICIONARIOCOMPARTTERCEXT1] FOREIGN KEY ( [DocDicionarioId] ) REFERENCES [DocDicionario]([DocDicionarioId])