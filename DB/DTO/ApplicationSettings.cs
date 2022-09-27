using System;
using System.Collections.Generic;
using System.Text;

namespace DB.DTO
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
