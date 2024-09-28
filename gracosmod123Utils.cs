using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace gracosmod123
{
    public static class gracosmod123Utils
    {
        internal static ILog Logger = LogManager.GetLogger("gracosmod123");

        public static void Log(string message)
        {
            Logger.Debug("[gracosmod123] " + message);
        }

        public static void Log(object message, params object[] formatData)
        {
            Log(string.Format(message.ToString(), formatData));
        }
    }
}
