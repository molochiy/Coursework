namespace Coursework.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Replacebrolemstosingleproblemaddedproblemtype : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AntennasRadiationPatternProblem", newName: "Problem");
            DropIndex("dbo.BranchingPointsProblem", new[] { "ResultId" });
            DropIndex("dbo.BranchingPointsProblem", new[] { "StateId" });
            DropIndex("dbo.BranchingPointsProblem", new[] { "UserId" });
            CreateTable(
                "dbo.ProblemType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Problem", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Problem", "TypeId");
            AddForeignKey("dbo.Problem", "TypeId", "dbo.ProblemType", "Id", cascadeDelete: true);
            DropTable("dbo.BranchingPointsProblem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BranchingPointsProblem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Eps = c.Double(nullable: false),
                        FModule = c.String(nullable: false),
                        FArgument = c.String(nullable: false),
                        M1 = c.Int(nullable: false),
                        M2 = c.Int(nullable: false),
                        ResultId = c.Int(),
                        StateId = c.Int(nullable: false),
                        TaskId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Problem", "TypeId", "dbo.ProblemType");
            DropIndex("dbo.Problem", new[] { "TypeId" });
            DropColumn("dbo.Problem", "TypeId");
            DropTable("dbo.ProblemType");
            CreateIndex("dbo.BranchingPointsProblem", "UserId");
            CreateIndex("dbo.BranchingPointsProblem", "StateId");
            CreateIndex("dbo.BranchingPointsProblem", "ResultId");
            RenameTable(name: "dbo.Problem", newName: "AntennasRadiationPatternProblem");
        }
    }
}
