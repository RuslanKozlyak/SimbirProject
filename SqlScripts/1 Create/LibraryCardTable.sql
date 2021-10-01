USE [LibraryTestV2]
GO

/****** Object:  Table [dbo].[library_card]    Script Date: 18.09.2021 20:00:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[library_card](
	[id] [int] NOT NULL,
	[person_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[pickup_date] [datetime2](7) NOT NULL,
	[added_date] [datetimeoffset](7) NULL,
	[modified_date] [datetimeoffset](7) NULL,
	[version] [int] NULL,
 CONSTRAINT [PK_library_card] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[library_card]  WITH CHECK ADD  CONSTRAINT [FK_library_card_book_book_id] FOREIGN KEY([book_id])
REFERENCES [dbo].[book] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[library_card] CHECK CONSTRAINT [FK_library_card_book_book_id]
GO

ALTER TABLE [dbo].[library_card]  WITH CHECK ADD  CONSTRAINT [FK_library_card_person_person_id] FOREIGN KEY([person_id])
REFERENCES [dbo].[person] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[library_card] CHECK CONSTRAINT [FK_library_card_person_person_id]
GO

