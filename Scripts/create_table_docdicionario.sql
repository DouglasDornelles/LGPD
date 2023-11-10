
CREATE TABLE [DocDicionario] (
  [DocDicionarioId]                INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [InformacaoId]                   INT    NOT NULL,
  [HipoteseTratamentoId]           INT    NOT NULL,
  [DocDicionarioSensivel]          BIT    NOT NULL,
  [DocDicionarioPodeEliminar]      BIT    NOT NULL,
  [DocDicionarioTransfInter]       BIT    NOT NULL,
  [DocDicionarioFinalidade]        NVARCHAR(MAX)    NOT NULL,
  [DocDicionarioDataInclusao]      DATETIME    NOT NULL,
  [DocumentoId]                    INT    NOT NULL,
  [DocDicionarioTipoTransfInterGa] NVARCHAR(MAX)    NOT NULL,
     PRIMARY KEY ( [DocDicionarioId] ))
CREATE NONCLUSTERED INDEX [IDOCDICIONARIO2] ON [DocDicionario] (
      [HipoteseTratamentoId])
CREATE NONCLUSTERED INDEX [IDOCDICIONARIO3] ON [DocDicionario] (
      [InformacaoId])
CREATE NONCLUSTERED INDEX [UDOCDICIONARIO9] ON [DocDicionario] (
      [DocDicionarioSensivel])
CREATE NONCLUSTERED INDEX [IDOCDICIONARIO4] ON [DocDicionario] (
      [DocumentoId])
ALTER TABLE [DocDicionario]
 ADD CONSTRAINT [IDOCDICIONARIO3] FOREIGN KEY ( [InformacaoId] ) REFERENCES [Informacao]([InformacaoId])
ALTER TABLE [DocDicionario]
 ADD CONSTRAINT [IDOCDICIONARIO2] FOREIGN KEY ( [HipoteseTratamentoId] ) REFERENCES [HipoteseTratamento]([HipoteseTratamentoId])
ALTER TABLE [DocDicionario]
 ADD CONSTRAINT [IDOCDICIONARIO4] FOREIGN KEY ( [DocumentoId] ) REFERENCES [Documento]([DocumentoId])