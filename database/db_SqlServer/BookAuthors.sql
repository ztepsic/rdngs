
create table dbo.BookAuthors (
	Id int identity(172, 1)
		constraint PK_BookAuth_Id primary key
,	Name nvarchar(30)
,	Surname nvarchar(30) not null
,	ShortBiography text
,	BiographyRootArticleSectionId int
,	BiographySrcName nvarchar(30)
,	BiographySrcUrl nvarchar(200)
,	constraint FK_BookAuthor_BiographyRootArticleSectionId
		foreign key (BiographyRootArticleSectionId) references dbo.ArticleSections (Id) 
			on delete cascade
			on update cascade
);
go


exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains book authors',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'


exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Book author name',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Surname',
								@name=N'MS_Description', @value=N'Book author surname',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ShortBiography',
								@name=N'MS_Description', @value=N'Book author short biography',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'BiographyRootArticleSectionId',
								@name=N'MS_Description', @value=N'Book author root article section',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'BiographySrcName',
								@name=N'MS_Description', @value=N'Book author biography source name',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'BiographySrcUrl',
								@name=N'MS_Description', @value=N'Book author biography source url',
								@level1type=N'TABLE', @level1name=N'BookAuthors',
								@level0type=N'SCHEMA', @level0name=N'dbo'

go