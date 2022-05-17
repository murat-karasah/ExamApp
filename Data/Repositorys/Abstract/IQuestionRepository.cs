using TimExamCase.Data.Entities;

namespace TimExamCase.Data.Repositorys.Abstract
{
    public interface IQuestionRepository
    {
        List<Question> GetAllExam(int id);
        Question GetByIdExam(int id);
        Question CreatedExam(Question question);
        void DeleteExam(int id);
    }
}
