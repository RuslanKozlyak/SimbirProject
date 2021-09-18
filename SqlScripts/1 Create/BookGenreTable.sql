USE [LibraryTestV2]
GO

/****** Object:  Table [dbo].[book_genre]    Script Date: 18.09.2021 20:00:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[book_genre](
	[id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[genre_id] [int] NOT NULL,
	[added_date] [datetimeoffset](7) NULL,
	[modified_date] [datetimeoffset](7) NULL,
	[version] [int] NULL,
 CONSTRAINT [PK_book_genre] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[book_genre]  WITH CHECK ADD  CONSTRAINT [FK_book_genre_book_book_id] FOREIGN KEY([book_id])
REFERENCES [dbo].[book] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[book_genre] CHECK CONSTRAINT [FK_book_genre_book_book_id]
GO

ALTER TABLE [dbo].[book_genre]  WITH CHECK ADD  CONSTRAINT [FK_book_genre_genre_genre_id] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genre] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[book_genre] CHECK CONSTRAINT [FK_book_genre_genre_genre_id]
GO

