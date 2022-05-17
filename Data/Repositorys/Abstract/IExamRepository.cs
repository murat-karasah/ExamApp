using TimExamCase.Data.Entities;

namespace TimExamCase.Data.Repositorys.Abstract
{
    public interface IExamRepository
    {
        List<Exam> GetAllExam();
        Exam GetByIdExam(int id);
        Exam CreatedExam(Exam exam);
        void DeleteExam(int id);

    }
}
