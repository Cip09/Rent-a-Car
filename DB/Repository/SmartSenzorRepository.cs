using DatabaseClass;
using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Repository
{
    public interface ISmartSenzorRepository
    {
        void addSenzor(SmartSenzor smartSenzor);
        void deleteSmartSenzor(int idSmartSenzor, int idSmartDevice);

        SmartSenzor updateSmartSenzor(SmartSenzor smartSenzor, int idSmartSenzor);

        IList<SmartSenzor> getSmartSenzors();

    }
    public class SmartSenzorRepository : ISmartSenzorRepository
    {
        private DatabaseContext db { get; set; }



        public SmartSenzorRepository(DatabaseContext databaseContext)
        {
            this.db = databaseContext;

        }

        public void addSenzor(SmartSenzor smartSenzor)
        {

            db.SmartSenzors.Add(smartSenzor);
            db.SaveChanges();
            db.Entry<SmartSenzor>(smartSenzor).Reload();



        }

        public void deleteSmartSenzor(int idSmartSenzor, int idSmartDevice)
        {
            // if (idSmartDevice != null) {
            var smartDevice = db.SmartDevices.ToList().Where(x => x.id == idSmartDevice).FirstOrDefault();


            var smartSenzor = db.SmartSenzors.ToList().Where(x => x.id == idSmartSenzor).FirstOrDefault();

            using (var transaction = db.Database.BeginTransaction())
            {
                if (smartDevice != null)
                {
                    smartDevice.smartSenzor = null;
                }

                db.SmartSenzors.Remove(smartSenzor);
                db.SaveChanges();

                transaction.Commit();

            }




        }
        public SmartSenzor updateSmartSenzor(SmartSenzor smartSenzor, int idSmartSenzor)
        {
            var resultSmartSenzor = db.SmartSenzors.ToList().Where(x => x.id == idSmartSenzor).FirstOrDefault();

            resultSmartSenzor.senzorDescription = smartSenzor.senzorDescription;
            resultSmartSenzor.maximumValue = smartSenzor.maximumValue;
            db.Update(resultSmartSenzor);
            db.SaveChanges();

            return resultSmartSenzor;
        }

        public IList<SmartSenzor> getSmartSenzors() {

            return db.SmartSenzors.ToList();
        }
    }
}
