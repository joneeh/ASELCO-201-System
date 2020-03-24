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

CREATE TABLE [dbo].[adminlogin] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] NVARCHAR (20) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[logs] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [change]      VARCHAR (100) NOT NULL,
    [datechanged] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[employeeRec] (
    [Id]                   INT           NOT NULL,
    [fname]                VARCHAR (50)  NULL,
    [lname]                VARCHAR (50)  NULL,
    [mname]                VARCHAR (50)  NULL,
    [birthDate]            DATE          NULL,
    [birthPlace]           VARCHAR (100) NULL,
    [educAttainment]       VARCHAR (100) NULL,
    [dateHired]            DATE          NULL,
    [dateadded]            DATE          NULL,
    [dateedited]           DATE          NULL,
    [datedied]             DATE          NULL,
    [dateresigned]         DATE          NULL,
    [SSSno]                VARCHAR (12)  NULL,
    [HDMFno]               VARCHAR (16)  NULL,
    [TIN]                  VARCHAR (13)  NULL,
    [philhealth]           VARCHAR (14)  NULL,
    [employeeclass]        VARCHAR (20)  NULL,
    [employeestatus]       VARCHAR (20)  NULL,
    [profilepic]           IMAGE         NULL,
    [birthcertificate]     IMAGE         NULL,
    [marriagecertificate]  IMAGE         NULL,
    [diploma]              IMAGE         NULL,
    [barangayclearance]    IMAGE         NULL,
    [neuropsyclearance]    IMAGE         NULL,
    [policeclearance]      IMAGE         NULL,
    [mayorsclearance]      IMAGE         NULL,
    [judgesclearance]      IMAGE         NULL,
    [tor]                  IMAGE         NULL,
    [officeorders]         IMAGE         NULL,
    [notices]              IMAGE         NULL,
    [medicalcertificateID] INT           NULL,
    [drugtestreportID]     INT           NULL,
    [memorandumID]         INT           NULL,
    [contractsID]          INT           NULL,
    [performanceEvalID]    INT           NULL,
    [servicerecordsID]     INT           NULL,
    [meritdemeritID]       INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


create view employechart (employeeClass, Count)
as
select employeeclass, COUNT(*)
from employeeRec where employeeclass IS NOT NULL
group by employeeclass
