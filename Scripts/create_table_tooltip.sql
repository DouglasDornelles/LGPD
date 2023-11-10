
CREATE TABLE [Tooltip] (
  [TooltipId]        INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [TooltipDescricao] NVARCHAR(MAX)    NOT NULL,
  [TooltipAtivo]     BIT    NOT NULL,
  [CampoId]          INT    NOT NULL,
  [TooltipTelaId]    INT    NOT NULL,
     PRIMARY KEY ( [TooltipId] ))
CREATE NONCLUSTERED INDEX [ITOOLTIP1] ON [Tooltip] (
      [CampoId])
CREATE NONCLUSTERED INDEX [ITOOLTIP2] ON [Tooltip] (
      [TooltipTelaId])
ALTER TABLE [Tooltip]
 ADD CONSTRAINT [ITOOLTIP1] FOREIGN KEY ( [CampoId] ) REFERENCES [Campo]([CampoId])
ALTER TABLE [Tooltip]
 ADD CONSTRAINT [ITOOLTIP2] FOREIGN KEY ( [TooltipTelaId] ) REFERENCES [Tela]([TelaId])