USE [LibraryTestV2]
GO

/****** Object:  Table [dbo].[book]    Script Date: 18.09.2021 20:00:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[book](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[author_id] [int] NOT NULL,
	[year_of_writing] [datetime2](7) NULL,
	[added_date] [datetimeoffset](7) NULL,
	[modified_date] [datetimeoffset](7) NULL,
	[version] [int] NULL,
 CONSTRAINT [PK_book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_book_author_author_id] FOREIGN KEY([author_id])
REFERENCES [dbo].[author] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_book_author_author_id]
GO

