// IAppSettingsService.cs
using System.Threading.Tasks;

public interface IAppSettingsService
{
    Task LoadAppSettingsAsync();
    string GetSetting(string key);
    Dictionary<string, string> GetSettingsDictionary();
}
