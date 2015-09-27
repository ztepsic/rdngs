
create table dbo.ArticleSections (
	Id int identity(1, 1)
		constraint PK_ArticleSection_Id primary key
,	ParentId int
,	Title nvarchar(30) not null
,	Content ntext not null
,	Level int not null default 0
,	[Order] int not null default 1
,	constraint FK_ArticleSection_ParentId
		foreign key (ParentId) references dbo.ArticleSections (Id) 
			on delete no action
			on update no action
);
go


exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains article sections',
								@level1type=N'TABLE', @level1name=N'ArticleSections',
								@level0type=N'SCHEMA', @level0name=N'dbo'


exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ParentId',
								@name=N'MS_Description', @value=N'Parent article section',
								@level1type=N'TABLE', @level1name=N'ArticleSections',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Title',
								@name=N'MS_Description', @value=N'Article section title',
								@level1type=N'TABLE', @level1name=N'ArticleSections',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Content',
								@name=N'MS_Description', @value=N'Article section content',
								@level1type=N'TABLE', @level1name=N'ArticleSections',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Level',
								@name=N'MS_Description', @value=N'Article section level',
								@level1type=N'TABLE', @level1name=N'ArticleSections',
								@level0type=N'SCHEMA', @level0name=N'dbo'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Order',
								@name=N'MS_Description', @value=N'Article section order in its group level',
								@level1type=N'TABLE', @level1name=N'ArticleSections',
								@level0type=N'SCHEMA', @level0name=N'dbo'


go