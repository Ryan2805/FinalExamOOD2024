namespace FinalExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                {
                    BookingID = c.Int(nullable: false, identity: true),
                    BookingsDate = c.DateTime(nullable: false),
                    NumberOfParticipants = c.Int(nullable: false),
                    CustomerID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Movies", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerID = c.Int(nullable: false, identity: true),
                    CustomerName = c.String(nullable: false),
                    CustomerNumber = c.Int(nullable: false),
                })  

                .PrimaryKey(t => t.CustomerID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "CustomeID", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "CustomerID" });
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
