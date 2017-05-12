namespace API_V1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentPermittedInExams", "New_Ex_Id", "dbo.Exams");
            DropIndex("dbo.StudentPermittedInExams", new[] { "New_Ex_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.StudentPermittedInExams", "New_Ex_Id");
            AddForeignKey("dbo.StudentPermittedInExams", "New_Ex_Id", "dbo.Exams", "Ex_Id", cascadeDelete: true);
        }
    }
}
