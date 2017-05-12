using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace API_V1._0.Models
{
    public class Applicationdb : DbContext
    {
        public Applicationdb() :base("iti-exam_control")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasMany(Ques => Ques.Questions)
                .WithMany(ex => ex.Exams)
                .Map(Table =>
                {
                    Table.MapLeftKey("Exam_Id");
                    Table.MapRightKey("Ques_Id");
                    Table.ToTable("QuestionInExam");
                });

            modelBuilder.Entity<NonRightAnswersForQuestion>()
                .HasRequired(Ques => Ques.Questions)
                .WithMany(nra => nra.NonRightAnswersForQuestion)
                .HasForeignKey(Qid => Qid.Ques_Id);



        }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<TopicInCourses> Topics { get; set; }
        public virtual DbSet<QuestionInExam> QuestionsInExam { get; set; }
        public virtual DbSet<StudentAnswerQuestionInExam> StudentsAnswerQuestionInExam { get; set; }
        public virtual DbSet<StudentPermittedInExam> StudentsPermittedInExam { get; set; }

    }
}