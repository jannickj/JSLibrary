using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using JSLibrary;
using JSLibrary.IiLang;
using JSLibrary.IiLang.DataContainers;
using JSLibrary.IiLang.Exceptions;
using JSLibrary.IiLang.Parameters;
using NUnit.Framework;

namespace JSLibrary_Test.IiLang
{
	[TestFixture]
	public class XmlDeserializationTest
	{
		public void TryReadXmlOfIdentifierWithoutValue_ThrowException()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilIdentifier));

			XElement actual_src = XElement.Parse(@"<identifier />");
			Assert.Throws<MissingXmlAttributeException>(() => serializer.Deserialize(actual_src.CreateReader()));
		}

		[Test]
		public void ReadXmlOfFunctionWithChildren_EisFunctionObjectWithChildren()
		{
			IilFunction expected = new IilFunction("test_fun", new IilIdentifier("test_id"), new IilNumeral(42));

			XmlSerializer serializer = new XmlSerializer(typeof (IilFunction));

			XElement actual_src = XElement.Parse(
				@"<function name=""test_fun"">
					<identifier value=""test_id"" />
					<number value=""42"" />
				</function>");

			IilFunction actual = (IilFunction) serializer.Deserialize(actual_src.CreateReader());
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ReadXmlRepresentationOfAction_moveToAction_ReturnsCorrectMovetToActionObject()
		{
			IilAction expected = new IilAction("moveTo", new IilNumeral(2), new IilNumeral(3));

			


			string xmldata = "<action name=\"moveTo\">\n"+
								"<actionParameter>\n" +
									"<number value=\"2\" />\n" +
								"</actionParameter>\n" +
								"<actionParameter>\n" +
									"<number value=\"3\" />\n" +
								"</actionParameter>\n" +
							"</action>\n";

			

			StreamReader sreader = new StreamReader(ExtendedString.ToStream(xmldata), Encoding.UTF8);
			XmlReaderSettings rset = new XmlReaderSettings();
			rset.ConformanceLevel = ConformanceLevel.Fragment;
			XmlReader xreader = XmlReader.Create(sreader, rset);

//			XElement actual_src = XElement.Parse(
//				);

            IilAction actual = (IilAction)new IilAction();
            actual.ReadXml(xreader);
			Assert.AreEqual(expected, actual);
		}

        [Test]
        public void ReadXmlRepresentationOfAction_emptyFunction_ReturnsCorrectMovetToActionObject()
        {
            IilAction expected = new IilAction("moveTo", new IilFunction("test"));




            string xmldata = "<action name=\"moveTo\">\n" +
                                "<actionParameter>\n" +
                                    "<function name=\"test\"/>\n" +
                                "</actionParameter>\n" +
                            "</action>\n";



            StreamReader sreader = new StreamReader(ExtendedString.ToStream(xmldata), Encoding.UTF8);
            XmlReaderSettings rset = new XmlReaderSettings();
            rset.ConformanceLevel = ConformanceLevel.Fragment;
            XmlReader xreader = XmlReader.Create(sreader, rset);

            //			XElement actual_src = XElement.Parse(
            //				);

            IilAction actual = (IilAction)new IilAction();
            actual.ReadXml(xreader);
            Assert.AreEqual(expected, actual);
        }

		[Test]
		public void TryReadXmlOfFunctionWithoutName_ThrowException()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilFunction));

			XElement actual_src = XElement.Parse(
				@"<function>
					<identifier value=""test_id"" />
					<number value=""42"" />
				</function>");

			Assert.Catch<Exception>(() => serializer.Deserialize(actual_src.CreateReader()));
		}

		[Test]
		public void TryReadXmlOfIdentifierWithValue_EisIdentifierObject()
		{
			IilIdentifier expected = new IilIdentifier("test_id");

			XmlSerializer serializer = new XmlSerializer(typeof (IilIdentifier));

			XElement actual_src = XElement.Parse(@"<identifier value=""test_id"" />");

			IilIdentifier actual = (IilIdentifier) serializer.Deserialize(actual_src.CreateReader());
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TryReadXmlOfNumeralWithValue_EisNumeralObject()
		{
			IilNumeral expected = new IilNumeral(42);

			XmlSerializer serializer = new XmlSerializer(typeof (IilNumeral));

			XElement actual_src = XElement.Parse(@"<number value=""42"" />");

			IilNumeral actual = (IilNumeral) serializer.Deserialize(actual_src.CreateReader());
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TryReadXmlOfNumeralWithoutValue_ThrowException()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilNumeral));

			XElement actual_src = XElement.Parse(@"<number />");
			Assert.Catch<Exception>(() => serializer.Deserialize(actual_src.CreateReader()));
		}

		[Test]
		public void TryReadXmlRepresentationOfActionWithoutName_ActionObject()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilAction));

			XElement actual_src = XElement.Parse(
				@"<action>
					<actionParameter>
						<number value=""2.0"" />
					</actionParameter>
					<actionParameter>
						<number value=""3.0"" />
					</actionParameter>
				</action>");

			Assert.Catch<Exception>(() => serializer.Deserialize(actual_src.CreateReader()));
		}

		[Test]
		public void ReadXmlRepresentationOfActionWithoutContentInSingleElement_EmptyActionObject()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilAction));
			IilAction expected = new IilAction ("test");

			XElement actual_src = XElement.Parse(
				@"<action name = ""test"" />");

			IilAction actual = (IilAction)serializer.Deserialize (actual_src.CreateReader ());
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void ReadXmlRepresentationOfActionWithoutContentInTwoElements_EmptyActionObject()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilAction));
			IilAction expected = new IilAction ("test");

			XElement actual_src = XElement.Parse(
				@"<action name = ""test"">
				</action>");

			IilAction actual = (IilAction)serializer.Deserialize (actual_src.CreateReader ());
			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void TryReadXmlRepresentationOfPerceptCollection_PerceptCollection()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilPerceptCollection));

			IilPerceptCollection expected = new IilPerceptCollection (new IilPercept ("test", new IilNumeral (2.0)));

			XElement actual_src = XElement.Parse (
				@"<perceptCollection>
					<percept name=""test"">
						<perceptParameter>
							<number value=""2.0"" />
						</perceptParameter>
					</percept>
				</perceptCollection>");


			IilPerceptCollection actual = (IilPerceptCollection) serializer.Deserialize(actual_src.CreateReader());

			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void TryReadXmlRepresentationOfPerceptCollectionWithSeveralPercepts_PerceptCollection()
		{
			XmlSerializer serializer = new XmlSerializer(typeof (IilPerceptCollection));

			IilPerceptCollection expected = new IilPerceptCollection (
				new IilPercept ("test", 
					new IilNumeral (2.0)),
				new IilPercept ("test2",
					new IilIdentifier ("testid"))
				);

			XElement actual_src = XElement.Parse (
				@"<perceptCollection>
					<percept name=""test"">
						<perceptParameter>
							<number value=""2.0"" />
						</perceptParameter>
					</percept>
					<percept name=""test2"">
						<perceptParameter>
							<identifier value=""testid"" />
						</perceptParameter>
					</percept>
				</perceptCollection>");


			IilPerceptCollection actual = (IilPerceptCollection) serializer.Deserialize(actual_src.CreateReader());

			Assert.AreEqual (expected, actual);
		}
	}
}