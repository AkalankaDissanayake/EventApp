USE [DbName]
GO

/****** Object:  Table [dbo].[Error]    Script Date: 5/6/2017 11:53:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Error](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[ObjectName] [varchar](100) NULL,
	[ErrorNumber] [int] NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [varchar](max) NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[OcceredDate] [datetime] NULL,
 CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED 
(
	[ErrorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

USE [DbName]
GO
/****** Object:  Table [dbo].[SampleData]    Script Date: 5/6/2017 11:54:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SampleData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SampleData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [DbName]
GO
/****** Object:  Table [dbo].[tblEvent]    Script Date: 5/6/2017 11:54:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEvent](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[VenueName] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[Address1] [varchar](100) NULL,
	[CountryCode] [varchar](20) NULL,
	[Postcode] [varchar](50) NULL,
	[City] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[EventStart] [datetime] NULL,
	[EventEnd] [datetime] NULL,
	[EventDescription] [varchar](max) NULL,
	[Latitude] [varchar](50) NULL,
	[Longitude] [varchar](50) NULL,
	[StatusID] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[EventImage] [image] NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblEvent] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


USE [DbName]
GO
/****** Object:  Table [dbo].[tblEventStatus]    Script Date: 5/6/2017 11:54:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEventStatus](
	[EventStatusID] [int] NULL,
	[StatusName] [varchar](50) NULL
) ON [PRIMARY]

GO

USE [DbName]
GO
/****** Object:  Table [dbo].[tblEventTicket]    Script Date: 5/6/2017 11:55:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEventTicket](
	[EventTicketID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[Type] [int] NULL,
	[Name] [varchar](100) NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblEventTicket] PRIMARY KEY CLUSTERED 
(
	[EventTicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[AddEditEvent]    Script Date: 5/6/2017 11:55:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
Stored Procedure    : [AddEditEvent]
Description         : [AddEditEvent] 
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

exec AddEditEvent @EventID =0
*/
CREATE PROCEDURE [dbo].[AddEditEvent]
@EventID int = null,
@Title varchar(100) = null,
@VenueName varchar(100) = null,
@Address varchar(100) = null,
@Address1 varchar(100) = null,
@CountryCode varchar(100) = null,
@Postcode varchar(100) = null,
@City varchar(100) = null,
@Country varchar(100) = null,
@EventStart varchar(100) = null,
@EventEnd varchar(100) = null,
@EventDescription  varchar(100) = null,
@Latitude varchar(100) = null,
@Longitude varchar(100) = null,
@StatusID varchar(100) = null,
@EventImage varchar(100) = null

AS

BEGIN
BEGIN TRY

    Declare @LEventID int = isnull(@EventID,0)

    IF(@EventID>0)
    begin
	   UPDATE [dbo].[tblEvent]
		 SET [Title] = @Title
		    ,[VenueName] = @VenueName
		    ,[Address] = @Address
		    ,[Address1] = @Address1
		    ,[CountryCode] = @CountryCode
		    ,[Postcode] = @Postcode
		    ,[City] = @City
		    ,[Country] = @Country
		    ,[EventStart] = @EventStart
		    ,[EventEnd] = @EventEnd
		    ,[EventDescription] = @EventDescription
		    ,[Latitude] = @Latitude
		    ,[Longitude] = @Longitude
		    ,[StatusID] = @StatusID
		    ,[EventImage] = @EventImage
	    WHERE EventID = @EventID
    end
    else
    begin
INSERT INTO [dbo].[tblEvent]
           ([Title]
           ,[VenueName]
           ,[Address]
           ,[Address1]
           ,[CountryCode]
           ,[Postcode]
           ,[City]
           ,[Country]
           ,[EventStart]
           ,[EventEnd]
           ,[EventDescription]
           ,[Latitude]
           ,[Longitude]
           ,[StatusID]
           ,[EventImage]
		 ,[CreatedDate])
     VALUES
           (
		 @Title,
		 @VenueName, 
		 @Address ,
		 @Address1 ,
		 @CountryCode,
		 @Postcode ,
		 @City ,
		 @Country ,
		 @EventStart,
		 @EventEnd ,
		 @EventDescription,
		 @Latitude ,
		 @Longitude, 
		 @StatusID ,
		 @EventImage,
		 GETDATE())
		 
		 set @LEventID =scope_identity()
    end

    select @LEventID EventID
END TRY
BEGIN CATCH

    DECLARE @ErrorNumber INT= ERROR_NUMBER();
    DECLARE @ErrorLine INT= ERROR_LINE();
    DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT= ERROR_SEVERITY();
    DECLARE @ErrorState INT= ERROR_STATE();
   EXEC LogError @ObjectName ='AddEditEvent',@ErrorNumber=@ErrorNumber,
	   @ErrorLine=@ErrorLine,@ErrorMessage= @ErrorMessage,@ErrorSeverity=@ErrorSeverity,
	   @ErrorState=@ErrorState
END CATCH;
END



GO


USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[AddEditEventTicket]    Script Date: 5/6/2017 11:55:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
Stored Procedure    : AddEditEventTicket
Description         : AddEditEventTicket 
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

exec AddEditEvent @EventID =0
*/
CREATE PROCEDURE [dbo].[AddEditEventTicket]
@EventTicketID int = null,
@EventID int =null,
@Type int = null,
@Name varchar(100) = null,
@Quantity int = null,
@Price decimal = null
AS
BEGIN
BEGIN TRY

    Declare @LEventTicketID int = isnull(@EventTicketID,0)

    IF(@LEventTicketID>0)
    begin
	   UPDATE [dbo].[tblEventTicket]
		 SET 
		     [Name] = @Name
		    ,[Quantity] = @Quantity
		    ,[Price] = @Price
	    WHERE EventTicketID = @LEventTicketID
    end
    else
    begin
INSERT INTO [dbo].[tblEventTicket]
           ([Type]
		 ,[EventID]
           ,[Name]
           ,[Quantity]
           ,[Price])
     VALUES
           (@Type
		 ,@EventID
           ,@Name
           ,@Quantity
           ,@Price)
		 
		 set @LEventTicketID =scope_identity()
    end

    select @LEventTicketID EventTicketID
END TRY
BEGIN CATCH

    DECLARE @ErrorNumber INT= ERROR_NUMBER();
    DECLARE @ErrorLine INT= ERROR_LINE();
    DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT= ERROR_SEVERITY();
    DECLARE @ErrorState INT= ERROR_STATE();
   EXEC LogError @ObjectName ='AddEditEventTicket',@ErrorNumber=@ErrorNumber,
	   @ErrorLine=@ErrorLine,@ErrorMessage= @ErrorMessage,@ErrorSeverity=@ErrorSeverity,
	   @ErrorState=@ErrorState
END CATCH;
END



GO

USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[AddEditSampleData]    Script Date: 5/6/2017 11:55:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
Stored Procedure    : [AddEditSampleData]
Description         : [AddEditSampleData] 
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

*/
CREATE PROCEDURE [dbo].[AddEditSampleData]
@XID int = 0,
@XName varchar(50) = ''
AS

BEGIN

Declare @ID int= isnull(@XID,0),
        @Name varchar(50) = isnull(@XName,'')

    if(@ID =0)
        begin
            insert into SampleData
            values(@Name);
        end
    else 
        begin
            update SampleData set Name = @XName
            where ID = @ID
        end
END



GO

USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSampleData]    Script Date: 5/6/2017 11:56:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
Stored Procedure    : GetAll Sample Data
Description         : GetAll Samle Data with Pagination
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

*/
CREATE PROCEDURE [dbo].[GetAllSampleData]
@XPageIndex int = 1,
@XPageSize int = 10,
@XSearchText varchar(50) = ''
AS
BEGIN

	Declare @PageIndex int = isnull(@XPageIndex,0),
			@PageSize int = isnull(@XPageSize,0),
			@SearchText varchar(50) = isnull(@XSearchText,'')

    select ID as ID,Name as Name,ROW_NUMBER() over(order by ID) as RowNum into #TempSample from SampleData with(nolock)
	where @XSearchText='' or Name like '%'+@XSearchText+'%'

	select * from #TempSample
	WHERE RowNum BETWEEN (((@PageIndex - 1) * (@XPageSize)) + 1) AND (@PageIndex * @XPageSize);

	select count(1) as TotalCount from #TempSample
        
END



GO

USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[GetEvetByID]    Script Date: 5/6/2017 11:56:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
Stored Procedure    : GetEvetByID
Description         : 
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

*/

CREATE PROCEDURE [dbo].[GetEvetByID] 
@EventID INT = NULL
AS
     BEGIN
         DECLARE @LEventID INT= isnull(@EventID, 0);
         BEGIN TRY
		   select * from tblEvent where EventID =@LEventID
		   Select * from tblEventTicket where  EventID =@LEventID
         END TRY
         BEGIN CATCH

             DECLARE @ErrorNumber INT= ERROR_NUMBER();
             DECLARE @ErrorLine INT= ERROR_LINE();
             DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE();
             DECLARE @ErrorSeverity INT= ERROR_SEVERITY();
             DECLARE @ErrorState INT= ERROR_STATE();
		   EXEC LogError @ObjectName ='GetEvetByID',@ErrorNumber=@ErrorNumber,
			   @ErrorLine=@ErrorLine,@ErrorMessage= @ErrorMessage,@ErrorSeverity=@ErrorSeverity,
			   @ErrorState=@ErrorState
         END CATCH;

     END;
GO

USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[GetReferenceData]    Script Date: 5/6/2017 11:56:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
Stored Procedure    : Get reference data
Description         : 
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

--exec GetReferenceData @XType = 0
*/

CREATE PROCEDURE [dbo].[GetReferenceData] @XType INT = NULL
AS
     BEGIN
         DECLARE @Type INT= isnull(@XType, 0);
         BEGIN TRY
		   IF(@Type = 0)
			  BEGIN

				Select EventID ID , Title as Value  from tblEvent
			  END;
         END TRY
         BEGIN CATCH

             DECLARE @ErrorNumber INT= ERROR_NUMBER();
             DECLARE @ErrorLine INT= ERROR_LINE();
             DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE();
             DECLARE @ErrorSeverity INT= ERROR_SEVERITY();
             DECLARE @ErrorState INT= ERROR_STATE();
		   EXEC LogError @ObjectName ='GetReferenceData',@ErrorNumber=@ErrorNumber,
			   @ErrorLine=@ErrorLine,@ErrorMessage= @ErrorMessage,@ErrorSeverity=@ErrorSeverity,
			   @ErrorState=@ErrorState
         END CATCH;

     END;
GO
USE [DbName]
GO

/****** Object:  StoredProcedure [dbo].[LogError]    Script Date: 5/6/2017 11:56:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
Stored Procedure    : Get reference data
Description         : 
Created Date        : 6 may 2017
***********************************************************
Modification Control
Code        Name            Date            Comment
-----------------------------------------------------------

*/

CREATE PROCEDURE [dbo].[LogError] 
@ObjectName varchar(100) = null,
@ErrorNumber INT= null,
@ErrorLine INT  = null,
@ErrorMessage VARCHAR(4000) = null,
@ErrorSeverity INT = null,
@ErrorState INT = null
AS
     BEGIN
	insert into Error(ObjectName,ErrorNumber,ErrorLine ,ErrorMessage,ErrorSeverity,ErrorState,OcceredDate)
	values(@ObjectName,@ErrorNumber,@ErrorLine,@ErrorMessage,@ErrorSeverity,@ErrorState,GETDATE());

     END;
GO


