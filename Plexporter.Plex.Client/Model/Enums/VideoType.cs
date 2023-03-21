using System.Xml.Serialization;

namespace Plexporter.Plex.Client.Model.Enums;

public enum VideoType
{
    Unknown = 0,
    
    [XmlEnum("movie")]
    Movie = 1,
    
    [XmlEnum("episode")]
    Television = 2
}