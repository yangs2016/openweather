use Openweather

if not exists(select * from sys.tables where name = N'GeoCode' and SCHEMA_NAME(schema_id)='dbo')
begin
create table [dbo].[GeoCode] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Latitude]    decimal(4,2)      NOT NULL,
    [Longitude]   decimal (4,2)      NOT NULL,
    [PostalCode]  VARCHAR (10)    NULL,
    [Description] NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
end

if not exists(select * from sys.tables where name = N'WeatherCondition' and SCHEMA_NAME(schema_id)='dbo')
begin
create TABLE [dbo].[WeatherCondition] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [GeoCodeId]    INT            NOT NULL,
    [Temperature]  decimal (5,2)    NOT NULL,
    [Condition]    NVARCHAR (200) NULL,
	[CreatedDate] datetime not null,
	[LastUpdatedDate] datetime not null,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

end

alter table dbo.WeatherCondition 
add constraint FK_GeocodeId foreign key (GeoCodeId) references dbo.GeoCode(Id) 
go

