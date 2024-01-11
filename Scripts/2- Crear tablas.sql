USE [Productos]
CREATE TABLE [dbo].[coCategoria](
	[nIdCategori] [int] IDENTITY(1,1) NOT NULL,
	[cNombCateg] [varchar](200) NOT NULL,
	[cEsActiva] [bit] NOT NULL,
 CONSTRAINT [PK_coCategoria] PRIMARY KEY CLUSTERED 
(
	[nIdCategori] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coProducto]    Script Date: 1/17/2023 1:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coProducto](
	[nIdProduct] [int] IDENTITY(1,1) NOT NULL,
	[cNombProdu] [varchar](200) NULL,
	[nPrecioProd] [decimal](12, 2) NULL,
	[nIdCategori] [int] NULL,
 CONSTRAINT [PK_coProducto] PRIMARY KEY CLUSTERED 
(
	[nIdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO