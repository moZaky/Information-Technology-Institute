using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_V1._0.Models
{
    public class StudentAnswerQuestionInExam
    {
        [Column("Ques_Id", Order = 0), Key, ForeignKey("Questions")]
        public Guid Ques_Id { get; set; }
        public Question Questions { get; set; }

        [Column("Ex_Id", Order = 1), Key, ForeignKey("Exams")]
        public Guid Ex_Id { get; set; }
        public Exam Exams { get; set; }

        public double Grade { get; set; }
        public int Student_Id { get; set; }
        public int Branch_Id { get; set; }
        public int Intake_Number { get; set; }

    }
}