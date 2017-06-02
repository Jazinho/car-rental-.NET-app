using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLogger
{
   public static class Instance
    {
        public static Service1 Logger
        {
            get
            {
                if (Logger == null)
                    Logger = new Service1();

                return Logger;
            }

            private set
            {

            }
        }
    }
}
