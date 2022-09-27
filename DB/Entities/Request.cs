using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public bool Response { get; set; }
        public string Message { get; set; }

        public Car Car { get; set; }

        public User User { get; set; }
    }
}
