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
    public class Phone
    {
        public int ID { get; set; }
        
        public string AdditionalFeatures { get; set; }
        
        public string BatteryStandbyTime { get; set; }
        
        public string BatteryTalkTime { get; set; }
        
        public string BatteryType { get; set; }
        
        public float CameraPrimary { get; set; }
        
        public string ConnectivityBluetooth { get; set; }
        
        public string ConnectivityCell { get; set; }

        public bool ConnectivityGPS { get; set; }

        public bool ConnectivityInfrared { get; set; }
        
        public string ConnectivityWiFi { get; set; }

        public string Description { get; set; }
        
        public string DisplayScreenResolution { get; set; }
        
        public string DisplayScreenSize { get; set; }

        public bool DisplayTouchScreen { get; set; }

        public bool HardwareAccelerometer { get; set; }
        
        public string HardwareAudioJack { get; set; }
        
        public string HardwareCPU { get; set; }

        public bool HardwareFMRadio { get; set; }

        public bool HardwarePhysicalKeyboard { get; set; }
        
        public string HardwareUSB { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "String length cannot be longer than 100 characters.", MinimumLength = 1)]
        public string Name { get; set; }
        
        public float Width { get; set; }
        
        public float Height { get; set; }
        
        public float Depth { get; set; }
        
        public float Weight { get; set; }
        
        public int StorageFlash { get; set; }
        
        public int StorageRAM { get; set; }


        public virtual ICollection<PhoneAvailability> Availabilities { get; set; }
        
        public virtual ICollection<PhoneCameraFeature> CameraFeatures { get; set; }

        public virtual ICollection<PhoneImage> Images { get; set; }

        public virtual PhonePlatformParameters PlatformParameters { get; set; }
    }
}