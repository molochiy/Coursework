using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Coursework.Services.Concrete
{
  static class SerializationService
  {

    public static T FromXmlString<T>(string xml) where T : new()
    {
      var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
      ms.Seek(0, SeekOrigin.Begin);
      var serializer = new XmlSerializer(typeof(T));
      return (T)serializer.Deserialize(ms);
    }

    public static string ToXmlString(object o)
    {
      var ms = new MemoryStream();
      var serializer = new XmlSerializer(o.GetType());
      serializer.Serialize(ms, o);
      ms.Close();
      return Encoding.UTF8.GetString(ms.ToArray());
    }
  }
}
