CREATE TABLE [dbo].[category] (
    [CatId]      INT           IDENTITY (1, 1) NOT NULL,
    [CatNom]     VARCHAR (50)  NOT NULL,
    [CatDetails] VARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([CatId] ASC)
);

