using System.Xml.Serialization;

namespace Plexporter.Plex.Client.Model;

[XmlRoot("MediaContainer")]
public class MediaContainer
{
    [XmlAttribute("size")]
    public int Size { get; set; }
    
    [XmlElement("Video")]
    public List<Video> Videos { get; set; }
}