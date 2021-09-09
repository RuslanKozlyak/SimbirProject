USE [Library]
GO

/****** Object:  Table [dbo].[library_card]    Script Date: 09.09.2021 0:24:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[library_card](
	[book_id] [int] NOT NULL,
	[person_id] [int] NOT NULL,
 CONSTRAINT [PK_library_card] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC,
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[library_card]  WITH CHECK ADD  CONSTRAINT [FK_library_card_book] FOREIGN KEY([book_id])
REFERENCES [dbo].[book] ([íd])
GO

ALTER TABLE [dbo].[library_card] CHECK CONSTRAINT [FK_library_card_book]
GO

ALTER TABLE [dbo].[library_card]  WITH CHECK ADD  CONSTRAINT [FK_library_card_person] FOREIGN KEY([person_id])
REFERENCES [dbo].[person] ([id])
GO

ALTER TABLE [dbo].[library_card] CHECK CONSTRAINT [FK_library_card_person]
GO

