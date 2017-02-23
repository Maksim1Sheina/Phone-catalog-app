namespace Task_4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task_4.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Task_4.Models.Task_4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Task_4.Models.Task_4Context context)
        {
            context.Phones.AddOrUpdate(x => x.ID,
                new Phone() {
                    ID = 1,
                    AdditionalFeatures = "Front Facing 1.3MP Camera",
                    BatteryStandbyTime = "",
                    BatteryTalkTime = "",
                    BatteryType = "Lithium Ion (Li-Ion) (2780 mAH)",
                    CameraPrimary = 5.0F,
                    ConnectivityBluetooth = "Bluetooth 2.1",
                    ConnectivityCell = "T-mobile HSPA+ @ 2100/1900/AWS/850 MHz",
                    ConnectivityGPS = true,
                    ConnectivityInfrared = false,
                    ConnectivityWiFi = "802.11 b/g",
                    Description = "Introducing Dell\u2122 Streak 7. Share photos, videos and movies together. It\u2019s small enough to carry around, big enough to gather around. Android\u2122 2.2-based tablet with over-the-air upgrade capability for future OS releases.  A vibrant 7-inch, multitouch display with full Adobe\u00ae Flash 10.1 pre-installed.  Includes a 1.3 MP front-facing camera for face-to-face chats on popular services such as Qik or Skype.  16 GB of internal storage, plus Wi-Fi, Bluetooth and built-in GPS keeps you in touch with the world around you.  Connect on your terms. Save with 2-year contract or flexibility with prepaid pay-as-you-go plans",
                    DisplayScreenResolution = "WVGA (800 x 480)",
                    DisplayScreenSize = "7.0 inches",
                    DisplayTouchScreen = true,
                    HardwareAccelerometer = true,
                    HardwareAudioJack = "3.5mm",
                    HardwareCPU = "nVidia Tegra T20",
                    HardwareFMRadio = false,
                    HardwarePhysicalKeyboard = false,
                    HardwareUSB = "USB 2.0",
                    Name = "Dell Streak 7",
                    Width = 199.9F,
                    Height = 119.8F,
                    Depth = 12.4F,
                    Weight = 450.5F,
                    StorageFlash = 16000,
                    StorageRAM = 512
                },
                new Phone()
                {
                    ID = 2,
                    AdditionalFeatures = "Adobe Flash Player 10, Quadband GSM Worldphone, Advance Business Security, Complex Password Secure, Review & Edit Documents with Quick Office, Personal 3G Mobile Hotspot for up to 5 WiFi enabled Devices, Advanced Social Networking brings all social content into a single homescreen widget",
                    BatteryStandbyTime = "230 hours",
                    BatteryTalkTime = "8 hours",
                    BatteryType = "Lithium Ion (Li-Ion) (1400 mAH)",
                    CameraPrimary = 5.0F,
                    ConnectivityBluetooth = "Bluetooth 2.1",
                    ConnectivityCell = "WCDMA 850/1900/2100, CDMA 800/1900, GSM 850/900/1800/1900, HSDPA 10.2 Mbps (Category 9/10), CDMA EV-DO Release A, EDGE Class 12, GPRS Class 12, HSUPA 1.8 Mbps",
                    ConnectivityGPS = true,
                    ConnectivityInfrared = false,
                    ConnectivityWiFi = "802.11 b/g/n",
                    Description = "With Quad Band GSM, the DROID 2 Global can send email and make and receive calls from more than 200 countries. It features an improved QWERTY keyboard, super-fast 1.2 GHz processor and enhanced security for all your business needs.",
                    DisplayScreenResolution = "FWVGA (854 x 480)",
                    DisplayScreenSize = "3.7 inches",
                    DisplayTouchScreen = true,
                    HardwareAccelerometer = true,
                    HardwareAudioJack = "3.5mm",
                    HardwareCPU = "1.2 GHz TI OMAP",
                    HardwareFMRadio = false,
                    HardwarePhysicalKeyboard = true,
                    HardwareUSB = "USB 2.0",
                    Name = "DROID\u2122 2 Global by Motorola",
                    Width = 60.5F,
                    Height = 116.3F,
                    Depth = 13.7F,
                    Weight = 169.0F,
                    StorageFlash = 8192,
                    StorageRAM = 512
                },
                new Phone()
                {
                    ID = 3,
                    AdditionalFeatures = "Front-facing camera. Sensors: proximity, ambient light, barometer, gyroscope.",
                    BatteryStandbyTime = "336 hours",
                    BatteryTalkTime = "24 hours",
                    BatteryType = "Other (3250 mAH)",
                    CameraPrimary = 5.0F,
                    ConnectivityBluetooth = "Bluetooth 2.1",
                    ConnectivityCell = "CDMA 800 /1900 LTE 700, Rx diversity in all bands",
                    ConnectivityGPS = true,
                    ConnectivityInfrared = false,
                    ConnectivityWiFi = "802.11 a/b/g/n",
                    Description = "MOTOROLA XOOM has a super-powerful dual-core processor and Android\u2122 3.0 (Honeycomb) \u2014 the Android platform designed specifically for tablets. With its 10.1-inch HD widescreen display, you\u2019ll enjoy HD video in a thin, light, powerful and upgradeable tablet.",
                    DisplayScreenResolution = "WXGA (1200 x 800)",
                    DisplayScreenSize = "10.1 inches",
                    DisplayTouchScreen = true,
                    HardwareAccelerometer = true,
                    HardwareAudioJack = "3.5mm",
                    HardwareCPU = "1 GHz Dual Core Tegra 2",
                    HardwareFMRadio = false,
                    HardwarePhysicalKeyboard = false,
                    HardwareUSB = "USB 2.0",
                    Name = "MOTOROLA XOOM\u2122",
                    Width = 249.0F,
                    Height = 168.0F,
                    Depth = 12.7F,
                    Weight = 726.0F,
                    StorageFlash = 32000,
                    StorageRAM = 1000
                },
                new Phone()
                {
                    ID = 4,
                    AdditionalFeatures = "Sensors: proximity, ambient light, barometer, gyroscope",
                    BatteryStandbyTime = "336 hours",
                    BatteryTalkTime = "24 hours",
                    BatteryType = "Other ( mAH)",
                    CameraPrimary = 5.0F,
                    ConnectivityBluetooth = "Bluetooth 2.1",
                    ConnectivityCell = "",
                    ConnectivityGPS = true,
                    ConnectivityInfrared = false,
                    ConnectivityWiFi = "802.11 b/g/n",
                    Description = "Motorola XOOM with Wi-Fi has a super-powerful dual-core processor and Android\u2122 3.0 (Honeycomb) \u2014 the Android platform designed specifically for tablets. With its 10.1-inch HD widescreen display, you\u2019ll enjoy HD video in a thin, light, powerful and upgradeable tablet.",
                    DisplayScreenResolution = "WXGA (1200 x 800)",
                    DisplayScreenSize = "10.1 inches",
                    DisplayTouchScreen = true,
                    HardwareAccelerometer = true,
                    HardwareAudioJack = "3.5mm",
                    HardwareCPU = "1 GHz Dual Core Tegra 2",
                    HardwareFMRadio = false,
                    HardwarePhysicalKeyboard = false,
                    HardwareUSB = "USB 2.0",
                    Name = "Motorola XOOM\u2122 with Wi-Fi",
                    Width = 249.1F,
                    Height = 167.8F,
                    Depth = 12.9F,
                    Weight = 708.9F,
                    StorageFlash = 32000,
                    StorageRAM = 1000
                },
                new Phone()
                {
                    ID = 5,
                    AdditionalFeatures = "Contour Display, Near Field Communications (NFC), Three-axis gyroscope, Anti-fingerprint display coating, Internet Calling support (VoIP/SIP)",
                    BatteryStandbyTime = "428 hours",
                    BatteryTalkTime = "6 hours",
                    BatteryType = "Lithium Ion (Li-Ion) (1500 mAH)",
                    CameraPrimary = 5.0F,
                    ConnectivityBluetooth = "Bluetooth 2.1",
                    ConnectivityCell = "Quad-band GSM: 850, 900, 1800, 1900\r\nTri-band HSPA: 900, 2100, 1700\r\nHSPA type: HSDPA (7.2Mbps) HSUPA (5.76Mbps)",
                    ConnectivityGPS = true,
                    ConnectivityInfrared = false,
                    ConnectivityWiFi = "802.11 b/g/n",
                    Description = "Nexus S is the next generation of Nexus devices, co-developed by Google and Samsung. The latest Android platform (Gingerbread), paired with a 1 GHz Hummingbird processor and 16GB of memory, makes Nexus S one of the fastest phones on the market. It comes pre-installed with the best of Google apps and enabled with new and popular features like true multi-tasking, Wi-Fi hotspot, Internet Calling, NFC support, and full web browsing. With this device, users will also be the first to receive software upgrades and new Google mobile apps as soon as they become available. For more details, visit http://www.google.com/nexus.",
                    DisplayScreenResolution = "WVGA (800 x 480)",
                    DisplayScreenSize = "4.0 inches",
                    DisplayTouchScreen = true,
                    HardwareAccelerometer = true,
                    HardwareAudioJack = "3.5mm",
                    HardwareCPU = "1GHz Cortex A8 (Hummingbird) processor",
                    HardwareFMRadio = false,
                    HardwarePhysicalKeyboard = false,
                    HardwareUSB = "USB 2.0",
                    Name = "Nexus S",
                    Width = 63.0F,
                    Height = 123.9F,
                    Depth = 10.88F,
                    Weight = 129.0F,
                    StorageFlash = 16384,
                    StorageRAM = 512
                });

            context.PhoneAvailabilities.AddOrUpdate(x => x.ID,
                new PhoneAvailability() { ID = 1, Availability = "T-Mobile", PhoneID = 1 },
                new PhoneAvailability() { ID = 2, Availability = "Verizon", PhoneID = 2 },

                new PhoneAvailability() { ID = 3, Availability = "Verizon", PhoneID = 3 },

                new PhoneAvailability() { ID = 4, Availability = "", PhoneID = 4 },

                new PhoneAvailability() { ID = 5, Availability = "M1", PhoneID = 5 },
                new PhoneAvailability() { ID = 6, Availability = "O2", PhoneID = 5 },
                new PhoneAvailability() { ID = 7, Availability = "Orange", PhoneID = 5 },
                new PhoneAvailability() { ID = 8, Availability = "Singtel", PhoneID = 5 },
                new PhoneAvailability() { ID = 9, Availability = "StarHub", PhoneID = 5 },
                new PhoneAvailability() { ID = 10, Availability = "T-Mobile", PhoneID = 5 },
                new PhoneAvailability() { ID = 11, Availability = "Vodafone", PhoneID = 5 }
            );

            context.PhoneCameraFeatures.AddOrUpdate(x => x.ID,
                new PhoneCameraFeature() { ID = 1, CameraFeature = "Flash", PhoneID = 1 },
                new PhoneCameraFeature() { ID = 2, CameraFeature = "Video", PhoneID = 1 },

                new PhoneCameraFeature() { ID = 3, CameraFeature = "Flash", PhoneID = 2 },
                new PhoneCameraFeature() { ID = 4, CameraFeature = "Video", PhoneID = 2 },

                new PhoneCameraFeature() { ID = 5, CameraFeature = "Flash", PhoneID = 3 },
                new PhoneCameraFeature() { ID = 6, CameraFeature = "Video", PhoneID = 3 },

                new PhoneCameraFeature() { ID = 7, CameraFeature = "Flash", PhoneID = 4 },
                new PhoneCameraFeature() { ID = 8, CameraFeature = "Video", PhoneID = 4 },

                new PhoneCameraFeature() { ID = 9, CameraFeature = "Flash", PhoneID = 5 },
                new PhoneCameraFeature() { ID = 10, CameraFeature = "Video", PhoneID = 5 }
            );

            context.PhoneImages.AddOrUpdate(x => x.ID,
                new PhoneImage() { ID = 1, ImageURL = "http://localhost:4871/Album/dell-streak-7.0.jpg", PhoneID = 1 },
                new PhoneImage() { ID = 2, ImageURL = "http://localhost:4871/Album/dell-streak-7.1.jpg", PhoneID = 1 },
                new PhoneImage() { ID = 3, ImageURL = "http://localhost:4871/Album/dell-streak-7.2.jpg", PhoneID = 1 },
                new PhoneImage() { ID = 4, ImageURL = "http://localhost:4871/Album/dell-streak-7.3.jpg", PhoneID = 1 },
                new PhoneImage() { ID = 5, ImageURL = "http://localhost:4871/Album/dell-streak-7.4.jpg", PhoneID = 1 },

                new PhoneImage() { ID = 6, ImageURL = "http://localhost:4871/Album/droid-2-global-by-motorola.0.jpg", PhoneID = 2 },
                new PhoneImage() { ID = 7, ImageURL = "http://localhost:4871/Album/droid-2-global-by-motorola.1.jpg", PhoneID = 2 },
                new PhoneImage() { ID = 8, ImageURL = "http://localhost:4871/Album/droid-2-global-by-motorola.2.jpg", PhoneID = 2 },

                new PhoneImage() { ID = 9, ImageURL = "http://localhost:4871/Album/motorola-xoom.0.jpg", PhoneID = 3 },
                new PhoneImage() { ID = 10, ImageURL = "http://localhost:4871/Album/motorola-xoom.1.jpg", PhoneID = 3 },
                new PhoneImage() { ID = 11, ImageURL = "http://localhost:4871/Album/motorola-xoom.2.jpg", PhoneID = 3 },

                new PhoneImage() { ID = 12, ImageURL = "http://localhost:4871/Album/motorola-xoom-with-wi-fi.0.jpg", PhoneID = 4 },
                new PhoneImage() { ID = 13, ImageURL = "http://localhost:4871/Album/motorola-xoom-with-wi-fi.1.jpg", PhoneID = 4 },
                new PhoneImage() { ID = 14, ImageURL = "http://localhost:4871/Album/motorola-xoom-with-wi-fi.2.jpg", PhoneID = 4 },
                new PhoneImage() { ID = 15, ImageURL = "http://localhost:4871/Album/motorola-xoom-with-wi-fi.3.jpg", PhoneID = 4 },
                new PhoneImage() { ID = 16, ImageURL = "http://localhost:4871/Album/motorola-xoom-with-wi-fi.4.jpg", PhoneID = 4 },
                new PhoneImage() { ID = 17, ImageURL = "http://localhost:4871/Album/motorola-xoom-with-wi-fi.5.jpg", PhoneID = 4 },

                new PhoneImage() { ID = 18, ImageURL = "http://localhost:4871/Album/nexus-s.0.jpg", PhoneID = 5 },
                new PhoneImage() { ID = 19, ImageURL = "http://localhost:4871/Album/nexus-s.1.jpg", PhoneID = 5 },
                new PhoneImage() { ID = 20, ImageURL = "http://localhost:4871/Album/nexus-s.2.jpg", PhoneID = 5 },
                new PhoneImage() { ID = 21, ImageURL = "http://localhost:4871/Album/nexus-s.3.jpg", PhoneID = 5 }
            );

            context.PhonePlatformParameters.AddOrUpdate(
                new PhonePlatformParameters()
                {
                    PhoneID = 1,
                    PlatformType = "Android",
                    PlatrormVersion = "2.2",
                    PlatformUI = "Dell Stage"
                },
                new PhonePlatformParameters()
                {
                    PhoneID = 2,
                    PlatformType = "Android",
                    PlatrormVersion = "2.2",
                    PlatformUI = ""
                },
                new PhonePlatformParameters()
                {
                    PhoneID = 3,
                    PlatformType = "Android",
                    PlatrormVersion = "3.0",
                    PlatformUI = "Android"
                },
                new PhonePlatformParameters()
                {
                    PhoneID = 4,
                    PlatformType = "Android",
                    PlatrormVersion = "3.0",
                    PlatformUI = "Honeycomb"
                },
                new PhonePlatformParameters()
                {
                    PhoneID = 5,
                    PlatformType = "Android",
                    PlatrormVersion = "2.3",
                    PlatformUI = "Android"
                }
            );
        }
    }
}
