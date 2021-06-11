CREATE TABLE [dbo].[Employee] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [IdJob]     INT           NULL,
    [FirstName] VARCHAR (50)  NULL,
    [LastName]  VARCHAR (50)  NULL,
    [Email]     VARCHAR (100) NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_Job] FOREIGN KEY ([IdJob]) REFERENCES [dbo].[Job] ([Id])
);

