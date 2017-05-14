using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_V1._0.Models
{
    public class Exam
    {

        public Exam()
        {
            Questions = new HashSet<Question>();
            QuestionInExam = new HashSet<QuestionInExam>();
        }

        [Key]
        public Guid Ex_Id { get; set; }
        public string Ex_Name { get; set; }
        public int Branch_Id { get; set; }
        public int Track_Id { get; set; }
        public DateTime? Date { get; set; }
        public int Intake_Number { get; set; }
        public int Number_Of_Ques { get; set; }
        public string Ins_Id { get; set; }  // Id of instructor who add this question .
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuestionInExam> QuestionInExam { get; set; }

    }
}