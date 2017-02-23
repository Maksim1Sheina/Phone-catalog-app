namespace Task_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneAvailabilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Availability = c.String(),
                        PhoneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Phones", t => t.PhoneID, cascadeDelete: true)
                .Index(t => t.PhoneID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdditionalFeatures = c.String(),
                        BatteryStandbyTime = c.String(),
                        BatteryTalkTime = c.String(),
                        BatteryType = c.String(),
                        CameraPrimary = c.Single(nullable: false),
                        ConnectivityBluetooth = c.String(),
                        ConnectivityCell = c.String(),
                        ConnectivityGPS = c.Boolean(nullable: false),
                        ConnectivityInfrared = c.Boolean(nullable: false),
                        ConnectivityWiFi = c.String(),
                        Description = c.String(),
                        DisplayScreenResolution = c.String(),
                        DisplayScreenSize = c.String(),
                        DisplayTouchScreen = c.Boolean(nullable: false),
                        HardwareAccelerometer = c.Boolean(nullable: false),
                        HardwareAudioJack = c.String(),
                        HardwareCPU = c.String(),
                        HardwareFMRadio = c.Boolean(nullable: false),
                        HardwarePhysicalKeyboard = c.Boolean(nullable: false),
                        HardwareUSB = c.String(),
                        Name = c.String(),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        Depth = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        StorageFlash = c.Int(nullable: false),
                        StorageRAM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhoneCameraFeatures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CameraFeature = c.String(),
                        PhoneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Phones", t => t.PhoneID, cascadeDelete: true)
                .Index(t => t.PhoneID);
            
            CreateTable(
                "dbo.PhoneImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        PhoneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Phones", t => t.PhoneID, cascadeDelete: true)
                .Index(t => t.PhoneID);
            
            CreateTable(
                "dbo.PhonePlatformParameters",
                c => new
                    {
                        PhoneID = c.Int(nullable: false),
                        PlatformType = c.String(),
                        PlatrormVersion = c.String(),
                        PlatformUI = c.String(),
                    })
                .PrimaryKey(t => t.PhoneID)
                .ForeignKey("dbo.Phones", t => t.PhoneID)
                .Index(t => t.PhoneID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhonePlatformParameters", "PhoneID", "dbo.Phones");
            DropForeignKey("dbo.PhoneImages", "PhoneID", "dbo.Phones");
            DropForeignKey("dbo.PhoneCameraFeatures", "PhoneID", "dbo.Phones");
            DropForeignKey("dbo.PhoneAvailabilities", "PhoneID", "dbo.Phones");
            DropIndex("dbo.PhonePlatformParameters", new[] { "PhoneID" });
            DropIndex("dbo.PhoneImages", new[] { "PhoneID" });
            DropIndex("dbo.PhoneCameraFeatures", new[] { "PhoneID" });
            DropIndex("dbo.PhoneAvailabilities", new[] { "PhoneID" });
            DropTable("dbo.PhonePlatformParameters");
            DropTable("dbo.PhoneImages");
            DropTable("dbo.PhoneCameraFeatures");
            DropTable("dbo.Phones");
            DropTable("dbo.PhoneAvailabilities");
        }
    }
}
