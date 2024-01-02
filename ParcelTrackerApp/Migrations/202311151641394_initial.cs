namespace ParcelTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parcels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TrackingNumber = c.String(),
                    Status = c.String(),
                    LastUpdated = c.DateTime(nullable: false),
                    Destination = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Parcels");
        }
    }
}
