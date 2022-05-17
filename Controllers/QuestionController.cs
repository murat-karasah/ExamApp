using Microsoft.AspNetCore.Mvc;
using TimExamCase.Data.Entities;
using TimExamCase.Data.Repositorys.Abstract;

namespace TimExamCase.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionRepository questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        [HttpGet]
        public IActionResult CreateQuestion(int id)
        {
            return View();
        }

        [Route("Question/CreateQuestion/{id:int}")]
        [HttpPost]
        public IActionResult CreateQuestion(Question question,int id)
        {
            question.ExamID= id;
            questionRepository.CreatedExam(question);
            return RedirectToAction("CreateQuestion", "Exam", new { id = id  });
        }
    }
}
