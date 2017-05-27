namespace Coursework.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamingofproblemsnames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AntennasSynthesisProblem", newName: "AntennasRadiationPatternProblem");
            RenameTable(name: "dbo.BranchingLinesProblem", newName: "BranchingPointsProblem");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BranchingPointsProblem", newName: "BranchingLinesProblem");
            RenameTable(name: "dbo.AntennasRadiationPatternProblem", newName: "AntennasSynthesisProblem");
        }
    }
}
