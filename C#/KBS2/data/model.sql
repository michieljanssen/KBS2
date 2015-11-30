CREATE TABLE [dbo].[HeeftCijfer] (
    [toetsid]   NVARCHAR (10) NOT NULL,
    [studentid] INT           NOT NULL,
    [datum]     DATETIME      NOT NULL,
    [cijfer]    FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([toetsid] ASC, [studentid] ASC, [datum] ASC),
    FOREIGN KEY ([studentid]) REFERENCES [dbo].[Student] ([Id]),
    FOREIGN KEY ([toetsid]) REFERENCES [dbo].[Toets] ([Id])
);

GO
CREATE TABLE [dbo].[Klas] (
    [Id]    NVARCHAR (10) NOT NULL,
    [oplid] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[Student] (
    [Id]     INT           NOT NULL,
    [klasid] NVARCHAR (10) NOT NULL,
    [naam]   NVARCHAR (50) NOT NULL,
    [jaar]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([klasid]) REFERENCES [dbo].[Klas] ([Id])
);

GO
CREATE TABLE [dbo].[Toets] (
    [Id]    NVARCHAR (10) NOT NULL,
    [type]  NVARCHAR (20) NOT NULL,
    [vakid] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([vakid]) REFERENCES [dbo].[Vak] ([Id]),
    FOREIGN KEY ([vakid]) REFERENCES [dbo].[Vak] ([Id])
);

GO
CREATE TABLE [dbo].[Vak] (
    [Id]    NVARCHAR (20) NOT NULL,
    [oplid] NVARCHAR (10) NOT NULL,
    [ec]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
