using System.ComponentModel.DataAnnotations;

namespace FLS.Data.WebApi.Settings
{
    public class SettingDetailsSearchFilter
    {
        public SettingScope SettingScope { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string SettingKey { get; set; }
    }
}

