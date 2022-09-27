using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.DTO
{
    public class SmartDeviceDTO
    { 
        [Key]
        public int id { get; set; }

        public string description { get; set; }

        public string location { get; set; }

        public int maxEnergyConsumtion { get; set; }

        public int baselineEnergyConsumtion { get; set; }

        public virtual SmartSenzorDTO smartSenzorDTO { get; set; }

        public ApplicationUserModel userDTO { get; set; }


        public static SmartDevice mappingSmartDeviceDTOtoSmartDevice(SmartDeviceDTO smartDeviceDTO) {
            SmartDevice smartDevice = new SmartDevice() {
                description = smartDeviceDTO.description,
                locatin = smartDeviceDTO.location,
                maxEnergyConsumtion = smartDeviceDTO.maxEnergyConsumtion,
                baselineEnergyConsumtion = smartDeviceDTO.baselineEnergyConsumtion,
            };

            return smartDevice;                       
        }


    }
}
