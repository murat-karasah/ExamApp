1-sql connection string path => Data\DataAccess\TimExamDbContext.cs
	optionsBuilder.UseSqlServer("Server=<YourName>;Database=timDb;Trusted_Connection = true;");
2-Ef Core Migration or Sql Script
	EF core migration:
	Migration folder deleted
	Package Manager Console:
		PM> add-migration MyMigration
		PM> Update-Database
	sql script:
	Run tempDb.sql script inside sql folder

