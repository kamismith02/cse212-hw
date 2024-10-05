using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("bbox")]
    public List<double> Bbox { get; set; } // Bounding box

    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

public class Metadata
{
    [JsonPropertyName("generated")]
    public long Generated { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("api")]
    public string Api { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }
}

public class Feature
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}

public class Properties
{
    [JsonPropertyName("mag")]
    public double Mag { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }

    [JsonPropertyName("tz")]
    public int? Tz { get; set; } // Nullable, since it can be null

    [JsonPropertyName("url")]
    public string Url { get; set; }

    // Additional properties can be added here as needed
}

public class Geometry
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; } // [longitude, latitude, depth]
}