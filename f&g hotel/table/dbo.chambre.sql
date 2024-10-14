CREATE TABLE [dbo].[chambre] (
    [ChId]           INT           IDENTITY (100, 1) NOT NULL,
    [ChNom]          VARCHAR (50)  NOT NULL,
    [ChCat]          INT           NOT NULL,
    [ChLocalisation] VARCHAR (150) NOT NULL,
    [ChPrix]         INT           NOT NULL,
    [ChDetails]      VARCHAR (150) NOT NULL,
    [Chstatut]       VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ChId] ASC),
    CONSTRAINT [FK1] FOREIGN KEY ([ChCat]) REFERENCES [dbo].[category] ([CatId]) ON DELETE CASCADE
);

