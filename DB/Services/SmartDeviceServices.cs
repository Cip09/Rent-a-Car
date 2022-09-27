using DatabaseClass;
using DB.DTO;
using DB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Services
{

    public interface ISmartDeviceServices {
        void addSmartDevice(SmartDeviceDTO smartDeviceDTO);

        void addSmartDeviceToUser(SmartDeviceDTO smartDeviceDTO, string idUser);

        void deleteSmartDevice(int idSmartDevice, string idClient);

        void updateSmartDevice(SmartDeviceDTO smartDeviceDTO, int idSmartDevice);

        IList<SmartDeviceDTO> getSmartDevices();


    }
    public class SmartDeviceServices : ISmartDeviceServices
    {

        public SmartDeviceRepository  smartDeviceRepository = new SmartDeviceRepository(DatabaseContext.getDbInstance());
        public void addSmartDevice(SmartDeviceDTO smartDeviceDTO) {

            var smartDevice = SmartDeviceDTO.mappingSmartDeviceDTOtoSmartDevice(smartDeviceDTO);
            smartDeviceRepository.addSmartDevice(smartDevice);

        }

        public void addSmartDeviceToUser(SmartDeviceDTO smartDeviceDTO, string idUser) {
            var smartDevice = SmartDeviceDTO.mappingSmartDeviceDTOtoSmartDevice(smartDeviceDTO);
            smartDeviceRepository.addSmartDeviceToUser(smartDevice, idUser);
        
        }

        public void deleteSmartDevice(int idSmartDevice, string idClient) {
            smartDeviceRepository.deleteSmartDevice(idSmartDevice, idClient);
        }

        public void updateSmartDevice(SmartDeviceDTO smartDeviceDTO, int idSmartDevice) {
          var smartDevice = SmartDeviceDTO.mappingSmartDeviceDTOtoSmartDevice(smartDeviceDTO);
            smartDeviceRepository.updateSmartDevice(smartDevice, idSmartDevice);
                        
        }

        public IList<SmartDeviceDTO> getSmartDevices() {
            var smartDeviceList = smartDeviceRepository.getSmartDevices();

            var resultList = smartDeviceList.Select(x => new SmartDeviceDTO()
            {
                id = x.id,
                description = x.description,
                location = x.locatin,
                maxEnergyConsumtion = x.maxEnergyConsumtion,
                baselineEnergyConsumtion = x.baselineEnergyConsumtion
            });

            return resultList.ToList();
        }
    }
}
