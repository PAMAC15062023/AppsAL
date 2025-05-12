
/****** Object:  Table [dbo].[InternalAudit_UserMaster]    Script Date: 8/23/2023 11:12:36 AM ******/
CREATE TABLE [dbo].[InternalAudit_UserMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[UserID] [varchar](100) NULL,
	[Password] [varchar](200) NULL,
	[RoleID] [int] NULL,
	[Email] [varchar](200) NULL,
	[CPC] [varchar](100) NULL,
	[Vertical] [varchar](100) NULL,
	[LoginDate] [datetime] NULL,
	[LogoutDate] [datetime] NULL,
	[IsFirstTime] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](100) NULL
) ON [PRIMARY]
GO

--Insert into InternalAudit_UserMaster
--(UserName,UserID,Password,RoleID,Email,CPC,Vertical,IsActive,CreatedDate,CreatedBy)
--Values('Suhani','R100004','iZUm9RWhQkwMECrJvxIkBomyQ5ISf38MUT2infoc5eY=',1,'s@sgmail.com','Mumbai','SSU',1,GetDate(),'R100004')
--===============================================================================================================================

CREATE TABLE [dbo].[InternalAudit_RoleMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[ModifyBy] [varchar](100) NULL
) ON [PRIMARY]
GO
--Insert into InternalAudit_RoleMaster (Role,IsActive,CreatedDate,CreatedBy)
--Values ('Auditor', 1, GetDate(), 'R100004')

--Insert into InternalAudit_RoleMaster (Role,IsActive,CreatedDate,CreatedBy)
--Values ('Auditee', 1, GetDate(), 'R100004')
--=======================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_LocationMaster]    Script Date: 8/23/2023 3:01:38 PM ******/

CREATE TABLE [dbo].[InternalAudit_LocationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Mumbai',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Kolkata',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Delhi',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Hyderabad',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Bangalore',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Chennai',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Pune',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Jaipur',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Bhopal',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Ahmedabad',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Lucknow',1,Getdate(),'R100004')

--insert into InternalAudit_LocationMaster (Location,IsActive,CreatedDate,CreatedBy)
--Values ('Chandigarh',1,Getdate(),'R100004')
--=============================================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_FinalStatusMaster]    Script Date: 8/23/2023 1:04:15 PM ******/

CREATE TABLE [dbo].[InternalAudit_FinalStatusMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FinalStatus] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL
) ON [PRIMARY]
GO

--Insert into InternalAudit_FinalStatusMaster (FinalStatus,IsActive,CreatedDate,CreatedBy)
--Values ('Open',1,GetDate(),'R100004')

--Insert into InternalAudit_FinalStatusMaster (FinalStatus,IsActive,CreatedDate,CreatedBy)
--Values ('In Progress',1,GetDate(),'R100004')

--Insert into InternalAudit_FinalStatusMaster (FinalStatus,IsActive,CreatedDate,CreatedBy)
--Values ('Close',1,GetDate(),'R100004')
--===========================================================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_AuditDecisionMaster]    Script Date: 8/23/2023 1:17:07 PM ******/

CREATE TABLE [dbo].[InternalAudit_AuditDecisionMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuditDecision] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL
) ON [PRIMARY]
GO

--insert into InternalAudit_AuditDecisionMaster (AuditDecision,IsActive,CreatedDate,CreatedBy)
--Values ('Observation', 1, GETDATE(), 'R100004')

--insert into InternalAudit_AuditDecisionMaster (AuditDecision,IsActive,CreatedDate,CreatedBy)
--Values ('OFI', 1, GETDATE(), 'R100004')

--insert into InternalAudit_AuditDecisionMaster (AuditDecision,IsActive,CreatedDate,CreatedBy)
--Values ('NC', 1, GETDATE(), 'R100004')
--=============================================================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_VerticalMaster]    Script Date: 8/23/2023 1:43:55 PM ******/

CREATE TABLE [dbo].[InternalAudit_VerticalMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Vertical] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL
) ON [PRIMARY]
GO

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('CISO',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('Admin',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('EBC',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('HR',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('CPV',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('IT',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('RCU',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('DCR',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('BVU',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('CPA',1,GetDate(),'R100004')

--Insert into InternalAudit_VerticalMaster (Vertical,IsActive,CreatedDate,CreatedBy)
--Values ('TPU',1,GetDate(),'R100004')
--====================================================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_UnitMaster]    Script Date: 8/23/2023 3:59:58 PM ******/

CREATE TABLE [dbo].[InternalAudit_UnitMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Unit] [varchar](50) NULL,
	[LocationID] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InternalAudit_UnitMaster]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[InternalAudit_LocationMaster] ([ID])
GO

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('A21',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('B22',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('A24',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('C19',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('B4',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('A24',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('C21',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('B4',1,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Kolkata',2,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Delhi',3,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Hyderabad',4,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Bangalore',5,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Chennai',6,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Pune',7,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Jaipur',8,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Bhopal',9,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Ahmedabad',10,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Chandigarh',12,1,GetDate(),'R100004')

--insert into InternalAudit_UnitMaster(Unit,LocationID,IsActive,CreatedDate,CreatedBy)
--Values ('Lucknow',11,1,GetDate(),'R100004')
--===========================================================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_QuarterValueMaster]    Script Date: 8/23/2023 4:15:59 PM ******/

CREATE TABLE [dbo].[InternalAudit_QuarterValueMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Quarter] [varchar](50) NULL,
	[value] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL
) ON [PRIMARY]
GO

--Insert into InternalAudit_QuarterValueMaster (Quarter,value,IsActive,CreatedDate,CreatedBy)
--Values('Q1-Q2',1,1,GetDate(),'R100004')

--Insert into InternalAudit_QuarterValueMaster (Quarter,value,IsActive,CreatedDate,CreatedBy)
--Values('Q3-Q4',2,1,GetDate(),'R100004')
--================================================================================================================================================================

/****** Object:  Table [dbo].[InternalAudit_ISMSClausesAndControls]    Script Date: 8/23/2023 4:34:30 PM ******/

CREATE TABLE [dbo].[InternalAudit_ISMSClausesAndControls](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Clause] [varchar](300) NULL,
	[ClauseRequirement] [varchar](300) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [varchar](50) NULL
) ON [PRIMARY]
GO

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	('4','context of the organization',1,GetDate(),'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	('4.1','Understanding the organization and its context',1,GetDate(),'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'4.2',	'Understanding the needs and expectations of interested parties',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'4.3',	'Determining the scope of the information security management system',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'4.4',	'Information security management system',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'5.1',	'Leadership and commitment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'5.2',	'Policy',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'5.3',	'Organizational roles, responsibilities and authorities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'6',	'Planning',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'6.1',	'Actions to address risks and opportunities',1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'6.2',	'Information security objectives and planning to achieve them',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'7',	'Support',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'7.1',	'Resources',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'7.2',	'Competence',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'7.3',	'Awareness',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'7.4',	'Communication',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'7.5',	'Documented information',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'8',	'Operation',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'8.1',	'Operational planning and control',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'8.2',	'Information security risk assessment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'8.3',	'Information security risk treatment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'9',	'Performance evaluation',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'9.1',	'Monitoring, measurement, analysis and evaluation',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'9.2',	'Internal audit',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'9.3',	'Management review',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'10',	'Improvement',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'10.1',	'Nonconformity and corrective action',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'10.2',	'Continual improvement',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.5.1.1','Policies for Information Security',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.5.1.2',	'Review of the policies for information security',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.1.1',	'Information security roles and responsibilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.1.2',	'Segregation of duties',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.1.3',	'Contact with authorities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.1.4',	'Contact with special interest groups',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.1.5',	'Information security in project management',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.2.1',	'Mobile device policy',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.6.2.2',	'Teleworking',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.7.1.1',	'Screening',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.7.1.2',	'Terms and conditions of employment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'A.7.2.1',	'Management responsibilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.7.2.2',	'Information security awareness, education  and training',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'A.7.2.3',	'Disciplinary process',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.7.3.1',	'Termination or change of employment responsibilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.1.1',	'Inventory of assets',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.1.2', 'Ownership of assets',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.1.3',	'Acceptable use of assets',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.8.1.4',	'Return of assets',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.2.1',	'Classification of information',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.8.2.2',	'Labeling of information',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.2.3',	'Handling of assets',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.3.1',	'Management of removable media',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.3.2',	'Disposal of media',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.8.3.3', 'Physical media transfer',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'A.9.1.1',	'Access control policy',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) values	
--(	'A.9.1.2',	'Access to networks and network services',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.2.1',	'User registration and de-registration',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.2.2',	'User access provisioning',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.2.3',	'Management of privileged access rights',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.2.4',	'Management of secret authentication information of users',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.2.5',	'Review of user access rights',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.2.6',	'Removal or adjustment of access rights',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.3.1',	'Use of secret authentication information',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.4.1',	'Information access restriction',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.4.2',	'Secure log-on procedures',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.4.3',	'Password management system',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.4.4',	'Use of privileged utility programs',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.9.4.5',	'Access control to program source code',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.10.1.1',	'Policy on the use of cryptographic controls',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.10.1.2',	'Key management',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.11.1.1',	'Physical security perimeter',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.1.2',	'Physical entry controls',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.1.3',	'Securing office, room and facilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.1.4',	'Protecting against external end environmental threats',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.1.5',	'Working in secure areas',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.1.6',	'Delivery and loading areas',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.11.2.1',	'Equipment sitting and protection',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.2.2',	'Supporting utilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.2.3',	'Cabling security',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.11.2.4',	'Equipment maintenance',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.11.2.5',	'Removal of assets',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.2.6',	'Security of equipment and assets off-premises',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.2.7',	'Secure disposal or reuse of equipment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.11.2.8',	'Unattended user equipment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.11.2.9',	'Clear desk and clear screen policy',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.12.1.1',	'Documented operating procedures',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.12.1.2',	'Change management',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.1.3',	'Capacity management',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.1.4',	'Separation of development, testing and operational environments',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.2.1',	'Controls against malware',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.3.1',	'Information backup',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.12.4.1',	'Event logging',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.4.2',	'Protection of log information',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.12.4.3',	'Administrator and operator logs',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.4.4',	'Clock synchronization',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.5.1',	'Installation of software on operational systems',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.12.6.1',	'Management of technical vulnerabilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.12.6.2',	'Restrictions on software installations',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.12.7.1',	'Information systems audit controls',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.13.1.1',	'Network controls',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.13.1.2',	'Security of network services',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.13.1.3',	'Segregation in networks',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.13.2.1',	'Information transfer policies and procedures',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.13.2.2',	'Agreements on information transfer',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.13.2.3',	'Electronic messaging',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.13.2.4',	'Confidentiality or non-disclosure agreements',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.1.1',	'Information security requirements analysis and specification',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.1.2',	'Securing applications services on public networks',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.1.3',	'Protecting application services transactions',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.2.1',	'Secure development policy',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.14.2.2',	'System Change control procedures',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.2.3',	'Technical review of applications after operating platform changes',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.2.4',	'Restrictions on changes to software packages',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.14.2.5',	'Secure system engineering principles',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.14.2.6',	'Secure development environment',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.2.7',	'Outsourced development',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.14.2.8',	'System security testing',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.14.2.9',	'System acceptance testing',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.14.3.1',	'Protection of test data',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.15.1.1',	'Information security policy for supplier relationships',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.15.1.2',	'Addressing security within supplier agreements',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.15.1.3',	'Information and communication technology supply chain',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.15.2.1',	'Monitoring and review of supplier services',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.15.2.2',	'Managing changes to supplier services',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.16.1.1',	'Responsibilities and procedures',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.16.1.2',	'Reporting information security events',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.16.1.3',	'Reporting information security weaknesses',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.16.1.4',	'Assessment of and decision on information security events',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.16.1.5',	'Response to information security incidents',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.16.1.6',	'Learning from information security incidents',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.16.1.7',	'Collection of evidence',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.17.1.1',	'Planning information security continuity',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.17.1.2',	'Implementing information security continuity',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.17.1.3',	'Verify, review and evaluate information security continuity',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.17.2.1',	'Availability of information processing facilities',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.18.1.1',	'Identification of applicable legislation and contractual requirements',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.18.1.2',	'Intellectual property rights (IPR)',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.18.1.3',	'Protection of records',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.18.1.4',	'Privacy and protection of personally identifiable information',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.18.1.5',	'Regulation of cryptographic controls',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.18.2.1',	'Independent review of information security',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy) 
--values	(	'A.18.2.4',	'Compliance with security policies and standards',	1,	GetDate(),	'R100004')

--Insert into InternalAudit_ISMSClausesAndControls (Clause,ClauseRequirement,IsActive,CreatedDate,CreatedBy)
--values	(	'A.18.2.3',	'Technical compliance review',	1,	GetDate(),	'R100004')
======================================================================================================================================================================================================================================