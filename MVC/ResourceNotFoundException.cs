using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPOIS.MVC
{
    class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException()
        {

        }

        public ResourceNotFoundException(string message)
            : base(String.Format("La risorsa: " + message + "non è stata trovata!"))
        {

        }

        public ResourceNotFoundException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
