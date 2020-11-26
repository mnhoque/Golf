using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class CustomerException:Exception
    {
        public CustomerException()
        {

        }
        public CustomerException(string message) : base(message)
        {
            
        }
    }
}
