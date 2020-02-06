CREATE TABLE [dbo].[login] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [username]       NVARCHAR (20) NOT NULL,
    [password]       NVARCHAR (50) NOT NULL,
    [profilePicture] IMAGE         NULL,
    [fName]          VARCHAR (30)  NOT NULL,
    [lName]          VARCHAR (30)  NOT NULL,
    [position]       VARCHAR (30)  NOT NULL,
    [department]     VARCHAR (30)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);