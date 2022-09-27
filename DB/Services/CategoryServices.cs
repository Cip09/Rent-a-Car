using DatabaseClass;
using DB.DTO;
using DB.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Services
{
    public class CategoryServices: ICategoryServices
    {
        private DatabaseContext _db { get; set; }
        public CategoryServices(DatabaseContext db)
        {
            this._db = db;
        }
        public List<CategoryCarDTO> GetAll()
        {
            return CategoryCarDTO.MappterEntityToDto(_db.CategoryCars.ToList());
        }
    }
}
