/* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    '
    '
    */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NicWrites.Models
{
    [XmlRoot(ElementName = "Blob")]
    public class Blob
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "LastModified")]
        public string LastModified { get; set; }
        [XmlElement(ElementName = "Etag")]
        public string Etag { get; set; }
        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "ContentType")]
        public string ContentType { get; set; }
        [XmlElement(ElementName = "ContentEncoding")]
        public string ContentEncoding { get; set; }
        [XmlElement(ElementName = "ContentLanguage")]
        public string ContentLanguage { get; set; }
    }

    [XmlRoot(ElementName = "Blobs")]
    [DataContract(Namespace = "")]
    public class Blobs
    {
        [XmlElement(ElementName = "Blob")]
        public List<Blob> Blob { get; set; }
    }

    [XmlRoot(ElementName = "EnumerationResults")]
    [DataContract(Namespace = "")]
    public class EnumerationResults
    {
        [XmlElement(ElementName = "Blobs")]
        public Blobs Blobs { get; set; }
        [XmlElement(ElementName = "NextMarker")]
        public string NextMarker { get; set; }
        [XmlAttribute(AttributeName = "ContainerName")]
        public string ContainerName { get; set; }
    }

}
