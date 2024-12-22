using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) was not found")
        {

        }

        public NotFoundException(string name)
           : base($"{name} was not found")
        {

        }
    }

}
