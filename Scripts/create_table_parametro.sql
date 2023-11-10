CREATE TABLE [Parametro] (
  [ParametroCod]              NCHAR(10)    NOT NULL,
  [ParametroDescricao]        NVARCHAR(100)    NOT NULL,
  [ParametroValor]            NVARCHAR(100)    NOT NULL,
  [ParametroComentario]       NVARCHAR(500)    NOT NULL,
  [ParametroDataInclusao]     DATETIME    NOT NULL,
  [ParametroDataAlteracao]    DATETIME    NOT NULL,
  [ParametroUsuarioInclusao]  NCHAR(20)    NOT NULL,
  [ParametroUsuarioAlteracao] NCHAR(20)    NOT NULL,
  [ParametroAtivo]            BIT    NOT NULL,
     PRIMARY KEY ( [ParametroCod] ))
CREATE NONCLUSTERED INDEX [UPARAMETRO1] ON [Parametro] (
      [ParametroDescricao])
CREATE NONCLUSTERED INDEX [UPARAMETRO2] ON [Parametro] (
      [ParametroValor])
CREATE NONCLUSTERED INDEX [UPARAMETRO3] ON [Parametro] (
      [ParametroComentario])
CREATE NONCLUSTERED INDEX [UPARAMETRO4] ON [Parametro] (
      [ParametroUsuarioInclusao])
CREATE NONCLUSTERED INDEX [UPARAMETRO5] ON [Parametro] (
      [ParametroUsuarioAlteracao])