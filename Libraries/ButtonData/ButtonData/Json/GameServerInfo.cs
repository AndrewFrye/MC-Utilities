﻿using Newtonsoft.Json;

namespace ButtonData.Json;

[Serializable]
public class GameServerInfo
{
    public string? DisplayName { get; set; }
    public string? WorkingDir { get; set; }
    public string? ProcessName { get; set; }
    public string[]? Args { get; set; }
    
    [JsonIgnore] public int Id { get; set; }
}