namespace Task_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_some_attribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phones", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "Name", c => c.String());
        }
    }
}
