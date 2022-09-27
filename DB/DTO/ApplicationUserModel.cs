using DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public static ApplicationUserModel MapperEntityToDto(User entity)
        {

            var dto = new ApplicationUserModel()
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                FullName = entity.FullName,
                PhoneNumber = entity.PhoneNumber
            };
            return dto;
        }

        public static User MapperDtoToEntity(ApplicationUserModel dto)
        {

            var user = new User()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber

            };
            return user;


        }
    }
}
