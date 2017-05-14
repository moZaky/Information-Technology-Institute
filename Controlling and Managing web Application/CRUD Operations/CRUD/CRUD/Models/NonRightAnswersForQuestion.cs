using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_V1._0.Models
{
    public class NonRightAnswersForQuestion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Answer_Id { get; set; }
        public string Answer_Content { get; set; }
        public Guid Ques_Id { get; set; }
        public Question Questions { get; set; }

    }
}