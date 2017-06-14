SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE SCHEMA [dw]
GO

CREATE TABLE [dw].[FCT_DS_WIPOHague](
    [Id] [uniqueidentifier] NOT NULL,
    [GroupType] [varchar](15) NOT NULL,
    [ReportingDate] [date] NOT NULL,
    [IntlRegistrations] [int] NOT NULL,
    [DesignsIntlRegistrations] [int] NOT NULL,
    [IntlApplications] [int] NOT NULL,
    [DesignsIntlApplications] [int] NOT NULL,
    [Renewals] [int] NOT NULL,
    [DesignsRenewals] [int] NOT NULL,
    [CreatedDate] [datetime] NOT NULL,
    [LastUpdateDate] [datetime] NULL,
    [IsDeleted] [bit] NULL,
    [DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_FCT_DS_WIPOHague] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  DEFAULT ((0)) FOR [IntlRegistrations]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  DEFAULT ((0)) FOR [DesignsIntlRegistrations]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  DEFAULT ((0)) FOR [IntlApplications]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  DEFAULT ((0)) FOR [DesignsIntlApplications]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  DEFAULT ((0)) FOR [Renewals]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  DEFAULT ((0)) FOR [DesignsRenewals]
GO

ALTER TABLE [dw].[FCT_DS_WIPOHague] ADD  CONSTRAINT [DF_DS_WIPOHague_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

