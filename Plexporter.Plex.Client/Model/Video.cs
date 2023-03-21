using System.Xml.Serialization;

namespace Plexporter.Plex.Client.Model;

[XmlRoot("Video")]
public class Video
{
    [XmlAttribute("title")]
    public string Title { get; set; }
    
    [XmlAttribute("parentTitle")]
    public string ParentTitle { get; set; }
    
    [XmlAttribute("grandparentTitle")]
    public string GrandparentTitle { get; set; }
    
    [XmlAttribute("librarySectionTitle")]
    public string LibrarySectionTitle { get; set; }
    
    [XmlElement("User", IsNullable = true)]
    public User? User { get; set; }

    [XmlElement("Session", IsNullable = true)]
    public Session? Session { get; set; }
    
    [XmlElement("Player", IsNullable = true)]
    public Player? Player { get; set; }
}