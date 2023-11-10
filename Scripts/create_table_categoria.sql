CREATE TABLE [Categoria] (
  [CategoriaId]    INT    NOT NULL    IDENTITY ( 1 , 1 ),
  [CategoriaNome]  NVARCHAR(100)    NOT NULL,
  [CategoriaAtivo] BIT    NOT NULL,
     PRIMARY KEY ( [CategoriaId] ))
CREATE NONCLUSTERED INDEX [UCATEGORIA1] ON [Categoria] (
      [CategoriaNome])