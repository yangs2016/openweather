create table [dbo].[GeoCode] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Latitude]    FLOAT (53)      NOT NULL,
    [Longitude]   FLOAT (53)      NOT NULL,
    [PostalCode]  VARCHAR (10)    NULL,
    [Description] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
go


CREATE TABLE [dbo].[WeatherCondition] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [GeoCodeId]    INT            NOT NULL,
    [Temperaturea] FLOAT (53)     NOT NULL,
    [Condition]    NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

go
alter table dbo.WeatherCondition 
add constraint FK_GeocodeId foreign key (GeoCodeId) references dbo.GeoCode(Id) 
go

