namespace Coursework.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednumberofpartitionforc1andc2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Problem", "NumberPartitionsC1", c => c.Int(nullable: false));
            AddColumn("dbo.Problem", "NumberPartitionsC2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Problem", "NumberPartitionsC2");
            DropColumn("dbo.Problem", "NumberPartitionsC1");
        }
    }
}
