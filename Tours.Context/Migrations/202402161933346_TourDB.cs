namespace Tours.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CountOfStars = c.Int(nullable: false),
                        CountryCode = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryCode, cascadeDelete: true)
                .Index(t => t.CountryCode);
            
            CreateTable(
                "dbo.HotelComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreationDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AllSale = c.Int(nullable: false),
                        DateReceipt = c.DateTimeOffset(nullable: false, precision: 7),
                        ReceivingPointId = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReceivingPoints", t => t.ReceivingPointId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ReceivingPointId);
            
            CreateTable(
                "dbo.ReceivingPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketCount = c.Int(nullable: false),
                        CountryCode = c.String(maxLength: 128),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        ImagePreview = c.Binary(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryCode)
                .Index(t => t.CountryCode);
            
            CreateTable(
                "dbo.TypeTours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourHotels",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Hotel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Hotel_Id })
                .ForeignKey("dbo.Tours", t => t.Tour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.TourOrders",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Order_Id })
                .ForeignKey("dbo.Tours", t => t.Tour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.TypeTourTours",
                c => new
                    {
                        TypeTour_Id = c.Int(nullable: false),
                        Tour_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeTour_Id, t.Tour_Id })
                .ForeignKey("dbo.TypeTours", t => t.TypeTour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.Tour_Id, cascadeDelete: true)
                .Index(t => t.TypeTour_Id)
                .Index(t => t.Tour_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.TypeTourTours", "Tour_Id", "dbo.Tours");
            DropForeignKey("dbo.TypeTourTours", "TypeTour_Id", "dbo.TypeTours");
            DropForeignKey("dbo.TourOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.TourOrders", "Tour_Id", "dbo.Tours");
            DropForeignKey("dbo.TourHotels", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.TourHotels", "Tour_Id", "dbo.Tours");
            DropForeignKey("dbo.Tours", "CountryCode", "dbo.Countries");
            DropForeignKey("dbo.Orders", "ReceivingPointId", "dbo.ReceivingPoints");
            DropForeignKey("dbo.HotelComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.HotelComments", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Hotels", "CountryCode", "dbo.Countries");
            DropIndex("dbo.TypeTourTours", new[] { "Tour_Id" });
            DropIndex("dbo.TypeTourTours", new[] { "TypeTour_Id" });
            DropIndex("dbo.TourOrders", new[] { "Order_Id" });
            DropIndex("dbo.TourOrders", new[] { "Tour_Id" });
            DropIndex("dbo.TourHotels", new[] { "Hotel_Id" });
            DropIndex("dbo.TourHotels", new[] { "Tour_Id" });
            DropIndex("dbo.Tours", new[] { "CountryCode" });
            DropIndex("dbo.Orders", new[] { "ReceivingPointId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.HotelComments", new[] { "UserId" });
            DropIndex("dbo.HotelComments", new[] { "HotelId" });
            DropIndex("dbo.Hotels", new[] { "CountryCode" });
            DropTable("dbo.TypeTourTours");
            DropTable("dbo.TourOrders");
            DropTable("dbo.TourHotels");
            DropTable("dbo.TypeTours");
            DropTable("dbo.Tours");
            DropTable("dbo.ReceivingPoints");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.HotelComments");
            DropTable("dbo.Hotels");
            DropTable("dbo.Countries");
        }
    }
}
