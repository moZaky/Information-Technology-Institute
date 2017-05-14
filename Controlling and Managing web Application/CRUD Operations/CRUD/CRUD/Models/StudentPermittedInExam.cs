using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_V1._0.Models
{
    public class StudentPermittedInExam
    {
        public int Student_Id { get; set; }


        [Column("Ex_Id", Order = 0), Key, ForeignKey("Exams")]
        public Guid Ex_Id { get; set; }
        public Exam Exams { get; set; }


        public DateTime? Date_Of_Permission { get; set; }

    }
}