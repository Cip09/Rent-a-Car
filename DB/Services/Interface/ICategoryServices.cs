

using DB.DTO;
using System.Collections.Generic;

namespace DB.Services.Interface
{
    public interface ICategoryServices
    {
        List<CategoryCarDTO> GetAll();
    }

}
