using Newtonsoft.Json;

namespace ButtonData.Json;

[Serializable]
public class Setting
{
    public string Name { get; set; }
    public string? Value { get; set; }
    public List<string>? ValueList { get; set; }
}