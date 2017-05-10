using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_V1._0.Models
{
    public class Questions
    {
        [Key]
        public int Ques_Id { get; set; }
        public Question_Types Ques_Type { get; set; }
        public string Ques_Content { get; set; }
        public bool Ques_Activation { get; set; }
        public Question_Level Ques_Level { get; set; }
        public int Ques_Repetition { get; set; }
        public string Ins_Id { get; set; }  // Id of instructor who add this question .



    }

    public enum Question_Types
    {
        TrueFalse ,
        MultimediaQuestions, // Audio , Video , Image Questions 
        MultipleChoiceQuestions,
        Comprehension,
        EditorialQuestions,
        CodeSample,
    }

    public enum Question_Level
    {
        ExtremelyHard,
        Hard,
        Meduim,
        Easy,
        ExtremelyEasy,
    }
}