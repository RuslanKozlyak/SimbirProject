USE [LibraryTestV2]
GO

/****** Object:  Table [dbo].[person]    Script Date: 18.09.2021 20:00:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[person](
	[id] [int] NOT NULL,
	[first_name] [nvarchar](max) NOT NULL,
	[last_name] [nvarchar](max) NOT NULL,
	[middle_name] [nvarchar](max) NULL,
	[birth_date] [nvarchar](max) NULL,
	[added_date] [datetimeoffset](7) NULL,
	[modified_date] [datetimeoffset](7) NULL,
	[version] [int] NULL,
 CONSTRAINT [PK_person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

