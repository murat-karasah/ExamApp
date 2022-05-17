namespace TimExamCase.Data.Entities
{
    public class Exam
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
