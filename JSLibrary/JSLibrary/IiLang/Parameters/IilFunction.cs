using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using JSLibrary.IiLang.Exceptions;
using System.Collections.Generic;

namespace JSLibrary.IiLang.Parameters
{
#pragma warning disable 
	[XmlRoot("function")]
	public class IilFunction : IilMultiParameter
	{
		public IilFunction()
		{
		}

		public IilFunction(String name, params IilParameter[] ps) : base(ps)
		{
			Name = name;
		}

		public IilFunction (String name, IEnumerable<IilParameter> ps)
			: base(ps.ToArray ())
		{
			Name = name;
		}

		public override string XmlTag
		{
			get { return "function"; }
		}

		public string Name { get; protected set; }

		public override void WriteXml(XmlWriter writer)
		{
			if (String.IsNullOrEmpty(Name))
				throw new MissingXmlAttributeException(@"String ""Name"" must not be empty");
			writer.WriteAttributeString("name", Name);

			base.WriteXml(writer);
		}

		public override void ReadXml(XmlReader reader)
		{
			reader.MoveToContent();
			if (reader.AttributeCount == 0)
				throw new MissingXmlAttributeException(@"Missing XML attribute ""name"".");
			Name = reader["name"];
			base.ReadXml(reader);
		}

		public override bool Equals(object obj)
		{
			if (GetType() != obj.GetType())
				return false;

			IilFunction fun = (IilFunction) obj;
			return (Parameters.SequenceEqual(fun.Parameters) && Name.Equals(fun.Name));
		}
	}
}