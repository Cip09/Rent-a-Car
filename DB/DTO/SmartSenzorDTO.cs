using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.DTO
{
   public class SmartSenzorDTO
    {
        [Key]
        public int id { get; set; }

        public string senzorDescription { get; set; }

        public int maximumValue { get; set; }

        public virtual SmartDeviceDTO smartDeviceDTO { get; set; }


        public static SmartSenzor mappingDTOtoEntity(SmartSenzorDTO smartSenzorDTO) {
            SmartSenzor smartSenzor = new SmartSenzor()
            {
                maximumValue = smartSenzorDTO.maximumValue,
                senzorDescription = smartSenzorDTO.senzorDescription
            };

            return smartSenzor;
        }

        public static SmartSenzorDTO mappingEntityToDTO(SmartSenzor smartSenzor) {
            SmartSenzorDTO resultDTO = new SmartSenzorDTO() { 
                maximumValue = smartSenzor.maximumValue,
                senzorDescription = smartSenzor.senzorDescription
            };

            return resultDTO;
        }
    }
}
