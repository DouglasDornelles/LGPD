CREATE TABLE [UserCustomizations] (
  [UserCustomizationsId]    NCHAR(40)    NOT NULL,
  [UserCustomizationsKey]   NVARCHAR(200)    NOT NULL,
  [UserCustomizationsValue] NVARCHAR(MAX)    NOT NULL,
     PRIMARY KEY ( [UserCustomizationsId],[UserCustomizationsKey] ))