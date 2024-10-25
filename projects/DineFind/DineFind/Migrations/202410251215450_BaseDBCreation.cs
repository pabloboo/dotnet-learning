namespace DineFind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseDBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuisinePreference_Name = c.String(),
                        PriceRange_MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceRange_MaxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Rating_Score = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Preference_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Preference_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Preferences", t => t.Preference_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Preference_Id);
            
            AddColumn("dbo.Restaurants", "Cuisine_Name", c => c.String());
            AddColumn("dbo.Restaurants", "Cuisine_Description", c => c.String());
            AddColumn("dbo.Restaurants", "Location_Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurants", "Location_Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurants", "RestaurantOwner_Id", c => c.Int());
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Restaurants", "Address", c => c.String(nullable: false, maxLength: 250));
            CreateIndex("dbo.Restaurants", "RestaurantOwner_Id");
            AddForeignKey("dbo.Restaurants", "RestaurantOwner_Id", "dbo.RestaurantOwners", "Id");
            DropColumn("dbo.Restaurants", "RestaurantOwner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "RestaurantOwner", c => c.String());
            DropForeignKey("dbo.Restaurants", "RestaurantOwner_Id", "dbo.RestaurantOwners");
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPreferences", "Preference_Id", "dbo.Preferences");
            DropForeignKey("dbo.UserPreferences", "User_Id", "dbo.Users");
            DropIndex("dbo.UserPreferences", new[] { "Preference_Id" });
            DropIndex("dbo.UserPreferences", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Restaurants", new[] { "RestaurantOwner_Id" });
            AlterColumn("dbo.Restaurants", "Address", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
            DropColumn("dbo.Restaurants", "RestaurantOwner_Id");
            DropColumn("dbo.Restaurants", "Location_Longitude");
            DropColumn("dbo.Restaurants", "Location_Latitude");
            DropColumn("dbo.Restaurants", "Cuisine_Description");
            DropColumn("dbo.Restaurants", "Cuisine_Name");
            DropTable("dbo.UserPreferences");
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.RestaurantOwners");
            DropTable("dbo.Preferences");
        }
    }
}
