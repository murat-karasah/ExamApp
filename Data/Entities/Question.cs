﻿namespace TimExamCase.Data.Entities
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionTest { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string TrueOption { get; set; }
        public Exam Exam { get; set; }
        public int ExamID { get; set; }
     }
}
