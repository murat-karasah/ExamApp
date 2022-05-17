using Microsoft.AspNetCore.Mvc;
using TimExamCase.Data.Entities;
using TimExamCase.Data.Repositorys.Abstract;

namespace TimExamCase.Controllers
{
    public class ExamController : Controller
    {
        private IExamRepository examRepository;
        private IQuestionRepository questionRepository;

        public ExamController(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
        }

        public IActionResult Index()
        {
            var exams = examRepository.GetAllExam();
            if (exams != null)
            {
                var examsCount = exams.Count();
                ViewBag.Message = examsCount + " Adet Sınav var.";

                return View(exams);

            }
            else
            {
                ViewBag.Message = "Sınav Yok.";

            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateExam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExam(Exam exam)
        {
           var myExam = examRepository.CreatedExam(exam);
            return RedirectToAction("CreateQuestion",new { id = myExam.ExamID });
        }

        [HttpGet]
        public IActionResult CreateQuestion(int id)
        {
            var myExam = examRepository.GetByIdExam(id);

            if (myExam != null)
            {
            var myQuestions = questionRepository.GetAllExam(id);
                ViewBag.ExamId = id.ToString();
                return View(myQuestions);

            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            examRepository.DeleteExam(id);
            return RedirectToAction("Index");
        }
    }
}
