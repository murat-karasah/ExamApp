using Microsoft.EntityFrameworkCore;
using TimExamCase.Data.Entities;

namespace TimExamCase.Data.DataAccess
{
    public class TimExamDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=pc;Database=timDb;Trusted_Connection = true;");


        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
