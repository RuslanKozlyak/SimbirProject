USE [Library]
GO

/****** Object:  Table [dbo].[author]    Script Date: 09.09.2021 0:23:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[author](
	[id] [int] NOT NULL,
	[first_name] [nchar](100) NOT NULL,
	[last_name] [nchar](100) NOT NULL,
	[middle_name] [nchar](100) NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

