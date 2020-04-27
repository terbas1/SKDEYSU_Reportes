using System;
using System.Collections.Generic;
using System.Text;

namespace Logín.Models
{
    public class Users
    {
        public Guid UserId { get; set; }
        public String UserNombres { get; set; }
        public String UserApellidos { get; set; }
        public String UserDNI { get; set; }
        public String UserCorreo { get; set; }
        public String UserCelular { get; set; }
        public String UserPassword { get; set; }

    }
}
