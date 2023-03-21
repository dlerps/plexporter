using System.Xml.Serialization;

namespace Plexporter.Plex.Client.Model;

[XmlRoot("User")]
public class User
{
    [XmlAttribute("id")]
    public long Id { get; set; }
    
    [XmlAttribute("title")]
    public string Title { get; set; }
}