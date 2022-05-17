using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using TimExamCase.Data.Entities;
using TimExamCase.Data.Repositorys.Abstract;
using TimExamCase.Models;

namespace TimExamCase.Controllers
{
    public class ExamUserController : Controller
    {
        private IExamRepository examRepository;
        private IQuestionRepository questionRepository;

        public ExamUserController(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
        }

        public IActionResult Index()
        {
          var list =  examRepository.GetAllExam();
            return View(list);
        }

        public IActionResult Start(int id)
        {
            
            var list = examRepository.GetAllExam();
            var questions =questionRepository.GetAllExam(id);
            ViewBag.ExamId = id;
            return View(questions);
        }

        [HttpGet]
        public IActionResult End( )
        {

             var endExam = HttpContext.Request.Query.ToList();
             
                var examId=endExam[0].Value;
                endExam.Remove(endExam[0]);
                List<AnswerModel> myAnswerList = new List<AnswerModel>();
                var questions = questionRepository.GetAllExam(Int32.Parse(examId));
                int t = 0;
                int f=0;
                foreach (var item in endExam)
                {
                    //item.Key soru ıd
                    //item.value verilen cevap
                    string myQuestion = questions.FirstOrDefault(x => x.QuestionID == Int32.Parse(item.Key)).TrueOption;
                string myRequest = item.Value.ToString();
                if (myQuestion.ToUpper() == myRequest.ToUpper())
                    {
                        t++;
                        AnswerModel model = new AnswerModel();
                        model.AnswerId = Int32.Parse(item.Key);
                        model.TrueOption = myQuestion;
                        model.SelectOption = item.Value;
                        model.StatuOption = true;
                        myAnswerList.Add(model);
                        //Cevap doğru ise

                    }
                    else
                    {
                        f++;
                        AnswerModel model = new AnswerModel();
                        model.AnswerId = Int32.Parse(item.Key);
                        model.TrueOption = myQuestion;
                        model.SelectOption = item.Value;
                        model.StatuOption = false;
                        myAnswerList.Add(model);

                        //Cevap yanlış ise

                    }
                int rawPuan = t+f;
                if(t==0)
                {
                    ViewBag.Puan = 0;

                }
                else
                {
                    int puan = (100 / rawPuan) * t;
                    ViewBag.Puan = puan;

                }

            }

            dynamic mymodel = new ExpandoObject();
            mymodel.Questions = questions;
            mymodel.Answer = myAnswerList;



            return View(mymodel);
        }
    }
}
