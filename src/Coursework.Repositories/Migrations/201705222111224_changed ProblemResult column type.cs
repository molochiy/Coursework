namespace Coursework.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedProblemResultcolumntype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProblemResult", "Result", c => c.String(nullable: false, storeType: "xml"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProblemResult", "Result", c => c.String(nullable: false));
        }
    }
}
