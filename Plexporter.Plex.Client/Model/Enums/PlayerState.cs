using System.Xml.Serialization;

namespace Plexporter.Plex.Client.Model.Enums;

public enum PlayerState
{
    Unknown = 0,
    
    [XmlEnum("playing")]
    Playing = 1,
    
    [XmlEnum("paused")]
    Paused = 2,
    
    [XmlEnum("buffering")]
    Buffering = 3
}