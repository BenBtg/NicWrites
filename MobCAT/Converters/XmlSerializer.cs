using System.IO;
using System.Xml;
using System.Text;

namespace Microsoft.MobCAT.Converters
{
    public class XmlSerializer : ISerializer<string>
    {
        public string MediaType => "text/xml";

        /// <inheritdoc />
        public T Deserialize<T>(string value)
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer (typeof(T));
                return (T)serializer.Deserialize(memoryStream);
            }
        }

        /// <inheritdoc />
        public string Serialize<T>(T value)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(memoryStream, value);
                var json = memoryStream.ToArray();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
        }
    }
}
