USE [Library]
GO

/****** Object:  Table [dbo].[person]    Script Date: 09.09.2021 0:24:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[person](
	[id] [int] NOT NULL,
	[birth_date] [date] NULL,
	[first_name] [nchar](100) NOT NULL,
	[last_name] [nchar](100) NOT NULL,
	[middle_name] [nchar](100) NULL,
 CONSTRAINT [PK_person_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

