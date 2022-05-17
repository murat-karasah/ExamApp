using TimExamCase.Data.DataAccess;
using TimExamCase.Data.Entities;
using TimExamCase.Data.Repositorys.Abstract;

namespace TimExamCase.Data.Repositorys.Concrete
{
    public class ExamRepository : IExamRepository
    {
        public Exam CreatedExam(Exam exam)
        {
            using (var db = new TimExamDbContext())
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return exam;
            }
        }

        public void DeleteExam(int id)
        {
            using (var db = new TimExamDbContext())
            {
                var exam = GetByIdExam(id);
                db.Exams.Remove(exam);
                db.SaveChanges();
            }
        }

        public List<Exam> GetAllExam()
        {
            using (var db = new TimExamDbContext())
            {
                return db.Exams.ToList();

            }
        }

        public Exam GetByIdExam(int id)
        {
            using (var db = new TimExamDbContext())
            {
                return db.Exams.FirstOrDefault(x => x.ExamID == id);
            }
        }
    }
}
