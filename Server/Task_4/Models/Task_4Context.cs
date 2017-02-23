using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task_4.Models
{
    public class Task_4Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Task_4Context() : base("name=Task_4Context")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<Task_4.Models.Phone> Phones { get; set; }

        public System.Data.Entity.DbSet<Task_4.Models.PhonePlatformParameters> PhonePlatformParameters { get; set; }

        public System.Data.Entity.DbSet<Task_4.Models.PhoneAvailability> PhoneAvailabilities { get; set; }

        public System.Data.Entity.DbSet<Task_4.Models.PhoneCameraFeature> PhoneCameraFeatures { get; set; }

        public System.Data.Entity.DbSet<Task_4.Models.PhoneImage> PhoneImages { get; set; }
    }
}
