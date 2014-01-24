using System;
using System.IO;

namespace JSLibrary.Logging
{
	public class Logger
	{
		public Func<DebugLevel,StreamWriter> StreamSelector { get; protected set; }

		public Logger (StreamWriter logstream, DebugLevel MaxDebugLevel)
		{
			StreamSelector = (dl => (dl <= MaxDebugLevel) ? logstream : null);
		}

		public Logger (Func<DebugLevel, StreamWriter> streamSelector)
		{
			this.StreamSelector = streamSelector;
		}

		public void LogString (string str, DebugLevel debugLevel)
		{
			LogStringWithPrefix (str, "", debugLevel);
		}

		public void LogStringWithTimeStamp (string str, DebugLevel debugLevel)
		{
			LogStringWithPrefix (str, TimeStamp () + " : [" + debugLevel.ToString () + "] ", debugLevel);
		}

		public void LogStringWithPrefix (string str, string prefix, DebugLevel debugLevel)
		{
			StreamWriter stream = StreamSelector (debugLevel);
			if (stream != null) {
				stream.WriteLine ("{0}{1}", prefix, str);
				stream.Flush ();
			}
		}
		
		internal string TimeStamp()
		{
			return DateTime.Now.ToString ("[dd/MM-yyyy HH:mm:ss]");
		}
	}
}

