USE [Productos]
SET IDENTITY_INSERT [dbo].[coCategoria] ON 
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (1, N'Perecederos', 1)
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (2, N'Embutidos', 1)
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (3, N'no perecederos', 1)
GO

SET IDENTITY_INSERT [dbo].[coCategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[coProducto] ON 
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (1, N'Arroz', CAST(1000.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (2, N'Frijoles', CAST(1200.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (3, N'Leche', CAST(1100.00 AS Decimal(12, 2)), 1)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (4, N'Atun', CAST(1100.00 AS Decimal(12, 2)), 3)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (5, N'Sal', CAST(300.00 AS Decimal(12, 2)), 3)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (6, N'Jabón', CAST(2500.00 AS Decimal(12, 2)), 3)
GO
SET IDENTITY_INSERT [dbo].[coProducto] OFF
GO