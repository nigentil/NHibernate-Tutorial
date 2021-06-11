CREATE TABLE [dbo].[Job] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [JobName] VARCHAR (50) NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

