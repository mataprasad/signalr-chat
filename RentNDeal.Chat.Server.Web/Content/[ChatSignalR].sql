USE [ChatSignalR]
GO
/****** Object:  Table [dbo].[DtChatUser]    Script Date: 08/05/2017 22:45:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DtChatUser](
	[ID] [varchar](50) NOT NULL,
	[Host] [nvarchar](100) NULL,
	[UserId] [nvarchar](100) NULL,
	[SessionId] [nvarchar](100) NULL,
	[ConnectionId] [varchar](100) NULL,
	[LoginDate] [datetime] NULL,
	[DisplayName] [nvarchar](100) NULL,
	[Ip] [varchar](50) NULL,
	[LoginStatus] [int] NULL,
 CONSTRAINT [PK_DtChatUsre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[UspLoginChatUser]    Script Date: 08/05/2017 22:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UspLoginChatUser]
(@ID varchar(50),
@Host nvarchar(1000),
@UserId varchar(100),
@SessionId nvarchar(100),
@ConnectionId varchar(100),
@LoginDate datetime,
@DisplayName nvarchar(100),
@Ip varchar(50),
@LoginStatus int)
AS
BEGIN
	DECLARE @TempChatId VARCHAR(50);
	SELECT @TempChatId=ID FROM DtChatUser WHERE UserId=@UserId AND SessionId=@SessionId AND IP=@Ip AND Host=@Host;
	IF @TempChatId IS NULL
	BEGIN
		INSERT INTO DtChatUser(ID,Host,UserId,SessionId,ConnectionId,LoginDate,DisplayName,Ip,LoginStatus)
			 VALUES(@ID,@Host,@UserId,@SessionId,@ConnectionId,@LoginDate,@DisplayName,@Ip,@LoginStatus)
		SET @TempChatId=@ID;
	END
	ELSE
	BEGIN
		UPDATE DtChatUser SET ConnectionId=@ConnectionId WHERE ID=@TempChatId
	END
	SELECT * FROM DtChatUser WHERE ID=@TempChatId;
END
GO
