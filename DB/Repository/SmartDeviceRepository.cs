using DatabaseClass;
using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Repository
{

    public interface ISmartDeviceRepository {
        void addSmartDevice(SmartDevice smartDevice);

        void addSmartDeviceToUser(SmartDevice smartDevice, string idUser);

        void deleteSmartDevice(int idSmartDevice, string idClient);

        void updateSmartDevice(SmartDevice smartDevice, int idSmartDevice);

    }
    public class SmartDeviceRepository : ISmartDeviceRepository
    {
        private DatabaseContext db { get; set; }
        public SmartDeviceRepository(DatabaseContext db) {
            this.db = db;
        }

        public void addSmartDevice(SmartDevice smartDevice) {
            db.SmartDevices.Add(smartDevice);
            db.SaveChanges();
            db.Entry<SmartDevice>(smartDevice).Reload();
        }

        public void addSmartDeviceToUser(SmartDevice smartDevice, string idUser) {
            var user = db.User.ToList().Where(x => x.Id == idUser).FirstOrDefault();

            db.SmartDevices.Add(smartDevice);
            db.SaveChanges();
            db.Entry<SmartDevice>(smartDevice).Reload();

            user.smartDeviceList.Add(smartDevice);

            db.SaveChanges();

        }

        public void deleteSmartDevice(int idSmartDevice, string idClient) {
            var smartDevice = db.SmartDevices.ToList().Where(x => x.id == idSmartDevice).FirstOrDefault();
            var client = db.User.ToList().Where(x => x.Id == idClient).FirstOrDefault();

            
            using (var transation = db.Database.BeginTransaction()) {
                if (client != null)
                {
                    client.smartDeviceList.Remove(smartDevice);
                }
                db.SmartDevices.Remove(smartDevice);

                db.SaveChanges();
                transation.Commit();


            }


        }

        public void updateSmartDevice(SmartDevice smartDevice, int idSmartDevice) {
            var result = db.SmartDevices.ToList().Where(x => x.id == idSmartDevice).FirstOrDefault();

            result.description = smartDevice.description;
            result.locatin = smartDevice.locatin;
            result.maxEnergyConsumtion = smartDevice.maxEnergyConsumtion;
            result.baselineEnergyConsumtion = smartDevice.baselineEnergyConsumtion;

           
            db.Update(result);
            db.SaveChanges();


        }

        public IList<SmartDevice> getSmartDevices() {

            return db.SmartDevices.ToList();
        }

    }
}
