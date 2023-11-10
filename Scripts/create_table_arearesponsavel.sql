CREATE TABLE [AreaResponsavel] (
  [AreaResponsavelId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [AreaResponsavelNome]  NVARCHAR(100)    NOT NULL,
  [AreaResponsavelAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [AreaResponsavelId] ))
CREATE NONCLUSTERED INDEX [UAREARESPONSAVEL1] ON [AreaResponsavel] (
      [AreaResponsavelNome])