using System.Xml.Serialization;

namespace Plexporter.Plex.Client.Model;

[XmlRoot("Session")]
public class Session
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute("location")]
    public string Location { get; set; }
}