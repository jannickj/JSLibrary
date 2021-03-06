﻿
using System;
namespace JSLibrary.Conversion
{
	public abstract class JSConverter
	{
		public abstract object KnownID
		{
			get;
		}

		public abstract object ForeignID
		{
			get;
		}

		public virtual bool CanConvertToForeign
		{
			get
			{
				return true;
			}
		}

		public virtual bool CanConvertToKnown
		{
			get
			{
				return true;
			}
		}

		internal abstract object BeginUnsafeConversionToForeign(object gobj);
		internal abstract object BeginUnsafeConversionToXmas(object obj);
	}

	/// <summary>
	/// An abstract converter meant to be implemented into actual converters
	/// </summary>
	/// <typeparam name="KnownType">The knowntype that the converter will convert foreign objects to and from</typeparam>
	/// <typeparam name="ForeignType">The foreign object type that the converter will convert XmasObjects to and from</typeparam>
	public abstract class JSConverter<KnownType, ForeignType> : JSConverter
	{
		private JSConversionTool conversionTool;

		public override object ForeignID
		{
			get { return typeof(ForeignType); }
		}

		public override object KnownID
		{
			get { return typeof(KnownType); }
		}

		protected internal JSConversionTool ConversionTool
		{
			get { return conversionTool; }
			internal set { conversionTool = value; }
		}


		/// <summary>
		/// This method is called when the converter is asked by the converter tool to convert a foreign object into a XmasObject 
		/// </summary>
		/// <param name="fobj">The foreign object to be converted</param>
		/// <returns>The known object that the foreign object was converted into</returns>
		public abstract KnownType BeginConversionToKnown(ForeignType fobj);

		/// <summary>
		/// This method is called when the converter is asked by the converter tool to convert a Xmas object into a foreign object  
		/// </summary>
		/// <param name="gobj">The known object to be converted</param>
		/// <returns>The foreign object that the Xmas object was converted into</returns>
		public abstract ForeignType BeginConversionToForeign(KnownType gobj);


		/// <summary>
		/// Requests the conversion of an XmasObject into an object, only if the ConversionTool the converter is added to is this possible.
		/// </summary>
        /// <exception cref="UnconvertableException">Is thrown if conversion was not possible</exception>
		/// <param name="gobj">The known to be converted</param>
		/// <returns>The object the Known was converted into</returns>
		protected object ConvertToForeign(object gobj)
		{
            try
            {
                return conversionTool.ConvertToForeignUnsafe(gobj);
            }
            catch (Exception e)
            {
                throw new UnableToConvertException(this, e);
            }
		}

		/// <summary>
		/// Requests the conversion of an object into an XmasObject, only if the ConversionTool the converter is added to is this possible.
		/// </summary>
		/// <exception cref="UnconvertableException">Is thrown if conversion was not possible</exception>
		/// <param name="fobj">The object to be converted</param>
		/// <returns>The XmasObject the object was converted into</returns>
		protected object ConvertToXmas(ForeignType fobj)
		{
            try
            {
                return conversionTool.ConvertToKnownUnsafe(fobj);
            }
            catch (Exception e)
            {
                throw new UnableToConvertException(this, e);
            }
		}

		internal override object BeginUnsafeConversionToForeign(object gobj)
		{
			return BeginConversionToForeign((KnownType) gobj);
		}

		internal override object BeginUnsafeConversionToXmas(object obj)
		{
			return BeginConversionToKnown((ForeignType) obj);
		}
	}
}