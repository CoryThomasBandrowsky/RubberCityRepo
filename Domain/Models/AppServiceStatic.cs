// AppServiceStatic.cs
using System.Collections.Generic;

public static class AppServiceStatic
{
    private static Dictionary<string, string> _settings = new Dictionary<string, string>();

    public static void Initialize(Dictionary<string, string> settings)
    {
        _settings = settings;
    }

    public static string GetSetting(string key)
    {
        return _settings.TryGetValue(key, out var value) ? value : null;
    }
}
