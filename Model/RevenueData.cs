using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TestesTarget.Model;

public class RevenueData
{
    [JsonPropertyName("dia")]
    [XmlElement("dia")]
    public int Day { get; set; }

    [JsonPropertyName("valor")]
    [XmlElement("valor")]
    public double Value { get; set; }
}
