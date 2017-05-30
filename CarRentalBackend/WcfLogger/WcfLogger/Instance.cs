using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLogger
{
   public static class Instance
    {
        public Service1 getLogger()
        {
            Service1 Logger = new Service1();
        }
    }
}
