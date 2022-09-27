using DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public bool Response { get; set; }
        public string Message { get; set; }
        
        public CarDTO CarDTO { get; set; }

        public ApplicationUserModel UserDTO { get; set; }

        public static Request MapperDtoToEntity(RequestDTO requestDTO)
        {
            var entity = new Request()
            {
               
                Response = requestDTO.Response,
                Message = requestDTO.Message,
               
                
            };
            if (requestDTO.CarDTO != null)
                entity.Car = CarDTO.MapperDtoToEntity(requestDTO.CarDTO);

            return entity;
            
            // User = ApplicationUserModel.MapperDtoToEntity(requestDTO.UserDTO)
        }

        public static RequestDTO MapperEntityToDto(Request request) {
            var requestDTO = new RequestDTO()
            {
                Id = request.Id,
                Response = request.Response,
                Message = request.Message,
               
            };
            if (request.Car != null)
                requestDTO.CarDTO = CarDTO.MapperEntityToDto(request.Car);
            // UserDTO = ApplicationUserModel.MapperEntityToDto(request.User) nu se foloseste niciodata
            return requestDTO;
        }
    }

   
}
