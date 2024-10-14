CREATE TABLE [dbo].[reservation] (
    [RId]        INT  IDENTITY (1, 1) NOT NULL,
    [RDate]      DATE NOT NULL,
    [RChambre]   INT  NOT NULL,
    [Agent]      INT  NOT NULL,
    [DateArr]    DATE NOT NULL,
    [DateSortie] DATE NOT NULL,
    [Montant]    INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([RId] ASC),
    CONSTRAINT [Fk2] FOREIGN KEY ([RChambre]) REFERENCES [dbo].[chambre] ([ChId]) ON DELETE CASCADE,
    CONSTRAINT [FK3] FOREIGN KEY ([Agent]) REFERENCES [dbo].[agent] ([AgId]) ON DELETE CASCADE
);

