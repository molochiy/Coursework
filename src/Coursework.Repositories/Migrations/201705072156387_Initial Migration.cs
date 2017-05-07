namespace Coursework.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AntennasSynthesisProblem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        C1 = c.Double(nullable: false),
                        C2 = c.Double(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProblemResult", t => t.ResultId)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ResultId)
                .Index(t => t.StateId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProblemResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BranchingLinesProblem",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProblemResult", t => t.ResultId)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ResultId)
                .Index(t => t.StateId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.RoleId })
                .ForeignKey("dbo.User", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AntennasSynthesisProblem", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRoles", "StudentId", "dbo.User");
            DropForeignKey("dbo.BranchingLinesProblem", "UserId", "dbo.User");
            DropForeignKey("dbo.BranchingLinesProblem", "StateId", "dbo.State");
            DropForeignKey("dbo.BranchingLinesProblem", "ResultId", "dbo.ProblemResult");
            DropForeignKey("dbo.AntennasSynthesisProblem", "StateId", "dbo.State");
            DropForeignKey("dbo.AntennasSynthesisProblem", "ResultId", "dbo.ProblemResult");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "StudentId" });
            DropIndex("dbo.BranchingLinesProblem", new[] { "UserId" });
            DropIndex("dbo.BranchingLinesProblem", new[] { "StateId" });
            DropIndex("dbo.BranchingLinesProblem", new[] { "ResultId" });
            DropIndex("dbo.AntennasSynthesisProblem", new[] { "UserId" });
            DropIndex("dbo.AntennasSynthesisProblem", new[] { "StateId" });
            DropIndex("dbo.AntennasSynthesisProblem", new[] { "ResultId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Role");
            DropTable("dbo.BranchingLinesProblem");
            DropTable("dbo.User");
            DropTable("dbo.State");
            DropTable("dbo.ProblemResult");
            DropTable("dbo.AntennasSynthesisProblem");
        }
    }
}
