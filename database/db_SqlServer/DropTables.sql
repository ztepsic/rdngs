use Readings;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'dbo'
		  and	TABLE_NAME = 'BookAuthors')
)
	drop table BookAuthors;

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'dbo'
		  and	TABLE_NAME = 'ArticleSections')
)
	drop table ArticleSections;
go

go