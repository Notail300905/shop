CREATE TABLE [dbo].[Login] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    [role_Title]     NVARCHAR (50) NOT NULL,
    [role_bitMask] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

