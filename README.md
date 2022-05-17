1-sql connection string path => Data\DataAccess\TimExamDbContext.cs<br>
	optionsBuilder.UseSqlServer("Server=<YourName>;Database=timDb;Trusted_Connection = true;");<br>
2-Ef Core Migration or Sql Script<br>
	EF core migration:<br>
	Migration folder deleted<br>
	Package Manager Console:<br>
		PM> add-migration MyMigration<br>
		PM> Update-Database<br>
	sql script:<br>
	Run tempDb.sql script inside sql folder<br>

