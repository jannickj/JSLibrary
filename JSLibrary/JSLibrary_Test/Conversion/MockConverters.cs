using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSLibrary.Conversion;

namespace JSLibrary_Test.Conversion
{
	abstract class A
	{
		public object value;
	}

	class AD1 : A
	{

	}

	class AD2 : A
	{

	}

	abstract class B
	{
		public object value;
	}

	class BD1 : B
	{

	}

	class BD2 : B
	{

	}
	 
	class BD1_AD1MockConverters : JSConverter<BD1,AD1>
	{
		public override AD1 BeginConversionToForeign(BD1 gobj)
		{
			return new AD1() { value = gobj.value };
		}

		public override BD1 BeginConversionToKnown(AD1 fobj)
		{
			return new BD1() { value = fobj.value };
		}
	}

	class BD2_AD2MockConverters : JSConverter<BD2, AD2>
	{
		public override AD2 BeginConversionToForeign(BD2 gobj)
		{
			return new AD2(){ value = gobj.value};
		}

		public override BD2 BeginConversionToKnown(AD2 fobj)
		{
			return new BD2() { value = fobj.value };
		}
	}

	class Multiply10MockConverts : JSConverterToForeign<Tuple<string, int>, int>
	{
		public override object KnownID
		{
			get
			{
				return "mul10";
			}
		}

		public override int BeginConversionToForeign(Tuple<string, int> gobj)
		{
			return gobj.Item2 * 10;
		}
	}

	class Multiply100MockConverts : JSConverterToForeign<Tuple<string, int>, int>
	{
		public override object KnownID
		{
			get
			{
				return "mul100";
			}
		}

		public override int BeginConversionToForeign(Tuple<string, int> gobj)
		{
			return gobj.Item2 * 100;
		}
	}
}
