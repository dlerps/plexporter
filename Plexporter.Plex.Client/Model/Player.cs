using System.Xml.Serialization;
using Plexporter.Plex.Client.Model.Enums;

namespace Plexporter.Plex.Client.Model;

public class Player
{
    [XmlAttribute("title")]
    public string Title { get; set; }

    [XmlAttribute("device")]
    public string Device { get; set; }
    
    [XmlAttribute("platform")]
    public string Platform { get; set; }
    
    [XmlAttribute("address")]
    public string Address { get; set; }
    
    [XmlAttribute("vendor")]
    public string Vendor { get; set; }
    
    [XmlAttribute("product")]
    public string Product { get; set; }
    
    [XmlAttribute("state")]
    public PlayerState State { get; set; }
}