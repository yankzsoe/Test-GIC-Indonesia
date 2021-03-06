/****** Object:  Table [dbo].[Contact]    Script Date: 2020-04-27 07:08:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Address] [varchar](150) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteContact]    Script Date: 2020-04-27 07:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<yayang suryana>
-- Create date: <25 April 2020>
-- Description:	<...>
-- =============================================
CREATE PROCEDURE [dbo].[USP_DeleteContact]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Contact WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertContact]    Script Date: 2020-04-27 07:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<yayang suryana>
-- Create date: <25 April 2020>
-- Description:	<Insert into Contact>
-- =============================================
CREATE PROCEDURE [dbo].[USP_InsertContact] 
	@Name varchar(50),
	@PhoneNumber varchar(15),
	@Address varchar(150)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Contact VALUES (@Name,@PhoneNumber,@Address)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateContact]    Script Date: 2020-04-27 07:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<yayang suryana>
-- Create date: <25 April 2020>
-- Description:	<...>
-- =============================================
CREATE PROCEDURE [dbo].[USP_UpdateContact] 
	@Id int,
	@Name varchar(50),
	@PhoneNumber varchar(15),
	@Address varchar(150)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Contact SET [Name] = @Name,
					   PhoneNumber = @PhoneNumber,
					   [Address] = @Address
	WHERE Id = @Id 
END
GO
