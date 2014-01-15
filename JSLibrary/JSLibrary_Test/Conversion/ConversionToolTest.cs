using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSLibrary.Conversion;
using NUnit.Framework;

namespace JSLibrary_Test.Conversion
{
	[TestFixture]
	public class ConversionToolTest
	{

		[Test]
		public void ConvertData_TypeBasedConverters_ConvertsBothWays()
		{
			string a1data = "a1data";
			string a2data = "a2data";
			var a1 = new AD1() { value = a1data };
			var a2 = new AD2() { value = a2data };
			 
			string b1data = "b1data";
			string b2data = "b2data";
			var b1 = new BD1() { value = b2data };
			var b2 = new BD2() { value = b2data };

			JSConversionTool<B, A> tool = new JSConversionTool<B, A>();
			tool.AddConverter(new BD1_AD1MockConverters());
			tool.AddConverter(new BD2_AD2MockConverters());
			B ba1 = tool.ConvertToKnown(a1);
			B ba2 = tool.ConvertToKnown(a1);

			A ab1 = tool.ConvertToForeign(b1);
			A ab2 = tool.ConvertToForeign(b1);


		}

	}
}
