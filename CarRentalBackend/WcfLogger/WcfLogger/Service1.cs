using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLogger
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public static string path = "C:\\Users\\Jan\\Documents\\Visual Studio 2015\\Projects\\car-rental-.NET-app\\CarRentalBackend\\log" + Guid.NewGuid().ToString("N") + ".txt";

        private static System.IO.StreamWriter file = new System.IO.StreamWriter(path);

        public void closeFile() { file.Close(); }

       
        public enum State { CRITICAL, ERROR, WARNING, INFO, DEBUG, NOTSET };
        static public State Mode = State.INFO;
       

        public void critical(string Text)
        {

            if (Mode.Equals(State.CRITICAL))
            {
                file.Write("critical (");
                file.Write(DateTime.Now.ToString("h:mm:ss tt"));
                file.Write("): ");
                file.WriteLine(Text);
                file.Flush();
            }

        }

        public void error(string Text)
        {
            if (Mode.Equals(State.ERROR) || Mode.Equals(State.CRITICAL))
            {

                file.Write("error (");
                file.Write(DateTime.Now.ToString("h:mm:ss tt"));
                file.Write("): ");
                file.WriteLine(Text);
                file.Flush();
            }
        }
        public void warning(string Text)
        {
            if (Mode.Equals(State.WARNING) || Mode.Equals(State.ERROR) || Mode.Equals(State.CRITICAL))
            {

                file.Write("warning (");
                file.Write(DateTime.Now.ToString("h:mm:ss tt"));
                file.Write("): ");
                file.WriteLine(Text);
                file.Flush();
            }
        }

        public void info(string Text)
        {
            if (Mode.Equals(State.INFO) || Mode.Equals(State.WARNING) || Mode.Equals(State.ERROR) || Mode.Equals(State.CRITICAL))
            {

                file.Write("info (");
                file.Write(DateTime.Now.ToString("h:mm:ss tt"));
                file.Write("): ");
                file.WriteLine(Text);
                file.Flush();
            }
        }

        public void debug(string Text)
        {
            if (Mode.Equals(State.DEBUG) || Mode.Equals(State.INFO) || Mode.Equals(State.WARNING) || Mode.Equals(State.ERROR) || Mode.Equals(State.CRITICAL))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                file.Write("debug (");
                file.Write(DateTime.Now.ToString("h:mm:ss tt"));
                file.Write("): ");
                file.WriteLine(Text);
                file.Flush();
            }
        }







        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
