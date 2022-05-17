using TimExamCase.Data.DataAccess;
using TimExamCase.Data.Entities;
using TimExamCase.Data.Repositorys.Abstract;

namespace TimExamCase.Data.Repositorys.Concrete
{
    public class QuestionRepository : IQuestionRepository
    {
        Question IQuestionRepository.CreatedExam(Question question)
        {
            using (var db = new TimExamDbContext())
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return question;
            }
        }

        void IQuestionRepository.DeleteExam(int id)
        {
            throw new NotImplementedException();
        }

        List<Question> IQuestionRepository.GetAllExam(int id)
        {
            using (var db = new TimExamDbContext())
            {
                var myExamQuestionList= db.Questions.Where(x=>x.ExamID==id).ToList();
                
                
                    return myExamQuestionList;
                

            }
        }

        Question IQuestionRepository.GetByIdExam(int id)
        {
            throw new NotImplementedException();
        }
    }
}
