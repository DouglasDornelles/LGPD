
CREATE TABLE [Documento] (
  [DocumentoId]                   INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [DocumentoNome]                 NVARCHAR(100)    NULL,
  [SubprocessoId]                 INT    NULL,
  [EncarregadoId]                 INT    NULL,
  [PersonaId]                     INT    NULL,
  [DocumentoFinalidadeTratamento] NVARCHAR(100)    NULL,
  [CategoriaId]                   INT    NULL,
  [TipoDadoId]                    INT    NULL,
  [FerramentaColetaId]            INT    NULL,
  [AbrangenciaGeograficaId]       INT    NULL,
  [FrequenciaTratamentoId]        INT    NULL,
  [TipoDescarteId]                INT    NULL,
  [TempoRetencaoId]               INT    NULL,
  [DocumentoPrevColetaDados]      BIT    NULL,
  [DocumentoBaseLegalNorm]        NVARCHAR(100)    NULL,
  [DocumentoBaseLegalNormIntExt]  NVARCHAR(100)    NULL,
  [DocumentoDadosCriancaAdolesc]  BIT    NULL,
  [DocumentoDadosGrupoVul]        BIT    NULL,
  [DocumentoMedidaSegurancaDesc]  NVARCHAR(MAX)    NULL,
  [DocumentoFluxoTratDadosDesc]   NVARCHAR(MAX)    NULL,
  [DocumentoAtivo]                BIT    NULL,
  [DocumentoOperador]             BIT    NULL,
  [DocumentoProcessoId]           INT    NULL,
  [DocumentoDataInclusao]         DATETIME    NULL,
  [DocumentoDataAlteracao]        DATETIME    NULL,
  [DocumentoControladorId]        INT    NULL,
  [AreaResponsavelId]             INT    NULL,
  [DocumentoUsuarioInclusao]      NVARCHAR(100)    NULL,
  [DocumentoUsuarioAlteracao]     NVARCHAR(100)    NULL,
  [DocumentoIsOperador]           BIT    NULL,
     PRIMARY KEY ( [DocumentoId] ))
CREATE NONCLUSTERED INDEX [IDOCUMENTO2] ON [Documento] (
      [TempoRetencaoId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO3] ON [Documento] (
      [TipoDescarteId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO4] ON [Documento] (
      [FrequenciaTratamentoId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO5] ON [Documento] (
      [AbrangenciaGeograficaId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO6] ON [Documento] (
      [FerramentaColetaId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO7] ON [Documento] (
      [TipoDadoId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO8] ON [Documento] (
      [CategoriaId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO9] ON [Documento] (
      [PersonaId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO10] ON [Documento] (
      [EncarregadoId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO11] ON [Documento] (
      [SubprocessoId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO12] ON [Documento] (
      [DocumentoProcessoId])
CREATE NONCLUSTERED INDEX [UDOCUMENTO25] ON [Documento] (
      [DocumentoNome])
CREATE NONCLUSTERED INDEX [IDOCUMENTO13] ON [Documento] (
      [DocumentoControladorId])
CREATE NONCLUSTERED INDEX [IDOCUMENTO14] ON [Documento] (
      [AreaResponsavelId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO11] FOREIGN KEY ( [SubprocessoId] ) REFERENCES [SubProcesso]([SubprocessoId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO10] FOREIGN KEY ( [EncarregadoId] ) REFERENCES [Encarregado]([EncarregadoId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO9] FOREIGN KEY ( [PersonaId] ) REFERENCES [Persona]([PersonaId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO8] FOREIGN KEY ( [CategoriaId] ) REFERENCES [Categoria]([CategoriaId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO7] FOREIGN KEY ( [TipoDadoId] ) REFERENCES [TipoDado]([TipoDadoId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO6] FOREIGN KEY ( [FerramentaColetaId] ) REFERENCES [FerramentaColeta]([FerramentaColetaId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO5] FOREIGN KEY ( [AbrangenciaGeograficaId] ) REFERENCES [AbrangenciaGeografica]([AbrangenciaGeograficaId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO4] FOREIGN KEY ( [FrequenciaTratamentoId] ) REFERENCES [FrequenciaTratamento]([FrequenciaTratamentoId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO3] FOREIGN KEY ( [TipoDescarteId] ) REFERENCES [TipoDescarte]([TipoDescarteId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO2] FOREIGN KEY ( [TempoRetencaoId] ) REFERENCES [TempoRetencao]([TempoRetencaoId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO14] FOREIGN KEY ( [AreaResponsavelId] ) REFERENCES [AreaResponsavel]([AreaResponsavelId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO12] FOREIGN KEY ( [DocumentoProcessoId] ) REFERENCES [Processo]([ProcessoId])
ALTER TABLE [Documento]
 ADD CONSTRAINT [IDOCUMENTO13] FOREIGN KEY ( [DocumentoControladorId] ) REFERENCES [Controlador]([ControladorId])