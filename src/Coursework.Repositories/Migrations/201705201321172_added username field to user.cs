namespace Coursework.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusernamefieldtouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Username");
        }
    }
}
