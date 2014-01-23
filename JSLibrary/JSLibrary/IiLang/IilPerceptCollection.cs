using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using JSLibrary.IiLang.DataContainers;
using System.Linq;

namespace JSLibrary.IiLang
{
	[XmlRoot("perceptCollection")]
	public class IilPerceptCollection : IilElement, IXmlSerializable
	{
		private List<IilPercept> percepts = new List<IilPercept>();

		public IilPerceptCollection ()
		{
		}

		public IilPerceptCollection (params IilPercept[] ps)
		{
			foreach (IilPercept p in ps)
				percepts.Add(p);
		}

		public List<IilPercept> Percepts
		{
			get { return percepts; }
		}

		public override string XmlTag
		{
			get { return "perceptCollection"; }
		}

		public override void ReadXml(XmlReader reader)
		{
			// No unit tests, we are only interested in writing perceptCollections
			reader.MoveToContent ();
			
			if (reader.IsEmptyElement) {
				reader.Read ();
			}

			reader.ReadStartElement();
			reader.MoveToContent();

			while (reader.MoveToContent() == XmlNodeType.Element)
			{
				IilPercept p = new IilPercept();
				p.ReadXml(reader);
				percepts.Add(p);
			}
			reader.Read();
		}

		public override void WriteXml(XmlWriter writer)
		{
			
			foreach (IilPercept p in percepts)
			{
				writer.WriteStartElement("percept");
				p.WriteXml(writer);
				writer.WriteEndElement();
			}
		}

		public override bool Equals (object obj)
		{
			if (GetType() != obj.GetType())
				return false;

			IilPerceptCollection pc = (IilPerceptCollection) obj;
			return percepts.SequenceEqual(pc.percepts);
		}
	}
}