CREATE TABLE [dbo].[agent] (
    [AgId]       INT  IDENTITY (1, 1) NOT NULL,
    [AgNom]      VARCHAR (50) NOT NULL,
    [AgTel]      VARCHAR (20) NOT NULL,
    [AgGenre]    VARCHAR (10) NOT NULL,
    [AgAdd]      VARCHAR (50) NOT NULL,
    [AgMotPasse] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AgId] ASC)
);

