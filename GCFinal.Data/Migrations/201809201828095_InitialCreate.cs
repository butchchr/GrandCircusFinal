namespace GCFinal.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.TripItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Hot = c.Boolean(nullable: false),
                    Warm = c.Boolean(nullable: false),
                    Cool = c.Boolean(nullable: false),
                    Cold = c.Boolean(nullable: false),
                    IsRain = c.Boolean(nullable: false),
                    IsWindy = c.Boolean(nullable: false),
                    IsDaily = c.Boolean(nullable: false),
                    IsEssential = c.Boolean(nullable: false),
                    IsBulk = c.Boolean(nullable: false),
                    Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.PackingItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TotalWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            this.DropTable("dbo.PackingItems");
            this.DropTable("dbo.TripItems");
        }
    }
}
