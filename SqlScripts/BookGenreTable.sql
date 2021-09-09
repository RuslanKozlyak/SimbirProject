USE [Library]
GO

/****** Object:  Table [dbo].[book_gener]    Script Date: 09.09.2021 0:23:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[book_gener](
	[book_id] [int] NOT NULL,
	[genre_id] [int] NOT NULL,
 CONSTRAINT [PK_book_gener_1] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC,
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[book_gener]  WITH CHECK ADD  CONSTRAINT [FK_book_gener_book] FOREIGN KEY([book_id])
REFERENCES [dbo].[book] ([íd])
GO

ALTER TABLE [dbo].[book_gener] CHECK CONSTRAINT [FK_book_gener_book]
GO

ALTER TABLE [dbo].[book_gener]  WITH CHECK ADD  CONSTRAINT [FK_book_gener_genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genre] ([id])
GO

ALTER TABLE [dbo].[book_gener] CHECK CONSTRAINT [FK_book_gener_genre]
GO

