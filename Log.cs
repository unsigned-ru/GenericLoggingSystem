using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLoggingSystem
{
    public abstract class Log
    {
        public virtual void Execute()
        {
            LogStream.WriteLog(Serialize());
        }

        public abstract string Serialize();

        public string GetTimeString()
        {
            DateTime now = DateTime.Now;
            return $"{now.Hour:00}:{now.Minute:00}:{now.Second:00}";
        }
    }
}
