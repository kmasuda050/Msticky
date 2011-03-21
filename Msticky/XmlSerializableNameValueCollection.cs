using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Text;
using System.Xml.Schema;
using System.Xml;

namespace Msticky
{
    public class XmlSerializableNameValueCollection : NameValueCollection, IXmlSerializable
    {
        public XmlSerializableNameValueCollection():base()
        {
        }

        public XmlSerializableNameValueCollection(NameValueCollection src):base(src)
        {
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            while (reader.GetAttribute("key") != null)
            {
                reader.ReadAttributeValue();
                Console.WriteLine(reader.GetAttribute("key") + " - " + reader.GetAttribute("value"));
                this.Add(reader.GetAttribute("key"), reader.GetAttribute("value"));

                reader.ReadStartElement("property");
            }
            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            foreach (string key in this.Keys)
            {
                writer.WriteStartElement("property");
                writer.WriteAttributeString("key", key);
                writer.WriteAttributeString("value", this[key]);
                writer.WriteEndElement();
            }
        }
    }
}
