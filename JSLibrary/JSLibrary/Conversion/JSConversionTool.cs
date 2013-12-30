using System;
using System.Collections.Generic;

namespace JSLibrary.Conversion
{
	/// <summary>
	/// Basic conversion tool from objects to XmasObjects and vice versa
	/// </summary>
	public abstract class JSConversionTool
	{
		internal abstract object ConvertToForeignUnsafe(object gobj);

		internal abstract object ConvertToKnownUnsafe(object fobj);
	}

	/// <summary>
	/// Conversion tool for objects of a certain type to XmasObject and vice versa
	/// </summary>
    /// <typeparam name="KnownType"></typeparam>
	/// <typeparam name="ForeignType"></typeparam>
	public class JSConversionTool<KnownType, ForeignType> : JSConversionTool
	{
		private Dictionary<Type, JSConverter> foreignLookup = new Dictionary<Type, JSConverter>();
		private Dictionary<Type, JSConverter> gooseLookup = new Dictionary<Type, JSConverter>();

		/// <summary>
		/// Instantiates a XmasConversionTool, used to convert objects
		/// </summary>
        public JSConversionTool()
		{
			NoConverter nocon = new NoConverter();
			gooseLookup.Add(typeof (object), nocon);
			foreignLookup.Add(typeof (object), nocon);
		}

		/// <summary>
		/// Adds a converter meant to be used by the converter for converting objects
		/// </summary>
		/// <typeparam name="XmasType">The Xmas type the converter will convert the foreign object to and from</typeparam>
		/// <typeparam name="ForeignTyped">The Foreign type the converter will convert the Xmas object to and from</typeparam>
		/// <param name="converter">The converter that is added to the tool</param>
		public virtual void AddConverter<XmasType, ForeignTyped>(JSConverter<XmasType, ForeignTyped> converter)
			where ForeignTyped : ForeignType
			where XmasType : KnownType
		{
			converter.ConversionTool = this;

            if (!(converter is JSConverterToForeign<KnownType, ForeignTyped>))
				foreignLookup.Add(typeof (ForeignTyped), converter);
            if (!(converter is JSConverterToKnown<KnownType, ForeignTyped>))
				gooseLookup.Add(typeof (XmasType), converter);
		}

		/// <summary>
		/// Converts the XmasObject into the an object with the tool's Foreign type
		/// </summary>
		/// <param name="gobj">XmasObject to be converted</param>
		/// <exception cref="UnconvertableException">Is thrown if conversion was not possible</exception>
		/// <returns>The object that the XmasObject is converted into</returns>

        public ForeignType ConvertToForeign(KnownType gobj)
		{
			Type original = gobj.GetType();
			Type gt = original;
			JSConverter converter;
			try
			{
				while (true)
				{
					if (gooseLookup.TryGetValue(gt, out converter))
					{
						if (gt != original)
						{
							SleekConverter sleek = new SleekConverter(converter.BeginUnsafeConversionToForeign,
																	  converter.BeginUnsafeConversionToXmas);
							gooseLookup.Add(original, sleek);
						}
						return (ForeignType)converter.BeginUnsafeConversionToForeign(gobj);
					}
					else
						gt = gt.BaseType;
				}
			}
			catch (Exception inner)
			{
				throw new UnconvertableException(gobj, inner);
			}
			
		}


		internal override object ConvertToForeignUnsafe(object gobj)
		{
			return ConvertToForeign((KnownType)gobj);
		}

		internal override object ConvertToKnownUnsafe(object fobj)
		{
			return ConvertToXmas((ForeignType) fobj);
		}

		/// <summary>
		/// Converts the Foreign object into an XmasObject
		/// </summary>
		/// <param name="foreign">The foreign object to be converted</param>
		/// <exception cref="UnconvertableException">Is thrown if conversion was not possible</exception>
		/// <returns>The XmasObject the foreign object is converted into</returns>
		public object ConvertToXmas(ForeignType foreign)
		{
			JSConverter converter;
			try
			{
				Type ft = foreign.GetType();
				if (foreignLookup.TryGetValue(ft, out converter))
				{
					return converter.BeginUnsafeConversionToXmas(foreign);
				}
				throw new KeyNotFoundException("Converter not found for "+foreign.GetType().Name);
			}
			catch (Exception inner)
			{
				throw new UnconvertableException(foreign, inner);
				
			}
			
		}


		private class NoConverter : JSConverter
		{
			internal override object BeginUnsafeConversionToForeign(object gobj)
			{
				throw new UnconvertableException(gobj);
			}

			internal override object BeginUnsafeConversionToXmas(object obj)
			{
				throw new UnconvertableException(obj);
			}
		}

		private class SleekConverter : JSConverter
		{
			private Func<object, object> toForeign;
			private Func<object, object> toXmas;

			public SleekConverter(Func<object, object> toForeign, Func<object, object> toXmas)
			{
				this.toForeign = toForeign;
				this.toXmas = toXmas;
			}

			internal override object BeginUnsafeConversionToForeign(object gobj)
			{
				return toForeign(gobj);
			}

			internal override object BeginUnsafeConversionToXmas(object obj)
			{
				return toXmas(obj);
			}
		}
	}
}