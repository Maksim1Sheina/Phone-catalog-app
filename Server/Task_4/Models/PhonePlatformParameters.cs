using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Task_4.Models
{
    /*[Serializable]
    [DataContract(IsReference = true)]*/
    public class PhonePlatformParameters
    {
        [Key]
        [ForeignKey("Phone")]
        public int PhoneID { get; set; }
        
        public string PlatformType { get; set; }
        
        public string PlatrormVersion { get; set; }
        
        public string PlatformUI { get; set; }

        public string PlatformFullDescription
        {
            get
            {
                return PlatformType + ": " + PlatrormVersion;
            }
        }


        public virtual Phone Phone { get; set; }
    }
}