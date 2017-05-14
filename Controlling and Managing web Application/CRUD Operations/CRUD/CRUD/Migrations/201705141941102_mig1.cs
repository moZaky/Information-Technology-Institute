namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Ex_Id = c.Guid(nullable: false),
                        Ex_Name = c.String(),
                        Branch_Id = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Intake_Number = c.Int(nullable: false),
                        Number_Of_Ques = c.Int(nullable: false),
                        Ins_Id = c.String(),
                    })
                .PrimaryKey(t => t.Ex_Id);
            
            CreateTable(
                "dbo.QuestionInExams",
                c => new
                    {
                        Ques_Id = c.Guid(nullable: false),
                        Ex_Id = c.Guid(nullable: false),
                        Grade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ques_Id, t.Ex_Id })
                .ForeignKey("dbo.Exams", t => t.Ex_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Ques_Id, cascadeDelete: true)
                .Index(t => t.Ques_Id)
                .Index(t => t.Ex_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Ques_Id = c.Guid(nullable: false),
                        Ques_Type = c.Int(nullable: false),
                        Ques_Content = c.String(),
                        Ques_Activation = c.Boolean(nullable: false),
                        Ques_Level = c.Int(nullable: false),
                        Ques_Repetition = c.Int(nullable: false),
                        Ins_Id = c.String(),
                        Topic_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Ques_Id)
                .ForeignKey("dbo.TopicInCourses", t => t.Topic_Id, cascadeDelete: true)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.NonRightAnswersForQuestions",
                c => new
                    {
                        Answer_Id = c.Guid(nullable: false, identity: true),
                        Answer_Content = c.String(),
                        Ques_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Answer_Id)
                .ForeignKey("dbo.Questions", t => t.Ques_Id, cascadeDelete: true)
                .Index(t => t.Ques_Id);
            
            CreateTable(
                "dbo.TopicInCourses",
                c => new
                    {
                        Topic_Id = c.Guid(nullable: false),
                        Topic_Name = c.String(),
                        Crs_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Topic_Id);
            
            CreateTable(
                "dbo.StudentPostponedInExams",
                c => new
                    {
                        New_Ex_Id = c.Guid(nullable: false),
                        Student_Id = c.Int(nullable: false),
                        Date_Of_Postponing = c.DateTime(),
                    })
                .PrimaryKey(t => t.New_Ex_Id)
                .ForeignKey("dbo.Exams", t => t.New_Ex_Id)
                .Index(t => t.New_Ex_Id);
            
            CreateTable(
                "dbo.StudentAnswerQuestionInExams",
                c => new
                    {
                        Ques_Id = c.Guid(nullable: false),
                        Ex_Id = c.Guid(nullable: false),
                        Grade = c.Double(nullable: false),
                        Student_Id = c.Int(nullable: false),
                        Branch_Id = c.Int(nullable: false),
                        Intake_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ques_Id, t.Ex_Id })
                .ForeignKey("dbo.Exams", t => t.Ex_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Ques_Id, cascadeDelete: true)
                .Index(t => t.Ques_Id)
                .Index(t => t.Ex_Id);
            
            CreateTable(
                "dbo.StudentPermittedInExams",
                c => new
                    {
                        Ex_Id = c.Guid(nullable: false),
                        Student_Id = c.Int(nullable: false),
                        Date_Of_Permission = c.DateTime(),
                    })
                .PrimaryKey(t => t.Ex_Id)
                .ForeignKey("dbo.Exams", t => t.Ex_Id)
                .Index(t => t.Ex_Id);
            
            CreateTable(
                "dbo.QuestionExams",
                c => new
                    {
                        Question_Ques_Id = c.Guid(nullable: false),
                        Exam_Ex_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Ques_Id, t.Exam_Ex_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Ques_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exam_Ex_Id, cascadeDelete: true)
                .Index(t => t.Question_Ques_Id)
                .Index(t => t.Exam_Ex_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentPermittedInExams", "Ex_Id", "dbo.Exams");
            DropForeignKey("dbo.StudentAnswerQuestionInExams", "Ques_Id", "dbo.Questions");
            DropForeignKey("dbo.StudentAnswerQuestionInExams", "Ex_Id", "dbo.Exams");
            DropForeignKey("dbo.StudentPostponedInExams", "New_Ex_Id", "dbo.Exams");
            DropForeignKey("dbo.QuestionInExams", "Ques_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Topic_Id", "dbo.TopicInCourses");
            DropForeignKey("dbo.NonRightAnswersForQuestions", "Ques_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionExams", "Exam_Ex_Id", "dbo.Exams");
            DropForeignKey("dbo.QuestionExams", "Question_Ques_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionInExams", "Ex_Id", "dbo.Exams");
            DropIndex("dbo.QuestionExams", new[] { "Exam_Ex_Id" });
            DropIndex("dbo.QuestionExams", new[] { "Question_Ques_Id" });
            DropIndex("dbo.StudentPermittedInExams", new[] { "Ex_Id" });
            DropIndex("dbo.StudentAnswerQuestionInExams", new[] { "Ex_Id" });
            DropIndex("dbo.StudentAnswerQuestionInExams", new[] { "Ques_Id" });
            DropIndex("dbo.StudentPostponedInExams", new[] { "New_Ex_Id" });
            DropIndex("dbo.NonRightAnswersForQuestions", new[] { "Ques_Id" });
            DropIndex("dbo.Questions", new[] { "Topic_Id" });
            DropIndex("dbo.QuestionInExams", new[] { "Ex_Id" });
            DropIndex("dbo.QuestionInExams", new[] { "Ques_Id" });
            DropTable("dbo.QuestionExams");
            DropTable("dbo.StudentPermittedInExams");
            DropTable("dbo.StudentAnswerQuestionInExams");
            DropTable("dbo.StudentPostponedInExams");
            DropTable("dbo.TopicInCourses");
            DropTable("dbo.NonRightAnswersForQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionInExams");
            DropTable("dbo.Exams");
        }
    }
}
