using DatabaseClass;
using DB.DTO;
using DB.Entities;
using DB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Services
{

    public interface ISmartSenzorServices {
        void addSmartSenzor(SmartSenzorDTO smartSenzorDTO);

        void deleteSmartSenzor(int idSmartSenzor, int idSmartDevice);
        SmartSenzorDTO updateSmartSenzor(SmartSenzorDTO smartSenzorDTO, int idSmartSenzor);

        IList<SmartSenzorDTO> getSmartSenzors();



    }
   public  class SmartSenzorServices : ISmartSenzorServices
    {

        public SmartSenzorRepository smartSenzorRepository = new SmartSenzorRepository(DatabaseContext.getDbInstance());
        
        public void addSmartSenzor(SmartSenzorDTO smartSenzorDTO) {

            
            var smartSenzor = new SmartSenzor()
            {
                maximumValue = smartSenzorDTO.maximumValue,
                senzorDescription = smartSenzorDTO.senzorDescription

            };

            smartSenzorRepository.addSenzor(smartSenzor);
                     

        }

        public void deleteSmartSenzor(int idSmartSenzor, int idSmartDevice) {

            smartSenzorRepository.deleteSmartSenzor(idSmartSenzor, idSmartDevice);
        
        }

        public SmartSenzorDTO updateSmartSenzor(SmartSenzorDTO smartSenzorDTO, int idSmartSenzor) {
            var smartSenzor = SmartSenzorDTO.mappingDTOtoEntity(smartSenzorDTO);
            var result = smartSenzorRepository.updateSmartSenzor(smartSenzor, idSmartSenzor);
            var resultDTO = SmartSenzorDTO.mappingEntityToDTO(result);


           return resultDTO;
        }

        public IList<SmartSenzorDTO> getSmartSenzors() {
          var smartSenzorList =  smartSenzorRepository.getSmartSenzors();
            var resultSelect = smartSenzorList.Select(x => new SmartSenzorDTO { 
                id = x.id,
                senzorDescription = x.senzorDescription,
                maximumValue = x.maximumValue
            });
            return resultSelect.ToList();
        }

    }
}
