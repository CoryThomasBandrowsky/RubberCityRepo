// AppSettingsService.cs
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AppSettingsService : IAppSettingsService
{
    private readonly IAppSettingsRepository _repository;
    private Dictionary<string, string> _settings;

    public AppSettingsService(IAppSettingsRepository repository)
    {
        _repository = repository;
        _settings = new Dictionary<string, string>();
    }

    public async Task LoadAppSettingsAsync()
    {
        var json = await _repository.GetAppSettingsJsonAsync();
        var jObject = JObject.Parse(json);
        var values = jObject["Values"] as JObject;

        if (values != null)
        {
            foreach (var pair in values)
            {
                _settings[pair.Key] = pair.Value.ToString();
            }
        }
    }

    public Dictionary<string, string> GetSettingsDictionary()
    {
        return new Dictionary<string, string>(_settings);
    }

    public string GetSetting(string key)
    {
        return _settings.TryGetValue(key, out var value) ? value : null;
    }
}
