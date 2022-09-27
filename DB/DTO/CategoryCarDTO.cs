using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.DTO
{
    public class CategoryCarDTO
    {
        public int Id { get; set; }
        public string NameCategoryCar { get; set; }

        public static List<CategoryCar> MappterDtoToEntity(List<CategoryCarDTO> categoryCarDTO) {
        
            var entity = categoryCarDTO.Select(x => new CategoryCar
            {
                NameCategoryCar = x.NameCategoryCar,
            }).ToList();

            return entity;
        }

        public static List<CategoryCarDTO> MappterEntityToDto(List<CategoryCar> categoryCarEntity)
        {
            var entity = categoryCarEntity.Select(x => new CategoryCarDTO
            {
                NameCategoryCar = x.NameCategoryCar,
            }).ToList();

            return entity;
        }
    }
}
