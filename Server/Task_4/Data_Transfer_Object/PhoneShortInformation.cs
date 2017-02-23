using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Task_4.Data_Transfer_Object
{
    public class PhoneShortInformation
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MainImageURL { get; set; }
    }
}