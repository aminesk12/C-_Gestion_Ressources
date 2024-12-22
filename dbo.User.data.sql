SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [Login], [Password], [NomPrenom], [Email], [Role]) VALUES (1, N'Ouail', N'1234', N'Gddar', N'gaddar@gmail.com', 2)
INSERT INTO [dbo].[User] ([Id], [Login], [Password], [NomPrenom], [Email], [Role]) VALUES (2, N'Ahmed', N'1234', N'nomPrenom1', N'ahmed@test.com', 3)
INSERT INTO [dbo].[User] ([Id], [Login], [Password], [NomPrenom], [Email], [Role]) VALUES (3, N'hakimRH', N'1234', N'nomPrenom2', N'hakim@gmail.com', 1)
INSERT INTO [dbo].[User] ([Id], [Login], [Password], [NomPrenom], [Email], [Role]) VALUES (4, N'fornisseur1', N'1234', N'fornisseur1', N'fornisseur1@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
