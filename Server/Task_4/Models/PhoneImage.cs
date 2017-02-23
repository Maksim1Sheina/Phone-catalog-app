using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Task_4.Models
{
    /*[Serializable]
    [DataContract(IsReference = true)]*/
    public class PhoneImage
    {
        public int ID { get; set; }
        
        public string ImageURL { get; set; }

        public int PhoneID { get; set; }


        public virtual Phone Phone { get; set; }
    }
}