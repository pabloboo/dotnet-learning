namespace DineFind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRestaurant2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantOwner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "RestaurantOwner");
        }
    }
}
