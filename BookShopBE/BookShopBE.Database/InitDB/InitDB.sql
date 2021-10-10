USE [BookShopDB]
GO
-- INSERT DATA INTO AUTHORS
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Nguyen Nhat Anh', N'0912333448', N'nhatanh.nguyen@gmail.com', NULL, CAST(N'2021-10-11T02:08:05.428' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Vu Phuong Thanh', N'0935121898' ,N'phuongthanh.vu@gmail.com', NULL, CAST(N'2021-10-11T02:12:06.428' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Nguyen Ha Trang', N'035992162', N'hatrang.nguyen@gmail.com', NULL, CAST(N'2021-10-11T02:14:08.669' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Nguyen Minh Nhat', N'0869664153', N'minhnhat.nguyen@gmail.com', NULL, CAST(N'2021-10-11T02:17:05.328' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Ha Anh Khang', N'0325729448', N'anhkhang.ha@gmail.com', NULL, CAST(N'2021-10-11T02:19:05.428' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Le Minh Chau', N'0333121989', N'minhchau.le@gmail.com', NULL, CAST(N'2021-10-11T02:20:06.224' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Vu Hong Hanh', N'0125442895' ,N'honghanh.vu@gmail.com', NULL, CAST(N'2021-10-11T02:22:01.468' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
INSERT [dbo].[Authors] ([Name], [PhoneNumber], [Email], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy])
				VALUES (N'Tran Minh Vuong', N'0925882635', N'minhvuong.tran@gmail.com', NULL, CAST(N'2021-10-11T02:24:01.328' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL)
GO

-- INSERT DATA INTO PUBLISHERS
INSERT [dbo].[Publishers] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Country], [Email])
				   VALUES (N'Nha xuat ban tre', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'Viet Nam', N'xuatbantre@gmail.com')
INSERT [dbo].[Publishers] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Country], [Email])
				   VALUES (N'Nha xuat ban tong hop', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'Viet Nam', N'bachkhoa.xuatban@gmail.com')
INSERT [dbo].[Publishers] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Country], [Email])
				   VALUES (N'Nha xuat ban khoa hoc', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'Viet Nam', N'giaoduc.xuatban@gmail.com')
INSERT [dbo].[Publishers] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Country], [Email])
				   VALUES (N'Nha xuat ban Kim Dong', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'Viet Nam', N'xuatbankimdong@gmail.com')
INSERT [dbo].[Publishers] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Country], [Email])
				   VALUES (N'Nha xuat ban Bach Khoa', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'Viet Nam', N'xuatbantonghop@gmail.com')
INSERT [dbo].[Publishers] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Country], [Email])
				   VALUES (N'Nha xuat ban chinh tri', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'Viet Nam', N'xuatbanchinhtri@gmail.com')
GO

-- INSERT DATA INTO BOOKS
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Mat biec', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 5, N'Tieu thuyet', 4.25, NULL, 2)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Ngoi khoc tren cay', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 5, N'Tieu thuyet', 3.25, NULL, 1)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Ky uc Northumbria', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Tieu thuyet', 2.25, NULL, 1)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Cho toi xin mot ve di tuoi tho', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Tieu thuyet', 3.15, NULL, 2)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Kham pha the gioi dong vat', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Sach khoa hoc', 2.89, NULL, 3)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Bi mat dai duong', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Sach khoa hoc', 3.55, NULL, 3)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Hinh hoc phang thi Olympic Toan', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 5, N'Toan hoc', 5.25, NULL, 4)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Anh se yeu em mai chu', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 3, N'Tieu thuyet', 1.89, NULL, 1)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Con meo ben cua so', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Tieu thuyet', 2.85, NULL, 2)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Kham pha so hoc', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Tieu thuyet', 4.05, NULL, 4)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Doraemon - Tap 1', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 5, N'Truyen tranh', 1.25, NULL, 5)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Doraemon - Tap 2', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 4, N'Truyen tranh', 1.25, NULL, 5)
INSERT [dbo].[Books] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Rate], [Genre], [Price], [Url], [PublisherId])
			  VALUES (N'Doraemon - Tap 3', CAST(N'2021-10-11T02:28:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, 5, N'Truyen tranh', 1.25, NULL, 5)
GO

-- INSERT DATA INTO STORES
INSERT [dbo].[Stores] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Address], [PhoneNumber])
				VALUES(N'Nha sach Minh Tam 1', CAST(N'2021-10-11T02:50:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'So 1 - Tan Mai - Hoang Mai', N'0912446869')
INSERT [dbo].[Stores] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Address], [PhoneNumber])
				VALUES(N'Nha sach Minh Tam 2', CAST(N'2021-10-11T02:50:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'So 5A - Giang Vo - Dong Da', N'0869558928')
INSERT [dbo].[Stores] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Address], [PhoneNumber])
				VALUES(N'Nha sach Minh Tam 3', CAST(N'2021-10-11T02:50:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'So 22B - Ta Quang Buu - Hai Ba Trung', N'0983276198')
INSERT [dbo].[Stores] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Address], [PhoneNumber])
				VALUES(N'Nha sach Minh Tam 4', CAST(N'2021-10-11T02:50:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'So 15 - Nguyen Trai - Thanh Xuan', N'0963225149')
INSERT [dbo].[Stores] ([Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Description], [Address], [PhoneNumber])
				VALUES(N'Nha sach Minh Tam 5', CAST(N'2021-10-11T02:50:06.925' AS DateTime), N'tunghavan.hust@gmail.com', NULL, NULL, NULL, N'So 20 - Xa Dan - Dong Da', N'0982555912')
GO

-- INSERT INTO BOOKAUTHORS
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Mat biec'), dbo.Get_Author_Id (N'Nguyen Nhat Anh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Ngoi khoc tren cay'), dbo.Get_Author_Id (N'Nguyen Nhat Anh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Ky uc Northumbria'), dbo.Get_Author_Id (N'Nguyen Ha Trang'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Cho toi xin mot ve di tuoi tho'), dbo.Get_Author_Id (N'Nguyen Nhat Anh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Kham pha the gioi dong vat'), dbo.Get_Author_Id (N'Le Minh Chau'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Bi mat dai duong'), dbo.Get_Author_Id (N'Ha Anh Khang'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Hinh hoc phang thi Olympic Toan'), dbo.Get_Author_Id (N'Vu Phuong Thanh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Anh se yeu em mai chu'), dbo.Get_Author_Id (N'Tran Minh Vuong'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Con meo ben cua so'), dbo.Get_Author_Id (N'Tran Minh Vuong'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Kham pha so hoc'), dbo.Get_Author_Id (N'Vu Phuong Thanh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Doraemon - Tap 1'), dbo.Get_Author_Id (N'Vu Hong Hanh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Doraemon - Tap 2'), dbo.Get_Author_Id (N'Vu Hong Hanh'))
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (dbo.Get_Book_Id (N'Doraemon - Tap 3'), dbo.Get_Author_Id (N'Vu Hong Hanh'))
GO

-- INSERT INTO BOOKSTORES
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Mat biec'), dbo.Get_Store_Id (N'Nha sach Minh Tam 1'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Ngoi khoc tren cay'), dbo.Get_Store_Id (N'Nha sach Minh Tam 1'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Ky uc Northumbria'), dbo.Get_Store_Id (N'Nha sach Minh Tam 2'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Cho toi xin mot ve di tuoi tho'), dbo.Get_Store_Id (N'Nha sach Minh Tam 2'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Kham pha the gioi dong vat'), dbo.Get_Store_Id (N'Nha sach Minh Tam 3'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Bi mat dai duong'), dbo.Get_Store_Id (N'Nha sach Minh Tam 4'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Hinh hoc phang thi Olympic Toan'), dbo.Get_Store_Id (N'Nha sach Minh Tam 5'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Anh se yeu em mai chu'), dbo.Get_Store_Id (N'Nha sach Minh Tam 5'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Con meo ben cua so'), dbo.Get_Store_Id (N'Nha sach Minh Tam 4'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Kham pha so hoc'), dbo.Get_Store_Id (N'Nha sach Minh Tam 2'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Doraemon - Tap 1'), dbo.Get_Store_Id (N'Nha sach Minh Tam 3'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Doraemon - Tap 2'), dbo.Get_Store_Id (N'Nha sach Minh Tam 2'))
GO
INSERT [dbo].[BookStores] ([BookId], [StoreId]) VALUES (dbo.Get_Book_Id (N'Doraemon - Tap 3'), dbo.Get_Store_Id (N'Nha sach Minh Tam 1'))
GO
