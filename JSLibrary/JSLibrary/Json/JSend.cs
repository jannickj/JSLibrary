using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSLibrary.Json
{

	public class JSend<T>
	{
		public string Status {get; set;}

		[JsonConverter(typeof(SingleOrListConverter))]
		public List<T> Data {get; set;}
		public uint Code {get; set;}
		public string Message { get; set;}

	}
}

