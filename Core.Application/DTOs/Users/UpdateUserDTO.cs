using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Users
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }
        public  string UserName { get;  }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
